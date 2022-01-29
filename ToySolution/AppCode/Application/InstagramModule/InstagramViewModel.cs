using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToySolution.AppCode.Application.InstagramModule
{
    public class InstagramViewModel
    {
        [Required]
        public int Id { get; set; }
        public string ImgPath { get; set; }
        public bool HomePageShow { get; set; }
        public IFormFile file { get; set; }

    }
}
