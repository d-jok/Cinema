using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema2.Models
{
    public class BuyTicket
    {
        [Key]
        [Required]
        [Display(Name = "ID")]
        public string ID { get; set; }

        [Required]
        [Display(Name = "Number")]
        public string Number { get; set; }

        [Required]
        [Display(Name = "Status")]
        public bool Status { get; set; }
    }
}
