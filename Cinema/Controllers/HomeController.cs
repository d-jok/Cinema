using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cinema.Models;
using Microsoft.AspNetCore.Http;

namespace Cinema.Controllers
{
    public class HomeController : Controller
    {
        private Context db;
        public string UserName { get; set; }

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
            var date = db.User.ToList();

            foreach(var item in date)
            {
                if (obj.Email == item.Email || obj.BankCard == item.BankCard)
                    return RedirectToAction("Registration");
            }

            if (obj.Email == "" || obj.Name == "" || obj.Password == "" || obj.BankCard == 0)
                return RedirectToAction("Registration");

            db.Entry(obj).State = EntityState.Added;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(User obj)
        {
            var date = db.User.ToList();
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(30)
            };

            foreach (var item in date)
            {
                if (obj.Email == item.Email && obj.Password == item.Password)
                {
                    Response.Cookies.Append("UserName", item.Name);
                    Response.Cookies.Append("Email", item.Email);
                    Response.Cookies.Append("Admin", item.Admin.ToString());
                

                    //HttpContext.Session.SetString("username", item.Name);
                    //HttpContext.Session.SetString("Email", item.Email);
                    //HttpContext.Session.SetInt32("Admin", item.Admin);
                    var U = Request.Cookies["UserName"].ToString();
                    //var U = HttpContext.Session.GetString("username");
                    if (U.Length != 0)
                        return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Login");
            /*db.Entry(obj).State = EntityState.Added;
            db.SaveChanges();

            return RedirectToAction("Index");*/
        }

        public IActionResult NewIndex()
        {
            return View();
        }

        //Sessions
        public async Task<IActionResult> Sessions()
        {
            return View(await db.Session.ToListAsync());
        }

        [ActionName("BuyTicket")]
        public async Task<IActionResult> BuyTicket(int? id)
        {
            if (id != null)
            {
                Session obj = await db.Session.FirstOrDefaultAsync(p => p.Id == id);
                if (obj != null)
                    return View(obj);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> BuyTicket(Ticket obj)
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

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
