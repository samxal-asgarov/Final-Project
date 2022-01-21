using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ToyStoreSolution.Models.DataContext;
using ToyStoreSolution.Models.Entities;

namespace ToySolution.AppCode.Application.InstagramModule
{
    public class InstagramSingleQuery : IRequest<InstagramPhoto>
    {
        
            //axtaris etmek ucun id getirmek ucun yazilir query!
            public int? Id { get; set; }

        public class InstagramSingleQueryHandler : IRequestHandler<InstagramSingleQuery, InstagramPhoto>
        {
            readonly StoreDbContext store;
            public InstagramSingleQueryHandler( StoreDbContext store)
            {
                this.store = store;
            }


            public async Task<InstagramPhoto> Handle(InstagramSingleQuery request, CancellationToken cancellationToken)
            {

                var instagram = await store.InstagramPhotos
                    .FirstOrDefaultAsync(m => m.Id == request.Id);
                return instagram;
            }
        }
    }
    
}
