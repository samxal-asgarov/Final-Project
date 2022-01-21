using ASP.NetCV.AppCode.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ToyStoreSolution.Models.DataContext;

namespace ToySolution.AppCode.Application.AboutToys
{
    public class AboutToysEditCommand: AboutToysViewModel,IRequest<int>
    {
        public class AboutToysEditCommandHandler : IRequestHandler<AboutToysEditCommand, int>
        {
            readonly StoreDbContext store;
            readonly IActionContextAccessor ctx;
            readonly IHostEnvironment env;
            public AboutToysEditCommandHandler(StoreDbContext store, IActionContextAccessor ctx, IHostEnvironment env)
            {
                this.store = store;
                this.ctx = ctx;
                this.env = env;
            }
            public async Task<int> Handle(AboutToysEditCommand request, CancellationToken cancellationToken)
            {
                if (request.Id != request.Id)
                {
                    return 0;
                }
                var entity = await store.AboutOurToys.FirstOrDefaultAsync(b => b.Id == request.Id && b.DeletedByUserID == null);
                if (entity == null)
                {
                    return 0;
                }


                if (ctx.ModelStateValid())
                {
                    entity.Tittle = request.Tittle;
                    entity.ImgPath = request.ImgPath;
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

                    await store.SaveChangesAsync(cancellationToken);
                    return entity.Id;

                }
                return 0;
            }
        }

       


    }
}
