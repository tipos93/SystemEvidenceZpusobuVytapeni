using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZV.DTO
{
    public class Vlastnik
    {

        public int Id_vlastnika { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public DateTime Datum_narozeni { get; set; }
        public DateTime? Datum_umrti { get; set; }
        public string Rodne_cislo { get; set; }
        public string Pohlavi { get; set; }
        public string Trvale_bydliste_ulice { get; set; }
        public int Trvale_bydliste_cislo_popisne { get; set; }
        public string Trvale_bydliste_mesto { get; set; }
        public string Trvale_bydliste_PSC { get; set; }
        public string Aktualni_vlastnik { get; set; }
        public string Vypis { get; set; }

        public override string ToString()
        {
            return "Id vlastnika: " + Id_vlastnika + " Jmeno: " + Jmeno + " Prijmeni: " + Prijmeni + " Datum narozeni: " + Datum_narozeni + " Datum umrti: " + Datum_umrti + " Rodne cislo: " + Rodne_cislo + " Pohlavi: " + Pohlavi + " Trvale bydliste ulice: " + Trvale_bydliste_ulice + " Trvale bydliste cislo popisne: " + Trvale_bydliste_cislo_popisne + " Trvale bydliste mesto: " + Trvale_bydliste_mesto + " Trvale bydliste PSC: " + Trvale_bydliste_PSC + " Aktualni vlastnik: " + Aktualni_vlastnik;
        }

    }
}
