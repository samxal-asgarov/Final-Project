using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToyStoreSolution.Models.Entities
{
    public class BaseEntities
    {
        public int Id { get; set; }
        public int? CreatByUserId { get; set; }
        public DateTime CreatDate { get; set; } = DateTime.Now;
        public int? DeletedByUserID { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
