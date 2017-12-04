using EZV.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZV.DAOFactory
{
    public interface IUzivatele
    {
        void Insert(Uzivatele uzivatele);
        void Update(Uzivatele uzivatele);
        void Delete(Uzivatele uzivatele);
        Collection<Uzivatele> Select();
        Uzivatele Select_id(string loginUzivatele);
    }
}
