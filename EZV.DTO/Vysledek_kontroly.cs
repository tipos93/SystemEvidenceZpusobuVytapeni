using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZV.DTO
{
    public class Vysledek_kontroly
    {

        public int Id_vysledku { get; set; }
        public string Ohodnoceni_kontroly { get; set; }
        public string Prijata_opatreni { get; set; }
        public int Id_kontroly { get; set; }
        public DateTime Datum_kontroly { get; set; }

        public override string ToString()
        {
            return "Id vysledku: " + Id_vysledku + " Vysledek kontroly: " + Ohodnoceni_kontroly + " Prijata opatreni: " + Prijata_opatreni + " Id kontroly: " + Id_kontroly + " Datum kontroly: " + Datum_kontroly;
        }

    }
}
