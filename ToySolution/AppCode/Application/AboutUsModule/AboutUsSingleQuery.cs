using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ToyStoreSolution.Models.DataContext;
using ToyStoreSolution.Models.Entities;

namespace ToySolution.AppCode.Application.AboutUsModule
{
    public class AboutUsSingleQuery:IRequest<AboutUs>
    {
        public int? Id { get; set; }
        public class AboutUsSingleQueryHandler : IRequestHandler<AboutUsSingleQuery, AboutUs>
        {
            readonly StoreDbContext store;
            public AboutUsSingleQueryHandler(StoreDbContext store)
            {
                this.store = store;
            }
            public async Task<AboutUs> Handle(AboutUsSingleQuery request, CancellationToken cancellationToken)
            {
                var instagram = await store.AboutUs
              .FirstOrDefaultAsync(m => m.Id == request.Id);
                return instagram;
            }
        }
    }
}
