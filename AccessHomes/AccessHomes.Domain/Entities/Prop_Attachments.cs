using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessHomes.Domain.Entities
{
    public class Prop_Attachments
    {
        public Properties Properties { get; set; }
        public Attachments[] Attachments { get; set; }
        public Amenities[] Amenities { get; set; }
    }
}
