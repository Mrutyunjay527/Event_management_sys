using Event_management_sys.Models;
using Microsoft.AspNetCore.Mvc;
using Event_management_sys.Data;
using System.Linq;
using Microsoft.AspNetCore.Http;


namespace Event_management_sys.Controllers
{
    public class BookingController : Controller
    {
        private readonly AppDbContext _context;

        public BookingController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Create(int id)
        {
            var ev = _context.Events.FirstOrDefault(e => e.ID == id);

            if (ev == null)
            {
                return Content("Event is null");
            }
            return View(ev);
        }

        [HttpPost]
        public IActionResult Create(int eventId, int tickets)
        {
            var ev = _context.Events.FirstOrDefault(e => e.ID == eventId);

            if (ev != null && ev.AvailableSeats >= tickets)
            {
                ev.AvailableSeats -= tickets;

                var userIdString = HttpContext.Session.GetString("UserID");

                if (string.IsNullOrEmpty(userIdString))
                {
                    return RedirectToAction("Login", "Account");
                }

                int userId = int.Parse(userIdString);

                Booking b = new Booking
                {
                  
                    EventID = ev.ID,
                    UserID = userId,
                    Tickets = tickets,
                    BookingDate = DateTime.Now
                };

                _context.Bookings.Add(b);
                _context.SaveChanges();

                return RedirectToAction("Index", "User");
            }
            ViewBag.Message = "Not enough Seats";
            return View();
        }

        public IActionResult MyBookings()
        {
            int userId = int.Parse(HttpContext.Session.GetString("UserID"));

            var myBookings = _context.Bookings
                .Where(b => b.UserID == userId)
                .ToList();

            return View(myBookings);
        }
    }
  
}


