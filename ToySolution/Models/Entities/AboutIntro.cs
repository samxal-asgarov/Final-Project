using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToyStoreSolution.Models.Entities
{
    public class AboutIntro:BaseEntities
    {
        public string Tittle { get; set; }
        public string Head { get; set; }
        public string Desc { get; set; }
        public string ImgPath { get; set; }
    }
}
