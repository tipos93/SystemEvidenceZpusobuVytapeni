using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZV.DAOFactory;
using EZV.DataMapper;

namespace EZV.Factory
{
    public class SqlFactory : IDotace_EUFactory, IHistorie_stavbyFactory, IHistorie_vysledku_kontrolyFactory, IKontrola_kvality_spalovaniFactory, IStavbaFactory, IStavbaVlastnikFactory, IVlastnikFactory, IVysledek_kontrolyFactory, IZpusob_vytapeniFactory, IUzivateleFactory
    {
        public IDotace_EU CreateDotace()
        {
            IDotace_EU dotace = new Dotace_EU_SqlMapper();
            return dotace;
        }

        public IHistorie_stavby CreateHistorieStavby()
        {
            IHistorie_stavby historieStavby = new Historie_stavby_SqlMapper();
            return historieStavby;
        }

        public IHistorie_vysledku_kontroly CreateHistoriiVysledkuKontroly()
        {
            IHistorie_vysledku_kontroly historieVysledkuKontroly = new Historie_vysledku_kontroly_SqlMapper();
            return historieVysledkuKontroly;
        }

        public IKontrola_kvality_spalovani CreateKontrola()
        {
            IKontrola_kvality_spalovani kontrola = new Kontrola_kvality_spalovani_SqlMapper();
            return kontrola;
        }

        public IStavba CreateStavba()
        {
            IStavba stavba = new Stavba_SqlMapper();
            return stavba;
        }

        public IStavbaVlastnik CreateStavbaVlastnik()
        {
            IStavbaVlastnik stavbaVlastnik = new StavbaVlastnik_SqlMapper();
            return stavbaVlastnik;
        }

        public IUzivatele CreateUzivatele()
        {
            IUzivatele uzivatele = new Uzivatele_SqlMapper();
            return uzivatele;
        }

        public IVlastnik CreateVlastnik()
        {
            IVlastnik vlastnik = new Vlastnik_SqlMapper();
            return vlastnik;
        }

        public IVysledek_kontroly CreateVysledekKontroly()
        {
            IVysledek_kontroly vysledekKontroly = new Vysledek_kontroly_SqlMapper();
            return vysledekKontroly;
        }

        public IZpusob_vytapeni CreateZpusob()
        {
            IZpusob_vytapeni zpusob = new Zpusob_vytapeni_SqlMapper();
            return zpusob;
        }
    }
}
