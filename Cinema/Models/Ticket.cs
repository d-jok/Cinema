using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }
        public int Row { get; set; }
        public int Place { get; set; }
        public int Session { get; set; }
    }
}
