using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToySolution.Models.Entities;
using ToyStoreSolution.Models.DataContext;
using ToyStoreSolution.Models.ViewModels;

namespace ToyStoreSolution.Controllers
{
    public class ContactController : Controller
    {
        readonly StoreDbContext db;
        public ContactController(StoreDbContext db)
        {
            this.db = db;
        }
        [HttpGet]
        public IActionResult Contact()
        {
            IndexViewModels iv = new IndexViewModels();
            iv.InstagramPhotos = db.InstagramPhotos.Where(f => f.DeletedByUserID == null).ToList();
            return View(iv);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Contact(IndexViewModels model)
        {
            if (ModelState.IsValid)
            {
                db.ContactPosts.Add(model.ContactPosts);
                db.SaveChanges();

                return Json(new
                {
                    error = false,
                    message = "Sizin muracietiniz qeyde alindi"

                });
            }

            return Json(new
            {
                error = true,
                message = "Sizin murecietiniz qeyde alinmadi "

            });
        }

    }
}
