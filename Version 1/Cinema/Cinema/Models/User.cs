using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models
{
    public class User
    {
        public int Id { get; set; }
      //  [Required(ErrorMessage = "Please provide username", AllowEmptyStrings = false)]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
     //   [Required(ErrorMessage = "Please provide Password", AllowEmptyStrings = false)]
        public string Password { get; set; }
        
    }
}
