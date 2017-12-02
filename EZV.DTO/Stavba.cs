using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZV.DTO
{
    public class Stavba
    {

        public int Id_stavby { get; set; }
        public string Typ_stavby { get; set; }
        public string Ulice { get; set; }
        public int Cislo_popisne { get; set; }
        public int Cislo_stavby_na_KU { get; set; }
        public string Nazev_KU { get; set; }
        public DateTime Datum_kolaudace { get; set; }

        public override string ToString()
        {
            return "Id stavby: " + Id_stavby + " Typ stavby: " + Typ_stavby + " Ulice: " + Ulice + " Cislo popisne: " + Cislo_popisne + " Cislo stavby na KU: " + Cislo_stavby_na_KU + " Nazev KU: " + Nazev_KU + " Datum kolaudace: " + Datum_kolaudace;
        }

    }
}
