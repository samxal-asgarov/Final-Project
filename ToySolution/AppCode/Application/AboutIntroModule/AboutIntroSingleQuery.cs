using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ToyStoreSolution.Models.DataContext;
using ToyStoreSolution.Models.Entities;

namespace ToySolution.AppCode.Application.AboutIntroModule
{
    public class AboutIntroSingleQuery : IRequest<AboutIntro>
    {

        //axtaris etmek ucun id getirmek ucun yazilir query!
        public int? Id { get; set; }

        public  class AboutIntroSingleQueryHandler : IRequestHandler<AboutIntroSingleQuery, AboutIntro>
        {
            readonly StoreDbContext store;
            public AboutIntroSingleQueryHandler(StoreDbContext store)
            {
                this.store = store;
            }

            public async Task<AboutIntro> Handle(AboutIntroSingleQuery request, CancellationToken cancellationToken)
            {
                var about = await store.AboutIntros
                     .FirstOrDefaultAsync(m => m.Id == request.Id);

                return about;
            }
        }
    }
}
