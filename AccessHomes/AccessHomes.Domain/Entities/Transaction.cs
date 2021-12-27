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
    public class Transaction
    {
        [Key]
        [Required]
        public int Id { get; set; }

        
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int PropertiesId { get; set; }
        public Properties Properties { get; set; }
        public bool IsPaid { get; set; }
        public bool IsReserved { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
