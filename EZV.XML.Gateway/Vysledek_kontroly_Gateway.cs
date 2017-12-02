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
    public class Vysledek_kontroly_Gateway : IVysledek_kontroly
    {
        /*
        public static XElement Insert(int Id_vysledku, string Ohodnoceni_kontroly, string Prijata_opatreni, int Id_kontroly, DateTime Datum_kontroly)
        {
           XElement result = new XElement("Vysledek kontroly",
                new XAttribute("Id vysledku", Id_vysledku),
                new XAttribute("Ohodnoceni kontroly", Ohodnoceni_kontroly),
                new XAttribute("Prijata opatreni", Prijata_opatreni),
                new XAttribute("Id kontroly", Id_kontroly),
                new XAttribute("Datum kontroly", Datum_kontroly));

            return result;
        }*/

        /*
        public static List<XElement> Select()
        {
            XDocument xDoc = XDocument.Load(Constants.FilePath);

            List<XElement> elementy = xDoc.Descendants("Vysledky kontrol").Descendants("Vysledek kontroly").ToList();

            return elementy;
        }*/

        private int hodnotaId = 0;

        public int Sequence()
        {
            XDocument xDoc = XDocument.Load(Constants.FilePath);

            List<XElement> elementy = xDoc.Descendants("Vysledky_kontrol").Descendants("Vysledek_kontroly").ToList();

            foreach (XElement element in elementy)
            {
                int id = int.Parse(element.Attribute("Id_vysledku").Value);
                if (id > this.hodnotaId)
                {
                    this.hodnotaId = id;
                }
            }
            return ++this.hodnotaId;
        }

        public void Insert(Vysledek_kontroly vysledek)
        {
            XElement result = new XElement("Vysledek_kontroly",
                new XAttribute("Id_vysledku", vysledek.Id_vysledku),
                new XAttribute("Ohodnoceni_kontroly", vysledek.Ohodnoceni_kontroly),
                new XAttribute("Prijata_opatreni", vysledek.Prijata_opatreni),
                new XAttribute("Id_kontroly", vysledek.Id_kontroly),
                new XAttribute("Datum_kontroly", vysledek.Datum_kontroly));
        }

        public Vysledek_kontroly Select_id(int idVysledku)
        {
            Collection<Vysledek_kontroly> vsechnyVysledky = this.Select();
            Vysledek_kontroly vybranyVysledek = null;

            foreach (Vysledek_kontroly vysledek in vsechnyVysledky)
            {
                if (vysledek.Id_vysledku == idVysledku)
                {
                    vybranyVysledek = vysledek;
                }
            }

            return vybranyVysledek;
        }

        public void Update(Vysledek_kontroly vysledek)
        {
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load(Constants.FilePath);

            XmlNode node = xmlDoc.SelectSingleNode("Databaze/Vysledky_kontrol/Vysledek_kontroly");
            if (node.Attributes[0].Value.Equals(vysledek.Id_vysledku))
            {
                node.Attributes[1].Value = vysledek.Ohodnoceni_kontroly;
                node.Attributes[2].Value = vysledek.Prijata_opatreni;
                node.Attributes[3].Value = vysledek.Id_kontroly.ToString();
                node.Attributes[4].Value = vysledek.Datum_kontroly.ToString();
            }

            xmlDoc.Save(Constants.FilePath);
        }

        public Collection<Vysledek_kontroly> Select()
        {
            /*
            Collection<Vysledek_kontroly> vsechnyVysledky;

            using (StreamReader reader = File.OpenText(Constants.FilePath))
            {
                XmlSerializer xser = new XmlSerializer(typeof(Collection<Vysledek_kontroly>));
                vsechnyVysledky = (Collection<Vysledek_kontroly>)xser.Deserialize(reader);
            }

            return vsechnyVysledky;
            */

            XDocument xDoc = XDocument.Load(Constants.FilePath);

            List<XElement> elementy = xDoc.Descendants("Vysledky_kontrol").Descendants("Vysledek_kontroly").ToList();

            Collection<Vysledek_kontroly> vsechnyVysledkyKontrol = new Collection<Vysledek_kontroly>();
            int id;
            int idKontroly;
            DateTime datum;

            foreach (XElement element in elementy)
            {
                Vysledek_kontroly vysledek = new Vysledek_kontroly();

                int.TryParse(element.Attribute("Id_vysledku").Value, out id);
                vysledek.Ohodnoceni_kontroly = element.Attribute("Ohodnoceni_kontroly").Value;
                vysledek.Prijata_opatreni = element.Attribute("Prijata_opatreni").Value;
                int.TryParse(element.Attribute("Id_kontroly").Value, out idKontroly);
                DateTime.TryParse(element.Attribute("Datum_kontroly").Value, out datum);

                vysledek.Id_vysledku = id;
                vysledek.Id_kontroly = idKontroly;
                vysledek.Datum_kontroly = datum;

                vsechnyVysledkyKontrol.Add(vysledek);
                vysledek = null;
            }

            return vsechnyVysledkyKontrol;
        }
    }
}
