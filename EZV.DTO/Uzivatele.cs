using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZV.DTO
{
    public class Uzivatele
    {
        public string Login { get; set; }
        public string Heslo { get; set; }
        public string Postaveni { get; set; }
        public string Aktualnost { get; set; }
        public int Id_vlastnika { get; set; }

        public override string ToString()
        {
            return " Login: " + Login + " Heslo: " + Heslo + " Postavení: " + Postaveni + " Aktuálnost: " + Aktualnost + " Id vlastníka: " + Id_vlastnika;
        }
    }
}
