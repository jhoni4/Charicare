using Charicare2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Charicare2.Models.AppViewModels
{
    public class DashboardListViewModel : BaseViewModel
    {
        public List<Donate> donates { get; set; }
        public List<User> donners { get; set; }
        public List<DonateType> DonateTypes { get; set; }
        public double TotalAmontOfMoney{ get; set; }
        public int TotalCountOfMoneyDonners { get; internal set; }
        public int TotalCountOfClothesDonners { get; internal set; }
        public int TotalCountOfGoodsDonners { get; internal set; }
        public int TotalCountOfMedicalDonners { get; internal set; }
        public int TotalCountOfClothesDonates { get; internal set; }
        public int TotalCountOfMoneyDonates { get; internal set; }
        public int TotalCountOfGoodsDonates { get; internal set; }
        public int TotalCountOfMedicalDonates { get; internal set; }

        public DashboardListViewModel() { }
        public DashboardListViewModel(ApplicationDbContext ctx) : base(ctx) { }
    }
}
