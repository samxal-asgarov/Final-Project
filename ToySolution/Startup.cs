using ASP.NetCV.Models.Entities.Membership;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using ToySolution.Models.DataContext;
using ToySolution.Models.Entities.Membership;
using ToyStoreSolution.Models.DataContext;

namespace ToySolution
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(cfg =>
            {
                var policy = new AuthorizationPolicyBuilder()        //mehdudyet yaradr viewlarimizda
                 .RequireAuthenticatedUser()
                 .Build();
                cfg.Filters.Add(new AuthorizeFilter(policy));


            });

            services.AddDbContext<StoreDbContext>(cfg =>
            {
                cfg.UseSqlServer(configuration.GetConnectionString("cString"));
            });


            //Mediatr Uchun Yazlib 
            services.AddMediatR(this.GetType().Assembly);

            services.AddIdentity<StoreUser, StoreRole>()
              .AddEntityFrameworkStores<StoreDbContext>().AddDefaultTokenProviders();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            


            services.Configure<IdentityOptions>(cfg =>
            {
                cfg.Password.RequireDigit = false; //Reqem teleb elesin?
                cfg.Password.RequireUppercase = false; //Boyuk reqem teleb elesin?
                cfg.Password.RequireLowercase = false; //Kick reqem teleb elesin?
                cfg.Password.RequiredUniqueChars = 1; //Tekrarlanmiyan nece  sombol olsun?(11-22-3)
                cfg.Password.RequireNonAlphanumeric = false; // 0-9 a-z A-Z  Olmayanlari teleb elemesin?
                cfg.Password.RequiredLength = 3; //Password nece simboldan ibaret olsun?

                cfg.User.RequireUniqueEmail = true; //Email tekrarlanmasin 1 adam ucun?
                                                    //cfg.User.AllowedUserNameCharacters = ""; //User neleri isdifade eliye biler?

                cfg.Lockout.MaxFailedAccessAttempts = 3;// 3 seferden cox sefh giris etse diyansin?
                cfg.Lockout.DefaultLockoutTimeSpan = new TimeSpan(0, 5, 0);//Nece deq gozlesin ?
            });
            services.ConfigureApplicationCookie(cfg =>
            {

                cfg.LoginPath = "/signin.html"; //Eger adam login olunmuyubsa hara gondersin?

                cfg.AccessDeniedPath = "/accessdenied.html";//Senin icazen var bu linke yeni link atanda gire bilmesin diye (yeni fb nese atanda ve ya tiktokda olanda beyenmek olmur zad)

                cfg.ExpireTimeSpan = new TimeSpan(0, 10, 10);//Seni sayitda nece deq saxlasin eger sen hecne elemirsense atacaq yeni login olduqdan sonra diansan ve ya saty girdikden sonra diansan

                cfg.Cookie.Name = "riode"; //Cookie adi ne olsun isdediyin adi yaza bilersen;

            });
            services.AddAuthentication();
            services.AddAuthorization();

            services.AddScoped<UserManager<StoreUser>>();
            services.AddScoped<SignInManager<StoreUser>>(); //signin menecer inject olunsun

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.SeedMembership();
            app.UseRouting();

            app.Use(async (context, next) =>
            {
                if (!context.Request.Cookies.ContainsKey("riode")
                && context.Request.RouteValues.TryGetValue("area", out object areaName)
                && areaName.ToString().ToLower().Equals("admin"))
                {
                    var attr = context.GetEndpoint().Metadata.GetMetadata<AllowAnonymousAttribute>();
                    if (attr == null)
                    {

                        context.Response.Redirect("/admin/singin.html");
                        await context.Response.CompleteAsync();

                    }

                }
                await next();
            });
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();



            app.UseEndpoints(endpoints =>
            {

               endpoints.MapControllerRoute("adminsingin", "admin/singin.html",

               defaults: new
               {
                   controller = "Account",
                   action = "singin",
                   area = "Admin"
               });


                endpoints.MapControllerRoute(

                    name: "Default-signin",
                    pattern: "accessdenied.html",
                    defaults: new
                    {
                        areas = "",
                        controller = "Home",
                        action = "accessdenied"
                    });

                endpoints.MapControllerRoute("adminsingin", "admin/singin.html",
                    defaults: new
                    {
                        controller = "Account",
                        action = "singin",
                        area = "Admin"
                    });



                endpoints.MapControllerRoute(

                    name: "Default-signin",
                    pattern: "signin.html",
                    defaults: new
                    {
                        areas = "",
                        controller = "Account",
                        action = "SignIn"
                    });

                endpoints.MapControllerRoute(

                    name: "Default-register",
                    pattern: "register.html",
                    defaults: new
                    {
                        areas = "",
                        controller = "Account",
                        action = "Register"
                    });
                endpoints.MapControllerRoute(

                    name: "Default-register-confirm",
                    pattern: "registration-confirm.html",
                    defaults: new
                    {
                        areas = "",
                        controller = "Account",
                        action = "RegisterConfirm"
                    });
                endpoints.MapControllerRoute("areas", "{area:exists}/{controller=Instagram}/{action=index}/{Id?}");

                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{Id?}");
            });
        }
    }



}
