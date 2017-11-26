using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.ObjectModel;
using EZV.Utils;
using EZV.DAOFactory;
using EZV.DTO;

namespace EZV.DataMapper
{
    public class Stavba_DataMapper : IStavba
    {

        public static String SQL_SELECT = "SELECT id_stavby, typ_stavby, ulice, cislo_popisne, typ_stavby || ', ' || ulice || ', ' || cislo_popisne AS vypis FROM Stavba";
        public static String SQL_SELECT_ID = "SELECT * FROM Stavba WHERE id_stavby=:id";
        public static String SQL_INSERT = "INSERT INTO Stavba (id_stavby, typ_stavby, ulice, cislo_popisne, cislo_stavby_na_KU, nazev_KU, datum_kolaudace) "
            + " VALUES (:id, :typ, :ulice, :cislo_popisne, :cislo_stavby, :nazev_KU, :datum_kolaudace)";
        public static String SQL_UPDATE = "UPDATE Stavba SET typ_stavby=:typ, ulice=:ulice, cislo_popisne=:cislo_popisne," +
            "cislo_stavby_na_KU=:cislo_stavby, nazev_KU=:nazev_KU, datum_kolaudace=:datum_kolaudace " +
            "WHERE id_stavby=:id";
        public static String SQL_SEQUENCE = "SELECT Stavba_seq.NEXTVAL FROM DUAL";

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
        }

        public void Insert(Stavba stavba)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, stavba);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
        }

        public void Update(Stavba stavba)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, stavba);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
        }

        public Collection<Stavba> Select()
        {
            Database db;
            db = new Database();
            db.Connect();

            OracleCommand command = db.CreateCommand(SQL_SELECT);
            OracleDataReader reader = db.Select(command);

            Collection<Stavba> Stavby = Read(reader, false);
            reader.Close();

            db.Close();

            return Stavby;
        }

        public Stavba Select_id(int idStavba)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue(":id", idStavba);
            OracleDataReader reader = db.Select(command);

            Collection<Stavba> stavby = Read(reader, true);
            Stavba stavba = null;

            if (stavby.Count == 1)
            {
                stavba = stavby[0];
            }

            reader.Close();
            db.Close();

            return stavba;
        }

        /*
        public static int Insert(Stavba stavba)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, stavba);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }*/

        /*
        public static int Update(Stavba stavba)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, stavba);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }*/

        /*
        public static Collection<Stavba> Select(Database Db = null)
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

            Collection<Stavba> Stavby = Read(reader, false);
            reader.Close();

            if (Db == null)
            {
                db.Close();
            }

            return Stavby;
        }*/

        /*
        public static Stavba Select_id(int idStavba, Database Db = null)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue(":id", idStavba);
            OracleDataReader reader = db.Select(command);

            Collection<Stavba> stavby = Read(reader, true);
            Stavba stavba = null;
            if (stavby.Count == 1)
            {
                stavba = stavby[0];
            }
            reader.Close();
            db.Close();
            return stavba;
        }*/

        private static void PrepareCommand(OracleCommand command, Stavba Stavba)
        {
            command.BindByName = true;
            command.Parameters.AddWithValue(":id", Stavba.Id_stavby);
            command.Parameters.AddWithValue(":typ", Stavba.Typ_stavby);
            command.Parameters.AddWithValue(":ulice", Stavba.Ulice);
            command.Parameters.AddWithValue(":cislo_popisne", Stavba.Cislo_popisne);
            command.Parameters.AddWithValue(":cislo_stavby", Stavba.Cislo_stavby_na_KU);
            command.Parameters.AddWithValue(":nazev_KU", Stavba.Nazev_KU);
            command.Parameters.AddWithValue(":datum_kolaudace", Stavba.Datum_kolaudace);
        }

        private static Collection<Stavba> Read(OracleDataReader reader, bool complete)
        {
            Collection<Stavba> Stavby = new Collection<Stavba>();

            while (reader.Read())
            {
                int i = -1;
                Stavba Stavba = new Stavba();
                Stavba.Id_stavby = reader.GetInt32(++i);
                Stavba.Typ_stavby = reader.GetString(++i);
                Stavba.Ulice = reader.GetString(++i);
                Stavba.Cislo_popisne = reader.GetInt32(++i);

                if (!complete)
                {
                    Stavba.Vypis = reader.GetString(++i);
                }
                
                if (complete)
                {
                    Stavba.Cislo_stavby_na_KU = reader.GetInt32(++i);
                    Stavba.Nazev_KU = reader.GetString(++i);
                    Stavba.Datum_kolaudace = reader.GetDateTime(++i);
                }

                Stavby.Add(Stavba);
            }
            return Stavby;
        }
    }
}
