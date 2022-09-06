using Business.Abstract;
using DataAccsess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace UIWeb.Areas.admin.Controllers
{
    [Area("admin"),Authorize]
    public class YorumlarController : Controller
    {
        private readonly ICommentService service;


        public YorumlarController(ICommentService service)
        {
            this.service = service;
        }
        [HttpGet]
        [Route("/admin/Yorumlar/{BlogId}")]

        public IActionResult Index(int BlogId)
        {
            return View(service.GetAll().Where(x=>x.BlogsId==BlogId));
        }
        [HttpGet]
        [Route("/admin/Yorumlar/Update/{Id}")]
        public IActionResult Update(int Id)
        {
            return View(service.GetById(x=>x.Id==Id));
        }
        [HttpPost]
        [Route("/admin/Yorumlar/Update/{Id}")]
        public IActionResult Update(int Id , Comments comments)
        {
            ViewBag.Message=service.Update(comments);
            return View(service.GetById(x => x.Id == Id));
        }
        [HttpGet]
        [Route("/admin/Yorumlar/Delete/{Id}")]

        public IActionResult Delete(int Id)
        {
            service.Delete(x => x.Id == Id);
        return Redirect("/admin/Bloglar");
        }
    }
}
