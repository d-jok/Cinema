using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cinema.Models;

namespace Cinema.Controllers
{
    public class HomeController : Controller
    {
        private Context db;

        public HomeController(Context context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(User obj)
        {
            db.Entry(obj).State = EntityState.Added;
            //db.SaveChanges();

            return RedirectToAction("Succeed");
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(User obj)
        {
            db.Entry(obj).State = EntityState.Added;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        //------------------------------------------------------------------------------
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
        public IActionResult Succeed()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
