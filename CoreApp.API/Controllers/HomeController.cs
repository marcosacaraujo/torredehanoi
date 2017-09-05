using System.Web.Mvc;

namespace CoreApp.API.Controllers
{
    public class HomeController : Controller
    {       
        public ActionResult Index()
        {
            return View();
        }
    }
}