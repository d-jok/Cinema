using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema2.Models
{
    public class Session
    {
        [Key]
        public int? Id { get; set; }
        public string MovieName { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string HallName { get; set; }
        public int? TicketPrice { get; set; }
        public List<SelectListItem> Films { get; set; }
    }
}
