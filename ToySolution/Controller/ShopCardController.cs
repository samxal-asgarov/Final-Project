using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToySolution.Models.ViewModels;
using ToyStoreSolution.Models.DataContext;

namespace ToySolution.Controllers
{
    public class ShopCardController : Controller
    {
        readonly StoreDbContext db;
        readonly IConfiguration configuration;
        public ShopCardController(StoreDbContext db, IConfiguration configuration)
        {
            this.db = db;
            this.configuration = configuration;

        }
        public async Task<IActionResult> ShopingCard()
        {
            var a = Request.Cookies.TryGetValue("basket", out string basketjson);
            if (a)
            {
                var basket = JsonConvert.DeserializeObject<List<BasketItem>>(basketjson);
                foreach (var basketElem in basket)
                {
                    var product = await db.Products
                         //.Include(pi => pi.ImgPath)
                         .FirstOrDefaultAsync(p => p.Id == basketElem.ProductId);

                    basketElem.ImagePath = product.ImgPath;
                    basketElem.Name = product.Name;
                    basketElem.Price = product.Value;



                }
                return View(basket);

            }

            return View();


        }
    }
}
