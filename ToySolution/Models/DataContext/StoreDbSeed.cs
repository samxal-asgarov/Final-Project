using ASP.NetCV.Models.Entities.Membership;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToySolution.Models.DataContext
{
    public static class StoreDbSeed
    {
        public static IApplicationBuilder SeedMembership(this IApplicationBuilder builder)
        {
            using (var scope = builder.ApplicationServices.CreateScope())
            {
                var role = new Role
                {
                    Name = "SuperAdmin"      ///bazada super admin yaratdiq
                };
                //RoleManager=Rolu  Idare Edir
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();

                //yoxluyuruq  super admin databazada var yoxsa yox

                bool hasRole = roleManager.RoleExistsAsync(role.Name).Result;

                if (hasRole == true)
                {
                    role = roleManager.FindByNameAsync(role.Name).Result;  //databazada varsa isdifade et
                }
                else
                {
                    var IRole = roleManager.CreateAsync(role).Result;  //yoxdursa yarat 

                    if (!IRole.Succeeded)  //eger yenisin yarada bilmiyibse
                    {
                        goto end;
                    }
                }
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();//role idare etmek ucun rolemanager

                string password = "123";

                var user = new User   //user yaratdiq
                {
                    UserName = "Samxal",
                    Email = "SamxalAs@mail.ru",
                    EmailConfirmed = true,
                    Active = true
                };
                //FindByEmailAsnyc bize tapmiyanda null tapanda ise null qaytarmir ve tapmiyanda user icindekilerni null edir.
                var foundUser = userManager.FindByEmailAsync(user.Email).Result;//databazada emaili axtarir var yoxsa yox

                if (foundUser != null && !userManager.IsInRoleAsync(foundUser, role.Name).Result)
                {
                    userManager.AddToRoleAsync(foundUser, role.Name).Wait();  //Biz yaratdiqmiz rola at
                }
                else if (foundUser == null)
                {
                    var IUserResult = userManager.CreateAsync(user, password).Result; // yox eger database hemin user yoxdusa yenisini yaratsin.

                    if (IUserResult.Succeeded) //ugurludsa
                    {
                        userManager.AddToRoleAsync(user, role.Name).Wait(); //Burda biz yaratdiqmiz user rola atiriq.

                    }
                }

            }



        end: return builder;

        }
    }
}
