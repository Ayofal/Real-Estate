
using System.ComponentModel.DataAnnotations;

namespace AccessHomes.Service.DTO.Request
{
    public class AddRatingRequest
    {
        [Required]
        public int PropertiesId { get; set; }
        [Required]
        public int Rating { get; set; }
        public string Comment { get; set; }
    }
}
