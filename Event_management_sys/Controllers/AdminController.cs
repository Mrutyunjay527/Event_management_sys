using Event_management_sys.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.AspNetCore.Identity;


namespace Event_management_sys.Controllers
{
    public class AdminController : Controller
    {
        // 🔹 INDEX
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("Login", "Account");
            }
            return View(DataStore.Events);
        }

        // 🔹 CREATE (GET)
        public IActionResult Create()
        {

            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        // 🔹 CREATE (POST)
        [HttpPost]
        public IActionResult Create(Event ev)
        {
            var roll = HttpContext.Session.GetString("Role");

            if (roll == null || roll != "Admin")

            {
                return RedirectToAction("Login", "Account");
            }

            // Auto ID
            ev.ID = DataStore.Events.Count > 0
                ? DataStore.Events.Max(e => e.ID) + 1
                : 1;

            // Set Available Seats
            ev.AvailableSeats = ev.TotalSeats;

            DataStore.Events.Add(ev);

            return RedirectToAction("Index");
        }

        // 🔹 EDIT (GET)
        public IActionResult Edit(int id)
        {
            var roll = HttpContext.Session.GetString("Role");

            if (roll == null || roll != "Admin")

            {
                return RedirectToAction("Login", "Account");
            }

            var ev = DataStore.Events.FirstOrDefault(e => e.ID == id);

            if (ev == null)
            {
                return NotFound();
            }

            return View(ev);
        }

        // 🔹 EDIT (POST)
        [HttpPost]
        public IActionResult Edit(Event ev)
        {
            var roll = HttpContext.Session.GetString("Role");

            if (roll == null || roll != "Admin")

            {
                return RedirectToAction("Login", "Account");
            }

            var existing = DataStore.Events.FirstOrDefault(e => e.ID == ev.ID);

            if (existing != null)
            {
                existing.Name = ev.Name;
                existing.Location = ev.Location;
                existing.EventDate = ev.EventDate;
                existing.Description = ev.Description;
                existing.TotalSeats = ev.TotalSeats;
                existing.TicketPrice = ev.TicketPrice;
            }

            return RedirectToAction("Index");
        }

        // 🔹 DELETE
        public IActionResult Delete(int id)
        {
            var roll = HttpContext.Session.GetString("Role");

            if (roll == null || roll != "Admin")

            {
                return RedirectToAction("Login", "Account");
            }

            var ev = DataStore.Events.FirstOrDefault(e => e.ID == id);

            if (ev != null)
            {
                DataStore.Events.Remove(ev);
            }

            return RedirectToAction("Index");
        }

        // 🔹 DETAILS
        public IActionResult Details(int id)
        {

            var roll = HttpContext.Session.GetString("Role");
            
                if (roll ==  null || roll != "Admin")
            
                 {
                    return RedirectToAction("Login", "Account");
                 }

            var ev = DataStore.Events.FirstOrDefault(e => e.ID == id);

            if (ev == null)
            {
                return NotFound();
            }

            return View(ev);
        }

       
    }
}