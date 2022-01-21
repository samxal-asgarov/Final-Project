using ASP.NetCV.AppCode.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ToySolution.Migrations;
using ToySolution.Models.Entities;
using ToySolution.Models.FormModels;
using ToySolution.Models.ViewModels;
using ToyStoreSolution.Models.DataContext;
using ToyStoreSolution.Models.Entities;
using ToyStoreSolution.Models.ViewModels;

namespace ToyStoreSolution.Controllers
{
    public class HomeController : Controller
    {
        readonly StoreDbContext db; 
        readonly IConfiguration configuration;
        public HomeController(StoreDbContext db,IConfiguration configuration)
        {
            this.db = db;
            this.configuration = configuration;

        }
        [AllowAnonymous]

        public IActionResult Index()

        {
            IndexViewModels iv = new IndexViewModels();
            iv.InstagramPhotos = db.InstagramPhotos.Where(f => f.DeletedByUserID == null).ToList();
            return View(iv);
        }

        [AllowAnonymous]


        public IActionResult Catalog()
        {
            IndexViewModels iv = new IndexViewModels();
            iv.Products = db.Products.Where(d => d.DeletedByUserID == null).ToList();
            iv.InstagramPhotos = db.InstagramPhotos.Where(f => f.DeletedByUserID == null).ToList();
            iv.Sort = db.Sort.Where(f => f.DeletedByUserID == null).ToList();
            return View(iv);
        }
   
        public IActionResult CatalogDetails(int id)
        {
            IndexViewModels iv = new IndexViewModels();
           iv.Products = db.Products.Where(f => f.Id == id && f.DeletedByUserID == null).ToList();
            iv.InstagramPhotos = db.InstagramPhotos.Where(f => f.DeletedByUserID == null).ToList();
            return View(iv);
        }



        public IActionResult Accessdenied()
        {
            return View();
        }






        [AllowAnonymous]

        public IActionResult Delivery()
        {
            IndexViewModels iv = new IndexViewModels();
            iv.Deliveries = db.Deliveries.Where(d => d.DeletedByUserID == null).ToList();
            iv.InstagramPhotos = db.InstagramPhotos.Where(f => f.DeletedByUserID == null).ToList();
            return View(iv);
        }
        [AllowAnonymous]

        public IActionResult About()
        {
            IndexViewModels iv = new IndexViewModels();
            iv.AboutUs = db.AboutUs.FirstOrDefault(f => f.DeletedByUserID == null);
            iv.AboutStories = db.AboutStories.FirstOrDefault(f => f.DeletedByUserID == null);
            iv.AboutIntros = db.AboutIntros.FirstOrDefault(f => f.DeletedByUserID == null);
            iv.AboutOurToys = db.AboutOurToys.FirstOrDefault(f => f.DeletedByUserID == null);
            iv.InstagramPhotos = db.InstagramPhotos.Where(f => f.DeletedByUserID == null).ToList();

            return View(iv);
        }
        [AllowAnonymous]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Subscribe( IndexViewModels model)
        {
            if (ModelState.IsValid)
            {

                var current = db.Subscribes.FirstOrDefault(s => s.Email.Equals(model.Subscribe.Email));
                if (current != null && current.EmailConfirmed == true)
                {
                    return Json(new
                    {
                        error = true,
                        message = "Siz abune olmusunuz tesekkurler!"
                    });
                }

                else if (current != null && (current.EmailConfirmed ?? false == false))
                {
                    return Json(new
                    {
                        error = true,
                        message = "Emailnize gelen linki tesdiqleyin zehmet olmasa!"
                    });
                }
                db.Subscribes.Add(model.Subscribe);
                db.SaveChanges();

                string token = $"subscribetoken-{model.Subscribe.Id}--{DateTime.Now:yyyyyMMddHHmmss}";
                token = token.Encrypt("");
                string path = $"{Request.Scheme}://{Request.Host}/subscribe-confirm?token={token}";

                string fromMail = configuration["emailAccount:userName"];
                string displayName = configuration["emailAccount:displayName"];
                string smtpServer = configuration["emailAccount:smtpServer"];
                int port = Convert.ToInt32(configuration["emailAccount:smtpPort"]);
                string password = configuration["emailAccount:password"];
                string cc = configuration["emailAccount:cc"];


                MailAddress from = new MailAddress(fromMail, displayName);

                MailAddress to = new MailAddress(model.Subscribe.Email);

                MailMessage message = new MailMessage(from, to);
                message.Subject = "ToyStore NewsLetter subscribe";
                message.Body = $"Zehmet olmasa <a href={path}>link</a> vasitesiyle abuneliyinizi tamamlayin";
                message.IsBodyHtml = true;
                if (!string.IsNullOrWhiteSpace(cc))
                    message.CC.Add(cc);


                SmtpClient smtpClient = new SmtpClient(smtpServer, port);
                smtpClient.Credentials = new NetworkCredential(fromMail, password);
                smtpClient.EnableSsl = true;
                smtpClient.Send(message);

           



                return Json(new
                {
                    error = false,
                    message = "Sorgunuz ugurla qeyde alindi! Emailnizde abunelliyinizi linke daxil olaraq tamamlayin!"
                });


            }

            return Json(new
            {
                error = true,
                message = "Sorgunuzda xeta var!Yeniden cehd edin!"
            });





           
        }

        [AllowAnonymous]

        [HttpGet]
        [Route("subscribe-confirm")]
        public IActionResult SubscibeConfirm(string token)   //token gelecey
        {
            token = token.Decrypte("");

            Match match = Regex.Match(token, @"subscribetoken-(?<id>[a-zA-Z0-9]*)(.*)-(?<timeStampt>\d{14})");
            if (match.Success)
            {
                int id = Convert.ToInt32(match.Groups["id"].Value);
                string executeTimeStamp = match.Groups["executeTimeStamp"].Value;
                var subsc = db.Subscribes.FirstOrDefault(s => s.Id == id);
                if (subsc == null)
                {
                    ViewBag.Message = Tuple.Create(true, "Token xetasi");
                    goto end;
                }

                if ((subsc.EmailConfirmed ?? false) == true)
                {
                    ViewBag.Message = Tuple.Create(true, "Artiq tesdiq edildi");
                    goto end;
                }






                subsc.EmailConfirmed = true;
                subsc.ConfirmedDate = DateTime.Now;
                db.SaveChanges();
                ViewBag.Message = Tuple.Create(false, "Abuneliyiniz tesdiq edildi");
            }
        end:
            return View();
        }
    }
}
