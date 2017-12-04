using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Collections.ObjectModel;
using EZV.DAOFactory;
using EZV.DTO;

namespace EZV.XML.Gateway
{
    public class Vysledek_kontroly_Gateway : IVysledek_kontroly
    {
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
            XDocument xDoc = XDocument.Load(Constants.FilePath);

            XElement result = new XElement("Vysledek_kontroly",
                new XAttribute("Id_vysledku", vysledek.Id_vysledku),
                new XAttribute("Ohodnoceni_kontroly", vysledek.Ohodnoceni_kontroly),
                new XAttribute("Prijata_opatreni", vysledek.Prijata_opatreni),
                new XAttribute("Id_kontroly", vysledek.Id_kontroly),
                new XAttribute("Datum_kontroly", vysledek.Datum_kontroly.ToShortDateString()));

            xDoc.Root.Element("Vysledky_kontrol").Add(result);
            xDoc.Save(Constants.FilePath);
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
            XDocument xDoc = XDocument.Load(Constants.FilePath);

            var q = from node in xDoc.Descendants("Vysledky_kontrol").Descendants("Vysledek_kontroly")
                    let attr = node.Attribute("Id_vysledku")
                    where (attr != null && attr.Value == vysledek.Id_vysledku.ToString())
                    select node;
            q.ToList().ForEach(x => {
                x.Attribute("Ohodnoceni_kontroly").Value = vysledek.Ohodnoceni_kontroly;
                x.Attribute("Prijata_opatreni").Value = vysledek.Prijata_opatreni;
                x.Attribute("Id_kontroly").Value = vysledek.Id_kontroly.ToString();
                x.Attribute("Datum_kontroly").Value = vysledek.Datum_kontroly.ToShortDateString();
            });

            xDoc.Save(Constants.FilePath);
        }

        public Collection<Vysledek_kontroly> Select()
        {
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
