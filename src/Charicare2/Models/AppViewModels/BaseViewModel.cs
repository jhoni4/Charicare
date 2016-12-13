using Charicare2.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charicare2.Models.AppViewModels
{
    public class BaseViewModel
    {
        public User User { get; set; }

        public BaseViewModel(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public BaseViewModel() { }

        private ApplicationDbContext context;
    }
}
