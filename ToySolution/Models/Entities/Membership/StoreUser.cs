using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToySolution.Models.Entities.Membership  
{
    public class StoreUser: IdentityUser<int>
    {
        public bool Active { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
       
    }
}
