using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Charicare2.Models
{
    public class Donate
    {
        [Key]
        public int DonateId { get; set; }

        [Required]
        [StringLength(55)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Note { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Value { get; set; }

        public int CustomerId { get; set; }

        public int DonateTypeId { get; set; }

        public DateTime DateCreated { get; set; }
        public Customer danatedBy { get; internal set; }
        public DonateType donatType { get; internal set; }
    }
}
