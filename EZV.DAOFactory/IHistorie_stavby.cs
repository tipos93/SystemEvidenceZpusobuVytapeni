using EZV.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZV.DAOFactory
{
    public interface IHistorie_stavby
    {
        void Insert(Historie_stavby historie_stavby);
        Collection<Historie_stavby> Select();
        Historie_stavby Select_id(int idZmeny);
    }
}
