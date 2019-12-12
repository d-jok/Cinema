using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cinema2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Extensions.Configuration;

namespace Cinema2.Controllers
{
    public class HomeController : Controller
    {
        private CinemaContext db;

        public HomeController(CinemaContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        /*public IActionResult BuyTicket()
        {
            return View();
        }*/

        public IActionResult Tickets()
        {
            return View();
        }
        /*public async Task<IActionResult> Tickets()
        {
            return View(await db.Tickets.ToListAsync());
        }*/

        public ActionResult BuyTicket()
        {
            Session film = new Session();
            film.Films = PopulateFilms();
            return View(film);
        }

        [HttpPost]
        public ActionResult Index(Session film)
        {
            film.Films = PopulateFilms();
            var selectedItem = film.Films.Find(p => p.Value == film.Id.ToString());
            if (selectedItem != null)
            {
                selectedItem.Selected = true;
                ViewBag.Message = "Film: " + selectedItem.Text;
            }

            return View(film);
        }

        private static List<SelectListItem> PopulateFilms()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            
            string constr = "Server=(localdb)\\mssqllocaldb;Database=aspnet-Cinema2-01232B47-6052-46FA-A45B-8C7AAD0C2BDD;Trusted_Connection=True;MultipleActiveResultSets=true";

            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = " SELECT DISTINCT MovieName, Id ,Date FROM Session";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            items.Add(new SelectListItem
                            {
                                Text = sdr["MovieName"].ToString(),
                                Value = sdr["Id"].ToString(),
                            });
                        }
                    }
                    con.Close();
                }
            }

            return items;
        }
//----------------------------------------------------
        public ActionResult Ticket()
        {
            Tickets tic = new Tickets();
            tic.ticks = PopulatePlace();
            return View(tic);
        }

        [HttpPost]
        public ActionResult Index1(Tickets tic)
        {
            tic.ticks = PopulatePlace();
            var selectedItem = tic.ticks.Find(p => p.Value == tic.Id.ToString());
            if (selectedItem != null)
            {
                selectedItem.Selected = true;
                ViewBag.Message = "Film: " + selectedItem.Text;
            }

            return View(tic);
        }

        private static List<SelectListItem> PopulatePlace()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            string constr = "Server=(localdb)\\mssqllocaldb;Database=aspnet-Cinema2-01232B47-6052-46FA-A45B-8C7AAD0C2BDD;Trusted_Connection=True;MultipleActiveResultSets=true";

            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = " SELECT DISTINCT Id, Place, Row FROM Tickets";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            items.Add(new SelectListItem
                            {
                                Value = sdr["Place"].ToString(),
                                Text = sdr["Row"].ToString(),
                            });
                        }
                    }
                    con.Close();
                }
            }

            return items;
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
