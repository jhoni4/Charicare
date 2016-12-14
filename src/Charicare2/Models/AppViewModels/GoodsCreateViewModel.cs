using Charicare2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charicare2.Models.AppViewModels
{
    public class GoodsCreateViewModel : BaseViewModel
    {
        public Donate Donate { get; set; }

        public User User { get; set; }

        public GoodsCreateViewModel() { }

        public GoodsCreateViewModel(ApplicationDbContext ctx) : base(ctx) { }
    }
}
