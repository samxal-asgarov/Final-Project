using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToySolution.AppCode.Application.AboutToys
{
    public class AboutToysViewModel
    {
        public int? Id { get; set; }
        public string Tittle { get; set; }
        public string Desc { get; set; }
        public string ImgPath { get; set; }

        public IFormFile file { get; set; }
    }
}
