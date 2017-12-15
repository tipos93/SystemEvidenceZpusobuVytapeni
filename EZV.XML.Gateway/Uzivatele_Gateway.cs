using EZV.DAOFactory;
using System;
using EZV.DTO;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;

namespace EZV.XML.Gateway
{
    public class Uzivatele_Gateway : IUzivatele
    {
        public void Delete(Uzivatele uzivatele)
        {
            XDocument xDoc = XDocument.Load(Constants.FilePath);

            var q = from node in xDoc.Descendants("Uzivatele").Descendants("Uzivatel")
                    let attr = node.Attribute("Login")
                    where (attr != null && attr.Value == uzivatele.Login)
                    select node;
            q.ToList().ForEach(x => x.Attribute("Aktualnost").Value = uzivatele.Aktualnost);

            xDoc.Save(Constants.FilePath);
        }

        public void Insert(Uzivatele uzivatele)
        {
            XDocument xDoc = XDocument.Load(Constants.FilePath);

            XElement result = new XElement("Uzivatel",
                new XAttribute("Login", uzivatele.Login),
                new XAttribute("Heslo", uzivatele.Heslo),
                new XAttribute("Postaveni", uzivatele.Postaveni),
                new XAttribute("Aktualnost", uzivatele.Aktualnost),
                new XAttribute("Id_vlastnika", uzivatele.Id_vlastnika));

            xDoc.Root.Element("Uzivatele").Add(result);
            xDoc.Save(Constants.FilePath);
        }

        public Collection<Uzivatele> Select()
        {
            XDocument xDoc = XDocument.Load(Constants.FilePath);

            List<XElement> elementy = xDoc.Descendants("Uzivatele").Descendants("Uzivatel").ToList();

            Collection<Uzivatele> vsichniUzivatele = new Collection<Uzivatele>();
            int idVlastnika;

            foreach (XElement element in elementy)
            {
                Uzivatele uzivatel = new Uzivatele();

                uzivatel.Login = element.Attribute("Login").Value;
                uzivatel.Heslo = element.Attribute("Heslo").Value;
                uzivatel.Postaveni = element.Attribute("Postaveni").Value;
                uzivatel.Aktualnost = element.Attribute("Aktualnost").Value;
                int.TryParse(element.Attribute("Id_vlastnika").Value, out idVlastnika);

                uzivatel.Id_vlastnika = idVlastnika;

                vsichniUzivatele.Add(uzivatel);
                uzivatel = null;
            }

            return vsichniUzivatele;
        }

        public Uzivatele Select_id(string loginUzivatele)
        {
            Collection<Uzivatele> vsichniUzivatele = this.Select();
            Uzivatele vybranyUzivatel = null;

            foreach (Uzivatele uzivatel in vsichniUzivatele)
            {
                if (uzivatel.Login.Equals(loginUzivatele))
                {
                    vybranyUzivatel = uzivatel;
                }
            }

            return vybranyUzivatel;
        }

        public void Update(Uzivatele uzivatele)
        {
            XDocument xDoc = XDocument.Load(Constants.FilePath);

            var q = from node in xDoc.Descendants("Uzivatele").Descendants("Uzivatel")
                    let attr = node.Attribute("Login")
                    where (attr != null && attr.Value == uzivatele.Login)
                    select node;
            q.ToList().ForEach(x => {
                x.Attribute("Heslo").Value = uzivatele.Heslo;
                x.Attribute("Postaveni").Value = uzivatele.Postaveni;
                x.Attribute("Aktualnost").Value = uzivatele.Aktualnost;
                x.Attribute("Id_vlastnika").Value = uzivatele.Id_vlastnika.ToString();
            });

            xDoc.Save(Constants.FilePath);
        }
    }
}
