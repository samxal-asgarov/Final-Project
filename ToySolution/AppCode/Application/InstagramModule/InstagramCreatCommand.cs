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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ToySolution.AppCode.Application.InstagramModule
{
    public class InstagramCreatCommand:IRequest<InstagramPhoto>
    {
        public string ImgPath { get; set; }
    
        public DateTime DateTime { get; set; }
        public IFormFile file { get; set; }


        public class InstagramCreatCommandHandler : IRequestHandler<InstagramCreatCommand, InstagramPhoto>
        {
            readonly StoreDbContext store;
            readonly IActionContextAccessor ctx;
            readonly IWebHostEnvironment env;
            public InstagramCreatCommandHandler(StoreDbContext store, IActionContextAccessor ctx, IWebHostEnvironment env)
            {
                this.store = store;
                this.ctx = ctx;
                this.env = env;
            }
            public async Task<InstagramPhoto> Handle(InstagramCreatCommand model, CancellationToken cancellationToken)
            {
                if (ctx.ModelStateValid())
                {
                    InstagramPhoto instagram = new InstagramPhoto();
                    string extension = Path.GetExtension(model.file.FileName);  //.jpg tapmaq ucundur. png .gng 

                    instagram.ImgPath = $"{Guid.NewGuid()}{extension}";//imagenin name 


                    string phsicalFileName = Path.Combine(env.ContentRootPath, "wwwroot", "uploads", "images", instagram.ImgPath);

                    using (var stream = new FileStream(phsicalFileName, FileMode.Create, FileAccess.Write))
                    {
                        await model.file.CopyToAsync(stream);
                    }

                  
                    



                    store.Add(instagram);
                    await store.SaveChangesAsync(cancellationToken);

                    return instagram;

                }
                return null;
            }
        }

    }
}
