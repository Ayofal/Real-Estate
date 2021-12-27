using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessHomes.Domain.Enum
{
    public enum Country
    {
        Afghanistan,
        Albania,
        Algeria,
        [Display(Name = "American Samoa")]
        AmericanSamoa,
        Andorra,
        Angola,
        Anguilla,
        [Display(Name = "Antigua and Barbuda")]
        AntiguaandBarbuda,
        Argentina,
        Armenia,
        Aruba,
        Australia,
        Austria,
        Azerbaijan,
        Bahamas,
        Bahrain,
        Bangladesh,
        Barbados,
        Belarus,
        Belgium,
        Belize,
        Benin,
        Bermuda,
        Bhutan,
        Bolivia,
        [Display(Name = "Bonaire, Sint Eustatius and Saba")]
        BonaireSintEustatiusandSaba,
        [Display(Name = "Bosnia and Herzegovina")]
        BosniaandHerzegovina,
        Botswana,
        Brazil,
        [Display(Name = "British Virgin Islands")]
        BritishVirginIslands,
        [Display(Name = "Brunei Darussalam")]
        BruneiDarussalam,
        Bulgaria,
        [Display(Name = "Burkina Faso")]
        BurkinaFaso,
        Burundi,
        [Display(Name = "Bosnia and Herzegovina")]
        CaboVerde,
        Cambodia,
        Cameroon,
        Canada,
        [Display(Name = "Cayman Islands")]
        CaymanIslands,
        [Display(Name = "Central African Republic")]
        CentralAfricanRepublic,
        Chad,
        [Display(Name = "Channel Islands")]
        ChannelIslands,
        Chile,
        China,
        [Display(Name = "China, Hong Kong SAR")]
        ChinaHongKong,
        [Display(Name = "China, Macao SAR")]
        ChinaMacao,
        Colombia,
        Comoros,
        Congo,
        [Display(Name = "Cook Islands")]
        CookIslands,
        [Display(Name = "Costa Rica")]
        CostaRica,
        Croatia,
        Cuba,
        Curaçao,
        Cyprus,
        Czechia,
        [Display(Name = "Côte d'Ivoire")]
        CôtedIvoire,
        [Display(Name = "Democratic People's Republic of Korea")]
        Korea,
        [Display(Name = "Democratic Republic of the Congo")]
        DemocraticRepublicofCongo,
        Denmark,
        Djibouti,
        Dominica,
        [Display(Name = "Dominican Republic")]
        DominicanRepublic,
        Ecuador,
        Egypt,
        [Display(Name = "El Salvador")]
        ElSalvador,
        [Display(Name = "Equatorial Guinea")]
        EquatorialGuinea,
        Eritrea,
        Estonia,
        Eswatini,
        Ethiopia,
        [Display(Name = "Falkland Islands(Malvinas)")]
        FalklandIslands,
        [Display(Name = "Faroe Islands")]
        FaroeIslands,
        Fiji,
        Finland,
        France,
        [Display(Name = "French Guinea")]
        FrenchGuiana,
        [Display(Name = "French Polynesia")]
        FrenchPolynesia,
        Gabon,
        Gambia,
        Georgia,
        Germany,
        Ghana,
        Gibraltar,
        Greece,
        Greenland,
        Grenada,
        Guadeloupe,
        Guam,
        Guatemala,
        Guinea,
        [Display(Name = "Guinea-Bissau")]
        GuineaBissau,
        Guyana,
        Haiti,
        [Display(Name = "Holy See")]
        HolySee,
        Honduras,
        Hungary,
        Iceland,
        India,
        Indonesia,
        [Display(Name = "Iran(Islamic Republic of)")]
        Iran,
        Iraq,
        Ireland,
        [Display(Name = "Isle of Man")]
        IsleofMan,
        Israel,
        Italy,
        Jamaica,
        Japan,
        Jordan,
        Kazakhstan,
        Kenya,
        Kiribati,
        Kuwait,
        Kyrgyzstan,
        [Display(Name = "Lao People's Democratic Republic")]
        Lao,
        Latvia,
        Lebanon,
        Lesotho,
        Liberia,
        Libya,
        Liechtenstein,
        Lithuania,
        Luxembourg,
        Madagascar,
        Malawi,
        Malaysia,
        Maldives,
        Mali,
        Malta,
        [Display(Name = "Marshall Islands")]
        MarshallIslands,
        Martinique,
        Mauritania,
        Mauritius,
        Mayotte,
        Mexico,
        [Display(Name = "Micronesia(Federated States of)")]
        Micronesia,
        Monaco,
        Mongolia,
        Montenegro,
        Montserrat,
        Morocco,
        Mozambique,
        Myanmar,
        Namibia,
        Nauru,
        Nepal,
        Netherlands,
        [Display(Name = "New Caledonia")]
        NewCaledonia,
        [Display(Name = "New Zealand")]
        NewZealand,
        Nicaragua,
        Niger,
        Nigeria,
        Niue,
        [Display(Name = "Northern Mariana Islands")]
        NorthernMarianaIslands,
        Norway,
        Oman,
        Pakistan,
        Palau,
        Panama,
        [Display(Name = "Papua New Guinea")]
        PapuaNewGuinea,
        Paraguay,
        Peru,
        Philippines,
        Poland,
        Portugal,
        [Display(Name = "Puerto Rico")]
        PuertoRico,
        Qatar,
        [Display(Name = "Republic of Korea")]
        RepublicofKorea,
        [Display(Name = "Republic of Moldova")]
        RepublicofMoldova,
        Romania,
        [Display(Name = "Russian Federation")]
        RussianFederation,
        Rwanda,
        Réunion,
        [Display(Name = "Saint Helena")]
        SaintHelena,
        [Display(Name = "Saint Kitts and Nevis")]
        SaintKittsandNevis,
        [Display(Name = "Saint Lucia")]
        SaintLucia,
        [Display(Name = "SaintPierreandMiquelon")]
        SaintPierreandMiquelon,
        [Display(Name = "Saint Vincent and the Grenadines")]
        SaintVincentandtheGrenadines,
        Samoa,
        [Display(Name = "San Marino")]
        SanMarino,
        [Display(Name = "Sao Tome and Principe")]
        SaoTomeandPrincipe,
        [Display(Name = "Saudi Arabia")]
        SaudiArabia,
        Senegal,
        Serbia,
        Seychelles,
        [Display(Name = "Sierra Leone")]
        SierraLeone,
        Singapore,
        [Display(Name = "Sint Maarten(Dutch part)")]
        SintMaarten,
        Slovakia,
        Slovenia,
        [Display(Name = "Solomon Islands")]
        SolomonIslands,
        Somalia,
        [Display(Name = "South Africa")]
        SouthAfrica,
        [Display(Name = "South Sudan")]
        SouthSudan,
        Spain,
        [Display(Name = "Sri Lanka")]
        SriLanka,
        [Display(Name = "State of Palestine")]
        StateofPalestine,
        Sudan,
        Suriname,
        Sweden,
        Switzerland,
        [Display(Name = "Syrian Arab Republic")]
        SyrianArabRepublic,
        Tajikistan,
        Thailand,
        [Display(Name = "The former Yugoslav Republic of Macedonia")]
        Macedonia,
        [Display(Name = "Timor-Leste")]
        TimorLeste,
        Togo,
        Tokelau,
        Tonga,
        [Display(Name = "Trinidad and Tobago")]
        TrinidadandTobago,
        Tunisia,
        Turkey,
        Turkmenistan,
        [Display(Name = "Turks and Caicos Islands")]
        TurksandCaicosIslands,
        Tuvalu,
        Uganda,
        Ukraine,
        [Display(Name = "United Arab Emirates")]
        UnitedArabEmirates,
        [Display(Name = "United Kingdom")]
        UnitedKingdom,
        [Display(Name = "United Republic of Tanzania")]
        UnitedRepublicofTanzania,
        [Display(Name = "United States Virgin Islands")]
        UnitedStatesVirginIslands,
        [Display(Name = "United States of America")]
        UnitedStatesofAmerica,
        Uruguay,
        Uzbekistan,
        Vanuatu,
        [Display(Name = "Venezuela(Bolivarian Republic of)")]
        Venezuela,
        [Display(Name = "Viet Nam")]
        VietNam,
        [Display(Name = "Wallis and Futuna Islands")]
        WallisandFutunaIslands,
        [Display(Name = "Western Sahara")]
        WesternSahara,
        Yemen,
        Zambia,
        Zimbabwe
    }
}
