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
    public class Stavba_XmlMapper : IStavba
    {
        private int hodnotaId = 0;

        public int Sequence()
        {
            XDocument xDoc = XDocument.Load(ConstantsXml.FilePath);

            List<XElement> elementy = xDoc.Descendants("Stavby").Descendants("Stavba").ToList();

            foreach (XElement element in elementy)
            {
                int id = int.Parse(element.Attribute("Id_stavby").Value);
                if (id > this.hodnotaId)
                {
                    this.hodnotaId = id;
                }
            }
            return ++this.hodnotaId;
        }

        public void Insert(Stavba stavba)
        {
            XDocument xDoc = XDocument.Load(ConstantsXml.FilePath);

            XElement result = new XElement("Stavba",
                new XAttribute("Id_stavby", stavba.Id_stavby),
                new XAttribute("Typ_stavby", stavba.Typ_stavby),
                new XAttribute("Ulice", stavba.Ulice),
                new XAttribute("Cislo_popisne", stavba.Cislo_popisne),
                new XAttribute("Cislo_stavby_na_KU", stavba.Cislo_stavby_na_KU),
                new XAttribute("Nazev_KU", stavba.Nazev_KU),
                new XAttribute("Datum_kolaudace", stavba.Datum_kolaudace.ToShortDateString()));

            xDoc.Root.Element("Stavby").Add(result);
            xDoc.Save(ConstantsXml.FilePath);
        }

        public Stavba Select_id(int idStavba)
        {
            XDocument xDoc = XDocument.Load(ConstantsXml.FilePath);

            List<XElement> elementy = xDoc.Descendants("Stavby").Descendants("Stavba").ToList();

            Stavba vybranaStavba = new Stavba();

            foreach (XElement element in elementy)
            {
                if (int.Parse(element.Attribute("Id_stavby").Value) == idStavba)
                {
                    vybranaStavba.Id_stavby = idStavba;
                    vybranaStavba.Typ_stavby = element.Attribute("Typ_stavby").Value;
                    vybranaStavba.Ulice = element.Attribute("Ulice").Value;
                    vybranaStavba.Cislo_popisne = int.Parse(element.Attribute("Cislo_popisne").Value);
                    vybranaStavba.Cislo_stavby_na_KU = int.Parse(element.Attribute("Cislo_stavby_na_KU").Value);
                    vybranaStavba.Nazev_KU = element.Attribute("Nazev_KU").Value;
                    vybranaStavba.Datum_kolaudace = DateTime.Parse(element.Attribute("Datum_kolaudace").Value);
                }
            }

            return vybranaStavba;

            /*
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
            */
        }

        public void Update(Stavba stavba)
        {
            XDocument xDoc = XDocument.Load(ConstantsXml.FilePath);

            var q = from node in xDoc.Descendants("Stavby").Descendants("Stavba")
                    let attr = node.Attribute("Id_stavby")
                    where (attr != null && attr.Value == stavba.Id_stavby.ToString())
                    select node;
            q.ToList().ForEach(x => {
                x.Attribute("Typ_stavby").Value = stavba.Typ_stavby;
                x.Attribute("Ulice").Value = stavba.Ulice;
                x.Attribute("Cislo_popisne").Value = stavba.Cislo_popisne.ToString();
                x.Attribute("Cislo_stavby_na_KU").Value = stavba.Cislo_stavby_na_KU.ToString();
                x.Attribute("Nazev_KU").Value = stavba.Nazev_KU;
                x.Attribute("Datum_kolaudace").Value = stavba.Datum_kolaudace.ToShortDateString();
            });

            xDoc.Save(ConstantsXml.FilePath);
        }

        public Collection<Stavba> Select()
        {
            XDocument xDoc = XDocument.Load(ConstantsXml.FilePath);

            List<XElement> elementy = xDoc.Descendants("Stavby").Descendants("Stavba").ToList();

            Collection<Stavba> vsechnyStavby = new Collection<Stavba>();
            int id;
            int cislo_popisne;
            int cislo_stavby;
            DateTime datum;

            foreach (XElement element in elementy)
            {
                Stavba stavba = new Stavba();

                int.TryParse(element.Attribute("Id_stavby").Value, out id);
                stavba.Typ_stavby = element.Attribute("Typ_stavby").Value;
                stavba.Ulice = element.Attribute("Ulice").Value;
                int.TryParse(element.Attribute("Cislo_popisne").Value, out cislo_popisne);
                int.TryParse(element.Attribute("Cislo_stavby_na_KU").Value, out cislo_stavby);
                stavba.Nazev_KU = element.Attribute("Nazev_KU").Value;
                DateTime.TryParse(element.Attribute("Datum_kolaudace").Value, out datum);

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
