using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZV.DTO
{
    public class StavbaVlastnik
    {
        public int Id_stavby { get; set; }
        public int Id_vlastnika { get; set; }

        public override string ToString()
        {
            return "Id stavby: " + Id_stavby + " Id vlastnika: " + Id_vlastnika;
        }
    }
}
