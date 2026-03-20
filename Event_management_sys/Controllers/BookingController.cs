using Microsoft.AspNetCore.Mvc;

namespace Event_management_sys.Controllers
{
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
