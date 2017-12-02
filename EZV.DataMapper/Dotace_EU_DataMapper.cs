using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.ObjectModel;
using EZV.Utils;
using EZV.DAOFactory;
using EZV.DTO;

namespace EZV.DataMapper
{
    public class Dotace_EU_DataMapper : IDotace_EU
    {

        public static String SQL_SELECT = "SELECT id_dotace, vyse_dotace, id_stavby FROM Dotace_EU";
        public static String SQL_SELECT_ID = "SELECT * FROM Dotace_EU WHERE id_dotace=:id";
        public static String SQL_INSERT = "INSERT INTO Dotace_EU (id_dotace, vyse_dotace, datum_prideleni, zpusob_pouziti, id_stavby) "
            + " VALUES (:id, :vyse, :datum_prideleni, :zpusob_pouziti, :id_stavby)";
        public static String SQL_UPDATE = "UPDATE Dotace_EU SET vyse_dotace=:vyse, datum_prideleni=:datum_prideleni, zpusob_pouziti=:zpusob_pouziti, " +
            "id_stavby=:id_stavby WHERE id_dotace=:id";
        public static String SQL_SEQUENCE = "SELECT Dotace_EU_seq.NEXTVAL FROM DUAL";


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

        public void Insert(Dotace_EU dotace_EU)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, dotace_EU);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
        }

        public void Update(Dotace_EU dotace_EU)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, dotace_EU);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
        }

        public Collection<Dotace_EU> Select()
        {
            Database db;
            db = new Database();
            db.Connect();

            OracleCommand command = db.CreateCommand(SQL_SELECT);
            OracleDataReader reader = db.Select(command);

            Collection<Dotace_EU> VsechnyDotace = Read(reader, false);
            reader.Close();

            db.Close();

            return VsechnyDotace;
        }

        public Dotace_EU Select_id(int idDotace)
        {
            Database db = new Database();
            db.Connect();

            OracleCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue(":id", idDotace);
            OracleDataReader reader = db.Select(command);

            Collection<Dotace_EU> vsechnyDotace = Read(reader, true);
            Dotace_EU dotace_EU = null;
            if (vsechnyDotace.Count == 1)
            {
                dotace_EU = vsechnyDotace[0];
            }
            
            reader.Close();
            db.Close();
            return dotace_EU;
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
        public static int Insert(Dotace_EU dotace_EU)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, dotace_EU);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }*/

        /*
        public static int Update(Dotace_EU dotace_EU)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, dotace_EU);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }*/

        /*
        public static Collection<Dotace_EU> Select(Database Db = null)
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

            Collection<Dotace_EU> VsechnyDotace = Read(reader, false);
            reader.Close();

            if (Db == null)
            {
                db.Close();
            }

            return VsechnyDotace;
        }*/

        /*
        public static Dotace_EU Select_id(int idDotace, Database Db = null)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue(":id", idDotace);
            OracleDataReader reader = db.Select(command);

            Collection<Dotace_EU> vsechnyDotace = Read(reader, true);
            Dotace_EU dotace_EU = null;
            if (vsechnyDotace.Count == 1)
            {
                dotace_EU = vsechnyDotace[0];
            }
            reader.Close();
            db.Close();
            return dotace_EU;
        }*/

        private static void PrepareCommand(OracleCommand command, Dotace_EU Dotace_EU)
        {
            command.BindByName = true;
            command.Parameters.AddWithValue(":id", Dotace_EU.Id_dotace);
            command.Parameters.AddWithValue(":vyse", Dotace_EU.Vyse_dotace);
            command.Parameters.AddWithValue(":datum_prideleni", Dotace_EU.Datum_prideleni);
            command.Parameters.AddWithValue(":zpusob_pouziti", Dotace_EU.Zpusob_pouziti);
            command.Parameters.AddWithValue(":id_stavby", Dotace_EU.Id_stavby);
        }

        private static Collection<Dotace_EU> Read(OracleDataReader reader, bool complete)
        {
            Collection<Dotace_EU> VsechnyDotace = new Collection<Dotace_EU>();

            while (reader.Read())
            {
                int i = -1;
                Dotace_EU Dotace_EU = new Dotace_EU();
                Dotace_EU.Id_dotace = reader.GetInt32(++i);
                Dotace_EU.Vyse_dotace = reader.GetInt32(++i);
                if (complete)
                {
                    Dotace_EU.Datum_prideleni = reader.GetDateTime(++i);
                    Dotace_EU.Zpusob_pouziti = reader.GetString(++i);
                }
                Dotace_EU.Id_stavby = reader.GetInt32(++i);

                VsechnyDotace.Add(Dotace_EU);
            }
            return VsechnyDotace;
        }
    }
}
