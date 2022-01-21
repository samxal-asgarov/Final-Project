using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ToyStoreSolution.Models.DataContext;
using ToyStoreSolution.Models.Entities;

namespace ToySolution.AppCode.Application.ProductIntroModule
{
    public class ProductSingleQuery:IRequest<Product>
    {
        public int? Id { get; set; }
        public class ProductSingleQueryHandler : IRequestHandler<ProductSingleQuery, Product>
        {
            private readonly StoreDbContext db;
            public ProductSingleQueryHandler(StoreDbContext db)
            {
                this.db = db;
            }
            public async Task<Product> Handle(ProductSingleQuery request, CancellationToken cancellationToken)
            {
                var product = await db.Products
                    .Include(s=>s.Sort)
                    .FirstOrDefaultAsync(m => m.Id == request.Id);
                return product;
            }
        }
    }
}
