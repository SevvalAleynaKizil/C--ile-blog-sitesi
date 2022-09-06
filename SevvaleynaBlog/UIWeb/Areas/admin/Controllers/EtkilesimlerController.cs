using Business.Abstract;
using Business.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace UIWeb.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class EtkilesimlerController : Controller
    {
        private readonly IInteractionService service;

        public EtkilesimlerController(IInteractionService service)
        {
            this.service = service;
        }
        [HttpGet]
        [Route("/admin/etkilesim/{Id}")]
        public IActionResult Index(int Id)
        {
            return View(service.GetAll().Where(x=>x.BlogsId==Id));

        }
        [HttpGet]
        [Route("/admin/etkilesim/Delete/{Id}")]

        public IActionResult Delete (int Id)
        {
            service.Delete(x => x.Id == Id);
            return Redirect("/admin/bloglar");
        }

    }
}
