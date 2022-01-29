using System.Collections.Generic;
using ToySolution.Models.Entities;
using ToySolution.Models.Entities.Membership;
using ToySolution.Models.FormModels;
using ToySolution.Models.ViewModels;
using ToyStoreSolution.Models.Entities;

namespace ToyStoreSolution.Models.ViewModels
{
    public class IndexViewModels
    {
        public List<Product> Products { get; set; } 
        public List<Delivery> Deliveries { get; set; }
        public virtual AboutUs AboutUs { get; set; }
        public virtual AboutStory  AboutStories { get; set; }
        public virtual AboutIntro AboutIntros { get; set; }
        public virtual  AboutOurToys AboutOurToys{ get; set; }
        public List<InstagramPhoto> InstagramPhotos { get; set; }
        public  ContactPosts ContactPosts { get; set; }
        public Subscribe Subscribe { get; set; }


        public List<Sort> Sort { get; set; }
        public List<BasketItem> BasketItems { get; set; }
        




    }
}
