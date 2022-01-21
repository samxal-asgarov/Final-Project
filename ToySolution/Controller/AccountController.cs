using ASP.NetCV.AppCode.Extensions;
using ASP.NetCV.Models.Entities.Membership;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ToySolution.AppCode.Extensions;
using ToySolution.Models.FormModels;
using ToyStoreSolution.Models.DataContext;
using ToyStoreSolution.Models.ViewModels;

namespace ToySolution.Controllers
{
    public class AccountController : Controller
    {
        readonly UserManager<User> userManager;
        readonly SignInManager<User> signInManager;
        readonly IConfiguration configuration;
        readonly StoreDbContext vv;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration, StoreDbContext vv)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.configuration = configuration;
            this.vv = vv;
        }
        [AllowAnonymous]
        public IActionResult SignIn()
        {
            
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "Home");

            }

            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn(LoginFormModel model)
        {

            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "Home");

            }
            if (ModelState.IsValid) //her shey qaydasndadrsa
            {
                User user = null;

                if (model.UserName.IsEmail())
                {
                    user = await userManager.FindByEmailAsync(model.UserName); //Eger Isdifadeci email gore giris edibse onu yoxlayir
                }
                else
                {
                    user = await userManager.FindByNameAsync(model.UserName);//eger isdifadeci username le daxil olubsa onu yoxlayir
                }

                if (user == null) //isdifadeci olmuyanda view gonder
                {
                    ViewBag.Ms = "Isdifadeci sifreniz ve ya parolnuz yanlisdir";
                    return View(user);
                }
                //if (user.EmailConfirmed == false)
                //{
                //    ViewBag.Ms = " Emailinizi testiq et!!";
                //    return View(user);
                //}
                if (await userManager.IsInRoleAsync(user, "user")) //databazada yolxuyur bele user var yoxsa yox
                {
                    ViewBag.Ms = "Isdifadeci adiniz ve ya parolnuz yanlisdir";   ///admin sign in de yazmaliyam
                    return View(user);
                }
                //if (user.Active == false)
                //{
                //    ViewBag.Ms = "Sizin girisinize qada var";
                //    return View(user);
                //}
                if (user.Active == true)
                {
                    var result = await signInManager.PasswordSignInAsync(user, model.Password, true, true);//giris edildi
                    if (result.Succeeded != true) // girisniz ugursuz oldu
                    {
                        ViewBag.Ms = "Isdifadeci sifresi ve parol sehvdir";
                        return View(user);

                    }
                    var redirectUrl = Request.Query["ReturnUrl"];

                    if (!string.IsNullOrWhiteSpace(redirectUrl))
                    {
                        return Redirect(redirectUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }


            }
            ViewBag.Ms = "Melumatlari doldurun";
            return View(model);
        }
        [AllowAnonymous]




        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterFormModel model)
        {
            if (ModelState.IsValid)//her shey qaydasindadirsa
            {
                var user = new User();
                user.Email = model.Email;
                user.Surname = model.SurName;
                user.Name = model.Name;
                user.UserName = model.UserName;
                user.EmailConfirmed = true;
              

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    string path = $"{Request.Scheme}://{Request.Host}/registration-confirm.html?email={user.Email}&token={token}"; // path duzeldirik
                    var emailRespons = configuration.SendEmail(user.Email, "ToyStore user registration", $"Zehmet olmasa <a href={path}>Link</a> vasitesile abuneliyi tamamlayin");//sorgu gonderirik emaile
                    if (emailRespons)
                    {
                        ViewBag.Ms = "Siz qeydiyyatdan ugurla kecidiniz";
                    }
                    else
                    {
                        ViewBag.Ms = "E-maile gondererken sehf askar olundu yeniden cehd edin";
                    }


                    return RedirectToAction(nameof(SignIn));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
            }


            return View();
        }

        [AllowAnonymous]
      
        public async Task<IActionResult> RegisterConfirm(string email, string token)
        {
            var faundUser = await userManager.FindByEmailAsync(email);//email axtarir
            if (faundUser == null)
            {
                ViewBag.Ms = "Xetali token";
                goto end;
            }

            token.Replace(" ", "+");

            var result = await userManager.ConfirmEmailAsync(faundUser, token);///eger tapibsa qeydiyyat tesdiqle

            if (!result.Succeeded)
            {
                ViewBag.Ms = "Xetali token";
                goto end;
            }


            ViewBag.Ms = "Hesabiniz ugurla tesdiqlendi";
            end:// her shey qaydasindadrsa
            return RedirectToAction(nameof(SignIn));
        }


        public async Task<IActionResult> Logout()
        {

            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(SignIn));

        }
    }
}
