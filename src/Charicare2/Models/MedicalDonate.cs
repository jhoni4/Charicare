using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Charicare2.Models
{
    public class MedicalDonate
    {
        [Key]
        public int MedicalDonateId { get; set; }

        [Required]
        [StringLength(55)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Note { get; set; }

        public int DonateTypeId { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

    }
}
