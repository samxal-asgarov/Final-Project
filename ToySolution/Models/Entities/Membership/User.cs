using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NetCV.Models.Entities.Membership
{
    public class User: IdentityUser<int>
    {
        public bool Active { get; set; } = true;
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
