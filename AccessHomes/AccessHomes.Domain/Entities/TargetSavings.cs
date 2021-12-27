using AccessHomes.Domain.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessHomes.Domain.Entities
{
    public class TargetSavings
    {
        [Key]
        [Required]
        public int Id { get; set; }

       
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public string Title { get; set; }
        public string Frequency { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal AmountPerCycle { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal TotalAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime WithDrawalDate { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal AmountSaved { get; set; }


    }
}
