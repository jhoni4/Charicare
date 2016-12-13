using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charicare2.Data;

namespace Charicare2.Models.AppViewModels
{
    public class DonateMoneyIndexViewModel : BaseViewModel
    {
        public DonateMoneyIndexViewModel() { }

        public DonateMoneyIndexViewModel(ApplicationDbContext ctx) : base(ctx) { }
    }
}
