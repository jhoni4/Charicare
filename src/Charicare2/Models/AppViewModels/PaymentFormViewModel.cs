using Charicare2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charicare2.Models;
using Stripe;

namespace Charicare2.ViewModels
{
    public class PaymentFormViewModel : BaseViewModel
    {
        internal string stripeToken;

        public Payment Payment { get; set; }

        public Subscription Subscription { get; set; }

        public List<Subscription> Subscriptions { get; set; }

        public PaymentFormViewModel() { }

        public PaymentFormViewModel(ApplicationDbContext ctx) : base(ctx) { }
    }
}


