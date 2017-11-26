﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;
using EZV.DAOFactory;
using EZV.DTO;

namespace EZV.XML.Gateway
{
    public class Historie_vysledku_kontroly_Gateway : IHistorie_vysledku_kontroly
    {
        /*
        public static XElement Insert(int Id_zmeny, string Vysledek_kontroly, string Prijata_opatreni, DateTime Casovy_okamzik_zmeny, int Id_vysledku)
        {
            XElement result = new XElement("Historie vysledku kontroly",
                new XAttribute("Id zmeny", Id_zmeny),
                new XAttribute("Vysledek kontroly", Vysledek_kontroly),
                new XAttribute("Prijata opatreni", Prijata_opatreni),
                new XAttribute("Casovy okamzik zmeny", Casovy_okamzik_zmeny),
                new XAttribute("Id vysledku", Id_vysledku));

            return result;
        }*/

        /*
        public static List<XElement> Select()
        {
            XDocument xDoc = XDocument.Load(Constants.FilePath);

            List<XElement> elementy = xDoc.Descendants("Historie vysledku kontrol").Descendants("Historie vysledku kontroly").ToList();

            return elementy;
        }*/

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
            /*
            Collection<Historie_vysledku_kontroly> vsechnyHistorie;

            using (StreamReader reader = File.OpenText(Constants.FilePath))
            {
                XmlSerializer xser = new XmlSerializer(typeof(Collection<Historie_vysledku_kontroly>));
                vsechnyHistorie = (Collection<Historie_vysledku_kontroly>)xser.Deserialize(reader);
            }

            return vsechnyHistorie;
            */

            XDocument xDoc = XDocument.Load(Constants.FilePath);

            List<XElement> elementy = xDoc.Descendants("Historie vysledku kontrol").Descendants("Historie vysledku kontroly").ToList();

            Collection<Historie_vysledku_kontroly> vsechnyHistorieVysledku = new Collection<Historie_vysledku_kontroly>();
            int id;
            DateTime okamzikZmeny;
            int idVysledku;

            foreach (XElement element in elementy)
            {
                Historie_vysledku_kontroly historieVysledku = new Historie_vysledku_kontroly();

                int.TryParse(element.Attribute("Id vysledku").Value, out id);
                historieVysledku.Vysledek_kontroly = element.Attribute("Vysledek kontroly").Value;
                historieVysledku.Prijata_opatreni = element.Attribute("Prijata opatreni").Value;
                DateTime.TryParse(element.Attribute("Casovy okamzik zmeny").Value, out okamzikZmeny);
                int.TryParse(element.Attribute("Id vysledku").Value, out idVysledku);
                
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
