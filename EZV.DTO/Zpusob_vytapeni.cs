using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZV.DTO
{
    public class Zpusob_vytapeni
    {

        public string Typ_vytapeni { get; set; }
        public DateTime Platnost_od { get; set; }
        public DateTime? Platnost_do { get; set; }
        public int Id_stavby { get; set; }

        public override string ToString()
        {
            return "Zpusob vytapeni: " + Typ_vytapeni + " Platnost od: " + Platnost_od + " Platnost do: " + Platnost_do + " Id stavby: " + Id_stavby;
        }

    }
}
