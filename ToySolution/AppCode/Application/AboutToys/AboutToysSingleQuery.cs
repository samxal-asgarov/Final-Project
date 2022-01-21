using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ToyStoreSolution.Models.DataContext;
using ToyStoreSolution.Models.Entities;

namespace ToySolution.AppCode.Application.AboutToys
{
    public class AboutToysSingleQuery : IRequest<AboutOurToys>
    {
        public int?  Id { get; set; }

        public class AboutToysSingleQueryHandler : IRequestHandler<AboutToysSingleQuery, AboutOurToys>
        {
            readonly StoreDbContext store;
            public AboutToysSingleQueryHandler(StoreDbContext store)
            {
                this.store = store;
            }
            public async Task<AboutOurToys> Handle(AboutToysSingleQuery request, CancellationToken cancellationToken)
            {
                var instagram = await store.AboutOurToys
              .FirstOrDefaultAsync(m => m.Id == request.Id);
                return instagram;
            }
        }
    }
}
