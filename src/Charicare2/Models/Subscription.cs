using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charicare2.Models
{
    public class Subscription
    {
        public Guid SubscriptionId { get; set; }
        
        public DateTime PurchaseDate { get; set; }
        
        public DateTime Expiry { get; set; }

        public int AmountInCents { get; set; }

        public string UserId { get; set; }

        public string PaymentSubscriptionId { get; set; }

        public Guid ApiKey { get; set; }
    }
}
