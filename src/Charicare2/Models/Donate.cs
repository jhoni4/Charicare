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

        public string Name { get; set; }

        [StringLength(255)]
        public string Note { get; set; }

        public double Value { get; set; }

        public int UserId { get; set; }

        public int DonateTypeId { get; set; }

    }
}
