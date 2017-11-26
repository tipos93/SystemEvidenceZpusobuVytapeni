using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZV.DTO
{
    public class Historie_stavby
    {

        public int Id_zmeny { get; set; }
        public string Typ_stavby { get; set; }
        public string Ulice { get; set; }
        public int Cislo_popisne { get; set; }
        public int Cislo_stavby_na_KU { get; set; }
        public string Nazev_KU { get; set; }
        public DateTime Datum_kolaudace { get; set; }
        public DateTime Casovy_okamzik_zmeny { get; set; }
        public int Id_vlastnika { get; set; }
        public int Id_stavby { get; set; }

        public override string ToString()
        {
            return "Id zmeny: " + Id_zmeny + " Typ stavby: " + Typ_stavby + " Ulice: " + Ulice + " Cislo popisne: " + Cislo_popisne + " Cislo stavby na KU: " + Cislo_stavby_na_KU + " Nazev KU: " + Nazev_KU + " Datum kolaudace: " + Datum_kolaudace + " Casovy okamzik zmeny: " + Casovy_okamzik_zmeny + " Id vlastnika: " + Id_vlastnika + " Id stavby: " + Id_stavby;
        }
    }
}
