using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToySolution.AppCode.Application.AboutIntroModule;
using ToyStoreSolution.Models.DataContext;
using ToyStoreSolution.Models.Entities;

namespace ToySolution.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutIntrosController : Controller
    {

        private readonly StoreDbContext _context;  private readonly IMediator mediatr;

        public AboutIntrosController(StoreDbContext context,IMediator mediatr)
        {
            _context = context;
            this.mediatr = mediatr;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.AboutIntros.ToListAsync());
        }

        // GET: InstagramController/Details/5
        public async Task<IActionResult> Details(AboutIntroSingleQuery query)
        {
            if (query.Id == null)
            {
                return NotFound();
            }

            AboutIntro story = await mediatr.Send(query);


            if (story == null)
            {
                return NotFound();
            }

            return View(story);
        }


        // GET: InstagramController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/BioSkilsInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(AboutIntroCreatCommand about)
        //{

        //    AboutIntro model = await mediatr.Send(about);

        //    if (model != null)

        //        return RedirectToAction(nameof(Index));

        //    return View(about);
        //}

        // GET: InstagramController/Edit/5
        public async Task<IActionResult> Edit(AboutIntroSingleQuery query)
        {
            var respons = await mediatr.Send(query);

            if (respons == null)
            {
                return NotFound();
            }
            AboutIntroViewModel vm = new AboutIntroViewModel();

            vm.Id = respons.Id;
            vm.ImgPath = respons.ImgPath;
            vm.Desc = respons.Desc;
            vm.Head = respons.Head;
            vm.Tittle = respons.Tittle;

            return View(vm);
        }

        // POST: Admin/BioSkilsInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
    
        public async Task<IActionResult> Edit(AboutIntroEditCommand request)
        {
            int id = await mediatr.Send(request);

            if (id > 0)

                return RedirectToAction(nameof(Index));

            return View(request);
        }


        // GET: InstagramController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bioSkilsInfo = await _context.AboutIntros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bioSkilsInfo == null)
            {
                return NotFound();
            }

            return View(bioSkilsInfo);
        }

        // POST: Admin/BioSkilsInfoes/Delete/5
      


        private bool Insta(int id)
        {
            return _context.AboutIntros.Any(e => e.Id == id);
        }
    }
}
