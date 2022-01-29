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
using ToySolution.Models.Entities.Membership;
using ToySolution.Models.FormModels;
using ToyStoreSolution.Models.DataContext;
using ToyStoreSolution.Models.ViewModels;

namespace ToySolution.Controllers
{
    [AllowAnonymous]

    public class AccountController : Controller
    {
        readonly UserManager<StoreUser> userManager;
        readonly SignInManager<StoreUser> signInManager;
        readonly IConfiguration configuration;
        readonly StoreDbContext vv;
        public AccountController(UserManager<StoreUser> userManager, SignInManager<StoreUser> signInManager, IConfiguration configuration, StoreDbContext vv)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.configuration = configuration;
            this.vv = vv;
        }
        public IActionResult SignIn()
        {


            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "Home");

            }

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(LoginFormModel model)
        {

            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "Home");

            }
            if (ModelState.IsValid) //her shey qaydasndadrsa
            {
                StoreUser user = null;

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
                    return View(model);
                }

                if (user.EmailConfirmed==false)
                {
                    ViewBag.Ms = "Zehmet olmasa E-mail hesabini tesdiq edin";

                    return View(model);

                }

                if (user.Active == false)
                {
                    ViewBag.Ms = "Siz admin terefinden ban olunmusuz";
                    return View(model);

                    //return View(/*viewName: "~/Areas/Admin/Views/Users/Activated.cshtml",*/ user);
                }
                if (user.Active == true)
                {
                    var result = await signInManager.PasswordSignInAsync(user, model.Password, true, true);//giris edildi
                    if (result.Succeeded != true) // girisniz ugursuz oldu
                    {
                        ViewBag.Ms = "Isdifadeci sifresi ve parol sehvdir";
                        return View(model);

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





        public IActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterFormModel register)
        {



            //Eger giris edibse routda myaccount/sing yazanda o seyfe acilmasin homa tulaasin
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "Home");

            }
            if (!ModelState.IsValid)
            {
                return View();
            }

            //Yeni user yaradiriq.
            StoreUser user = new StoreUser
            {

                UserName = register.UserName,
                Email = register.Email,
                Name = register.Name,
                Surname = register.SurName,
                Active = true
            };



            string token = $"subscribetoken-{register.UserName}-{DateTime.Now:yyyyMMddHHmmss}"; // token yeni id goturuk

            token = token.Encrypt("");

            string path = $"{Request.Scheme}://{Request.Host}/subscribe-confirmm?token={token}"; // path duzeldirik



            var mailSended = configuration.SendEmail(user.Email, "ToyStore Qeydiyyat ", $"Zehmet olmasa <a href={path}>Link</a> vasitesile abuneliyi tamamlayin");


            var person = await userManager.FindByNameAsync(user.UserName);


            if (person == null)
            {
                //Burda biz userManager vasitesile user ve RegistirVM passwword yoxluyuruq.(yaradiriq)
                var identityRuselt = await userManager.CreateAsync(user, register.Password);


                //Startupda yazdigimiz qanunlara uymursa Configure<IdentityOptions> onda error qaytariq summary ile.;
                if (!identityRuselt.Succeeded)
                {
                    foreach (var error in identityRuselt.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

                //Yaratdigimiz user ilk yarananda user rolu verik.

                await userManager.AddToRoleAsync(user, "User");

                return RedirectToAction("SignIn", "Account");

            }


            if (person.UserName != null)
            {
                ViewBag.ms = "Bu username evvelceden qeydiyyatdan kecib";

                return View(register);
            }
            return null;



        }





        [AllowAnonymous]

        [HttpGet]
        [Route("subscribe-confirmm")]
        public IActionResult SubscibeConfirm(string token)
        {


            token = token.Decrypte("");

            Match match = Regex.Match(token, @"subscribetoken-(?<id>[a-zA-Z0-9]*)(.*)-(?<timeStampt>\d{14})");

            if (match.Success)
            {
                string id = match.Groups["id"].Value;
                string executeTimeStamp = match.Groups["executeTimeStamp"].Value;

                var subsc = vv.Users.FirstOrDefault(s => s.UserName == id);

                if (subsc == null)
                {
                    ViewBag.ms = Tuple.Create(true, "Token xetasi");
                    goto end;
                }
                if (subsc.EmailConfirmed == true)
                {
                    ViewBag.ms = Tuple.Create(true, "Artiq tesdiq edildi");
                    goto end;
                }
                subsc.EmailConfirmed = true;
                vv.SaveChanges();

                ViewBag.ms = Tuple.Create(false, "Qeydiyyatdan ugurla kecdiniz!");

            }
        end:
            return View();
        }


        public async Task<IActionResult> Logout()
        {

            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(SignIn));

        }

      
    }
}

