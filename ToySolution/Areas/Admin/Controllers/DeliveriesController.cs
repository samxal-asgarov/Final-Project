using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToySolution.AppCode.Application.DeliveryModule;
using ToyStoreSolution.Models.DataContext;
using ToyStoreSolution.Models.Entities;

namespace ToySolution.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DeliveriesController : Controller
    {

        private readonly StoreDbContext _context;private readonly IMediator mediatr;

        public DeliveriesController(StoreDbContext context, IMediator mediatr)
        {
            _context = context;
            this.mediatr = mediatr;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Deliveries.ToListAsync());
        }

        // GET: InstagramController/Details/5
        public async Task<IActionResult> Details(DeliverySingleQuery query)
        {
            if (query.Id == null)
            {
                return NotFound();
            }





           Delivery instagram = await mediatr.Send(query);

            if (instagram == null)
            {
                return NotFound();
            }

            return View(instagram);
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
        public async Task<IActionResult> Create([Bind("Head,Id,CreatByUserId,CreatDate,DeletedByUserID,DeletedDate")] Delivery instagram)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instagram);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(instagram);
        }

        // GET: InstagramController/Edit/5
        public async Task<IActionResult> Edit(DeliverySingleQuery query)
        {
            var respons = await mediatr.Send(query);
            if (respons == null)
            {
                return NotFound();
            }

            DeliveryViewModel product = new DeliveryViewModel();
            product.Id = respons.Id;
            product.Head = respons.Head;
           

           

            return View(product);
        }

        // POST: Admin/BioSkilsInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DeliveryEditCommand command)
        {
            var id = await mediatr.Send(command);

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

            var bioSkilsInfo = await _context.Deliveries
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
            var bioSkilsInfo = await _context.Deliveries.FindAsync(id);
            _context.Deliveries.Remove(bioSkilsInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool Insta(int id)
        {
            return _context.Deliveries.Any(e => e.Id == id);
        }
    }
}
