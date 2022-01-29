using ASP.NetCV.AppCode.Extensions;
using ASP.NetCV.Models.Entities.Membership;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToySolution.Models.Entities.Membership;
using ToySolution.Models.FormModels;
using ToyStoreSolution.Models.DataContext;

namespace ToySolution.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]

    public class AccountController : Controller
    {
        readonly UserManager<StoreUser> userManager;
        readonly SignInManager<StoreUser> signInManager;
        readonly StoreDbContext db;
        public AccountController(UserManager<StoreUser> userManager, SignInManager<StoreUser> signInManager, StoreDbContext db)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.db = db;
        }
        [AllowAnonymous]
        public IActionResult Singin()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Singin(LoginFormModel user)
        {

            if (ModelState.IsValid)
            {

                StoreUser founderUser = null;

                if (user.UserName.IsEmail())
                {
                    founderUser = await userManager.FindByEmailAsync(user.UserName); //Eger Isdifadeci email gore giris edibse onu yoxlayir 
                }
                else
                {
                    founderUser = await userManager.FindByNameAsync(user.UserName); //YOX EGER USERNAME GORE GIRIBSE ONU AXTARIS EDIR.

                }

                if (founderUser == null) //Eger login ola bilmirse gonderir view gonderir yeni isdifadeci tapilmiyanda
                {
                    ViewBag.Ms = "Isdifadeci sifresi ve parol sefdir gagas";
                    return View(user);

                }

                var rIds = db.UserRoles.Where(ur => ur.UserId == founderUser.Id).Select(ur => ur.RoleId).ToArray();// Burada biz dabase icindeki UserRole id bizim isdifadecilerin rolu id beraberdise onda bize role Id versin


                var hasAnotherRole = db.Roles.Where(r => !r.Name.Equals("USER") && rIds.Contains(r.Id)).Any();//?????????  Adamin tekce userrolu varsa giriw ede bilmesin


                if (hasAnotherRole == false) //Adamin tekce user rolu varsa
                {

                    ViewBag.Ms = "Isdifadeci sifresi ve parol sefdir gagas";
                    return View(user);
                }





                var sRuselt = await signInManager.PasswordSignInAsync(founderUser, user.Password, true, true); //Burda giwi edirik.


                if (sRuselt.Succeeded != true) // Eger giriw zamani ugurlu deyilse yeni gire bilmirse 5
                {
                    ViewBag.Ms = "Isdifadeci sifresi ve parol sefdir gagas";
                    return View(user);

                }
                return RedirectToAction("Index", "Instagram");
            }
            ViewBag.Ms = "Melumatlari doldur gagas";
            return View(user);
        }
            
        public async Task<IActionResult> Logout()
        {

            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(Singin));

        }
    }
}
