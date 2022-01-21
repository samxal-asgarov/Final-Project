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

namespace ToySolution.AppCode.Application.AboutStoryModule
{
    public class AboutStoryEditCommand: AboutViewModel, IRequest<int>
    {
        public  class AboutStoryEditCommandHandler : IRequestHandler<AboutStoryEditCommand, int>
        {
            readonly StoreDbContext store;
            readonly IActionContextAccessor ctx;
            public AboutStoryEditCommandHandler(StoreDbContext store, IActionContextAccessor ctx)
            {
                this.store = store;
                this.ctx = ctx;
            }
            public async Task<int> Handle(AboutStoryEditCommand request, CancellationToken cancellationToken)
            {
                if (request.Id != request.Id)
                {
                    return 0;
                }
                var entity = await store.AboutStories.FirstOrDefaultAsync(b => b.Id == request.Id && b.DeletedByUserID == null);
                if (entity == null)
                {
                    return 0;
                }


                if (ctx.ModelStateValid())
                {
                    entity.Tittle = request.Tittle;
                    entity.Head = request.Head;
                    entity.Desc = request.Desc;

                    await store.SaveChangesAsync(cancellationToken);
                    return entity.Id;

                }
                return 0;
            }
        }
    }
}
