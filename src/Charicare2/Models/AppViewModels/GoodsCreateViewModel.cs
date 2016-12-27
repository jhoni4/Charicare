using Charicare2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charicare2.Models.AppViewModels
{
    public class GoodsCreateViewModel : BaseViewModel
    {
        public GoodsCreateViewModel() { }

        public GoodsCreateViewModel(ApplicationDbContext ctx) : base(ctx) { }

    }
}
