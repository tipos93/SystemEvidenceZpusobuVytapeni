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
    public class Dotace_EU_Gateway : IDotace_EU
    {
        /*
        public static XElement Insert(int Id_dotace, int Vyse_dotace, DateTime Datum_prideleni, string Zpusob_pouziti, int Id_stavby)
        {
            XElement result = new XElement("Dotace",
                new XAttribute("Id dotace", Id_dotace),
                new XAttribute("Vyse dotace", Vyse_dotace),
                new XAttribute("Datum prideleni", Datum_prideleni),
                new XAttribute("Zpusob pouziti", Zpusob_pouziti),
                new XAttribute("Id stavby", Id_stavby));

            return result;
        }*/

        /*
        public static List<XElement> SelectXml()
        {
            XDocument xDoc = XDocument.Load(Constants.FilePath);

            List<XElement> elementy = xDoc.Descendants("Dotace EU").Descendants("Dotace").ToList();

            return elementy;
        }*/

        private int hodnotaId = 0;

        public int Sequence()
        {
            XDocument xDoc = XDocument.Load(Constants.FilePath);

            List<XElement> elementy = xDoc.Descendants("Dotace_EU").Descendants("Dotace").ToList();

            foreach (XElement element in elementy)
            {
                int id = int.Parse(element.Attribute("Id_dotace").Value);
                if (id > this.hodnotaId)
                {
                    this.hodnotaId = id;
                }
            }
            return ++this.hodnotaId;
        }

        public void Insert(Dotace_EU dotace_EU)
        {
            XElement result = new XElement("Dotace",
                new XAttribute("Id_dotace", dotace_EU.Id_dotace),
                new XAttribute("Vyse_dotace", dotace_EU.Vyse_dotace),
                new XAttribute("Datum_prideleni", dotace_EU.Datum_prideleni),
                new XAttribute("Zpusob_pouziti", dotace_EU.Zpusob_pouziti),
                new XAttribute("Id_stavby", dotace_EU.Id_stavby));
        }

        public void Update(Dotace_EU dotace_EU)
        { 
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load(Constants.FilePath);

            XmlNode node = xmlDoc.SelectSingleNode("Databaze/Dotace_EU/Dotace");
            if (node.Attributes[0].Value.Equals(dotace_EU.Id_dotace))
            {
                node.Attributes[1].Value = dotace_EU.Vyse_dotace.ToString();
                node.Attributes[2].Value = dotace_EU.Datum_prideleni.ToString();
                node.Attributes[3].Value = dotace_EU.Zpusob_pouziti;
                node.Attributes[4].Value = dotace_EU.Id_stavby.ToString();
            }

            xmlDoc.Save(Constants.FilePath);
        }

        public Dotace_EU Select_id(int idDotace)
        {

            Collection<Dotace_EU> vsechnyDotace = this.Select();
            Dotace_EU vybranaDotace = null;

            foreach(Dotace_EU dotace in vsechnyDotace)
            {
                if(dotace.Id_dotace == idDotace)
                {
                    vybranaDotace = dotace;
                }
            }

            return vybranaDotace;

        }

        public Collection<Dotace_EU> Select()
        {
            /*
            Collection<Dotace_EU> vsechnyDotace;

            using (StreamReader reader = File.OpenText(Constants.FilePath))
            {
                XmlSerializer xser = new XmlSerializer(typeof(Collection<Dotace_EU>));
                vsechnyDotace = (Collection<Dotace_EU>)xser.Deserialize(reader);
            }

            return vsechnyDotace;
            */

            XDocument xDoc = XDocument.Load(Constants.FilePath);

            List<XElement> elementy = xDoc.Descendants("Dotace_EU").Descendants("Dotace").ToList();

            Collection<Dotace_EU> vsechnyDotace = new Collection<Dotace_EU>();
            int id;
            int vyse;
            DateTime datum;
            int idStavby;

            foreach (XElement element in elementy)
            {
                Dotace_EU dotace = new Dotace_EU();

                int.TryParse(element.Attribute("Id_dotace").Value, out id);
                int.TryParse(element.Attribute("Vyse_dotace").Value, out vyse);
                DateTime.TryParse(element.Attribute("Datum_prideleni").Value, out datum);
                dotace.Zpusob_pouziti = element.Attribute("Zpusob_pouziti").Value;
                int.TryParse(element.Attribute("Id_stavby").Value, out idStavby);

                dotace.Id_dotace = id;
                dotace.Vyse_dotace = vyse;
                dotace.Datum_prideleni = datum;
                dotace.Id_stavby = idStavby;

                vsechnyDotace.Add(dotace);
                dotace = null;
            }

            return vsechnyDotace;
        }
    }
}
