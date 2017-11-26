using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZV.DTO
{
    public class Kontrola_kvality_spalovani
    {

        public int Id_kontroly { get; set; }
        public DateTime Datum_kontroly { get; set; }
        public string Duvod_kontroly { get; set; }
        public int Id_stavby { get; set; }

        public override string ToString()
        {
            return "Id kontroly: " + Id_kontroly + " Datum kontroly: " + Datum_kontroly + " Duvod kontroly: " + Duvod_kontroly + " Id stavby: " + Id_stavby;
        }

    }
}
