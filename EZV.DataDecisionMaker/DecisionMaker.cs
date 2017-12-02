﻿using EZV.DAOFactory;
using EZV.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZV.DataDecisionMaker
{
    public static class DecisionMaker
    {
        public enum Items
        {
            Dotace, HistorieStavby, HistorieVysledku, Kontrola, Stavba, StavbaVlastnik, Vlastnik, Vysledek, Zpusob
        };

        private static SqlFactory NewSQLFactory()
        {
            return (new SqlFactory());
        }

        private static XmlFactory NewXMLFactory()
        {
            return (new XmlFactory());
        }

        public static object DecideSQL(Items items)
        {
            if (items == Items.Dotace)
            {
                IDotace_EUFactory dotaceFactory = NewSQLFactory();
                IDotace_EU dotace = dotaceFactory.CreateDotace();

                return dotace;
            }
            else if (items == Items.HistorieStavby)
            {
                IHistorie_stavbyFactory historieStavbyFactory = NewSQLFactory();
                IHistorie_stavby historieStavby = historieStavbyFactory.CreateHistorieStavby();

                return historieStavby;
            }
            else if (items == Items.HistorieVysledku)
            {
                IHistorie_vysledku_kontrolyFactory historieVysledkuFactory = NewSQLFactory();
                IHistorie_vysledku_kontroly historieVysledku = historieVysledkuFactory.CreateHistoriiVysledkuKontroly();

                return historieVysledku;
            }
            else if (items == Items.Kontrola)
            {
                IKontrola_kvality_spalovaniFactory kontrolaFactory = NewSQLFactory();
                IKontrola_kvality_spalovani kontrola = kontrolaFactory.CreateKontrola();

                return kontrola;
            }
            else if (items == Items.Stavba)
            {
                IStavbaFactory stavbaFactory = NewSQLFactory();
                IStavba stavba = stavbaFactory.CreateStavba();

                return stavba;
            }
            else if (items == Items.StavbaVlastnik)
            {
                IStavbaVlastnikFactory stavbaVlastnikFactory = NewSQLFactory();
                IStavbaVlastnik stavbaVlastnik = stavbaVlastnikFactory.CreateStavbaVlastnik();

                return stavbaVlastnik;
            }
            else if (items == Items.Vlastnik)
            {
                IVlastnikFactory vlastnikFactory = NewSQLFactory();
                IVlastnik vlastnik = vlastnikFactory.CreateVlastnik();

                return vlastnik;
            }
            else if (items == Items.Vysledek)
            {
                IVysledek_kontrolyFactory vysledekFactory = NewSQLFactory();
                IVysledek_kontroly vysledek = vysledekFactory.CreateVysledekKontroly();

                return vysledek;
            }
            else if (items == Items.Zpusob)
            {
                IZpusob_vytapeniFactory zpusobFactory = NewSQLFactory();
                IZpusob_vytapeni zpusob = zpusobFactory.CreateZpusob();

                return zpusob;
            }

            return null;
        }

        public static object DecideXML(Items items)
        {
            if (items == Items.Dotace)
            {
                IDotace_EUFactory dotaceFactory = NewXMLFactory();
                IDotace_EU dotace = dotaceFactory.CreateDotace();

                return dotace;
            }
            else if (items == Items.HistorieStavby)
            {
                IHistorie_stavbyFactory historieStavbyFactory = NewXMLFactory();
                IHistorie_stavby historieStavby = historieStavbyFactory.CreateHistorieStavby();

                return historieStavby;
            }
            else if (items == Items.HistorieVysledku)
            {
                IHistorie_vysledku_kontrolyFactory historieVysledkuFactory = NewXMLFactory();
                IHistorie_vysledku_kontroly historieVysledku = historieVysledkuFactory.CreateHistoriiVysledkuKontroly();

                return historieVysledku;
            }
            else if (items == Items.Kontrola)
            {
                IKontrola_kvality_spalovaniFactory kontrolaFactory = NewXMLFactory();
                IKontrola_kvality_spalovani kontrola = kontrolaFactory.CreateKontrola();

                return kontrola;
            }
            else if (items == Items.Stavba)
            {
                IStavbaFactory stavbaFactory = NewXMLFactory();
                IStavba stavba = stavbaFactory.CreateStavba();

                return stavba;
            }
            else if (items == Items.StavbaVlastnik)
            {
                IStavbaVlastnikFactory stavbaVlastnikFactory = NewXMLFactory();
                IStavbaVlastnik stavbaVlastnik = stavbaVlastnikFactory.CreateStavbaVlastnik();

                return stavbaVlastnik;
            }
            else if (items == Items.Vlastnik)
            {
                IVlastnikFactory vlastnikFactory = NewXMLFactory();
                IVlastnik vlastnik = vlastnikFactory.CreateVlastnik();

                return vlastnik;
            }
            else if (items == Items.Vysledek)
            {
                IVysledek_kontrolyFactory vysledekFactory = NewXMLFactory();
                IVysledek_kontroly vysledek = vysledekFactory.CreateVysledekKontroly();

                return vysledek;
            }
            else if (items == Items.Zpusob)
            {
                IZpusob_vytapeniFactory zpusobFactory = NewXMLFactory();
                IZpusob_vytapeni zpusob = zpusobFactory.CreateZpusob();

                return zpusob;
            }

            return null;
        }

        /*
        public static object DecideXML(Type type)
        {
            if (type == typeof(IDotace_EUFactory))
            {
                IDotace_EUFactory dotaceFactory = NewXMLFactory();
                IDotace_EU dotace = dotaceFactory.CreateDotace();

                return dotace;
            }
            else if (type == typeof(IHistorie_stavbyFactory))
            {
                IHistorie_stavbyFactory historieStavbyFactory = NewXMLFactory();
                IHistorie_stavby historieStavby = historieStavbyFactory.CreateHistorieStavby();

                return historieStavby;
            }
            else if (type == typeof(IHistorie_vysledku_kontrolyFactory))
            {
                IHistorie_vysledku_kontrolyFactory historieVysledkuFactory = NewXMLFactory();
                IHistorie_vysledku_kontroly historieVysledku = historieVysledkuFactory.CreateHistoriiVysledkuKontroly();

                return historieVysledku;
            }
            else if (type == typeof(IKontrola_kvality_spalovaniFactory))
            {
                IKontrola_kvality_spalovaniFactory kontrolaFactory = NewXMLFactory();
                IKontrola_kvality_spalovani kontrola = kontrolaFactory.CreateKontrola();

                return kontrola;
            }
            else if (type == typeof(IStavbaFactory))
            {
                IStavbaFactory stavbaFactory = NewXMLFactory();
                IStavba stavba = stavbaFactory.CreateStavba();

                return stavba;
            }
            else if (type == typeof(IStavbaVlastnikFactory))
            {
                IStavbaVlastnikFactory stavbaVlastnikFactory = NewXMLFactory();
                IStavbaVlastnik stavbaVlastnik = stavbaVlastnikFactory.CreateStavbaVlastnik();

                return stavbaVlastnik;
            }
            else if (type == typeof(IVlastnikFactory))
            {
                IVlastnikFactory vlastnikFactory = NewXMLFactory();
                IVlastnik vlastnik = vlastnikFactory.CreateVlastnik();

                return vlastnik;
            }
            else if (type == typeof(IVysledek_kontrolyFactory))
            {
                IVysledek_kontrolyFactory vysledekFactory = NewXMLFactory();
                IVysledek_kontroly vysledek = vysledekFactory.CreateVysledekKontroly();

                return vysledek;
            }
            else if (type == typeof(IZpusob_vytapeniFactory))
            {
                IZpusob_vytapeniFactory zpusobFactory = NewXMLFactory();
                IZpusob_vytapeni zpusob = zpusobFactory.CreateZpusob();

                return zpusob;
            }

            return null;
        }*/
    }
}
