using EZV.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZV.DAOFactory
{
    public interface IZpusob_vytapeni
    {
        void Insert(Zpusob_vytapeni zpusob_vytapeni);
        void Update(Zpusob_vytapeni zpusob_vytapeni);
        void Delete(Zpusob_vytapeni zpusob_vytapeni);
        Collection<Zpusob_vytapeni> Select();
        Zpusob_vytapeni Select_id(int idStavba, string zpusobVytapeni);
    }
}
