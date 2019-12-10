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
        int Id { get; set; }
        string MovieName { get; set; }
        DateTime Date { get; set; }
        DateTime Time { get; set; }
        string HallName { get; set; }
        int TicketPrice { get; set; }
    }
}
