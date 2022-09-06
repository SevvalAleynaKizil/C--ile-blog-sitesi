using Business.Abstract;
using DataAccsess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class YoneticilerController : Controller
    {
        private readonly IUserService service;
        public YoneticilerController(IUserService service)
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
        public IActionResult Insert(Users users)
        {
            ViewBag.Message=service.Insert(users);
            return View();

        }

        [HttpGet]
        [Route("/admin/yoneticiler/Update/{Id}")]
        public IActionResult Update(int Id)
        {
            return View(service.GetById(x => x.Id==Id));
        }
        [HttpPost]
        [Route("/admin/yoneticiler/Update/{Id}")]
        public IActionResult Update(int Id , Users users)
        {
            ViewBag.MessageId=service.Update(users);
            return View(service.GetById(x => x.Id == Id));
        }
        [HttpGet]
        [Route("/admin/yoneticiler/Delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            ViewBag.Message = service.Delete(x => x.Id == Id);
            return Redirect("/admin/yoneticiler");

        }
    }
}
