using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ToySolution.Views.ViewModels;
using ToyStoreSolution.Models.DataContext;
using ToyStoreSolution.Models.Entities;

namespace ToySolution.AppCode.Application.AboutUsModule
{
    public class AboutPagedQuery : IRequest<PagedViewModel<AboutUs>>
    {
        public int pageIndex { get; set; } = 1;
        public int pageSize { get; set; } = 3;
        public class AboutPagedQueryHandler : IRequestHandler<AboutPagedQuery, PagedViewModel<AboutUs>>
        {
            readonly StoreDbContext db;
            public AboutPagedQueryHandler(StoreDbContext db)
            {
                this.db = db; //Model
            }

            public async Task<PagedViewModel<AboutUs>> Handle(AboutPagedQuery model, CancellationToken cancellationToken)
            {
                var query = db.AboutUs.Where(b => b.CreatByUserId == null && b.DeletedByUserID == null).AsQueryable();



                return new PagedViewModel<AboutUs>(query, model.pageIndex, model.pageSize);

            }
        }
    }
}
