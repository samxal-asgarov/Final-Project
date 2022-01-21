using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToySolution.AppCode.Application.AboutToys;
using ToyStoreSolution.Models.DataContext;
using ToyStoreSolution.Models.Entities;

namespace ToySolution.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutToysController : Controller
    {

        private readonly StoreDbContext _context;
        private readonly IMediator mediator;

        public AboutToysController(StoreDbContext context,IMediator mediator)
        {
            _context = context;
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.AboutOurToys.ToListAsync());
        }

        // GET: InstagramController/Details/5
        public async Task<IActionResult> Details(AboutToysSingleQuery query)
        {
            if (query.Id == null)
            {
                return NotFound();
            }

            AboutOurToys about = await mediator.Send(query);


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
        public async Task<IActionResult> Create([Bind("Head,Tittle,Desc,Id,CreatByUserId,CreatDate,DeletedByUserID,DeletedDate")] AboutOurToys about)
        {
            if (ModelState.IsValid)
            {
                _context.Add(about);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(about);
        }

        // GET: InstagramController/Edit/5
        public async Task<IActionResult> Edit(AboutToysSingleQuery query)
        {
            var respons = await mediator.Send(query);
            if (respons == null)
            {
                return NotFound();
            }
            AboutToysViewModel vm = new AboutToysViewModel();
            vm.Id = respons.Id;
            vm.Tittle = respons.Tittle;
            vm.ImgPath = respons.ImgPath;
            vm.Desc = respons.Desc;
            return View(vm);
        }

        // POST: Admin/BioSkilsInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AboutToysEditCommand command)
        {
            var id = await mediator.Send(command);

            if (id > 0)

                return RedirectToAction(nameof(Index));

          

            return View(command);
        }


        // GET: InstagramController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bioSkilsInfo = await _context.AboutOurToys
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bioSkilsInfo == null)
            {
                return NotFound();
            }

            return View(bioSkilsInfo);
        }

        // POST: Admin/BioSkilsInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bioSkilsInfo = await _context.AboutOurToys.FindAsync(id);
            _context.AboutOurToys.Remove(bioSkilsInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool Insta(int id)
        {
            return _context.AboutOurToys.Any(e => e.Id == id);
        }
    }
}
