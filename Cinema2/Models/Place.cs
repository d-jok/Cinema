using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema2.Models
{
    public class Place
    {
        [Key]
        public int ID { get; set; }
        public int Number { get; set; }
        public int Status { get; set; }
    }
}
