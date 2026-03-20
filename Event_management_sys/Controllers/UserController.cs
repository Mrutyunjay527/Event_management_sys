using Event_management_sys.Models;
using Microsoft.AspNetCore.Mvc;

namespace Event_management_sys.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Dashboard()
        {
            return View(DataStore.Events);
        }

        public IActionResult Details(int id)
        { 
           var ev = DataStore.Events.FirstOrDefault(equals => equals.ID == id);
            return View(ev);
        }
    }
}
