using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charicare2.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Charicare2.Models.AppViewModels
{
    public class UserFormViewModel : BaseViewModel
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public int Telephone { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public List<SelectListItem> StateId { get; set; }

        public UserFormViewModel()  { }

        public UserFormViewModel(ApplicationDbContext ctx) : base(ctx)
        {
        }
    }
}
