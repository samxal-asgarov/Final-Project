using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ToyStoreSolution.Models.DataContext;
using ToyStoreSolution.Models.Entities;

namespace ToySolution.AppCode.Application.DeliveryModule
{
    public class DeliverySingleQuery: IRequest<Delivery>
    {
        public int? Id { get; set; }

        public class DeliverySingleQueryHandler : IRequestHandler<DeliverySingleQuery, Delivery>
        {
            readonly StoreDbContext store;
            public DeliverySingleQueryHandler(StoreDbContext store)
            {
                this.store = store;
            }
            public async Task<Delivery> Handle(DeliverySingleQuery request, CancellationToken cancellationToken)
            {
                var instagram = await store.Deliveries.FirstOrDefaultAsync(m => m.Id == request.Id);

                return instagram;
            }
        }
    }
}
