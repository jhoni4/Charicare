using Charicare2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charicare2.ViewModels
{
    public class BaseViewModel
    {
        private ApplicationDbContext context;

        public BaseViewModel(ApplicationDbContext ctx)
        {
            context = ctx;

        }
        public BaseViewModel() { }
    }
}
