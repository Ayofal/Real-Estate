using AccessHomes.Domain.Auth;
using AccessHomes.Domain.Entities;
using AccessHomes.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessHomes.Service.DTO.Response
{
    public class PropertyQueryResponse
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public double Size { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Neighbourhood { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Zip { get; set; }
        public string Bedrooms { set; get; }
        public string Bathrooms { set; get; }
        public bool Availability { get; set; }
        public DateTime DateAdded { get; set; }
        public UserQueryResponse User { get; set; }
        public string UserId { get; set; }
        public string Duration { get; set; }
        public string ParkingLot { get; set; }
        public List<AttachmentQueryResponse> Attachments { get; set; }
        public List<AmenityQueryResponse> Amenities { get; set; }
        public bool? IsEnabled { get; set; }

    }
}
