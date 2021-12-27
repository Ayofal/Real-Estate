using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessHomes.Service.DTO.Request
{
    public class AddInspectionRequest
    {
        [Required]
        public int PropertiesId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Comments { get; set; }
    }
}
