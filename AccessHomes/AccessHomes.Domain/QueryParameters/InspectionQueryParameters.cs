using AccessHomes.Domain.Common;
using System;

namespace AccessHomes.Domain.QueryParameters
{
    public class InspectionQueryParameters : UrlQueryParameters
    {
        public int PropertiesId { get; set; } 
        public DateTime? StartDate { get; set; } = null;
        public DateTime? EndDate { get; set; } = null;
    }
}
