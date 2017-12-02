using EZV.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZV.DAOFactory
{
    public interface IDotace_EU
    {
        int Sequence();
        void Insert(Dotace_EU dotace_EU);
        void Update(Dotace_EU dotace_EU);
        Collection<Dotace_EU> Select();
        Dotace_EU Select_id(int idDotace);
    }
}
