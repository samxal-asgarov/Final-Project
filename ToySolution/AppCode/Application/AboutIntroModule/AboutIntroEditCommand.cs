using ASP.NetCV.AppCode.Extensions;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ToyStoreSolution.Models.DataContext;

namespace ToySolution.AppCode.Application.AboutIntroModule
{
    public class AboutIntroEditCommand : AboutIntroViewModel, IRequest<int>
    {
        public class AboutIntroEditCommandHandler : IRequestHandler<AboutIntroEditCommand, int>
        {
            readonly StoreDbContext db;
            readonly IActionContextAccessor ctx;
            readonly IWebHostEnvironment env;


            public AboutIntroEditCommandHandler(StoreDbContext db, IActionContextAccessor ctx, IWebHostEnvironment env)
            {
                this.db = db;
                this.ctx = ctx;
                this.env = env;
            }
            public async Task<int> Handle(AboutIntroEditCommand request, CancellationToken cancellationToken)
            {
                
                if (request.Id != request.Id)
                {
                    return 0;
                }


                if (string.IsNullOrWhiteSpace(request.ImgPath) && request.file == null)
                {

                    ctx.ActionContext.ModelState.AddModelError("file", "Not Chosen");
                }

                var entity = await db.AboutIntros.FirstOrDefaultAsync(b => b.Id == request.Id && b.DeletedByUserID == null);
                
                if (entity == null)
                {
                    return 0;
                }

                if (ctx.ModelStateValid())
                {

                    entity.ImgPath = request.ImgPath;
                    entity.Head = request.Head;
                    entity.Tittle = request.Tittle;
                    entity.Desc = request.Desc;





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