﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public UserFormViewModel()  { }
    }
}
