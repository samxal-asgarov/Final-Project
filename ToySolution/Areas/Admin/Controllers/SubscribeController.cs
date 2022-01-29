using ASP.NetCV.AppCode.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToySolution.AppCode.Extensions;
using ToySolution.Models.Entities;
using ToyStoreSolution.Models.DataContext;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ToySolution.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubscribeController : Controller
    {
        private readonly StoreDbContext db;
        readonly IConfiguration configuration;

        public SubscribeController(StoreDbContext db, IConfiguration configuration)
        {
            this.db = db;
            this.configuration = configuration;
        }

        public async Task<IActionResult> Index(int typeId)
        {
            var query = db.Subscribes.AsQueryable()
                .Where(cp => cp.DeletedByUserID == null);


          
            return View(await query.ToListAsync());
        }


       
    }
}
