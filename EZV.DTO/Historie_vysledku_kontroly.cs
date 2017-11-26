using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZV.DTO
{
    public class Historie_vysledku_kontroly
    {

        public int Id_zmeny { get; set; }
        public string Vysledek_kontroly { get; set; }
        public string Prijata_opatreni { get; set; }
        public DateTime Casovy_okamzik_zmeny { get; set; }
        public int Id_vysledku { get; set; }

        public override string ToString()
        {
            return "Id zmeny: " + Id_zmeny + " Vysledek kontroly: " + Vysledek_kontroly + " Prijata opatreni: " + Prijata_opatreni + " Casovy okamzik zmeny: " + Casovy_okamzik_zmeny + " Id vysledku: " + Id_vysledku;
        }
    }
}
