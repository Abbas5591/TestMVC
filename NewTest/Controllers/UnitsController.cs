using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewTest.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using NewTest.Models;

namespace NewTest.Controllers
{
    public class UnitsController : Controller
    {

        private readonly ApplicationDbContext _context;

        public UnitsController(ApplicationDbContext context)
        {
            _context = context;   //_context : interact with database ._context is the instance of your database context class (ApplicationDbContext) that allows the UnitsController to interact with the database.
        }

        // GET: Units

        public IActionResult Index() 
        {
            var units = _context.Units.ToList(); //The method fetches all records from the Units table in the database.It synchronously retrieves the data and converts it into a list.
            return View(units);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            // Find the unit by its ID
            var unit = _context.Units.Find(id);
            if (unit == null)
            {
                return RedirectToAction(nameof(Index)); // If the unit does not exist, return Index
            }

            _context.Units.Remove(unit);
            _context.SaveChanges(); 

            return RedirectToAction(nameof(Index)); // Redirect to the Index page 
        }
    }
}
