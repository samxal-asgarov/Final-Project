using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ToySolution.Views.ViewModels;
using ToyStoreSolution.Models.DataContext;
using ToyStoreSolution.Models.Entities;

namespace ToySolution.AppCode.Application.InstagramModule
{
    public class InstagramPagedQuery : IRequest<PagedViewModel<InstagramPhoto>>
    {
        public int pageIndex { get; set; } = 1;
        public int pageSize { get; set; } = 3;

        public class InstagramPagedQueryHandler : IRequestHandler<InstagramPagedQuery, PagedViewModel<InstagramPhoto>>
        {
            readonly StoreDbContext db;
            public InstagramPagedQueryHandler(StoreDbContext db)
            {
                this.db = db; //Model
            }
            public async Task<PagedViewModel<InstagramPhoto>> Handle(InstagramPagedQuery model, CancellationToken cancellationToken)
            {
                var query = db.InstagramPhotos.Where(b => b.CreatByUserId == null && b.DeletedByUserID == null).AsQueryable();

                //int queryCount = await query.CountAsync(cancellationToken); // silinmemislerin sayni takir

                //var pagedData = await query.Skip((model.Pageindex - 1) * model.PageCount) // skip necensi seyfede,
                //    .Take(model.PageCount) // nece denesini gosdersin.
                //    .ToListAsync(cancellationToken);






                return new PagedViewModel<InstagramPhoto>(query, model.pageIndex, model.pageSize);
            }
        }
    }
}


