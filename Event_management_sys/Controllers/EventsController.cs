using Event_management_sys.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Event_management_sys.Controllers
{
    public class EventsController : Controller
    {
        private static List<Event> events = new List<Event>();
        public IActionResult Index()
        {
            return View(events);
        }


/* to create */
        public IActionResult Create()
        {
            return View();
        }

/* editing */
        public IActionResult Edit(int id)
        {
            var ev = events.FirstOrDefault(e => e.ID == id);

            if (ev == null)
            {
                return NotFound();
            }
            return View(ev);
        }

/* creating in http */
        [HttpPost]
        public IActionResult Create(Event ev)
        {
            ev.ID = events.Count + 1;
            events.Add(ev);
            return RedirectToAction("Index");
        }

/* editing in http */

        [HttpPost]

        public IActionResult Edit(Event ev)
        {
            var existing = events.FirstOrDefault(e => e.ID == ev.ID);
            if (existing != null)
            {
                existing.Name = ev.Name;
                existing.Location = ev.Location;
                existing.EventDate = ev.EventDate;  
                existing.Description = ev.Description;
                existing.TotalSeats = ev.TotalSeats;
                existing.TicketPrice = ev.TicketPrice;            }
            return RedirectToAction("Index");
        }

/* to delete */
        public IActionResult Delete(int id)
        {
            var ev = events.FirstOrDefault(e => e.ID == id);
            if (ev != null)
            {
                events.Remove(ev);
            }
            return RedirectToAction("Index");
        }
    }
}
