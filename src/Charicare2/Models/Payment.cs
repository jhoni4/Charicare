using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Charicare2.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        //[Required]
        //[StringLength(55)]
        //public string FirstName { get; set; }

        //[Required]
        //[StringLength(55)]
        //public string LastName { get; set; }

        //[Required]
        //[Display(Name = "Account Number", Description = "Please enter your card number")]
        //[Range(10000000, 99999999)]
        public int CardNumber { get; set; }

        //[Required]
        //[Range(100, 999)]
        public int CVC { get; set; }

        //[Required]
        public DateTime Expiration { get; set; }

        public ApplicationUser User { get; set; }

    }
}
