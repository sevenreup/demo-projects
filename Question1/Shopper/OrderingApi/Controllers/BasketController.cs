using Microsoft.AspNetCore.Mvc;

namespace OrderingApi.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
