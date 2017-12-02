using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.ObjectModel;
using EZV.Utils;
using EZV.DAOFactory;
using EZV.DTO;

namespace EZV.DataMapper
{
    public class Historie_stavby_DataMapper : IHistorie_stavby
    {

        public static String SQL_SELECT = "SELECT id_zmeny, typ_stavby, ulice, cislo_popisne, id_vlastnika, id_stavby FROM Historie_stavby";
        public static String SQL_SELECT_ID = "SELECT * FROM Historie_stavby WHERE id_zmeny=:id";
        public static String SQL_INSERT = "INSERT INTO Historie_stavby (id_zmeny, typ_stavby, ulice, cislo_popisne, cislo_stavby_na_KU, nazev_KU, datum_kolaudace, casovy_okamzik_zmeny, id_vlastnika, id_stavby) "
            + " VALUES (:id, :typ, :ulice, :cislo_popisne, :cislo_stavby, :nazev_KU, :datum_kolaudace, :okamzik_zmeny, :id_vlastnika, :id_stavby)";
        public static String SQL_SEQUENCE = "SELECT Historie_stavby_seq.NEXTVAL FROM DUAL";

        public int Sequence()
        {
            Database db;
            db = new Database();
            db.Connect();

            OracleCommand command = db.CreateCommand(SQL_SEQUENCE);
            OracleDataReader reader = db.Select(command);

            int hodnota = 0;
            while (reader.Read() != false)
            {
                hodnota = reader.GetInt32(0);
            }

            reader.Close();

            db.Close();

            return hodnota;
        }

        public void Insert(Historie_stavby historie_stavby)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, historie_stavby);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
        }

        public Collection<Historie_stavby> Select()
        {
            Database db;
            db = new Database();
            db.Connect();
            
            OracleCommand command = db.CreateCommand(SQL_SELECT);
            OracleDataReader reader = db.Select(command);

            Collection<Historie_stavby> Historie_staveb = Read(reader, false);
            reader.Close();
            
            db.Close();

            return Historie_staveb;
        }

        public Historie_stavby Select_id(int idZmeny)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue(":id", idZmeny);
            OracleDataReader reader = db.Select(command);

            Collection<Historie_stavby> historie_staveb = Read(reader, true);
            Historie_stavby historie_stavby = null;

            if (historie_staveb.Count == 1)
            {
                historie_stavby = historie_staveb[0];
            }

            reader.Close();
            db.Close();

            return historie_stavby;
        }

        /*
        public static int Sequence(Database Db = null)
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

            OracleCommand command = db.CreateCommand(SQL_SEQUENCE);
            OracleDataReader reader = db.Select(command);

            int hodnota = 0;
            while (reader.Read() != false)
            {
                hodnota = reader.GetInt32(0);
            }

            reader.Close();

            if (Db == null)
            {
                db.Close();
            }

            return hodnota;
        }*/

        /*
        public static int Insert(Historie_stavby historie_stavby)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, historie_stavby);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }*/

        /*
        public static Collection<Historie_stavby> Select(Database Db = null)
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

            OracleCommand command = db.CreateCommand(SQL_SELECT);
            OracleDataReader reader = db.Select(command);

            Collection<Historie_stavby> Historie_staveb = Read(reader, false);
            reader.Close();

            if (Db == null)
            {
                db.Close();
            }

            return Historie_staveb;
        }*/

        /*
        public static Historie_stavby Select_id(int idZmeny, Database Db = null)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue(":id", idZmeny);
            OracleDataReader reader = db.Select(command);

            Collection<Historie_stavby> historie_staveb = Read(reader, true);
            Historie_stavby historie_stavby = null;
            if (historie_staveb.Count == 1)
            {
                historie_stavby = historie_staveb[0];
            }
            reader.Close();
            db.Close();
            return historie_stavby;
        }*/

        private static void PrepareCommand(OracleCommand command, Historie_stavby Historie_stavby)
        {
            command.BindByName = true;
            command.Parameters.AddWithValue(":id", Historie_stavby.Id_zmeny);
            command.Parameters.AddWithValue(":typ", Historie_stavby.Typ_stavby);
            command.Parameters.AddWithValue(":ulice", Historie_stavby.Ulice);
            command.Parameters.AddWithValue(":cislo_popisne", Historie_stavby.Cislo_popisne);
            command.Parameters.AddWithValue(":cislo_stavby", Historie_stavby.Cislo_stavby_na_KU);
            command.Parameters.AddWithValue(":nazev_KU", Historie_stavby.Nazev_KU);
            command.Parameters.AddWithValue(":datum_kolaudace", Historie_stavby.Datum_kolaudace);
            command.Parameters.AddWithValue(":okamzik_zmeny", Historie_stavby.Casovy_okamzik_zmeny);
            command.Parameters.AddWithValue(":id_vlastnika", Historie_stavby.Id_vlastnika);
            command.Parameters.AddWithValue(":id_stavby", Historie_stavby.Id_stavby);
        }

        private static Collection<Historie_stavby> Read(OracleDataReader reader, bool complete)
        {
            Collection<Historie_stavby> Historie_staveb = new Collection<Historie_stavby>();

            while (reader.Read())
            {
                int i = -1;
                Historie_stavby Historie_stavby = new Historie_stavby();
                Historie_stavby.Id_zmeny = reader.GetInt32(++i);
                Historie_stavby.Typ_stavby = reader.GetString(++i);
                Historie_stavby.Ulice = reader.GetString(++i);
                Historie_stavby.Cislo_popisne = reader.GetInt32(++i);
                if (complete)
                {
                    Historie_stavby.Cislo_stavby_na_KU = reader.GetInt32(++i);
                    Historie_stavby.Nazev_KU = reader.GetString(++i);
                    Historie_stavby.Datum_kolaudace = reader.GetDateTime(++i);
                    Historie_stavby.Casovy_okamzik_zmeny = reader.GetDateTime(++i);
                }
                Historie_stavby.Id_vlastnika = reader.GetInt32(++i);
                Historie_stavby.Id_stavby = reader.GetInt32(++i);

                Historie_staveb.Add(Historie_stavby);
            }
            return Historie_staveb;
        }
    }
}
