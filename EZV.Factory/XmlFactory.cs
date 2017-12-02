using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZV.DAOFactory;
using EZV.XML.Gateway;

namespace EZV.Factory
{
    public class XmlFactory : IDotace_EUFactory, IHistorie_stavbyFactory, IHistorie_vysledku_kontrolyFactory, IKontrola_kvality_spalovaniFactory, IStavbaFactory, IStavbaVlastnikFactory, IVlastnikFactory, IVysledek_kontrolyFactory, IZpusob_vytapeniFactory
    {
        public IDotace_EU CreateDotace()
        {
            IDotace_EU dotace = new Dotace_EU_Gateway();
            return dotace;
        }

        public IHistorie_stavby CreateHistorieStavby()
        {
            IHistorie_stavby historieStavby = new Historie_stavby_Gateway();
            return historieStavby;
        }

        public IHistorie_vysledku_kontroly CreateHistoriiVysledkuKontroly()
        {
            IHistorie_vysledku_kontroly historieVysledkuKontroly = new Historie_vysledku_kontroly_Gateway();
            return historieVysledkuKontroly;
        }

        public IKontrola_kvality_spalovani CreateKontrola()
        {
            IKontrola_kvality_spalovani kontrola = new Kontrola_kvality_spalovani_Gateway();
            return kontrola;
        }

        public IStavba CreateStavba()
        {
            IStavba stavba = new Stavba_Gateway();
            return stavba;
        }

        public IStavbaVlastnik CreateStavbaVlastnik()
        {
            IStavbaVlastnik stavbaVlastnik = new StavbaVlastnik_Gateway();
            return stavbaVlastnik;
        }

        public IVlastnik CreateVlastnik()
        {
            IVlastnik vlastnik = new Vlastnik_Gateway();
            return vlastnik;
        }

        public IVysledek_kontroly CreateVysledekKontroly()
        {
            IVysledek_kontroly vysledekKontroly = new Vysledek_kontroly_Gateway();
            return vysledekKontroly;
        }

        public IZpusob_vytapeni CreateZpusob()
        {
            IZpusob_vytapeni zpusob = new Zpusob_vytapeni_Gateway();
            return zpusob;
        }
    }
}
