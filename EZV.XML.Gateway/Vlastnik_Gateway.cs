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
    public class Vlastnik_Gateway : IVlastnik
    {
        /*
        public static XElement Insert(int Id_vlastnika, string Jmeno, string Prijmeni, DateTime Datum_narozeni, DateTime? Datum_umrti, string Rodne_cislo, string Pohlavi, string Trvale_bydliste_ulice, int Trvale_bydliste_cislo_popisne, string Trvale_bydliste_mesto, string Trvale_bydliste_PSC, string Aktualni_vlastnik, string Vypis)
        {
            XElement result = new XElement("Vlastnik",
                new XAttribute("Id vlastnika", Id_vlastnika),
                new XAttribute("Jmeno", Jmeno),
                new XAttribute("Prijmeni", Prijmeni),
                new XAttribute("Datum narozeni", Datum_narozeni),
                new XAttribute("Datum umrti", Datum_umrti == null ? DBNull.Value : (object)Datum_umrti),
                new XAttribute("Rodne cislo", Rodne_cislo),
                new XAttribute("Pohlavi", Pohlavi),
                new XAttribute("Trvale bydliste ulice", Trvale_bydliste_ulice),
                new XAttribute("Trvale bydliste cislo popisne", Trvale_bydliste_cislo_popisne),
                new XAttribute("Trvale bydliste mesto", Trvale_bydliste_mesto),
                new XAttribute("Trvale bydliste PSC", Trvale_bydliste_PSC),
                new XAttribute("Aktualni vlastnik", Aktualni_vlastnik),
                new XAttribute("Vypis", Vypis));

            return result;
        }*/

        /*
        public static List<XElement> Select()
        {
            XDocument xDoc = XDocument.Load(Constants.FilePath);

            List<XElement> elementy = xDoc.Descendants("Vlastnici").Descendants("Vlastnik").ToList();

            return elementy;
        }*/

        public void Delete(Vlastnik vlastnik)
        {
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load(Constants.FilePath);

            XmlNode node = xmlDoc.SelectSingleNode("Database/Vlastnici/Vlastnik");
            if (node.Attributes[0].Value.Equals(vlastnik.Id_vlastnika))
            {
                node.Attributes[11].Value = vlastnik.Aktualni_vlastnik;
            }

            xmlDoc.Save(Constants.FilePath);
        }

        public void Insert(Vlastnik vlastnik)
        {
            XElement result = new XElement("Vlastnik",
                new XAttribute("Id vlastnika", vlastnik.Id_vlastnika),
                new XAttribute("Jmeno", vlastnik.Jmeno),
                new XAttribute("Prijmeni", vlastnik.Prijmeni),
                new XAttribute("Datum narozeni", vlastnik.Datum_narozeni),
                new XAttribute("Datum umrti", vlastnik.Datum_umrti == null ? DBNull.Value : (object)vlastnik.Datum_umrti),
                new XAttribute("Rodne cislo", vlastnik.Rodne_cislo),
                new XAttribute("Pohlavi", vlastnik.Pohlavi),
                new XAttribute("Trvale bydliste ulice", vlastnik.Trvale_bydliste_ulice),
                new XAttribute("Trvale bydliste cislo popisne", vlastnik.Trvale_bydliste_cislo_popisne),
                new XAttribute("Trvale bydliste mesto", vlastnik.Trvale_bydliste_mesto),
                new XAttribute("Trvale bydliste PSC", vlastnik.Trvale_bydliste_PSC),
                new XAttribute("Aktualni vlastnik", vlastnik.Aktualni_vlastnik));
        }

        public Vlastnik Select_id(int idVlastnik)
        {
            Collection<Vlastnik> vsichniVlastnici = this.Select();
            Vlastnik vybranyVlastnik = null;

            foreach (Vlastnik vlastnik in vsichniVlastnici)
            {
                if (vlastnik.Id_vlastnika == idVlastnik)
                {
                    vybranyVlastnik = vlastnik;
                }
            }

            return vybranyVlastnik;
        }

        public void Update(Vlastnik vlastnik)
        {
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load(Constants.FilePath);

            XmlNode node = xmlDoc.SelectSingleNode("Database/Vlastnici/Vlastnik");
            if (node.Attributes[0].Value.Equals(vlastnik.Id_vlastnika))
            {
                node.Attributes[1].Value = vlastnik.Jmeno;
                node.Attributes[2].Value = vlastnik.Prijmeni;
                node.Attributes[3].Value = vlastnik.Datum_narozeni.ToString();
                node.Attributes[4].Value = vlastnik.Datum_umrti.ToString();
                node.Attributes[5].Value = vlastnik.Rodne_cislo;
                node.Attributes[6].Value = vlastnik.Pohlavi;
                node.Attributes[7].Value = vlastnik.Trvale_bydliste_ulice;
                node.Attributes[8].Value = vlastnik.Trvale_bydliste_cislo_popisne.ToString();
                node.Attributes[9].Value = vlastnik.Trvale_bydliste_mesto;
                node.Attributes[10].Value = vlastnik.Trvale_bydliste_PSC;
                node.Attributes[11].Value = vlastnik.Aktualni_vlastnik;
            }

            xmlDoc.Save(Constants.FilePath);
        }

        public Collection<Vlastnik> Select()
        {
            /*
            Collection<Vlastnik> vsichniVlastnici;

            using (StreamReader reader = File.OpenText(Constants.FilePath))
            {
                XmlSerializer xser = new XmlSerializer(typeof(Collection<Vlastnik>));
                vsichniVlastnici = (Collection<Vlastnik>)xser.Deserialize(reader);
            }

            return vsichniVlastnici;
            */

            XDocument xDoc = XDocument.Load(Constants.FilePath);

            List<XElement> elementy = xDoc.Descendants("Vlastnici").Descendants("Vlastnik").ToList();

            Collection<Vlastnik> vsichniVlastnici = new Collection<Vlastnik>();
            int id;
            DateTime datumNarozeni;
            DateTime datumUmrti;
            int cisloPopisne;

            foreach (XElement element in elementy)
            {
                Vlastnik vlastnik = new Vlastnik();

                int.TryParse(element.Attribute("Id vlastnika").Value, out id);
                vlastnik.Jmeno = element.Attribute("Jmeno").Value;
                vlastnik.Prijmeni = element.Attribute("Prijmeni").Value;
                DateTime.TryParse(element.Attribute("Datum narozeni").Value, out datumNarozeni);
                try
                {
                    DateTime.TryParse(element.Attribute("Datum umrti").Value, out datumUmrti);
                    vlastnik.Datum_umrti = datumUmrti;
                }
                catch(Exception e)
                {
                    vlastnik.Datum_umrti = null;
                }
                vlastnik.Rodne_cislo = element.Attribute("Rodne cislo").Value;
                vlastnik.Pohlavi = element.Attribute("Pohlavi").Value;
                vlastnik.Trvale_bydliste_ulice = element.Attribute("Trvale bydliste ulice").Value;
                int.TryParse(element.Attribute("Trvale bydliste cislo popisne").Value, out cisloPopisne);
                vlastnik.Trvale_bydliste_mesto = element.Attribute("Trvale bydliste mesto").Value;
                vlastnik.Trvale_bydliste_PSC = element.Attribute("Trvale bydliste PSC").Value;
                vlastnik.Aktualni_vlastnik = element.Attribute("Aktualni vlastnik").Value;
                
                vlastnik.Id_vlastnika = id;
                vlastnik.Datum_narozeni = datumNarozeni;
                vlastnik.Trvale_bydliste_cislo_popisne = cisloPopisne;

                vsichniVlastnici.Add(vlastnik);
                vlastnik = null;
            }

            return vsichniVlastnici;
        }
    }
}
