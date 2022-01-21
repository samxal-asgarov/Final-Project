using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToyStoreSolution.Models.Entities
{
    public class AboutUs:BaseEntities
    {
       
        public string Tittle { get; set; }
        public string Desc { get; set; }
        public string ImgPath { get; set; }

    }
}
