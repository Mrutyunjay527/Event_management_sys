using Event_management_sys.Models;
using Microsoft.AspNetCore.Mvc;
using Event_management_sys.Data;
using System.Linq;

namespace Event_management_sys.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Events.ToList());
        }

        public IActionResult Details(int id)
        { 
           var ev = _context.Events.FirstOrDefault(equals => equals.ID == id);
            return View(ev);
        }
    }
}
