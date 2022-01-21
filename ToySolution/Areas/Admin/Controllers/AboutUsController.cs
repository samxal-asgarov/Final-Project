using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToySolution.AppCode.Application.AboutUsModule;
using ToyStoreSolution.Models.DataContext;
using ToyStoreSolution.Models.Entities;

namespace ToySolution.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutUsController : Controller
    {

        private readonly StoreDbContext _context;
        private readonly IMediator mediator;

        public AboutUsController(StoreDbContext context,IMediator mediator)
        {
            _context = context;
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index(AboutPagedQuery about)
        {
            var response = await mediator.Send(about);

            return View(response);
        }

        // GET: InstagramController/Details/5
        public async Task<IActionResult> Details(AboutUsSingleQuery query)
        {
            if (query.Id == null)
            {
                return NotFound();
            }

            AboutUs about = await mediator.Send(query);


            if (about == null)
            {
                return NotFound();
            }

            return View(about);
        }


        // GET: InstagramController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/BioSkilsInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AboutUsCreatCommand about)
        {
            AboutUs model = await mediator.Send(about);

            if (model != null)
                return RedirectToAction(nameof(Index));

            return View(about);
        }

        // GET: InstagramController/Edit/5
        public async Task<IActionResult> Edit(AboutUsSingleQuery query)
        {
            var respons = await mediator.Send(query);

            if (respons == null)
            {
                return NotFound();
            }
            AboutUsViewModel vm = new AboutUsViewModel();

            vm.Id = respons.Id;
            vm.ImgPath = respons.ImgPath;
            vm.Tittle = respons.Tittle;
            vm.Desc = respons.Desc;
            

            return View(vm);
        }

        // POST: Admin/BioSkilsInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AboutUsEditCommand about)
        {
            int id = await mediator.Send(about);

            if (id > 0)

                return RedirectToAction(nameof(Index));

            return View(about);
        }


        // GET: InstagramController/Delete/5
       

        // POST: Admin/BioSkilsInfoes/Delete/5
        [HttpPost]
      
        public async Task<IActionResult> DeleteConfirmed(AboutUsRemoveCommand requst)
        {
            var respons = await mediator.Send(requst);

            return Json(respons);
        }


        private bool Insta(int id)
        {
            return _context.AboutUs.Any(e => e.Id == id);
        }
    }
}
