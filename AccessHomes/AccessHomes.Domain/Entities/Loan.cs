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
    public class Loan
    {
        [Key]
        [Required]
        public int Id { get; set; }      
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int PropertiesId { get; set; }
        public Properties Properties { get; set; }
        public double Principal { get; set; }
        public double Interest { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal ServiceFee { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Fee { get; set; }
        public DateTime LoanDate { get; set; }
    }
}
