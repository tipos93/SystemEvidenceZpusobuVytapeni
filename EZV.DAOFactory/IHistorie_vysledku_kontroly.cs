using EZV.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZV.DAOFactory
{
    public interface IHistorie_vysledku_kontroly
    {
        Collection<Historie_vysledku_kontroly> Select();
        Historie_vysledku_kontroly Select_id(int idZmeny);
    }
}
