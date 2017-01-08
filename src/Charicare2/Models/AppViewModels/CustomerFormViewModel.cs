using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charicare2.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Charicare2.Models.AppViewModels
{
    public class CustomerFormViewModel : BaseViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int Telephone { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public List<SelectListItem> StateId { get; set; }

        public CustomerFormViewModel()  { }

        public CustomerFormViewModel(ApplicationDbContext ctx) : base(ctx)
        {
        }
    }
}
