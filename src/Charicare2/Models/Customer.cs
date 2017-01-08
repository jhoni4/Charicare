using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Charicare2.Models
{
    // Add profile data for application Customers by adding properties to the ApplicationCustomer class
    public class Customer 
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(55)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(55)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong mobile")]
        [DisplayFormat(DataFormatString = "{0:###-###-####}")]
        public long Telephone { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

    }
}

