using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToyStoreSolution.Models.Entities
{
    public class InstagramPhoto:BaseEntities
    {
        public string ImgPath { get; set; }
        public bool HomePageShow { get; set; }
    }
}
