using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.ObjectModel;
using EZV.Utils;
using EZV.DAOFactory;
using EZV.DTO;

namespace EZV.DataMapper
{
    public class Vysledek_kontroly_DataMapper : IVysledek_kontroly
    {

        public static String SQL_SELECT = "SELECT id_vysledku, vysledek_kontroly, id_kontroly FROM Vysledek_kontroly";
        public static String SQL_SELECT_ID = "SELECT * FROM Vysledek_kontroly WHERE id_vysledku=:id";
        public static String SQL_INSERT = "INSERT INTO Vysledek_kontroly (id_vysledku, vysledek_kontroly, prijata_opatreni, id_kontroly, datum_kontroly) "
            + " VALUES (:id, :vysledek_kontroly, :prijata_opatreni, :id_kontroly, :datum_kontroly)";
        public static String SQL_UPDATE = "UPDATE Vysledek_kontroly SET vysledek_kontroly=:vysledek_kontroly, prijata_opatreni=:prijata_opatreni, id_kontroly=:id_kontroly," +
            "datum_kontroly=:datum_kontroly WHERE id_vysledku=:id";
        public static String SQL_SEQUENCE = "SELECT Vysledek_kontroly_seq.NEXTVAL FROM DUAL";

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

        public void Insert(Vysledek_kontroly vysledek)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, vysledek);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
        }

        public void Update(Vysledek_kontroly vysledek)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, vysledek);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
        }

        public Collection<Vysledek_kontroly> Select()
        {
            Database db;
            db = new Database();
            db.Connect();

            OracleCommand command = db.CreateCommand(SQL_SELECT);
            OracleDataReader reader = db.Select(command);

            Collection<Vysledek_kontroly> Vysledky = Read(reader, false);
            reader.Close();

            db.Close();

            return Vysledky;
        }

        public Vysledek_kontroly Select_id(int idVysledku)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue(":id", idVysledku);
            OracleDataReader reader = db.Select(command);

            Collection<Vysledek_kontroly> vysledky = Read(reader, true);
            Vysledek_kontroly vysledek = null;

            if (vysledky.Count == 1)
            {
                vysledek = vysledky[0];
            }

            reader.Close();
            db.Close();

            return vysledek;
        }

        /*
        public static int Insert(Vysledek_kontroly vysledek)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, vysledek);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }*/

        /*
        public static int Update(Vysledek_kontroly vysledek)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, vysledek);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }*/

        /*
        public static Collection<Vysledek_kontroly> Select(Database Db = null)
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

            Collection<Vysledek_kontroly> Vysledky = Read(reader, false);
            reader.Close();

            if (Db == null)
            {
                db.Close();
            }

            return Vysledky;
        }*/

        /*
        public static Vysledek_kontroly Select_id(int idVysledku, Database Db = null)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue(":id", idVysledku);
            OracleDataReader reader = db.Select(command);

            Collection<Vysledek_kontroly> vysledky = Read(reader, true);
            Vysledek_kontroly vysledek = null;
            if (vysledky.Count == 1)
            {
                vysledek = vysledky[0];
            }
            reader.Close();
            db.Close();
            return vysledek;
        }*/

        private static void PrepareCommand(OracleCommand command, Vysledek_kontroly Vysledek)
        {
            command.BindByName = true;
            command.Parameters.AddWithValue(":id", Vysledek.Id_vysledku);
            command.Parameters.AddWithValue(":vysledek_kontroly", Vysledek.Ohodnoceni_kontroly);
            command.Parameters.AddWithValue(":prijata_opatreni", Vysledek.Prijata_opatreni == null ? DBNull.Value : (object)Vysledek.Prijata_opatreni);
            command.Parameters.AddWithValue(":id_kontroly", Vysledek.Id_kontroly);
            command.Parameters.AddWithValue(":datum_kontroly", Vysledek.Datum_kontroly);
        }

        private static Collection<Vysledek_kontroly> Read(OracleDataReader reader, bool complete)
        {
            Collection<Vysledek_kontroly> Vysledky = new Collection<Vysledek_kontroly>();

            while (reader.Read())
            {
                int i = -1;
                Vysledek_kontroly Vysledek = new Vysledek_kontroly();
                Vysledek.Id_vysledku = reader.GetInt32(++i);
                Vysledek.Ohodnoceni_kontroly = reader.GetString(++i);
                if (complete)
                {
                    if (!reader.IsDBNull(++i))
                    {
                        Vysledek.Prijata_opatreni = reader.GetString(i);
                    }
                }
                Vysledek.Id_kontroly = reader.GetInt32(++i);
                if (complete)
                {
                    Vysledek.Datum_kontroly = reader.GetDateTime(++i);
                }
                Vysledky.Add(Vysledek);
            }
            return Vysledky;
        }
    }
}
