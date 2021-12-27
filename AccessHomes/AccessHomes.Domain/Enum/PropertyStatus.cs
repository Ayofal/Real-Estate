using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessHomes.Domain.Enum
{
    public enum PropertyStatus
    {
        Rent,
        Sale,
        [Display(Name = "Rent To Own")]
        RentToOwn
    }
}
