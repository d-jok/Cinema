using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cinema2.Models;
using Microsoft.EntityFrameworkCore;

namespace Cinema2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private KinoContext db;

        public HomeController(KinoContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Place()
        {
            return View(await db.Place.ToListAsync());
        }

        public IActionResult CreatePlace()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatePlace(BuyTicket obj)
        {
            db.Entry(obj).State = EntityState.Added;
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
