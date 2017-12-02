using EZV.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZV.DAOFactory
{
    public interface IVysledek_kontroly
    {
        int Sequence();
        void Insert(Vysledek_kontroly vysledek);
        void Update(Vysledek_kontroly vysledek);
        Collection<Vysledek_kontroly> Select();
        Vysledek_kontroly Select_id(int idVysledku);
    }
}
