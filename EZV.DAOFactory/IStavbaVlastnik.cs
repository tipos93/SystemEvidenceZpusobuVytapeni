using EZV.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZV.DAOFactory
{
    public interface IStavbaVlastnik
    {
        void Insert(StavbaVlastnik stavbaVlastnik);
        void Update(StavbaVlastnik stavbaVlastnik);
        Collection<StavbaVlastnik> Select();
    }
}
