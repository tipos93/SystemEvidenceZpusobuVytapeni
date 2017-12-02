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
    public class StavbaVlastnik_Gateway : IStavbaVlastnik
    {
        /*
        public static XElement Insert(int Id_stavby, int Id_vlastnika)
        {
            XElement result = new XElement("StavbaVlastnik",
                new XAttribute("Id stavby", Id_stavby),
                new XAttribute("Id vlastnika", Id_vlastnika));

            return result;
        }*/

        /*
        public static List<XElement> Select()
        {
            XDocument xDoc = XDocument.Load(Constants.FilePath);

            List<XElement> elementy = xDoc.Descendants("StavbyVlastnici").Descendants("StavbaVlastnik").ToList();

            return elementy;
        }*/

        public void Insert(StavbaVlastnik stavbaVlastnik)
        {
            XElement result = new XElement("StavbaVlastnik",
                new XAttribute("Id_stavby", stavbaVlastnik.Id_stavby),
                new XAttribute("Id_vlastnika", stavbaVlastnik.Id_vlastnika));
        }

        public void Update(StavbaVlastnik stavbaVlastnik)
        {
            XDocument xDoc = XDocument.Load(Constants.FilePath);

            List<XElement> elementy = xDoc.Descendants("StavbyVlastnici").Descendants("StavbaVlastnik").ToList();

            //vytvoreni DTO pro praci s daty
            Stavba vybranaStavba = new Stavba();
            Vlastnik vlastnikProUpravu = new Vlastnik();

            //pristup k jinym tridam
            Stavba_Gateway stavbaGateway = new Stavba_Gateway();
            Historie_stavby_Gateway historieStavbyGateway = new Historie_stavby_Gateway();
            Vlastnik_Gateway vlastnikGateway = new Vlastnik_Gateway();

            //nahrani vsech informaci o stavbe, ktera je aktualizovana
            vybranaStavba = stavbaGateway.Select_id(stavbaVlastnik.Id_stavby);

            //vyber vsech vlastniku staveb
            Collection<StavbaVlastnik> stavbyVlastnici = this.Select();
            foreach(StavbaVlastnik vlastnik in stavbyVlastnici)
            {
                //vyber vlastniku, kteri vlastni upravovanou stavbu
                if(vlastnik.Id_stavby == stavbaVlastnik.Id_stavby)
                {
                    foreach (XElement element in elementy)
                    {
                        //odstraneni vsech vlastniku upravovane stavby
                        if(int.Parse(element.Attribute("Id_stavby").Value) == stavbaVlastnik.Id_stavby 
                            && int.Parse(element.Attribute("Id_vlastnika").Value) == vlastnik.Id_vlastnika)
                        {
                            element.Remove();
                        }
                    }

                    Historie_stavby historieStavby = new Historie_stavby();

                    historieStavby.Id_zmeny = historieStavbyGateway.Sequence();
                    historieStavby.Typ_stavby = vybranaStavba.Typ_stavby;
                    historieStavby.Ulice = vybranaStavba.Ulice;
                    historieStavby.Cislo_popisne = vybranaStavba.Cislo_popisne;
                    historieStavby.Cislo_stavby_na_KU = vybranaStavba.Cislo_stavby_na_KU;
                    historieStavby.Nazev_KU = vybranaStavba.Nazev_KU;
                    historieStavby.Datum_kolaudace = vybranaStavba.Datum_kolaudace;
                    historieStavby.Casovy_okamzik_zmeny = DateTime.Now;
                    historieStavby.Id_vlastnika = vlastnik.Id_vlastnika;
                    historieStavby.Id_stavby = stavbaVlastnik.Id_stavby;

                    //vlozeni smazaneho zaznamu do archivace
                    historieStavbyGateway.Insert(historieStavby);

                    //znovunacteni vsech vlastniku staveb
                    Collection<StavbaVlastnik> upraveniStavbyVlastnici = this.Select();
                    int pocetZaznamuVlastnika = 0;
                    foreach(StavbaVlastnik stavbyVlastnik in upraveniStavbyVlastnici)
                    {
                        //kontrola, jestli odstraneny vlastnik vlastni jeste nejakou stavbu nebo uz ne
                        if(stavbyVlastnik.Id_vlastnika == vlastnik.Id_vlastnika)
                        {
                            pocetZaznamuVlastnika++;
                        }
                    }

                    //pokud nevlastni uz zadnou stavbu, pak se zrusi jeho aktualnost
                    if(pocetZaznamuVlastnika == 0)
                    {
                        vlastnikProUpravu.Id_vlastnika = vlastnik.Id_vlastnika;
                        vlastnikProUpravu.Aktualni_vlastnik = "N";

                        vlastnikGateway = new Vlastnik_Gateway();
                        vlastnikGateway.Update(vlastnikProUpravu);
                    }
                }
            }

            //vlozeni noveho upraveneho zaznamu
            this.Insert(stavbaVlastnik);

            //nastaveni aktualniho vlastnika
            vlastnikProUpravu.Id_vlastnika = stavbaVlastnik.Id_vlastnika;
            vlastnikProUpravu.Aktualni_vlastnik = "A";
            vlastnikGateway.Update(vlastnikProUpravu);

            /*
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load(Constants.FilePath);

            XmlNode node = xmlDoc.SelectSingleNode("Databaze/StavbyVlastnici/StavbaVlastnik");

            if (node.Attributes[0].Value.Equals(stavbaVlastnik.Id_stavby))
            {
                node.Attributes[1].Value = stavbaVlastnik.Id_vlastnika.ToString();
            }

            xmlDoc.Save(Constants.FilePath);
            */
        }

        public Collection<StavbaVlastnik> Select()
        {
            /*
            Collection<StavbaVlastnik> vsichniStavbyVlastnici;

            using (StreamReader reader = File.OpenText(Constants.FilePath))
            {
                XmlSerializer xser = new XmlSerializer(typeof(Collection<StavbaVlastnik>));
                vsichniStavbyVlastnici = (Collection<StavbaVlastnik>)xser.Deserialize(reader);
            }

            return vsichniStavbyVlastnici;
            */

            XDocument xDoc = XDocument.Load(Constants.FilePath);

            List<XElement> elementy = xDoc.Descendants("StavbyVlastnici").Descendants("StavbaVlastnik").ToList();

            Collection<StavbaVlastnik> vsichniStavbyVlastnici = new Collection<StavbaVlastnik>();
            int idStavby;
            int idVlastnika;

            foreach (XElement element in elementy)
            {
                StavbaVlastnik stavbaVlastnik = new StavbaVlastnik();

                int.TryParse(element.Attribute("Id_stavby").Value, out idStavby);
                int.TryParse(element.Attribute("Id_vlastnika").Value, out idVlastnika);

                stavbaVlastnik.Id_stavby = idStavby;
                stavbaVlastnik.Id_vlastnika = idVlastnika;

                vsichniStavbyVlastnici.Add(stavbaVlastnik);
                stavbaVlastnik = null;
            }

            return vsichniStavbyVlastnici;
        }
    }
}
