using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ToySolution.Views.ViewModels;
using ToyStoreSolution.Models.DataContext;
using ToyStoreSolution.Models.Entities;

namespace ToySolution.AppCode.Application.ProductIntroModule
{
    public class ProductPagedQuery : IRequest<PagedViewModel<Product>>
    {
        public int pageIndex { get; set; } = 1;
        public int pageSize { get; set; } = 3;

        public class ProductPagedQueryHandler : IRequestHandler<ProductPagedQuery, PagedViewModel<Product>>
        {
            readonly StoreDbContext db;
            public ProductPagedQueryHandler(StoreDbContext db)
            {
                this.db = db; //Model
            }
            public async Task<PagedViewModel<Product>> Handle(ProductPagedQuery request, CancellationToken cancellationToken)
            {
                var query = db.Products
                    .Include(e => e.Sort)
                    .Where(b => b.CreatByUserId == null && b.DeletedByUserID == null).AsQueryable();
                
         






                return new PagedViewModel<Product>(query,request.pageIndex,request.pageSize);
            }
        }
    }
}
