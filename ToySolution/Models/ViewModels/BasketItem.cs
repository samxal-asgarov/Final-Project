using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToySolution.Models.ViewModels
{
    public class BasketItem
    {
      
        public int ProductId { get; set; }
      
        public int Count { get; set; }
        public string    ImagePath { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public decimal Amount
        { 
            get
            {
                return Price * Count;
            }
        }

    }
}
