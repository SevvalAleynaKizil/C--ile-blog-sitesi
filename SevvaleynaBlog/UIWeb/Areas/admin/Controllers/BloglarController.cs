using Business.Abstract;
using DataAccsess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;

namespace UIWeb.Areas.admin.Controllers
{
    [Area("admin"),Authorize]
    public class BloglarController : Controller
    {
        private readonly IBlogService service;

        public BloglarController(IBlogService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View(service.GetAll());
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Insert(Blogs blog, IFormFile file)
        {
            blog.UserId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "Id").Value.ToString());
            blog.BlogDateTime=DateTime.Now;

            if (file != null)
            {
                string DosyaUzanti = Path.GetExtension(file.FileName);//acb.jpg
                string[] IzinverilenUzantilar = { ".jpg", ".jpeg", ".png" };
                if (IzinverilenUzantilar.Contains(DosyaUzanti)) 
                {
                    string RastgeleAd = Guid.NewGuid() + DosyaUzanti;
                    string KayitYeri = Path.Combine(Directory.GetCurrentDirectory() ,$"wwwroot/images/{RastgeleAd}");
                    //C:\Users\emiry\source\repos\Blog_Sitesi + wwwroot/images/DosyaAdi.jpg


                    using (var Stream = new FileStream(KayitYeri, FileMode.Create))
                    {
                        file.CopyTo(Stream);

                    }

                    blog.Images = RastgeleAd;
                    ViewBag.Message = service.Insert(blog);

                }
                else
                {
                    ViewBag.Error = "Lütfen .jpg , .jpeg , veya .png uzantılı dosya seçiniz";
                }
            }
            else
            {
                ViewBag.Error = "Lütfen Dosya Seçiniz";
            }
            return View();

        }
        [HttpGet]
        [Route("/admin/bloglar/Update/{Id}")]


        public IActionResult Update(int Id)
        {
            return View(service.GetById(x=>x.Id==Id));
        }
        [HttpPost]
        [Route("/admin/bloglar/Update/{Id}")]


        public IActionResult Update(int Id,Blogs blog , IFormFile file)
        {
            blog.UserId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == "Id").Value.ToString());
            blog.BlogDateTime = DateTime.Now;
            if (file != null)
            {
                string DosyaUzanti= Path.GetExtension(file.FileName);
                string[] IzinVerilenUzantilar = { ".jpg", ".jpeg", ".png" };
                if (IzinVerilenUzantilar.Contains(DosyaUzanti))
                {
                    string RastgeleAd = Guid.NewGuid() + DosyaUzanti;
                    string KayitYeri = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{RastgeleAd}");

                    using (var Stream = new FileStream(KayitYeri, FileMode.Create))
                    {
                        file.CopyTo(Stream);
                    }
                    blog.Images = RastgeleAd;
                    ViewBag.Message=service.Update(blog);
                }
                else
                {
                    ViewBag.Error = ("Lütfen jpg , jpeg veya png uazntılı dosya seçiniz");
                }

            }
            else
            {
                ViewBag.Mesage = service.Update(blog);
            }

            return View(service.GetById(x=>x.Id==Id));
        }
        [HttpGet]
        [Route("/admin/Bloglar/Delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            service.Delete(x=>x.Id == Id);
            return Redirect("/admin/bloglar");

        }


    }
}
