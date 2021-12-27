using AccessHomes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessHomes.Service.DTO.Response
{
    public class Prop_AttachmentsQueryResponse
    {
        public PropertyQueryResponse Properties { get; set; }
        public AttachmentQueryResponse[] Attachments { get; set; }
        public AmenityQueryResponse[] Amenities { get; set; }
    }
}
