using Microsoft.AspNetCore.Mvc;

namespace IceCreamsShopping.Controllers
{
    public class OrderItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
