using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessHomes.Domain.Entities
{
    public class CumulativeRating
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int PropertiesId { get; set; }
        public double AverageRating { get; set; }
        public int Count { get; set; }
    }
}
