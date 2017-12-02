using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.ObjectModel;
using EZV.Utils;
using EZV.DAOFactory;
using EZV.DTO;

namespace EZV.DataMapper
{
    public class Kontrola_kvality_spalovani_DataMapper : IKontrola_kvality_spalovani
    {

        public static String SQL_SELECT = "SELECT id_kontroly, datum_kontroly, id_stavby FROM Kontrola_kvality_spalovani";
        public static String SQL_SELECT_ID = "SELECT * FROM Kontrola_kvality_spalovani WHERE id_kontroly=:id";
        public static String SQL_INSERT = "INSERT INTO Kontrola_kvality_spalovani (id_kontroly, datum_kontroly, duvod_kontroly, id_stavby) "
            + " VALUES (:id, :datum_kontroly, :duvod_kontroly, :id_stavby)";
        public static String SQL_UPDATE = "UPDATE Kontrola_kvality_spalovani SET datum_kontroly=:datum_kontroly, duvod_kontroly=:duvod_kontroly, id_stavby=:id_stavby " +
            "WHERE id_kontroly=:id";
        public static String SQL_SEQUENCE = "SELECT Kontrola_kvality_spalovani_seq.NEXTVAL FROM DUAL";


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

        public void Insert(Kontrola_kvality_spalovani kontrola)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, kontrola);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
        }

        public void Update(Kontrola_kvality_spalovani kontrola)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, kontrola);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
        }

        public Collection<Kontrola_kvality_spalovani> Select()
        {
            Database db;
            db = new Database();
            db.Connect();

            OracleCommand command = db.CreateCommand(SQL_SELECT);
            OracleDataReader reader = db.Select(command);

            Collection<Kontrola_kvality_spalovani> Kontroly = Read(reader, false);
            reader.Close();

            db.Close();

            return Kontroly;
        }

        public Kontrola_kvality_spalovani Select_id(int idKontroly)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue(":id", idKontroly);
            OracleDataReader reader = db.Select(command);

            Collection<Kontrola_kvality_spalovani> kontroly = Read(reader, true);
            Kontrola_kvality_spalovani kontrola = null;

            if (kontroly.Count == 1)
            {
                kontrola = kontroly[0];
            }

            reader.Close();
            db.Close();

            return kontrola;
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
        public static int Insert(Kontrola_kvality_spalovani kontrola)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, kontrola);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }*/

        /*
        public static int Update(Kontrola_kvality_spalovani kontrola)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, kontrola);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }*/

        /*
        public static Collection<Kontrola_kvality_spalovani> Select(Database Db = null)
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

            Collection<Kontrola_kvality_spalovani> Kontroly = Read(reader, false);
            reader.Close();

            if (Db == null)
            {
                db.Close();
            }

            return Kontroly;
        }*/

        /*
        public static Kontrola_kvality_spalovani Select_id(int idKontroly, Database Db = null)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue(":id", idKontroly);
            OracleDataReader reader = db.Select(command);

            Collection<Kontrola_kvality_spalovani> kontroly = Read(reader, true);
            Kontrola_kvality_spalovani kontrola = null;
            if (kontroly.Count == 1)
            {
                kontrola = kontroly[0];
            }
            reader.Close();
            db.Close();
            return kontrola;
        }*/

        private static void PrepareCommand(OracleCommand command, Kontrola_kvality_spalovani Kontrola)
        {
            command.BindByName = true;
            command.Parameters.AddWithValue(":id", Kontrola.Id_kontroly);
            command.Parameters.AddWithValue(":datum_kontroly", Kontrola.Datum_kontroly);
            command.Parameters.AddWithValue(":duvod_kontroly", Kontrola.Duvod_kontroly);
            command.Parameters.AddWithValue(":id_stavby", Kontrola.Id_stavby);
        }

        private static Collection<Kontrola_kvality_spalovani> Read(OracleDataReader reader, bool complete)
        {
            Collection<Kontrola_kvality_spalovani> Kontroly = new Collection<Kontrola_kvality_spalovani>();

            while (reader.Read())
            {
                int i = -1;
                Kontrola_kvality_spalovani Kontrola = new Kontrola_kvality_spalovani();
                Kontrola.Id_kontroly = reader.GetInt32(++i);
                Kontrola.Datum_kontroly = reader.GetDateTime(++i);
                if (complete)
                {
                    Kontrola.Duvod_kontroly = reader.GetString(++i);
                }
                Kontrola.Id_stavby = reader.GetInt32(++i);

                Kontroly.Add(Kontrola);
            }
            return Kontroly;
        }
    }
}
