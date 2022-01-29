using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToyStoreSolution.Models.Entities
{
    public class Product:BaseEntities
    {
        public string Name { get; set; }
        public decimal Value  { get; set; }
        public string ImgPath { get; set; }
        public string Desc { get; set; }
        public string Sku { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Length { get; set; }
        public string Body { get; set; }
        public bool HomePageShow { get; set; }
        public int SortId { get; set; }
      
        public virtual Sort Sort { get; set; }

    }
}
