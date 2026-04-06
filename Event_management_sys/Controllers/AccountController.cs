using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Event_management_sys.Data;
using Event_management_sys.Models;
using System.Linq;

namespace Event_management_sys.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        //  LOGIN PAGE
        public IActionResult Login()
        {
            return View();
        }

        //  LOGIN (POST)
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                HttpContext.Session.SetString("Role", user.Role);
                HttpContext.Session.SetString("UserID", user.ID.ToString());

                if (user.Role == "Admin")
                    return RedirectToAction("Index", "Admin");
                else
                    return RedirectToAction("Index", "User");
            }

            ViewBag.Message = "Invalid login";
            return View();
        }

        //  REGISTER PAGE
        public IActionResult Register()
        {
            return View();
        }

        //  REGISTER (POST)
        [HttpPost]
        public IActionResult Register(User user)
        {
            if (_context.Users.Any(u => u.Email == user.Email))
            {
                ViewBag.Message = "User already exists. Please login.";
                return View("Login");
            }

            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();

                return RedirectToAction("Login");
            }

            return View(user);
        }

        //  LOGOUT
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}