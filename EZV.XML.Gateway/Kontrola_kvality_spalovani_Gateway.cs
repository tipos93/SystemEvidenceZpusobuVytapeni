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
    public class Kontrola_kvality_spalovani_Gateway : IKontrola_kvality_spalovani
    {
        /*
        public static XElement Insert(int Id_kontroly, DateTime Datum_kontroly, string Duvod_kontroly, int Id_stavby)
        {
            XElement result = new XElement("Kontrola kvality spalovani",
                new XAttribute("Id kontroly", Id_kontroly),
                new XAttribute("Datum kontroly", Datum_kontroly),
                new XAttribute("Duvod kontroly", Duvod_kontroly),
                new XAttribute("Id stavby", Id_stavby));

            return result;
        }*/

        /*
        public static List<XElement> Select()
        {
            XDocument xDoc = XDocument.Load(Constants.FilePath);

            List<XElement> elementy = xDoc.Descendants("Kontroly kvality spalovani").Descendants("Kontrola kvality spalovani").ToList();

            return elementy;
        }*/

        private int hodnotaId = 0;

        public int Sequence()
        {
            XDocument xDoc = XDocument.Load(Constants.FilePath);

            List<XElement> elementy = xDoc.Descendants("Kontroly_kvality_spalovani").Descendants("Kontrola_kvality_spalovani").ToList();

            foreach (XElement element in elementy)
            {
                int id = int.Parse(element.Attribute("Id_kontroly").Value);
                if (id > this.hodnotaId)
                {
                    this.hodnotaId = id;
                }
            }
            return ++this.hodnotaId;
        }

        public void Insert(Kontrola_kvality_spalovani kontrola)
        {
            XElement result = new XElement("Kontrola_kvality_spalovani",
            new XAttribute("Id_kontroly", kontrola.Id_kontroly),
            new XAttribute("Datum_kontroly", kontrola.Datum_kontroly),
            new XAttribute("Duvod_kontroly", kontrola.Duvod_kontroly),
            new XAttribute("Id_stavby", kontrola.Id_stavby));
        }

        public Kontrola_kvality_spalovani Select_id(int idKontroly)
        {
            Collection<Kontrola_kvality_spalovani> vsechnyKontroly = this.Select();
            Kontrola_kvality_spalovani vybranaKontrola = null;

            foreach (Kontrola_kvality_spalovani kontrola in vsechnyKontroly)
            {
                if (kontrola.Id_kontroly == idKontroly)
                {
                    vybranaKontrola = kontrola;
                }
            }

            return vybranaKontrola;
        }

        public void Update(Kontrola_kvality_spalovani kontrola)
        {
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load(Constants.FilePath);

            XmlNode node = xmlDoc.SelectSingleNode("Databaze/Kontroly_kvality_spalovani/Kontrola_kvality_spalovani");
            if (node.Attributes[0].Value.Equals(kontrola.Id_kontroly))
            {
                node.Attributes[1].Value = kontrola.Datum_kontroly.ToString();
                node.Attributes[2].Value = kontrola.Duvod_kontroly;
                node.Attributes[4].Value = kontrola.Id_stavby.ToString();
            }

            xmlDoc.Save(Constants.FilePath);
        }

        public Collection<Kontrola_kvality_spalovani> Select()
        {
            /*
            Collection<Kontrola_kvality_spalovani> vsechnyKontroly;

            using (StreamReader reader = File.OpenText(Constants.FilePath))
            {
                XmlSerializer xser = new XmlSerializer(typeof(Collection<Kontrola_kvality_spalovani>));
                vsechnyKontroly = (Collection<Kontrola_kvality_spalovani>)xser.Deserialize(reader);
            }

            return vsechnyKontroly;
            */

            XDocument xDoc = XDocument.Load(Constants.FilePath);

            List<XElement> elementy = xDoc.Descendants("Kontroly_kvality_spalovani").Descendants("Kontrola_kvality_spalovani").ToList();

            Collection<Kontrola_kvality_spalovani> vsechnyKontroly = new Collection<Kontrola_kvality_spalovani>();
            int id;
            DateTime datum;
            int idStavby;

            foreach (XElement element in elementy)
            {
                Kontrola_kvality_spalovani kontrola = new Kontrola_kvality_spalovani();

                int.TryParse(element.Attribute("Id_kontroly").Value, out id);
                DateTime.TryParse(element.Attribute("Datum_kontroly").Value, out datum);
                kontrola.Duvod_kontroly = element.Attribute("Duvod_kontroly").Value;
                int.TryParse(element.Attribute("Id_stavby").Value, out idStavby);
                
                kontrola.Id_kontroly = id;
                kontrola.Datum_kontroly = datum;
                kontrola.Id_stavby = idStavby;

                vsechnyKontroly.Add(kontrola);
                kontrola = null;
            }

            return vsechnyKontroly;
        }
    }
}
