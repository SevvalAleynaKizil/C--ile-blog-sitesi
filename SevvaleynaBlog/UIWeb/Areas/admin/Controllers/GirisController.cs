using Business.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace UIWeb.Areas.admin.Controllers
{
    [Area("admin")]
    public class GirisController : Controller
    {
        private readonly IUserService service;
        public GirisController(IUserService service)
        {
            this.service = service;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string Email,string Sifre)
        {
            var BulunanUser = service.GetById(x => x.Email == Email && x.Password == Sifre);

            if (BulunanUser != null)
            {
                var Claims = new List<Claim>
                    {

                    new Claim(ClaimTypes.Name, BulunanUser.Name),
                    new Claim(ClaimTypes.Email, BulunanUser.Email),
                    new Claim("Id", BulunanUser.Id.ToString())
                    };
                var UserIdentity = new ClaimsIdentity(Claims,"YoneticiClaims");
                ClaimsPrincipal principal = new ClaimsPrincipal(UserIdentity);

                HttpContext.SignInAsync(principal);
                return Redirect("/admin/bloglar");
            }
            else
            {
            
                ViewBag.Error = "Email Adresi veya Şifreniz Hatalı";
                return View();
            }

            
        }
    }
}
