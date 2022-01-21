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

namespace ToySolution.AppCode.Application.AboutUsModule
{
    public class AboutUsCreatCommand:IRequest<AboutUs>
    {

        public string Tittle { get; set; }
        public string Desc { get; set; }
        public string ImgPath { get; set; }
        public IFormFile file { get; set; }
     


        public class AboutUsCreatCommandHandler : IRequestHandler<AboutUsCreatCommand, AboutUs>
        {
            readonly StoreDbContext store;
            readonly IActionContextAccessor ctx;
            readonly IWebHostEnvironment env;
            public AboutUsCreatCommandHandler(StoreDbContext store, IActionContextAccessor ctx, IWebHostEnvironment env)
            {
                this.store = store;
                this.ctx = ctx;
                this.env = env;
            }
            public async Task<AboutUs> Handle(AboutUsCreatCommand model, CancellationToken cancellationToken)
            {
                if (ctx.ModelStateValid())
                {
                    AboutUs instagram = new AboutUs();
                    string extension = Path.GetExtension(model.file.FileName);  //.jpg tapmaq ucundur. png .gng 

                    instagram.ImgPath = $"{Guid.NewGuid()}{extension}";//imagenin name 


                    string phsicalFileName = Path.Combine(env.ContentRootPath, "wwwroot", "uploads", "images", instagram.ImgPath);

                    using (var stream = new FileStream(phsicalFileName, FileMode.Create, FileAccess.Write))
                    {
                        await model.file.CopyToAsync(stream);
                    }

                    model.Desc = instagram.Desc;
                    model.Tittle = instagram.Tittle;




                    store.Add(instagram);
                    await store.SaveChangesAsync(cancellationToken);

                    return instagram;

                }
                return null;
            }
        }
    }
}
