using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToySolution.AppCode.Application.AboutStoryModule;
using ToyStoreSolution.Models.DataContext;
using ToyStoreSolution.Models.Entities;

namespace ToySolution.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutStoryController : Controller
    {

        private readonly StoreDbContext _context;
        private readonly IMediator mediatr;
        public AboutStoryController(StoreDbContext context,  IMediator mediatr)
        {
            _context = context;
            this.mediatr = mediatr;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.AboutStories.ToListAsync());
        }

        // GET: InstagramController/Details/5
        public async Task<IActionResult> Details(AboutStorySingleQuery query)
        {
            if (query.Id == null)
            {
                return NotFound();
            }

            AboutStory story = await mediatr.Send(query);


            if (story == null)
            {
                return NotFound();
            }

            return View(story);
        }


      
   

        // GET: InstagramController/Edit/5
        public async Task<IActionResult> Edit(AboutStorySingleQuery query)
        {
            var respons = await mediatr.Send(query);

            if (respons == null)
            {
                return NotFound();
            }
            AboutViewModel vm = new AboutViewModel();

            vm.Id = respons.Id;
            vm.Desc = respons.Desc;
            vm.Head = respons.Head;
            vm.Tittle = respons.Tittle;

            return View(vm);
        }

        // POST: Admin/BioSkilsInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AboutStoryEditCommand about)
        {
            int id = await mediatr.Send(about);

            if (id > 0)

                return RedirectToAction(nameof(Index));

            return View(about);
        }
    


        private bool Insta(int id)
        {
            return _context.AboutStories.Any(e => e.Id == id);
        }
    }
}
