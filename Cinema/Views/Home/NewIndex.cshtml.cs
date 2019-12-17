using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Cinema.Helpers;
using Cinema.Models;

namespace Cinema.Views.Home
{
    public class NewIndexModel : PageModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public int? Admin { get; set; }

        public void OnGet()
        {
            //Username = HttpContext.Request.Cookies["UserName"];
            
            //Username = U;
            //Email = Request.Cookies["Email"];
            //Admin = Request.Cookies["Admin"];
            //Username = HttpContext.Session.GetString("username");
            //Email = HttpContext.Session.GetString("Email");
            //Admin = HttpContext.Session.GetInt32("Admin");
            //return Page();
        }
        public IActionResult OnPost()
        {
            HttpContext.Session.SetString("username", Username);
            return RedirectToPage("NewIndex");
        }
       /* public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("UserName");
            return RedirectToPage("Index");
        }*/
    }
}