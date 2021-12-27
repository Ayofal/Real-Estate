using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessHomes.Domain.Enum
{
    public enum Amenity
    {
        [Display(Name = "Equipped Kitchen")]
        EquippedKitchen,
        Gym,
        Laundry,
        [Display(Name = "Media Room")]
        MediaRoom,
        Backyard,
        Pool,
        [Display(Name = "24hr Electricity")]
        Electricity,
        [Display(Name = "Water Supply")]
        WaterSupply,
        [Display(Name = "Air Conditioning")]
        AirConditioning,
        [Display(Name = "Washing Machine")]
        WashingMachine,
        WIFI
    }
}
