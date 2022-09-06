
using Business.Abstract;
using DataAccsess.Models;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogService service;
        private readonly ICommentService comment;
        private readonly IInteractionService interaction;
        public HomeController(IBlogService service , ICommentService comment, IInteractionService interaction)
        {
            this.service = service;
            this.comment = comment;
            this.interaction = interaction;
        }



        public IActionResult Index()
        {
            return View(service.GetAll());
        }
        [Route("/blog/Details/{Id}")]
        public IActionResult Details(int Id)
        {
            ViewBag.Yorumlar = comment.GetAll().Where(x => x.BlogsId == Id).ToList();
            ViewBag.Etkilesimler = interaction.GetAll().Where(x => x.BlogsId == Id).ToList();
            ViewBag.Olumlu = interaction.GetAll().Where(x => x.BlogsId == Id && x.Status == true).ToList();

            //Beğenmedi etkileşimlerini getiriyor
            ViewBag.Olumsuz = interaction.GetAll().Where(x => x.BlogsId == Id && x.Status == false).ToList();
            return View(service.GetById(x=>x.Id==Id));

        }
        [HttpPost]
        [Route("/blog/Details/{Id}")]
        public IActionResult Details(int Id, Comments comments)
        {
            comments.BlogsId = Id;
            comments.CommentDate = DateTime.Now;
            comments.Status = false;
            comments.Id = 0;
            ViewBag.Message = comment.Insert(comments);

            ViewBag.Yorumlar = comment.GetAll().Where(x => x.BlogsId == Id).ToList();

            

            return View(service.GetById(x => x.Id == Id));

         

        }
    }
}
