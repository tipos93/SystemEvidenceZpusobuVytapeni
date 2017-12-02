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
    public class Zpusob_vytapeni_Gateway : IZpusob_vytapeni
    {
        /*
        public static XElement Insert(string Typ_vytapeni, DateTime Platnost_od, DateTime? Platnost_do, int Id_stavby)
        {
            XElement result = new XElement("Zpusob vytapeni",
                new XAttribute("Typ vytapeni", Typ_vytapeni),
                new XAttribute("Platnost od", Platnost_od),
                new XAttribute("Platnost do", Platnost_do == null ? DBNull.Value : (object)Platnost_do),
                new XAttribute("Id stavby", Id_stavby));

            return result;
        }*/

        /*
        public static List<XElement> Select()
        {
            XDocument xDoc = XDocument.Load(Constants.FilePath);

            List<XElement> elementy = xDoc.Descendants("Zpusoby vytapeni").Descendants("Zpusob vytapeni").ToList();

            return elementy;
        }*/

        public void Delete(Zpusob_vytapeni zpusob_vytapeni)
        {
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load(Constants.FilePath);

            XmlNode node = xmlDoc.SelectSingleNode("Databaze/Zpusoby_vytapeni/Zpusob_vytapeni");
            if (node.Attributes[0].Value.Equals(zpusob_vytapeni.Typ_vytapeni) && node.Attributes[3].Value.Equals(zpusob_vytapeni.Id_stavby))
            {
                node.Attributes[2].Value = zpusob_vytapeni.Platnost_do.ToString();
            }

            xmlDoc.Save(Constants.FilePath);
        }

        public void Insert(Zpusob_vytapeni zpusob_vytapeni)
        {
            XElement result = new XElement("Zpusob_vytapeni",
                new XAttribute("Typ_vytapeni", zpusob_vytapeni.Typ_vytapeni),
                new XAttribute("Platnost_od", zpusob_vytapeni.Platnost_od),
                new XAttribute("Platnost_do", zpusob_vytapeni.Platnost_do == null ? DBNull.Value : (object)zpusob_vytapeni.Platnost_do),
                new XAttribute("Id_stavby", zpusob_vytapeni.Id_stavby));
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
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load(Constants.FilePath);
        
            XmlNode node = xmlDoc.SelectSingleNode("Databaze/Zpusoby_vytapeni/Zpusob_vytapeni");
            if (node.Attributes[0].Value.Equals(zpusob_vytapeni.Typ_vytapeni) && node.Attributes[3].Value.Equals(zpusob_vytapeni.Id_stavby))
            {
                node.Attributes[1].Value = zpusob_vytapeni.Platnost_od.ToString();
                node.Attributes[2].Value = zpusob_vytapeni.Platnost_do.ToString();
            }

            xmlDoc.Save(Constants.FilePath);
        }

        public Collection<Zpusob_vytapeni> Select()
        {
            /*
            Collection<Zpusob_vytapeni> vsechnyZpusoby;

            using (StreamReader reader = File.OpenText(Constants.FilePath))
            {
                XmlSerializer xser = new XmlSerializer(typeof(Collection<Zpusob_vytapeni>));
                vsechnyZpusoby = (Collection<Zpusob_vytapeni>)xser.Deserialize(reader);
            }

            return vsechnyZpusoby;
            */

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
