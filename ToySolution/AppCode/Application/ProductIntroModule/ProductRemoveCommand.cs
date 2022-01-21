using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ToySolution.AppCode.Infrastucture;
using ToyStoreSolution.Models.DataContext;

namespace ToySolution.AppCode.Application.ProductIntroModule
{
    public class ProductRemoveCommand :IRequest<CommandJsonRespons>
    {
        public int? Id { get; set; }
        public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, CommandJsonRespons>
        {
            readonly StoreDbContext db;
            public ProductRemoveCommandHandler(StoreDbContext db)
            {
                this.db = db;
            }
            public async Task<CommandJsonRespons> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
            {
                var response = new CommandJsonRespons();


                if (request.Id == null || request.Id < 1)
                {
                    response.Error = true;
                    response.Message = "Melumat tamligi qorunmuyub";
                    goto end;
                }

                var instagram = await db.Products.FirstOrDefaultAsync(m => m.Id == request.Id && m.DeletedByUserID == null);

                if (instagram == null)
                {
                    response.Error = true;
                    response.Message = "Melumat movcud deyildir.";
                    goto end;
                }

                instagram.DeletedByUserID = 1;
                instagram.DeletedDate = DateTime.Now;
                await db.SaveChangesAsync(cancellationToken);

                response.Error = false;
                response.Message = "Ugurlu elemlyat";
            end:
                return response;
            }
        }
        }
    }

