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
        public IEnumerable<MedicalDonate> Medicals { get; set; }
        public List<DonateType> DonateTypes { get; set; }
        public User User { get; set; }
        public Donate Donate { get; set; }
        public double TotalAmontOfMoney{ get; set; }
        public DashboardListViewModel() { }
        public DashboardListViewModel(ApplicationDbContext ctx) : base(ctx) { }
    }
}
