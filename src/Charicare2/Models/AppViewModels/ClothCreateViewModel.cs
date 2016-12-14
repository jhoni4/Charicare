using Charicare2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charicare2.Models.AppViewModels
{
    public class ClothCreateViewModel : BaseViewModel
    {
        public int DonateTypeId { get; set; }

        public int UserId { get; set; }

        public ClothCreateViewModel() { }

        public ClothCreateViewModel(ApplicationDbContext ctx) : base(ctx) { }

    }
}
