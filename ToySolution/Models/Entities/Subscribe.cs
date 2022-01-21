using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToyStoreSolution.Models.Entities;

namespace ToySolution.Models.Entities
{
    public class Subscribe: BaseEntities
    {
        public string Email { get; set; }
        public bool? EmailConfirmed { get; set; }
        public DateTime? ConfirmedDate { get; set; }
    }
}
