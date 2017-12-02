using EZV.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZV.DAOFactory
{
    public interface IStavba
    {
        int Sequence();
        void Insert(Stavba stavba);
        void Update(Stavba stavba);
        Collection<Stavba> Select();
        Stavba Select_id(int idStavba);
    }
}
