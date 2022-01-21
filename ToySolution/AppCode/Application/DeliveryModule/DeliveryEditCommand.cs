using ASP.NetCV.AppCode.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ToyStoreSolution.Models.DataContext;

namespace ToySolution.AppCode.Application.DeliveryModule
{
    public class DeliveryEditCommand: DeliveryViewModel, IRequest<int>
    {
        public class DeliveryEditCommandHandler : IRequestHandler<DeliveryEditCommand, int>
        {
            readonly StoreDbContext store;
            readonly IActionContextAccessor ctx;
       
            public DeliveryEditCommandHandler(StoreDbContext store, IActionContextAccessor ctx)
            {
                this.store = store;
                this.ctx = ctx;
                
            }
            public async Task<int> Handle(DeliveryEditCommand request, CancellationToken cancellationToken)
            {
                if (request.Id != request.Id)
                {
                    return 0;
                }
                var entity = await store.Deliveries.FirstOrDefaultAsync(b => b.Id == request.Id && b.DeletedByUserID == null);
                if (entity == null)
                {
                    return 0;
                }


                if (ctx.ModelStateValid())
                {
                    entity.Head = request.Head;
             

                  

                    await store.SaveChangesAsync(cancellationToken);
                    return entity.Id;

                }
                return 0;
            }
        }
    }
}
