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
    public class Historie_vysledku_kontroly_Gateway : IHistorie_vysledku_kontroly
    {
        private int hodnotaId = 0;

        public int Sequence()
        {
            XDocument xDoc = XDocument.Load(Constants.FilePath);

            List<XElement> elementy = xDoc.Descendants("Historie_vysledku_kontrol").Descendants("Historie_vysledku_kontroly").ToList();

            foreach (XElement element in elementy)
            {
                int id = int.Parse(element.Attribute("Id_vysledku").Value);
                if (id > this.hodnotaId)
                {
                    this.hodnotaId = id;
                }
            }
            return ++this.hodnotaId;
        }

        public Historie_vysledku_kontroly Select_id(int idZmeny)
        {
            Collection<Historie_vysledku_kontroly> vsechnyHistorie = this.Select();
            Historie_vysledku_kontroly vybranaHistorie = null;

            foreach (Historie_vysledku_kontroly historie in vsechnyHistorie)
            {
                if (historie.Id_zmeny == idZmeny)
                {
                    vybranaHistorie = historie;
                }
            }

            return vybranaHistorie;
        }

        public Collection<Historie_vysledku_kontroly> Select()
        {
            XDocument xDoc = XDocument.Load(Constants.FilePath);

            List<XElement> elementy = xDoc.Descendants("Historie_vysledku_kontrol").Descendants("Historie_vysledku_kontroly").ToList();

            Collection<Historie_vysledku_kontroly> vsechnyHistorieVysledku = new Collection<Historie_vysledku_kontroly>();
            int id;
            DateTime okamzikZmeny;
            int idVysledku;

            foreach (XElement element in elementy)
            {
                Historie_vysledku_kontroly historieVysledku = new Historie_vysledku_kontroly();

                int.TryParse(element.Attribute("Id_vysledku").Value, out id);
                historieVysledku.Vysledek_kontroly = element.Attribute("Vysledek_kontroly").Value;
                historieVysledku.Prijata_opatreni = element.Attribute("Prijata_opatreni").Value;
                DateTime.TryParse(element.Attribute("Casovy_okamzik_zmeny").Value, out okamzikZmeny);
                int.TryParse(element.Attribute("Id_vysledku").Value, out idVysledku);
                
                historieVysledku.Id_zmeny = id;
                historieVysledku.Casovy_okamzik_zmeny = okamzikZmeny;
                historieVysledku.Id_vysledku = idVysledku;

                vsechnyHistorieVysledku.Add(historieVysledku);
                historieVysledku = null;
            }

            return vsechnyHistorieVysledku;
        }
    }
}
