using AccessHomes.Domain.Entities;
using AccessHomes.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessHomes.Service.DTO.Response
{
    public class AmenityQueryResponse
    {
       
        public int Id { get; set; }
        //public PropertyQueryResponse Properties { get; set; }
        //public int PropertiesId { get; set; }
        public string Amenity { get; set; }
        public int Number { get; set; }
    }
}
