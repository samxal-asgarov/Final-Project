using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToySolution.AppCode.Application.AboutStoryModule
{
    public class AboutViewModel
    {
        [Required]
        public int Id { get; set; }
        public string Head { get; set; }
        public string Tittle { get; set; }
        public string Desc { get; set; }
    }
}
