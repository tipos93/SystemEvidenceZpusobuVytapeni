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
    public class Historie_stavby_XmlMapper : IHistorie_stavby
    {
        private int hodnotaId = 0;

        public int Sequence()
        {
            XDocument xDoc = XDocument.Load(ConstantsXml.FilePath);

            List<XElement> elementy = xDoc.Descendants("Historie_staveb").Descendants("Historie_stavby").ToList();

            foreach (XElement element in elementy)
            {
                int id = int.Parse(element.Attribute("Id_zmeny").Value);
                if (id > this.hodnotaId)
                {
                    this.hodnotaId = id;
                }
            }
            return ++this.hodnotaId;
        }

        public void Insert(Historie_stavby historie_stavby)
        {
            XDocument xDoc = XDocument.Load(ConstantsXml.FilePath);

            XElement result = new XElement("Historie_stavby",
            new XAttribute("Id_zmeny", historie_stavby.Id_zmeny),
            new XAttribute("Typ_stavby", historie_stavby.Typ_stavby),
            new XAttribute("Ulice", historie_stavby.Ulice),
            new XAttribute("Cislo_popisne", historie_stavby.Cislo_popisne),
            new XAttribute("Cislo_stavby_na_KU", historie_stavby.Cislo_stavby_na_KU),
            new XAttribute("Nazev_KU", historie_stavby.Nazev_KU),
            new XAttribute("Datum_kolaudace", historie_stavby.Datum_kolaudace.ToShortDateString()),
            new XAttribute("Casovy_okamzik_zmeny", historie_stavby.Casovy_okamzik_zmeny.ToShortDateString()),
            new XAttribute("Id_vlastnika", historie_stavby.Id_vlastnika),
            new XAttribute("Id_stavby", historie_stavby.Id_stavby));

            xDoc.Root.Element("Historie_staveb").Add(result);
            xDoc.Save(ConstantsXml.FilePath);
        }

        public Historie_stavby Select_id(int idZmeny)
        {
            Collection<Historie_stavby> vsechnyHistorie = this.Select();
            Historie_stavby vybranaHistorie = null;

            foreach (Historie_stavby historie in vsechnyHistorie)
            {
                if (historie.Id_zmeny == idZmeny)
                {
                    vybranaHistorie = historie;
                }
            }

            return vybranaHistorie;
        }

        public Collection<Historie_stavby> Select()
        {
            XDocument xDoc = XDocument.Load(ConstantsXml.FilePath);

            List<XElement> elementy = xDoc.Descendants("Historie_staveb").Descendants("Historie_stavby").ToList();

            Collection<Historie_stavby> vsechnyHistorieStaveb = new Collection<Historie_stavby>();
            int id;
            int cislo_popisne;
            int cislo_stavby;
            DateTime datum;
            DateTime okamzikZmeny;
            int idVlastnika;
            int idStavby;

            foreach (XElement element in elementy)
            {
                Historie_stavby historieStavby = new Historie_stavby();

                int.TryParse(element.Attribute("Id_zmeny").Value, out id);
                historieStavby.Typ_stavby = element.Attribute("Typ_stavby").Value;
                historieStavby.Ulice = element.Attribute("Ulice").Value;
                int.TryParse(element.Attribute("Cislo_popisne").Value, out cislo_popisne);
                int.TryParse(element.Attribute("Cislo_stavby_na_KU").Value, out cislo_stavby);
                historieStavby.Nazev_KU = element.Attribute("Nazev_KU").Value;
                DateTime.TryParse(element.Attribute("Datum_kolaudace").Value, out datum);
                DateTime.TryParse(element.Attribute("Casovy_okamzik_zmeny").Value, out okamzikZmeny);
                int.TryParse(element.Attribute("Id_vlastnika").Value, out idVlastnika);
                int.TryParse(element.Attribute("Id_stavby").Value, out idStavby);

                historieStavby.Id_zmeny = id;
                historieStavby.Cislo_popisne = cislo_popisne;
                historieStavby.Cislo_stavby_na_KU = cislo_stavby;
                historieStavby.Datum_kolaudace = datum;
                historieStavby.Casovy_okamzik_zmeny = okamzikZmeny;
                historieStavby.Id_vlastnika = idVlastnika;
                historieStavby.Id_stavby = idStavby;

                vsechnyHistorieStaveb.Add(historieStavby);
                historieStavby = null;
            }

            return vsechnyHistorieStaveb;
        }
    }
}
