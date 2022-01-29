using ASP.NetCV.AppCode.Extensions;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ToyStoreSolution.Models.DataContext;
using ToyStoreSolution.Models.Entities;

namespace ToySolution.AppCode.Application.ProductIntroModule
{
    public class ProductCreatCommand: IRequest<Product>
    {
        public string Name { get; set; }
        public decimal Value { get; set; }
        public string ImgPath { get; set; }
        public string Desc { get; set; }
        public string Sku { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Length { get; set; }
        public string Body { get; set; }
        public bool HomePageShow { get; set; }
      
        public int SortId { get; set; }
        public virtual Sort Sort { get; set; }

        public IFormFile file { get; set; }

        public class ProductCreatCommandHandler : IRequestHandler<ProductCreatCommand, Product>
        {
            readonly StoreDbContext store;
            readonly IActionContextAccessor ctx;
            readonly IWebHostEnvironment env;
            public ProductCreatCommandHandler(StoreDbContext store, IActionContextAccessor ctx, IWebHostEnvironment env)
            {
                this.store = store;
                this.ctx = ctx;
                this.env = env;
            }
            public async Task<Product> Handle(ProductCreatCommand model, CancellationToken cancellationToken)
            {
                if (ctx.ModelStateValid())
                {
                    Product instagram = new Product();
                    string extension = Path.GetExtension(model.file.FileName);  //.jpg tapmaq ucundur. png .gng 

                    instagram.ImgPath = $"{Guid.NewGuid()}{extension}";//imagenin name 


                    string phsicalFileName = Path.Combine(env.ContentRootPath, "wwwroot", "uploads", "images", instagram.ImgPath);

                    using (var stream = new FileStream(phsicalFileName, FileMode.Create, FileAccess.Write))
                    {
                        await model.file.CopyToAsync(stream);
                    }
                    instagram.Name = model.Name;
                    instagram.Sku = model.Sku;
                    instagram.SortId = model.SortId;
                    instagram.Value = model.Value;
                    instagram.Weight = model.Weight;
                    instagram.Width = model.Width;
                    instagram.Length = model.Length;
                    instagram.Height = model.Height;
                    instagram.Body = model.Body;
                    instagram.Desc = model.Desc;
                    instagram.HomePageShow = model.HomePageShow;
               




                    store.Add(instagram);
                    await store.SaveChangesAsync(cancellationToken);

                    return instagram;

                }
                return null;
            }

            
        }
    }
}
