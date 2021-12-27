using AccessHomes.Domain.Auth;
using AccessHomes.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessHomes.Domain.Entities
{
    public class Properties
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal? Price { get; set; }
        public PropertyStatus? Status  { get; set; }
        public PropertyType? Type { get; set; }
        public double? Size { get; set; }
        public string Address { get; set; }
        public Country? Country { get; set; }
        public States? State { get; set; }
        public Cities? City { get; set; }
        public string Neighbourhood { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public string Zip { get; set; }
        public Bedrooms? Bedrooms { set; get; }
        public Bathrooms? Bathrooms { set; get; }
        public bool? Availability { get; set; }
        public DateTime? DateAdded { get; set; } = DateTime.Now;
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public RentDuration? Duration { get; set; }
        public ParkingLot? ParkingLot { get; set; }
        public List<Attachments> Attachments { get; set; }
        public List<Amenities> Amenities { get; set; }
        public bool? IsEnabled { get; set; } = false;

    }
}
