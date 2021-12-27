using AccessHomes.Domain.Entities;
using AccessHomes.Service.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessHomes.Service.DTO.Request
{
    public class CreateProp_AttachmentsRequest
    {
        public CreatePropertyRequest Properties { get; set; }
        public CreateAttachmentRequest[] Attachments { get; set; }
        public CreateAmenityRequest[] Amenities { get; set; }
    }
}
