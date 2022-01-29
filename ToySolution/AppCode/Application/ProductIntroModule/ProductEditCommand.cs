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

namespace ToySolution.AppCode.Application.ProductIntroModule
{
    public class ProductEditCommand : ProductViewModel, IRequest<int>
    {
        public class ProductEditCommandHandler : IRequestHandler<ProductEditCommand, int>
        {
            readonly StoreDbContext db;
            readonly IActionContextAccessor ctx;
            readonly IHostEnvironment env;


            public ProductEditCommandHandler(StoreDbContext db, IActionContextAccessor ctx, IHostEnvironment env)
            {
                this.db = db;
                this.ctx = ctx;
                this.env = env;
            }
            public async Task<int> Handle(ProductEditCommand request, CancellationToken cancellationToken)
            {

                if (request.Id != request.Id)
                {
                    return 0;
                }


                if (string.IsNullOrWhiteSpace(request.ImgPath) && request.file == null)
                {

                    ctx.ActionContext.ModelState.AddModelError("file", "Not Chosen");
                }

                var entity = await db.Products.FirstOrDefaultAsync(b => b.Id == request.Id && b.DeletedByUserID == null);

                if (entity == null)
                {
                    return 0;
                }

                if (ctx.ModelStateValid())
                {

                    entity.Height = request.Height;
                    entity.ImgPath = request.ImgPath;
                    entity.Length = request.Length;
                    entity.Name = request.Name;
                    entity.Sku = request.Sku;

                    entity.SortId = request.SortId;
                    entity.Value = request.Value;
                    entity.Weight = request.Weight;
                    entity.Width = request.Width;
                    entity.Body = request.Body;
                    entity.Desc = request.Desc;
                 
                    entity.HomePageShow = request.HomePageShow;





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
