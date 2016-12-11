using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Charicare2.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Subscriptions = new List<Subscription>();
        }
        public bool IsActive { get; set; }

        public virtual ICollection<Subscription> Subscriptions { get; set; }

        public string CustomerIdentifier { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public int ZipCode { get; set; }

        public string EmailAddress { get; set; }

        public string CompanyName { get; set; }

        //public  SaveSubscription() {  }
    }
}
