using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZV.DTO
{
    public class Dotace_EU 
    {

        public int Id_dotace { get; set; }
        public int Vyse_dotace { get; set; }
        public DateTime Datum_prideleni { get; set; }
        public string Zpusob_pouziti { get; set; }
        public int Id_stavby { get; set; }

        public override string ToString()
        {
            return "Id dotace: " + Id_dotace + " Vyse dotace: " + Vyse_dotace + " Datum prideleni: " + Datum_prideleni + " Zpusob pouziti: " + Zpusob_pouziti + " Id stavby: " + Id_stavby;
        }

    }
}
