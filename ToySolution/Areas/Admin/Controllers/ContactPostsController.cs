using ASP.NetCV.AppCode.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToySolution.AppCode.Extensions;
using ToySolution.Models.Entities;
using ToyStoreSolution.Models.DataContext;

namespace ToySolution.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactPostsController : Controller
    {
        private readonly StoreDbContext db;
        readonly IConfiguration configuration;

        public ContactPostsController(StoreDbContext db, IConfiguration configuration)
        {
            this.db = db;
            this.configuration = configuration;
        }

        public async Task<IActionResult> Index(int typeId)
        {
            var query = db.ContactPosts.AsQueryable()
                .Where(cp => cp.DeletedByUserID == null);


            ViewBag.query = query.Count();
            ViewBag.Count = query.Where(cp => cp.AnswerByUserID == null).Count();
            ViewBag.Count1 = query.Where(cp => cp.AnswerByUserID != null).Count();

            switch (typeId)
            {
                case 1:
                    query = query.Where(cp => cp.AnswerByUserID == null);
                    break;
                case 2:
                    query = query.Where(cp => cp.AnswerByUserID != null);
                    break;
                default:
                    break;
            }
            return View(await query.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactPost = await db.ContactPosts
                .FirstOrDefaultAsync(m => m.Id == id
                && m.DeletedByUserID == null
                && m.AnswerByUserID == null);

            if (contactPost == null)
            {
                return NotFound();
            }

            return View(contactPost);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Answer([Bind("Id", "Answer")] ContactPosts model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var contactPost = await db.ContactPosts
                .FirstOrDefaultAsync(m => m.Id == model.Id
                && m.DeletedByUserID == null
                && m.AnswerByUserID == null);

            if (contactPost == null)
            {
                return NotFound();
            }

            contactPost.Answer = model.Answer;
            contactPost.AnswerDate = DateTime.Now;
            contactPost.AnswerByUserID = 1;

            string token = $"subscribetoken-{model.Id}-{DateTime.Now:yyyyMMddHHmmss}"; // token yeni id goturuk

            token = token.Encrypt("");

            string path = $"{Request.Scheme}://{Request.Host}/subscribe-confirm?token={token}"; // path duzeldirik



            var mailSended = configuration.SendEmail(contactPost.Email, "ToyStore", $"Sorgunuza cavab olaraq  `{model.Answer}` ");


            await db.SaveChangesAsync();
            return Redirect(nameof(Index));
        }
    }
}
