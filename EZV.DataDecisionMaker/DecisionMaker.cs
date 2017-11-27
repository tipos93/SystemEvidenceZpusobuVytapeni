using EZV.DAOFactory;
using EZV.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZV.DataDecisionMaker
{
    public static class DecisionMaker
    {
        public static SqlFactory DecideSQL()
        {
            return (new SqlFactory());
        }

        public static XmlFactory DecideXML()
        {
            return (new XmlFactory());
        }
    }
}
