using Microsoft.AspNetCore.Authorization;
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
using ToyStoreSolution.Models.ViewModels;

namespace ToySolution.Controllers
{
    [AllowAnonymous]
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
                    var product = await db.Products.FirstOrDefaultAsync(p => p.Id == basketElem.ProductId);

                    basketElem.ImagePath = product.ImgPath;
                    basketElem.Name = product.Name;
                    basketElem.Price = product.Value;

               

                }
                IndexViewModels vm = new IndexViewModels();
               
                vm.BasketItems = basket;
                return View(vm);

            }

            return View();


        }
        [HttpPost]
        public async Task<IActionResult> CardAmmount()
        {
            var a = Request.Cookies.TryGetValue("basket", out string basketjson);
            if (a)
            {
                var basket = JsonConvert.DeserializeObject<List<BasketItem>>(basketjson);
                foreach (var basketElem in basket)
                {
                    var product = await db.Products.FirstOrDefaultAsync(p => p.Id == basketElem.ProductId);

                  
                    basketElem.Price = product.Value;



                }
                IndexViewModels vm = new IndexViewModels();

                vm.BasketItems = basket;
                return Json(new
                {
                    error = false,
                    amount=basket.Sum(b=>b.Amount),
                    message = ""
                });

            }

            return Json(new
            {
                error = true,
                message="coocie bosdur"
            }) ;


        }
    }
}
