using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema2.Models
{
    public struct Tick
    {
        public int place;
        public int row;
    }

    public class Tickets
    {
        [Key]
        public int? Id { get; set; }
        public int? Status { get; set; }
        public int? Row { get; set; }
        public int? Place { get; set; }
        public int? Session { get; set; }

        public List<SelectListItem> ticks { get; set; }
    }
}
