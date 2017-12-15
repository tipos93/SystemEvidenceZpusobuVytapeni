using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Collections.ObjectModel;
using EZV.DAOFactory;
using EZV.DTO;
using System.Globalization;

namespace EZV.XML.Gateway
{
    public class Vlastnik_XmlMapper : IVlastnik
    {
        private int hodnotaId = 0;

        private bool kontrolaRodnehoCisla(string pohlavi, string rodneCislo, DateTime datumNarozeni)
        {
            string vytvoreneDatumNarozeni;
            int denNarozeni = int.Parse(datumNarozeni.ToString("dd"));
            int mesicNarozeni = int.Parse(datumNarozeni.ToString("MM"));
            int rokNarozeni = int.Parse(datumNarozeni.ToString("yy"));

            if (pohlavi == "Z")
            {
                vytvoreneDatumNarozeni = rokNarozeni.ToString() + (mesicNarozeni + 50).ToString() + denNarozeni.ToString();
            }
            else
            {
                vytvoreneDatumNarozeni = rokNarozeni.ToString() + mesicNarozeni.ToString() + denNarozeni.ToString();
            }

            if (vytvoreneDatumNarozeni != rodneCislo.Substring(0, 6))
                return false;

            int lichySoucet = 0;
            int sudySoucet = 0;
            for (int i = 0; i < rodneCislo.Length; i++)
            {
                if (i % 2 == 0)
                {
                    lichySoucet = lichySoucet + int.Parse(rodneCislo[i].ToString());
                }
                else
                {
                    sudySoucet = sudySoucet + int.Parse(rodneCislo[i].ToString());
                }
            }

            int rozdil = lichySoucet - sudySoucet;

            if (rozdil % 11 != 0)
                return false;

            return true;
        }

        public int Sequence()
        {
            XDocument xDoc = XDocument.Load(ConstantsXml.FilePath);

            List<XElement> elementy = xDoc.Descendants("Vlastnici").Descendants("Vlastnik").ToList();

            foreach (XElement element in elementy)
            {
                int id = int.Parse(element.Attribute("Id_vlastnika").Value);
                if (id > this.hodnotaId)
                {
                    this.hodnotaId = id;
                }
            }
            return ++this.hodnotaId;
        }

        public void Delete(Vlastnik vlastnik)
        {
            XDocument xDoc = XDocument.Load(ConstantsXml.FilePath);

            var q = from node in xDoc.Descendants("Vlastnici").Descendants("Vlastnik")
                    let attr = node.Attribute("Id_vlastnika")
                    where (attr != null && attr.Value == vlastnik.Id_vlastnika.ToString())
                    select node;
            q.ToList().ForEach(x => x.Attribute("Aktualni_vlastnik").Value = vlastnik.Aktualni_vlastnik);

            xDoc.Save(ConstantsXml.FilePath);
        }

        public void Insert(Vlastnik vlastnik)
        {
            if (this.kontrolaRodnehoCisla(vlastnik.Pohlavi, vlastnik.Rodne_cislo, vlastnik.Datum_narozeni) == false)
                throw new Exception();

            XDocument xDoc = XDocument.Load(ConstantsXml.FilePath);

            XElement result = new XElement("Vlastnik",
                new XAttribute("Id_vlastnika", vlastnik.Id_vlastnika),
                new XAttribute("Jmeno", vlastnik.Jmeno),
                new XAttribute("Prijmeni", vlastnik.Prijmeni),
                new XAttribute("Datum_narozeni", vlastnik.Datum_narozeni.ToShortDateString()),
                new XAttribute("Datum_umrti", vlastnik.Datum_umrti == null ? DBNull.Value : (object)vlastnik.Datum_umrti.ToString()),
                new XAttribute("Rodne_cislo", vlastnik.Rodne_cislo),
                new XAttribute("Pohlavi", vlastnik.Pohlavi),
                new XAttribute("Trvale_bydliste_ulice", vlastnik.Trvale_bydliste_ulice),
                new XAttribute("Trvale_bydliste_cislo_popisne", vlastnik.Trvale_bydliste_cislo_popisne),
                new XAttribute("Trvale_bydliste_mesto", vlastnik.Trvale_bydliste_mesto),
                new XAttribute("Trvale_bydliste_PSC", vlastnik.Trvale_bydliste_PSC),
                new XAttribute("Aktualni_vlastnik", vlastnik.Aktualni_vlastnik));

            xDoc.Root.Element("Vlastnici").Add(result);
            xDoc.Save(ConstantsXml.FilePath);
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
            XDocument xDoc = XDocument.Load(ConstantsXml.FilePath);

            var q = from node in xDoc.Descendants("Vlastnici").Descendants("Vlastnik")
                    let attr = node.Attribute("Id_vlastnika")
                    where (attr != null && attr.Value == vlastnik.Id_vlastnika.ToString())
                    select node;
            q.ToList().ForEach(x => {
                x.Attribute("Jmeno").Value = vlastnik.Jmeno;
                x.Attribute("Prijmeni").Value = vlastnik.Prijmeni;
                x.Attribute("Datum_narozeni").Value = vlastnik.Datum_narozeni.ToShortDateString();
                x.Attribute("Datum_umrti").Value = vlastnik.Datum_umrti.ToString();
                x.Attribute("Rodne_cislo").Value = vlastnik.Rodne_cislo;
                x.Attribute("Pohlavi").Value = vlastnik.Pohlavi;
                x.Attribute("Trvale_bydliste_ulice").Value = vlastnik.Trvale_bydliste_ulice;
                x.Attribute("Trvale_bydliste_cislo_popisne").Value = vlastnik.Trvale_bydliste_cislo_popisne.ToString();
                x.Attribute("Trvale_bydliste_mesto").Value = vlastnik.Trvale_bydliste_mesto;
                x.Attribute("Trvale_bydliste_PSC").Value = vlastnik.Trvale_bydliste_PSC;
                x.Attribute("Aktualni_vlastnik").Value = vlastnik.Aktualni_vlastnik;
            });

            xDoc.Save(ConstantsXml.FilePath);
        }

        public Collection<Vlastnik> Select()
        {
            XDocument xDoc = XDocument.Load(ConstantsXml.FilePath);

            List<XElement> elementy = xDoc.Descendants("Vlastnici").Descendants("Vlastnik").ToList();

            Collection<Vlastnik> vsichniVlastnici = new Collection<Vlastnik>();
            int id;
            DateTime datumNarozeni;
            DateTime datumUmrti;
            int cisloPopisne;

            foreach (XElement element in elementy)
            {
                Vlastnik vlastnik = new Vlastnik();

                int.TryParse(element.Attribute("Id_vlastnika").Value, out id);
                vlastnik.Jmeno = element.Attribute("Jmeno").Value;
                vlastnik.Prijmeni = element.Attribute("Prijmeni").Value;
                DateTime.TryParse(element.Attribute("Datum_narozeni").Value, out datumNarozeni);
                try
                {
                    DateTime.TryParse(element.Attribute("Datum_umrti").Value, out datumUmrti);
                    vlastnik.Datum_umrti = datumUmrti;
                }
                catch(Exception e)
                {
                    vlastnik.Datum_umrti = null;
                }
                vlastnik.Rodne_cislo = element.Attribute("Rodne_cislo").Value;
                vlastnik.Pohlavi = element.Attribute("Pohlavi").Value;
                vlastnik.Trvale_bydliste_ulice = element.Attribute("Trvale_bydliste_ulice").Value;
                int.TryParse(element.Attribute("Trvale_bydliste_cislo_popisne").Value, out cisloPopisne);
                vlastnik.Trvale_bydliste_mesto = element.Attribute("Trvale_bydliste_mesto").Value;
                vlastnik.Trvale_bydliste_PSC = element.Attribute("Trvale_bydliste_PSC").Value;
                vlastnik.Aktualni_vlastnik = element.Attribute("Aktualni_vlastnik").Value;
                
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
