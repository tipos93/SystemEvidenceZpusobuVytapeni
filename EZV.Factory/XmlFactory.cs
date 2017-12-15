using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZV.DAOFactory;
using EZV.XML.Gateway;

namespace EZV.Factory
{
    public class XmlFactory : IDotace_EUFactory, IHistorie_stavbyFactory, IHistorie_vysledku_kontrolyFactory, IKontrola_kvality_spalovaniFactory, IStavbaFactory, IStavbaVlastnikFactory, IVlastnikFactory, IVysledek_kontrolyFactory, IZpusob_vytapeniFactory, IUzivateleFactory
    {
        public IDotace_EU CreateDotace()
        {
            IDotace_EU dotace = new Dotace_EU_XmlMapper();
            return dotace;
        }

        public IHistorie_stavby CreateHistorieStavby()
        {
            IHistorie_stavby historieStavby = new Historie_stavby_XmlMapper();
            return historieStavby;
        }

        public IHistorie_vysledku_kontroly CreateHistoriiVysledkuKontroly()
        {
            IHistorie_vysledku_kontroly historieVysledkuKontroly = new Historie_vysledku_kontroly_XmlMapper();
            return historieVysledkuKontroly;
        }

        public IKontrola_kvality_spalovani CreateKontrola()
        {
            IKontrola_kvality_spalovani kontrola = new Kontrola_kvality_spalovani_XmlMapper();
            return kontrola;
        }

        public IStavba CreateStavba()
        {
            IStavba stavba = new Stavba_XmlMapper();
            return stavba;
        }

        public IStavbaVlastnik CreateStavbaVlastnik()
        {
            IStavbaVlastnik stavbaVlastnik = new StavbaVlastnik_XmlMapper();
            return stavbaVlastnik;
        }

        public IUzivatele CreateUzivatele()
        {
            IUzivatele uzivatele = new Uzivatele_XmlMapper();
            return uzivatele;
        }

        public IVlastnik CreateVlastnik()
        {
            IVlastnik vlastnik = new Vlastnik_XmlMapper();
            return vlastnik;
        }

        public IVysledek_kontroly CreateVysledekKontroly()
        {
            IVysledek_kontroly vysledekKontroly = new Vysledek_kontroly_XmlMapper();
            return vysledekKontroly;
        }

        public IZpusob_vytapeni CreateZpusob()
        {
            IZpusob_vytapeni zpusob = new Zpusob_vytapeni_XmlMapper();
            return zpusob;
        }
    }
}
