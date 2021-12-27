using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessHomes.Domain.Enum
{
    public enum PropertyType
    {
        [Display(Name = "Residential (General)")]
        General,
        [Display(Name = "Residential (Student Package)")]
        StudentPackage,
        Commercial,
        Land
    }
}
