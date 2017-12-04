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
    public class Zpusob_vytapeni_Gateway : IZpusob_vytapeni
    {
        public void Delete(Zpusob_vytapeni zpusob_vytapeni)
        {
            XDocument xDoc = XDocument.Load(Constants.FilePath);

            var q = from node in xDoc.Descendants("Zpusoby_vytapeni").Descendants("Zpusob_vytapeni")
                    let attr = node.Attribute("Typ_vytapeni")
                    let attr1 = node.Attribute("Id_stavby")
                    where (attr != null && attr.Value == zpusob_vytapeni.Typ_vytapeni) && (attr1 != null && attr1.Value == zpusob_vytapeni.Id_stavby.ToString())
                    select node;
            q.ToList().ForEach(x => x.Attribute("Platnost_do").Value = zpusob_vytapeni.Platnost_do.ToString());

            xDoc.Save(Constants.FilePath);
        }

        public void Insert(Zpusob_vytapeni zpusob_vytapeni)
        {
            XDocument xDoc = XDocument.Load(Constants.FilePath);

            XElement result = new XElement("Zpusob_vytapeni",
                new XAttribute("Typ_vytapeni", zpusob_vytapeni.Typ_vytapeni),
                new XAttribute("Platnost_od", zpusob_vytapeni.Platnost_od.ToShortDateString()),
                new XAttribute("Platnost_do", zpusob_vytapeni.Platnost_do == null ? DBNull.Value : (object)zpusob_vytapeni.Platnost_do.ToString()),
                new XAttribute("Id_stavby", zpusob_vytapeni.Id_stavby));

            xDoc.Root.Element("Zpusoby_vytapeni").Add(result);
            xDoc.Save(Constants.FilePath);
        }

        public Zpusob_vytapeni Select_id(int idStavba, string zpusobVytapeni)
        {
            Collection<Zpusob_vytapeni> vsechnyZpusoby = this.Select();
            Zpusob_vytapeni vybranyZpusob = null;

            foreach (Zpusob_vytapeni zpusob in vsechnyZpusoby)
            {
                if (zpusob.Id_stavby == idStavba && zpusob.Typ_vytapeni == zpusobVytapeni)
                {
                    vybranyZpusob = zpusob;
                }
            }

            return vybranyZpusob;
        }

        public void Update(Zpusob_vytapeni zpusob_vytapeni)
        {
            XDocument xDoc = XDocument.Load(Constants.FilePath);

            var q = from node in xDoc.Descendants("Zpusoby_vytapeni").Descendants("Zpusob_vytapeni")
                    let attr = node.Attribute("Typ_vytapeni")
                    let attr1 = node.Attribute("Id_stavby")
                    where (attr != null && attr.Value == zpusob_vytapeni.Typ_vytapeni) && (attr1 != null && attr1.Value == zpusob_vytapeni.Id_stavby.ToString())
                    select node;
            q.ToList().ForEach(x => {
                x.Attribute("Platnost_od").Value = zpusob_vytapeni.Platnost_od.ToShortDateString();
                x.Attribute("Platnost_do").Value = zpusob_vytapeni.Platnost_do.ToString();
            });

            xDoc.Save(Constants.FilePath);
        }

        public Collection<Zpusob_vytapeni> Select()
        {
            XDocument xDoc = XDocument.Load(Constants.FilePath);

            List<XElement> elementy = xDoc.Descendants("Zpusoby_vytapeni").Descendants("Zpusob_vytapeni").ToList();

            Collection<Zpusob_vytapeni> vsechnyZpusoby = new Collection<Zpusob_vytapeni>();
            DateTime platnostOd;
            DateTime platnostDo;
            int idStavby;

            foreach (XElement element in elementy)
            {
                Zpusob_vytapeni zpusob = new Zpusob_vytapeni();

                zpusob.Typ_vytapeni = element.Attribute("Typ_vytapeni").Value;
                DateTime.TryParse(element.Attribute("Platnost_od").Value, out platnostOd);
                try
                {
                    DateTime.TryParse(element.Attribute("Platnost_do").Value, out platnostDo);
                    zpusob.Platnost_do = platnostDo;
                }
                catch (Exception e)
                {
                    zpusob.Platnost_do = null;
                }
                int.TryParse(element.Attribute("Id_stavby").Value, out idStavby);

                zpusob.Platnost_od = platnostOd;
                zpusob.Id_stavby = idStavby;

                vsechnyZpusoby.Add(zpusob);
                zpusob = null;
            }

            return vsechnyZpusoby;
        }
    }
}
