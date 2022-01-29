using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using ToySolution.AppCode.Application.InstagramModule;
using ToyStoreSolution.Models.DataContext;
using ToyStoreSolution.Models.Entities;

namespace ToySolution.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles="SuperAdmin")]
    public class InstagramController : Controller
    {
      
        private readonly StoreDbContext _context;
        private readonly IMediator mediatr;

        public InstagramController(StoreDbContext context, IMediator mediatr)
        {
            _context = context;
            this.mediatr = mediatr;

        }

        public async Task<IActionResult> Index(InstagramPagedQuery query)
        {
            var response = await mediatr.Send(query);
            
            return View(response);
        }

        // GET: InstagramController/Details/5
        public async Task<IActionResult> Details(InstagramSingleQuery query)
        {
            if (query.Id == null)
            {
                return NotFound();
            }

          



            InstagramPhoto instagram = await mediatr.Send(query);

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
        public async Task<IActionResult> Create(InstagramCreatCommand instagram)
        {
           InstagramPhoto model = await mediatr.Send(instagram);

            if (model != null)

                return RedirectToAction(nameof(Index));

            return View(instagram);
        }

        // GET: InstagramController/Edit/5
        public async Task<IActionResult> Edit(InstagramSingleQuery query)
        {
            var respons = await mediatr.Send(query);

            if (respons == null)
            {
                return NotFound();
            }
            InstagramViewModel vm = new InstagramViewModel();

            vm.Id = respons.Id;
            vm.ImgPath = respons.ImgPath;
          

            return View(vm);
        }

        // POST: Admin/BioSkilsInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(InstagramEditCommand request)
        {
            int id = await mediatr.Send(request);

            if (id > 0)
                
                return RedirectToAction(nameof(Index));

            return View(request);
        }



   

        [HttpPost]
        public async Task<IActionResult> Delete(InstagramRemoveCommand requst)
        {
            var respons = await mediatr.Send(requst);

            return Json(respons);
        }


        private bool Insta(int id)
        {
            return _context.InstagramPhotos.Any(e => e.Id == id);
        }
    }
}
