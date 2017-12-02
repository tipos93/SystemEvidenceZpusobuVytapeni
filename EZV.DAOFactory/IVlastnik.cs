using EZV.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZV.DAOFactory
{
    public interface IVlastnik
    {
        int Sequence();
        void Insert(Vlastnik vlastnik);
        void Update(Vlastnik vlastnik);
        void Delete(Vlastnik vlastnik);
        Collection<Vlastnik> Select();
        Vlastnik Select_id(int idVlastnik);
    }
}
