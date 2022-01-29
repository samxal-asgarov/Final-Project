using ASP.NetCV.Models.Entities.Membership;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToySolution.Models.Entities.Membership;
using ToySolution.Models.ViewModels;
using ToyStoreSolution.Models.DataContext;

namespace ToySolution.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]

    public class UsersController : Controller
    {
        readonly UserManager<StoreUser> userManager;
        readonly SignInManager<StoreUser> signInManager;
        readonly StoreDbContext db;
        public UsersController(UserManager<StoreUser> userManager, SignInManager<StoreUser> signInManager, StoreDbContext db)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<StoreUser> riodeUsers = userManager.Users.ToList();


            List<UserVM> users = new List<UserVM>();
            foreach (StoreUser item in riodeUsers)
            {
                UserVM vm = new UserVM
                {
                    Id = item.Id,
                    Email = item.Email,
                    UserName = item.UserName,
                    Active = item.Active,
                    Role = ((await userManager.GetRolesAsync(item))[0])

                };
                users.Add(vm);
            }
            return View(users);

        }


        public async Task<IActionResult> Activated(string id)
        {

            if (id == null)
            {
                return NotFound();
            }

            StoreUser user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();

            }

            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Activated(string id, bool Activated)
        {

            if (id == null)
            {
                return NotFound();
            }

            StoreUser user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();

            }


            user.Active = Activated;
            await db.SaveChangesAsync();
            return RedirectToAction("index");


        }

        public async Task<IActionResult> RessetPassword(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            StoreUser riode = await userManager.FindByIdAsync(id);
            if (riode == null)
            {
                return NotFound();

            }
            return View(riode);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RessetPassword(string id, string newPassword)
        {
            if (id == null)
            {
                return NotFound();
            }
            StoreUser user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();

            }

            string token = await userManager.GeneratePasswordResetTokenAsync(user);
            var identityResult = await userManager.ResetPasswordAsync(user, token, newPassword);
            if (!identityResult.Succeeded)
            {
                foreach (var item in identityResult.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(user);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
