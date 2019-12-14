using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Cinema.Helpers;

namespace Cinema.Views.Home
{
    public class NewIndexModel : PageModel
    {
        public string Username { get; set; }
        public string Email { get; set; }

        public void OnGet()
        {
            //Username = Request.Cookies["MyCookie"];
            Username = HttpContext.Session.GetString("username");
            Email = HttpContext.Session.GetString("Email");
        }

        public IActionResult OnGetLogout()
        {
            //HttpContext.Session.Remove("username");
            return RedirectToPage("Index");
        }
    }
}