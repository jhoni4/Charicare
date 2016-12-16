using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Charicare2.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class User 
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(55)]
        public string FullName { get; set; }

        [Required]
        //[DataType(DataType.EmailAddress)]
        //[EmailAddress]
        public string Email { get; set; }

        [DisplayFormat(DataFormatString = "{0:###-###-####}")]
        public long Telephone { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }
    }
}
