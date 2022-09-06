
using Business.Abstract;
using DataAccsess.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace UIWeb.Controllers
{
    public class JSONController : Controller
    {
        //Ajax methodları IActionResault ile iletişime geçemez
        //Ajax Methodları JsonResult ile iletişime geçerler
        private readonly IInteractionService service; 
        
        public JSONController(IInteractionService service)
        {
            this.service = service;
        }
        [Route("/bloglar/EtkilesimGetir/{Id}")]
        public PartialViewResult EtkilesimGetir(int Id)
        {
            //Beğendi etkileşimlerini getiriyor
            ViewBag.Olumlu = service.GetAll().Where(x => x.BlogsId == Id && x.Status == true).ToList();

            //Beğenmedi etkileşimlerini getiriyor
            ViewBag.Olumsuz = service.GetAll().Where(x => x.BlogsId == Id && x.Status == false).ToList();

            ViewBag.BlogId = Id;
            return PartialView("/Views/Shared/PartialEtkilesim.cshtml");
        }
        public JsonResult EtkilesimYonetimi(int BlogId , bool Status)
        {
            string ipAdresi = Dns.GetHostAddresses(Dns.GetHostName())[1].ToString();
            var Dogrula = service.GetById(x => x.IpAddress == ipAdresi && x.BlogsId == BlogId);
            if (Dogrula==null)
            {
                Interaction i = new Interaction();
                i.IpAddress = ipAdresi;
                i.Status = Status;
                i.BlogsId= BlogId;
                service.Insert(i);
            }
            else
            {
                //Daha önce Oylama True ise , ikinci Oylaması FALSE ise False çekecek
                if (Dogrula.Status==true && (Status==false))
                {
                    Dogrula.Status = false;
                    service.Update(Dogrula);
                }
                //Daha önceki Oylama False ise , ikici oylamasını true ya çevirirse true ya çekilir
                else if (Dogrula.Status == false && (Status == true))
                {
                    Dogrula.Status = true;
                    service.Update(Dogrula);
                }
            }
            return Json("");
        }
    }
}
