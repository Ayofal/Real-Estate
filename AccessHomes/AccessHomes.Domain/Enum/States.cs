using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessHomes.Domain.Enum
{
    public enum States
    {
        Abia,
        Adamawa,
        [Display(Name = "Akwa Ibom")]
        AkwaIbom,
        Anambra,
        Bauchi,
        Bayelsa,
        Benue,
        Bornu,
        [Display(Name = "Cross River")]
        CrossRiver,
        Delta,
        Ebonyi,
        Edo,
        Ekiti,
        Enugu,
        Gombe,
        Imo,
        Jigawa,
        Kaduna,
        Kano,
        Katsina,
        Kebbi,
        Kogi,
        Kwara,
        Lagos,
        Nasarawa,
        Niger,
        Ogun,
        Ondo,
        Osun,
        Oyo,
        Plateau,
        Rivers,
        Sokoto,
        Taraba,
        Yobe,
        Zamfara
    }
}
