using AccessHomes.Domain.Common;
using System;

namespace AccessHomes.Domain.QueryParameters
{
    public class RatingQueryParameters : UrlQueryParameters
    {
        public int PropertiesId { get; set; }
    }
}
