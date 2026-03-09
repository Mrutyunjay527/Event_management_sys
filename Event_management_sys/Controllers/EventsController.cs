using Event_management_sys.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Event_management_sys.Controllers
{
    public class EventsController : Controller
    {
        private static List<Event> events = new List<Event>();
        public IActionResult Index()
        {
            return View(events);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Event ev)
        {
            ev.ID = events.Count + 1;
            events.Add(ev);
            return RedirectToAction("Index");
        }
    }
}
