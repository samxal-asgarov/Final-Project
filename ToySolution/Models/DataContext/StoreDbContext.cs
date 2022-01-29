using ASP.NetCV.Models.Entities.Membership;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToySolution.Models.Entities;
using ToySolution.Models.Entities.Membership;
using ToyStoreSolution.Models.Entities;

namespace ToyStoreSolution.Models.DataContext
{
    public class StoreDbContext : IdentityDbContext<StoreUser, StoreRole, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
           : base(options)
        {

        }

        // Database olan membershiplerin ADi qabaginda bu kod vasitesile qeyd edrik
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<StoreUser>(e => {
                // adi   //ADI qabagindaki
                e.ToTable("StoreUser", "Membership");

            });

            builder.Entity<StoreRole>(e => {

                e.ToTable("StoreRole", "Membership");

            });

            builder.Entity<UserRole>(e => {

                e.ToTable("UserRoles", "Membership");

            });

            builder.Entity<UserClaim>(e => {

                e.ToTable("UserClaims", "Membership");

            });

            builder.Entity<RoleClaim>(e => {

                e.ToTable("RoleClaims", "Membership");

            });
            builder.Entity<UserToken>(e => {

                e.ToTable("UserTokens", "Membership");

            });
            builder.Entity<UserLogin>(e => {

                e.ToTable("UserLogins", "Membership");

            });
        }


        public DbSet<Product> Products { get; set; }

        public DbSet<Delivery> Deliveries { get; set; } 
        public DbSet<AboutIntro> AboutIntros { get; set; }  
        public DbSet<AboutStory> AboutStories { get; set; } 
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<AboutOurToys> AboutOurToys { get; set; }
        public DbSet<InstagramPhoto> InstagramPhotos { get; set; }
        public DbSet<Sort> Sort { get; set; }
        public DbSet<ContactPosts> ContactPosts { get; set; } 
        public DbSet<Subscribe> Subscribes { get; set; }



    }






}
