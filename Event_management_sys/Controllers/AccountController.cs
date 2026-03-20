using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Event_management_sys.Controllers
{
    public class AccountController : Controller
    {
        //login page
        public IActionResult Login()
        {
            return View("Login");
        }

        //Post login
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (email == "admin@gmail.com" && password == "admin")
            {
                HttpContext.Session.SetString("Role", "Admin");
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                HttpContext.Session.SetString("Role", "User");
                return RedirectToAction("Dashboard", "User");
            }
        }
        // logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
