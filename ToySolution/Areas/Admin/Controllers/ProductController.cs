using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;
using ToySolution.AppCode.Application.ProductIntroModule;
using ToyStoreSolution.Models.DataContext;
using ToyStoreSolution.Models.Entities;

namespace ToySolution.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {

        private readonly StoreDbContext _context;
        private readonly IMediator mediatr;

        public ProductsController(StoreDbContext context, IMediator mediatr)
        {
            _context = context;
            this.mediatr = mediatr;
        }

        public async Task<IActionResult> Index(ProductPagedQuery query)
        {
            var response = await mediatr.Send(query);

            return View (response);
          
       
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(ProductSingleQuery query,Product product)
        {
            if (query.Id == null)
            {
                return NotFound();
            }

            



            Product instagram = await mediatr.Send(query);
            ViewData["ProductTypesId"] = new SelectList(_context.Sort.Where(b => b.DeletedByUserID == null), "Id", "Name");

            if (instagram == null)
            {
                return NotFound();
            }
            
            return View(instagram);
        }


        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["ProductTypesId"] = new SelectList(_context.Sort.Where(b => b.DeletedByUserID == null), "Id", "Name");
            return View();
        }

        // POST: Admin/BioSkilsInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreatCommand product)
        {
           
            Product model = await mediatr.Send(product);

            if (model != null)

                return RedirectToAction(nameof(Index));
            ViewData["ProductTypesId"] = new SelectList(_context.Sort.Where(b => b.DeletedByUserID == null), "Id", "Name", product.Sort);
            return View(product);

        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(ProductSingleQuery query)
        {
            var respons = await mediatr.Send(query);
            if (respons == null)
            {
                return NotFound();
            }
            ViewData["ProductTypesId"] = new SelectList(_context.Sort.Where(b => b.DeletedByUserID == null), "Id", "Name");


            ProductViewModel product = new ProductViewModel();
            product.Id = respons.Id;
            product.Height = respons.Height;
            product.ImgPath = respons.ImgPath;
            product.Length = respons.Length;
            product.Name = respons.Name;
            product.Sku = respons.Sku;
            product.SortId = respons.SortId;
            product.Value = respons.Value;
            product.Weight = respons.Weight;
            product.Width = respons.Width;
            product.Body = respons.Body;
            product.Desc = respons.Desc;


            return View(product);

        }

        // POST: Admin/BioSkilsInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductEditCommand command)
        {
            var id = await mediatr.Send(command);

            if (id > 0)

                return RedirectToAction(nameof(Index));

            ViewData["ProductTypesId"] = new SelectList(_context.Sort.Where(b => b.DeletedByUserID == null), "Id", "Name", command.Sort);

            return View(command);
        }


        // GET: Products/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(ProductRemoveCommand requst)
        {
            var respons = await mediatr.Send(requst);

            return Json(respons);
        }


        private bool Pro(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
