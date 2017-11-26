using EZV.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZV.DAOFactory
{
    public interface IKontrola_kvality_spalovani
    {
        void Insert(Kontrola_kvality_spalovani kontrola);
        void Update(Kontrola_kvality_spalovani kontrola);
        Collection<Kontrola_kvality_spalovani> Select();
        Kontrola_kvality_spalovani Select_id(int idKontroly);
    }
}
