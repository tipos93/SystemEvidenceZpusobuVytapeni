using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Collections.ObjectModel;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using EZV.DAOFactory;
using EZV.DTO;

namespace EZV.XML.Gateway
{
    public class Stavba_Gateway : IStavba
    {
        /*
        public static XElement Insert(int Id_stavby, string Typ_stavby, string Ulice, int Cislo_popisne, int Cislo_stavby_na_KU, string Nazev_KU, DateTime Datum_kolaudace, string Vypis)
        {
            XElement result = new XElement("Stavba",
                new XAttribute("Id stavby", Id_stavby),
                new XAttribute("Typ stavby", Typ_stavby),
                new XAttribute("Ulice", Ulice),
                new XAttribute("Cislo popisne", Cislo_popisne),
                new XAttribute("Cislo stavby na KU", Cislo_stavby_na_KU),
                new XAttribute("Nazev KU", Nazev_KU),
                new XAttribute("Datum kolaudace", Datum_kolaudace),
                new XAttribute("Vypis", Vypis));

            return result;
        }*/

        /*
        public static List<XElement> Select()
        {
            XDocument xDoc = XDocument.Load(Constants.FilePath);

            List<XElement> elementy = xDoc.Descendants("Stavby").Descendants("Stavba").ToList();

            return elementy;
        }*/

        public void Insert(Stavba stavba)
        {
            XElement result = new XElement("Stavba",
                new XAttribute("Id stavby", stavba.Id_stavby),
                new XAttribute("Typ stavby", stavba.Typ_stavby),
                new XAttribute("Ulice", stavba.Ulice),
                new XAttribute("Cislo popisne", stavba.Cislo_popisne),
                new XAttribute("Cislo stavby na KU", stavba.Cislo_stavby_na_KU),
                new XAttribute("Nazev KU", stavba.Nazev_KU),
                new XAttribute("Datum kolaudace", stavba.Datum_kolaudace));
        }

        public Stavba Select_id(int idStavba)
        {
            Collection<Stavba> vsechnyStavby = this.Select();
            Stavba vybranaStavba = null;

            foreach (Stavba stavba in vsechnyStavby)
            {
                if (stavba.Id_stavby == idStavba)
                {
                    vybranaStavba = stavba;
                }
            }

            return vybranaStavba;
        }

        public void Update(Stavba stavba)
        {
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load(Constants.FilePath);

            XmlNode node = xmlDoc.SelectSingleNode("Database/Stavby/Stavba");
            if (node.Attributes[0].Value.Equals(stavba.Id_stavby))
            {
                node.Attributes[1].Value = stavba.Typ_stavby;
                node.Attributes[2].Value = stavba.Ulice;
                node.Attributes[3].Value = stavba.Cislo_popisne.ToString();
                node.Attributes[4].Value = stavba.Cislo_stavby_na_KU.ToString();
                node.Attributes[5].Value = stavba.Nazev_KU;
                node.Attributes[6].Value = stavba.Datum_kolaudace.ToString();
            }

            xmlDoc.Save(Constants.FilePath);
        }

        public Collection<Stavba> Select()
        {
            /*
            Collection<Stavba> vsechnyStavby;

            using (StreamReader reader = File.OpenText(Constants.FilePath))
            {
                XmlSerializer xser = new XmlSerializer(typeof(Collection<Stavba>));
                vsechnyStavby = (Collection<Stavba>)xser.Deserialize(reader);
            }

            return vsechnyStavby;*/

            XDocument xDoc = XDocument.Load(Constants.FilePath);

            List<XElement> elementy = xDoc.Descendants("Stavby").Descendants("Stavba").ToList();

            Collection<Stavba> vsechnyStavby = new Collection<Stavba>();
            int id;
            int cislo_popisne;
            int cislo_stavby;
            DateTime datum;

            foreach (XElement element in elementy)
            {
                Stavba stavba = new Stavba();

                int.TryParse(element.Attribute("Id stavby").Value, out id);
                stavba.Typ_stavby = element.Attribute("Typ stavby").Value;
                stavba.Ulice = element.Attribute("Ulice").Value;
                int.TryParse(element.Attribute("Cislo popisne").Value, out cislo_popisne);
                int.TryParse(element.Attribute("Cislo stavby na KU").Value, out cislo_stavby);
                stavba.Nazev_KU = element.Attribute("Nazev KU").Value;
                DateTime.TryParse(element.Attribute("Datum kolaudace").Value, out datum);

                stavba.Id_stavby = id;
                stavba.Cislo_popisne = cislo_popisne;
                stavba.Cislo_stavby_na_KU = cislo_stavby;
                stavba.Datum_kolaudace = datum;

                vsechnyStavby.Add(stavba);
                stavba = null;
            }

            return vsechnyStavby;
        }
    }
}
