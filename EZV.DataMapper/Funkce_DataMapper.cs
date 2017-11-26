using EZV.Utils;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;

namespace EZV.DataMapper
{
    public class Funkce_DataMapper
    {

        public static String SQL_SELECT1 = @"SELECT s.typ_stavby, s.ulice, s.cislo_popisne, k.duvod_kontroly, v.vysledek_kontroly, v.prijata_opatreni, vl.jmeno, vl.prijmeni, vl.trvale_bydliste_ulice, vl.trvale_bydliste_cislo_popisne, vl.trvale_bydliste_mesto, vl.trvale_bydliste_PSC 
                                            FROM Kontrola_kvality_spalovani k
                                            JOIN Stavba s ON s.id_stavby = k.id_stavby
                                            JOIN Vysledek_kontroly v ON v.id_kontroly = k.id_kontroly
                                            JOIN StavbaVlastnik sv ON sv.id_stavby = s.id_stavby
                                            JOIN Vlastnik vl ON vl.id_vlastnika = sv.id_vlastnika
                                            WHERE
                                                NOT EXISTS (
                                                                SELECT *
                                                                FROM Vysledek_kontroly v1
                                                                JOIN Kontrola_kvality_spalovani k1 ON v1.id_kontroly = k1.id_kontroly
                                                                WHERE
                                                                        v1.datum_kontroly > v.datum_kontroly
                                                                        AND k.id_stavby = k1.id_stavby
                                                            )
                                            AND v.vysledek_kontroly = 'neuspesna'";

        public static String SQL_SELECT2 = @"SELECT s.typ_stavby, s.ulice, s.cislo_popisne, SUM(d.vyse_dotace) AS celkova_dotace, vl.jmeno, vl.prijmeni, vl.trvale_bydliste_ulice, vl.trvale_bydliste_cislo_popisne, vl.trvale_bydliste_mesto, vl.trvale_bydliste_PSC 
                                            FROM Zpusob_vytapeni z
                                            JOIN Stavba s ON s.id_stavby = z.id_stavby
                                            JOIN Dotace_EU d ON d.id_stavby = s.id_stavby
                                            JOIN StavbaVlastnik sv ON sv.id_stavby = s.id_stavby
                                            JOIN Vlastnik vl ON sv.id_vlastnika = vl.id_vlastnika
                                            WHERE z.zpusob_vytapeni = 'tuhá paliva'
                                            GROUP BY s.typ_stavby, s.ulice, s.cislo_popisne, vl.jmeno, vl.prijmeni, vl.trvale_bydliste_ulice, vl.trvale_bydliste_cislo_popisne, vl.trvale_bydliste_mesto, vl.trvale_bydliste_PSC";

        public static DataTable SelectKontrol(Database Db = null)
        {
            Database db;
            if (Db == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)Db;
            }

            DataTable table = new DataTable("neuspesneKontroly");

            OracleCommand command = db.CreateCommand(SQL_SELECT1);

            OracleDataAdapter adapt = new OracleDataAdapter(command);

            adapt.Fill(table);

            return table;
                        
        }

        public static DataTable SelectPaliv(Database Db = null)
        {
            Database db;
            if (Db == null)
            {
                db = new Database();
                db.Connect();
            }
            else
            {
                db = (Database)Db;
            }

            DataTable table = new DataTable("tuhaPaliva");

            OracleCommand command = db.CreateCommand(SQL_SELECT2);

            OracleDataAdapter adapt = new OracleDataAdapter(command);

            adapt.Fill(table);

            return table;

        }

    }
}
