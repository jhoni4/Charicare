using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charicare2.Models
{
    public class Customer
    {
        public int CustomerId {get; set;}

        public string FirstName { get; set; }

        public string Lastname { get; set; }

        public int ChargeAmount { get; set; }
    }
}
