using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using AccessHomes.Domain.Auth;
using AccessHomes.Domain.Entities;
using AccessHomes.Domain.Enum;

namespace AccessHomes.Service.DTO.Request
{
    public class CreatePropertyRequest
    {
        //[Key]
        //[Required]
        //public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public PropertyStatus? Status { get; set; }
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
        public RentDuration? Duration { get; set; }
        public ParkingLot? ParkingLot { get; set; }
        public List<CreateAmenityRequest> Amenities { get; set; }


    }
}
