using ASP.NetCV.AppCode.Extensions;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ToyStoreSolution.Models.DataContext;
using ToyStoreSolution.Models.Entities;

namespace ToySolution.AppCode.Application.InstagramModule
{
    public class InstagramEditCommand: InstagramViewModel, IRequest<int>
    {
     

        public class InstagramEditCommandHandler : IRequestHandler<InstagramEditCommand, int>
        {
            readonly StoreDbContext db;
            readonly IActionContextAccessor ctx;
            readonly IWebHostEnvironment env;


            public InstagramEditCommandHandler(StoreDbContext db, IActionContextAccessor ctx, IWebHostEnvironment env)
            {
                this.db = db;
                this.ctx = ctx;
                this.env = env;
            }
            public async Task<int> Handle(InstagramEditCommand request, CancellationToken cancellationToken)
            {
                if (request.Id != request.Id)
                {
                    return 0;
                }


                if (string.IsNullOrWhiteSpace(request.ImgPath) && request.file == null)
                {

                    ctx.ActionContext.ModelState.AddModelError("file", "Not Chosen");
                }

                var entity = await db.InstagramPhotos.FirstOrDefaultAsync(b => b.Id == request.Id && b.DeletedByUserID == null);

                if (entity == null)
                {
                    return 0;
                }

                if (ctx.ModelStateValid())
                {
                
                    entity.ImgPath = request.ImgPath;
                   





                    if (request.file != null)
                    {

                        string extension = Path.GetExtension(request.file.FileName);  //.jpg tapmaq ucundur.

                        request.ImgPath = $"{Guid.NewGuid()}{extension}";//imagenin name 


                        string phsicalFileName = Path.Combine(env.ContentRootPath, "wwwroot", "uploads", "images", request.ImgPath);

                        using (var stream = new FileStream(phsicalFileName, FileMode.Create, FileAccess.Write))
                        {
                            await request.file.CopyToAsync(stream);
                        }

                        if (!string.IsNullOrWhiteSpace(entity.ImgPath))
                        {
                            System.IO.File.Delete(Path.Combine(env.ContentRootPath, "wwwroot", "uploads", "images", entity.ImgPath));

                        }
                        entity.ImgPath = request.ImgPath;
                    }

                    await db.SaveChangesAsync(cancellationToken);
                    return entity.Id;



                }
                return 0;


            }
        }
    }
}
