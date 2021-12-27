﻿using AccessHomes.Domain.Entities;
using AccessHomes.Service.DTO.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessHomes.Service.DTO.Request
{
    public class CreateAttachmentRequest
    {
        //[Key]
        //[Required]
        //public int Id { get; set; }
        //public Properties Properties { get; set; }
        //public int PropertiesId { get; set; }
        public string ImageUrl { get; set; }
        public string PublicId { get; set; }
    }
}
