using AccessHomes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessHomes.Service.DTO.Response
{
    public class AttachmentQueryResponse
    {
        
        public int Id { get; set; }
        //public PropertyQueryResponse Properties { get; set; }
        //public int PropertiesId { get; set; }
        public string ImageUrl { get; set; }
    }
}
