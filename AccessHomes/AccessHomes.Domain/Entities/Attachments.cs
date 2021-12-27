using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessHomes.Domain.Entities
{
    public class Attachments
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int PropertiesId { get; set; }
        public Properties Properties { get; set; }
        public string PublicId { get; set; }
        public string ImageUrl { get; set; }
    }
}
