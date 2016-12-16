using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Charicare2.Data;

namespace Charicare2.Models.AppViewModels
{
    public class DonateClothesIndexViewModel : BaseViewModel
    {
        public int UserId { get; internal set; }

        public int DonateTypeId { get; internal set; }

        public DonateClothesIndexViewModel() { }

        public DonateClothesIndexViewModel(ApplicationDbContext ctx) : base(ctx) { }
    }
}
