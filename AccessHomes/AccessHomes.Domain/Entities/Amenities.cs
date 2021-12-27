using AccessHomes.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessHomes.Domain.Entities
{
    public class Amenities
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int PropertiesId { get; set; }
        public Properties Properties { get; set; }
        public Amenity Amenity { get; set; }
        public int Number { get; set; }
    }
}
