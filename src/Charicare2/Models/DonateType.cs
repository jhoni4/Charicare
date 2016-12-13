using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Charicare2.Models
{
    public class DonateType
    {
        [Key]
        public int DonateTypeId { get; set; }

        public string Name { get; set; }

        //public ICollection<ClothesDonate> ClothesDonates { get; set; }
        //public ICollection<MedicalDonate> MedicalDonates { get; set; }
        //public ICollection<MoneyDonate> MoneyDonates { get; set; }
        //public ICollection<GoodsDonate> GoodsDonates { get; set; }




    }
}
