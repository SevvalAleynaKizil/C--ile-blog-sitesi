using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.admin.Controllers
{
    [Area("admin")]
    public class CikisController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.SignOutAsync(); // Çıkış Yaptıran method
            return Redirect("/admin");
        }
    }
}
