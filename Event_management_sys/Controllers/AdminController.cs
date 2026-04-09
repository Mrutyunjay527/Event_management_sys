using Event_management_sys.Models;
using Event_management_sys.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Event_management_sys.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        // INDEX
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("Login", "Account");
            }

            return View(_context.Events.ToList());
        }

        // CREATE (GET)
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        // CREATE (POST)
        [HttpPost]
        public IActionResult Create(Event ev)
        {
            var role = HttpContext.Session.GetString("Role");

            if (role == null || role != "Admin")
            {
                return RedirectToAction("Login", "Account");
            }

            
            ev.AvailableSeats = ev.TotalSeats;

            _context.Events.Add(ev);
            _context.SaveChanges(); 

            return RedirectToAction("Index");
        }

        // EDIT (GET)
        public IActionResult Edit(int id)
        {
            var role = HttpContext.Session.GetString("Role");

            if (role == null || role != "Admin")
            {
                return RedirectToAction("Login", "Account");
            }

            var ev = _context.Events.FirstOrDefault(e => e.ID == id);

            if (ev == null)
            {
                return NotFound();
            }

            return View(ev);
        }

        // EDIT (POST)
        [HttpPost]
        public IActionResult Edit(Event ev)
        {
            var role = HttpContext.Session.GetString("Role");

            if (role == null || role != "Admin")
            {
                return RedirectToAction("Login", "Account");
            }

            var existing = _context.Events.FirstOrDefault(e => e.ID == ev.ID);

            if (existing != null)
            {
                existing.Name = ev.Name;
                existing.Location = ev.Location;
                existing.EventDate = ev.EventDate;
                //existing.Description = ev.Description;
                existing.TotalSeats = ev.TotalSeats;
                existing.TicketPrice = ev.TicketPrice;

                _context.SaveChanges(); 
            }

            return RedirectToAction("Index");
        }

        // DELETE
        public IActionResult Delete(int id)
        {
            var role = HttpContext.Session.GetString("Role");

            if (role == null || role != "Admin")
            {
                return RedirectToAction("Login", "Account");
            }

            var ev = _context.Events.FirstOrDefault(e => e.ID == id);

            if (ev != null)
            {
                _context.Events.Remove(ev);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // DETAILS
        public IActionResult Details(int id)
        {
            var role = HttpContext.Session.GetString("Role");

            if (role == null || role != "Admin")
            {
                return RedirectToAction("Login", "Account");
            }

            var ev = _context.Events.FirstOrDefault(e => e.ID == id);

            if (ev == null)
            {
                return NotFound();
            }

            return View(ev);
        }
    }
}