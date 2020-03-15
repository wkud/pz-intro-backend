using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Core.Models
{
    public class User
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        
        [StringLength(9, ErrorMessage = "Not a valid phone number!")]
        [RegularExpression("[1-9]")]
        public string PhoneNumber { get; set; }

    }
}
