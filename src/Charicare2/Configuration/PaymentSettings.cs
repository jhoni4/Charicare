using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charicare2.Configuration
{
    public class PaymentSettings
    {
        public string StripePrivateKey { get; set; }

        public string StripePublicKey { get; set; }
    }
}
