using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using EZV.DAOFactory;
using EZV.DTO;

namespace EZV.XML.Gateway
{
    public class StavbaVlastnik_Gateway : IStavbaVlastnik
    {
        /*
        public static XElement Insert(int Id_stavby, int Id_vlastnika)
        {
            XElement result = new XElement("StavbaVlastnik",
                new XAttribute("Id stavby", Id_stavby),
                new XAttribute("Id vlastnika", Id_vlastnika));

            return result;
        }*/

        /*
        public static List<XElement> Select()
        {
            XDocument xDoc = XDocument.Load(Constants.FilePath);

            List<XElement> elementy = xDoc.Descendants("StavbyVlastnici").Descendants("StavbaVlastnik").ToList();

            return elementy;
        }*/

        public void Insert(StavbaVlastnik stavbaVlastnik)
        {
            XElement result = new XElement("StavbaVlastnik",
                new XAttribute("Id stavby", stavbaVlastnik.Id_stavby),
                new XAttribute("Id vlastnika", stavbaVlastnik.Id_vlastnika));
        }

        public void Update(StavbaVlastnik stavbaVlastnik)
        {
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load(Constants.FilePath);

            XmlNode node = xmlDoc.SelectSingleNode("Database/StavbyVlastnici/StavbaVlastnik");
            if (node.Attributes[0].Value.Equals(stavbaVlastnik.Id_stavby))
            {
                node.Attributes[1].Value = stavbaVlastnik.Id_vlastnika.ToString();
            }

            xmlDoc.Save(Constants.FilePath);
        }

        public Collection<StavbaVlastnik> Select()
        {
            /*
            Collection<StavbaVlastnik> vsichniStavbyVlastnici;

            using (StreamReader reader = File.OpenText(Constants.FilePath))
            {
                XmlSerializer xser = new XmlSerializer(typeof(Collection<StavbaVlastnik>));
                vsichniStavbyVlastnici = (Collection<StavbaVlastnik>)xser.Deserialize(reader);
            }

            return vsichniStavbyVlastnici;
            */

            XDocument xDoc = XDocument.Load(Constants.FilePath);

            List<XElement> elementy = xDoc.Descendants("StavbyVlastnici").Descendants("StavbaVlastnik").ToList();

            Collection<StavbaVlastnik> vsichniStavbyVlastnici = new Collection<StavbaVlastnik>();
            int idStavby;
            int idVlastnika;

            foreach (XElement element in elementy)
            {
                StavbaVlastnik stavbaVlastnik = new StavbaVlastnik();

                int.TryParse(element.Attribute("Id stavby").Value, out idStavby);
                int.TryParse(element.Attribute("Id vlastnika").Value, out idVlastnika);

                stavbaVlastnik.Id_stavby = idStavby;
                stavbaVlastnik.Id_vlastnika = idVlastnika;

                vsichniStavbyVlastnici.Add(stavbaVlastnik);
                stavbaVlastnik = null;
            }

            return vsichniStavbyVlastnici;
        }
    }
}
