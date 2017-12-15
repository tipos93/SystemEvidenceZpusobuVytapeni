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
    public class StavbaVlastnik_XmlMapper : IStavbaVlastnik
    {
        public void Insert(StavbaVlastnik stavbaVlastnik)
        {
            XDocument xDoc = XDocument.Load(ConstantsXml.FilePath);

            XElement result = new XElement("StavbaVlastnik",
                new XAttribute("Id_stavby", stavbaVlastnik.Id_stavby),
                new XAttribute("Id_vlastnika", stavbaVlastnik.Id_vlastnika));

            xDoc.Root.Element("StavbyVlastnici").Add(result);
            xDoc.Save(ConstantsXml.FilePath);
        }

        public void Update(StavbaVlastnik stavbaVlastnik)
        {
            //XDocument xDoc = XDocument.Load(Constants.FilePath);

            //List<XElement> elementy = xDoc.Descendants("StavbyVlastnici").Descendants("StavbaVlastnik").ToList();

            //vytvoreni DTO pro praci s daty
            Stavba vybranaStavba = new Stavba();
            Vlastnik vlastnikProUpravu = new Vlastnik();

            //pristup k jinym tridam
            Stavba_XmlMapper stavbaGateway = new Stavba_XmlMapper();
            Historie_stavby_XmlMapper historieStavbyGateway = new Historie_stavby_XmlMapper();
            Vlastnik_XmlMapper vlastnikGateway = new Vlastnik_XmlMapper();

            //nahrani vsech informaci o stavbe, ktera je aktualizovana
            vybranaStavba = stavbaGateway.Select_id(stavbaVlastnik.Id_stavby);

            //vyber vsech vlastniku staveb
            Collection<StavbaVlastnik> stavbyVlastnici = this.Select();
            foreach(StavbaVlastnik vlastnik in stavbyVlastnici)
            {
                //vyber vlastniku, kteri vlastni upravovanou stavbu
                if(vlastnik.Id_stavby == stavbaVlastnik.Id_stavby)
                {
                    //nacitani z xml a hledani polozky s id upravovane stavby a id vlastniku, kteri ji vlastni, pro mozne smazani
                    XDocument xDoc = XDocument.Load(ConstantsXml.FilePath);
                    var q = from node in xDoc.Descendants("StavbyVlastnici").Descendants("StavbaVlastnik")
                            let attr = node.Attribute("Id_stavby")
                            let attr1 = node.Attribute("Id_vlastnika")
                            where (attr != null && attr.Value == stavbaVlastnik.Id_stavby.ToString()) && (attr1 != null && attr1.Value == vlastnik.Id_vlastnika.ToString())
                            select node;
                    q.ToList().ForEach(x => x.Remove());
                    xDoc.Save(ConstantsXml.FilePath);

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

                        vlastnikGateway.Delete(vlastnikProUpravu);
                    }
                }
            }

            //vlozeni noveho upraveneho zaznamu
            this.Insert(stavbaVlastnik);

            //nastaveni aktualniho vlastnika
            vlastnikProUpravu.Id_vlastnika = stavbaVlastnik.Id_vlastnika;
            vlastnikProUpravu.Aktualni_vlastnik = "A";
            vlastnikGateway.Delete(vlastnikProUpravu);
        }

        public Collection<StavbaVlastnik> Select()
        {
            XDocument xDoc = XDocument.Load(ConstantsXml.FilePath);

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
