using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToyStoreSolution.Models.Entities;

namespace ToySolution.AppCode.Application.ProductIntroModule
{
    public class ProductViewModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
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
        public  Sort Sort { get; set; }

        public IFormFile file { get; set; }

    }
}
