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
        public int UserId { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public int Telephone { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }
    }
}
