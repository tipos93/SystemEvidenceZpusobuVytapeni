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
    public class Kontrola_kvality_spalovani_XmlMapper : IKontrola_kvality_spalovani
    {
        private int hodnotaId = 0;

        public int Sequence()
        {
            XDocument xDoc = XDocument.Load(ConstantsXml.FilePath);

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
            XDocument xDoc = XDocument.Load(ConstantsXml.FilePath);

            XElement result = new XElement("Kontrola_kvality_spalovani",
            new XAttribute("Id_kontroly", kontrola.Id_kontroly),
            new XAttribute("Datum_kontroly", kontrola.Datum_kontroly.ToShortDateString()),
            new XAttribute("Duvod_kontroly", kontrola.Duvod_kontroly),
            new XAttribute("Id_stavby", kontrola.Id_stavby));

            xDoc.Root.Element("Kontroly_kvality_spalovani").Add(result);
            xDoc.Save(ConstantsXml.FilePath);
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
            XDocument xDoc = XDocument.Load(ConstantsXml.FilePath);

            var q = from node in xDoc.Descendants("Kontroly_kvality_spalovani").Descendants("Kontrola_kvality_spalovani")
                    let attr = node.Attribute("Id_kontroly")
                    where (attr != null && attr.Value == kontrola.Id_kontroly.ToString())
                    select node;
            q.ToList().ForEach(x => {
                x.Attribute("Datum_kontroly").Value = kontrola.Datum_kontroly.ToShortDateString();
                x.Attribute("Duvod_kontroly").Value = kontrola.Duvod_kontroly;
                x.Attribute("Id_stavby").Value = kontrola.Id_stavby.ToString();
            });

            xDoc.Save(ConstantsXml.FilePath);
        }

        public Collection<Kontrola_kvality_spalovani> Select()
        {
            XDocument xDoc = XDocument.Load(ConstantsXml.FilePath);

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
