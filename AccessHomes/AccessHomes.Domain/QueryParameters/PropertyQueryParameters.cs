using AccessHomes.Domain.Entities;
using AccessHomes.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AccessHomes.Domain.QueryParameters
{
    public class PropertyQueryParameters
    {
       public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
        public PropertyStatus? Status { get; set; }
        public PropertyType? Type { get; set; }
        public Country? Country { get; set; }
        public States? State { get; set; }
        public Cities? City { get; set; }      
        public Bedrooms? Bedrooms { set; get; }
        public Bathrooms? Bathrooms { set; get; }
        public string UserId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        //public List<AmenityQueryParameters> Amenities { get; set; }
    }
}
