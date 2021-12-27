using AccessHomes.Domain.Entities;
using AccessHomes.Service.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessHomes.Service.DTO.Request
{
    public class UpdateProp_AttachmentsRequest
    {
        public UpdatePropertyRequest Properties { get; set; }
        public UpdateAttachmentRequest[] Attachments { get; set; }
        public UpdateAmenityRequest[] Amenities { get; set; }
    }
}
