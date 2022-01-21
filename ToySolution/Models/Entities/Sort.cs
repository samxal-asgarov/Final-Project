using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToyStoreSolution.Models.Entities
{
    public class Sort:BaseEntities
    {
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}
