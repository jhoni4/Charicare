using Charicare2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charicare2.Models.AppViewModels
{
    public class DonateTypeListViewModel : BaseViewModel
    {
        public string Name { get; set; }

        public List<DonateType> DonateTypes { get; set; }

        public DonateType DonateType { get; set; }

        public DonateTypeListViewModel() { }

        public DonateTypeListViewModel(ApplicationDbContext ctx) : base(ctx) { }
    }
}
