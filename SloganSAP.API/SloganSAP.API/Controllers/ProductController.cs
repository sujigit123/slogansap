using Microsoft.AspNetCore.Mvc;

namespace SloganSAP.API.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
