using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ToyStoreSolution.Models.DataContext;
using ToyStoreSolution.Models.Entities;

namespace ToySolution.AppCode.Application.AboutStoryModule
{
    public class AboutStorySingleQuery : IRequest<AboutStory>
    {

        //axtaris etmek ucun id getirmek ucun yazilir query!
        public int? Id { get; set; }

        public class AboutStroySingleQueryHandler : IRequestHandler<AboutStorySingleQuery, AboutStory>
        {
            readonly StoreDbContext store;
            public AboutStroySingleQueryHandler(StoreDbContext store)
            {
                this.store = store;
            }
            public async Task<AboutStory> Handle(AboutStorySingleQuery request, CancellationToken cancellationToken)
            {
                var story = await store.AboutStories
                     .FirstOrDefaultAsync(m => m.Id == request.Id);
                return story;
            }
        }
    }



}
