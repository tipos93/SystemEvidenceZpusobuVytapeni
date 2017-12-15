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
    public class Dotace_EU_XmlMapper : IDotace_EU
    {
        private int hodnotaId = 0;

        public int Sequence()
        {
            XDocument xDoc = XDocument.Load(ConstantsXml.FilePath);

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
            XDocument xDoc = XDocument.Load(ConstantsXml.FilePath);

            XElement result = new XElement("Dotace",
                new XAttribute("Id_dotace", dotace_EU.Id_dotace),
                new XAttribute("Vyse_dotace", dotace_EU.Vyse_dotace),
                new XAttribute("Datum_prideleni", dotace_EU.Datum_prideleni.ToShortDateString()),
                new XAttribute("Zpusob_pouziti", dotace_EU.Zpusob_pouziti),
                new XAttribute("Id_stavby", dotace_EU.Id_stavby));

            xDoc.Root.Element("Dotace_EU").Add(result);
            xDoc.Save(ConstantsXml.FilePath);
        }

        public void Update(Dotace_EU dotace_EU)
        {
            XDocument xDoc = XDocument.Load(ConstantsXml.FilePath);

            var q = from node in xDoc.Descendants("Dotace_EU").Descendants("Dotace")
                    let attr = node.Attribute("Id_dotace")
                    where (attr != null && attr.Value == dotace_EU.Id_dotace.ToString())
                    select node;
            q.ToList().ForEach(x => {
                x.Attribute("Vyse_dotace").Value = dotace_EU.Vyse_dotace.ToString();
                x.Attribute("Datum_prideleni").Value = dotace_EU.Datum_prideleni.ToShortDateString();
                x.Attribute("Zpusob_pouziti").Value = dotace_EU.Zpusob_pouziti;
                x.Attribute("Id_stavby").Value = dotace_EU.Id_stavby.ToString();
            });

            xDoc.Save(ConstantsXml.FilePath);
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
            XDocument xDoc = XDocument.Load(ConstantsXml.FilePath);

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
