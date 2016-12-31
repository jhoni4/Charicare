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
        public Customer Customer { get; set; }

        public Donate Donate { get; set; }

        public string LastPerson { get; set; }
        
        public string Donator { get; set; }

        public int CustomerId { get; set; }

        public int DonateTypeId { get; set; }

        public BaseViewModel() { }

        public BaseViewModel(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        private ApplicationDbContext context;
    }
}
