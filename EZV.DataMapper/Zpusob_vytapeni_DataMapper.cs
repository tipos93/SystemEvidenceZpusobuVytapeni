using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using EZV.Utils;
using EZV.DAOFactory;
using EZV.DTO;

namespace EZV.DataMapper
{
    public class Zpusob_vytapeni_DataMapper : IZpusob_vytapeni
    {

        public static String SQL_SELECT = "SELECT zpusob_vytapeni, id_stavby FROM Zpusob_vytapeni";
        public static String SQL_SELECT_ID = "SELECT * FROM Zpusob_vytapeni WHERE id_stavby=:id_stavby AND zpusob_vytapeni=:zpusob_vytapeni";
        public static String SQL_INSERT = "INSERT INTO Zpusob_vytapeni (zpusob_vytapeni, platnost_od, platnost_do, id_stavby) "
            + " VALUES (:zpusob_vytapeni, :platnost_od, :platnost_do, :id_stavby)";
        public static String SQL_UPDATE = "UPDATE Zpusob_vytapeni SET platnost_od=:platnost_od, platnost_do=:platnost_do " +
            "WHERE id_stavby=:id_stavby AND zpusob_vytapeni=:zpusob_vytapeni";
        public static String SQL_DELETE = "UPDATE Zpusob_vytapeni SET platnost_do=:platnost_do " +
            "WHERE id_stavby=:id_stavby AND zpusob_vytapeni=:zpusob_vytapeni";

        public void Insert(Zpusob_vytapeni zpusob_vytapeni)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, zpusob_vytapeni);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
        }

        public void Update(Zpusob_vytapeni zpusob_vytapeni)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, zpusob_vytapeni);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
        }

        public void Delete(Zpusob_vytapeni zpusob_vytapeni)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_DELETE);
            PrepareCommand(command, zpusob_vytapeni);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
        }

        public Collection<Zpusob_vytapeni> Select()
        {
            Database db;
            db = new Database();
            db.Connect();

            OracleCommand command = db.CreateCommand(SQL_SELECT);
            OracleDataReader reader = db.Select(command);

            Collection<Zpusob_vytapeni> Zpusoby_vytapeni = Read(reader, false);
            reader.Close();

            db.Close();

            return Zpusoby_vytapeni;
        }

        public Zpusob_vytapeni Select_id(int idStavba, string zpusobVytapeni)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue(":id", idStavba);
            command.Parameters.AddWithValue(":zpusob_vytapeni", zpusobVytapeni);
            OracleDataReader reader = db.Select(command);

            Collection<Zpusob_vytapeni> zpusoby_vytapeni = Read(reader, true);
            Zpusob_vytapeni zpusob_vytapeni = null;

            if (zpusoby_vytapeni.Count == 1)
            {
                zpusob_vytapeni = zpusoby_vytapeni[0];
            }

            reader.Close();
            db.Close();

            return zpusob_vytapeni;
        }

        /*
        public static int Insert(Zpusob_vytapeni zpusob_vytapeni)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, zpusob_vytapeni);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }*/
        
        /*
        public static int Update(Zpusob_vytapeni zpusob_vytapeni)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, zpusob_vytapeni);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }*/

        /*
        public static int Delete(Zpusob_vytapeni zpusob_vytapeni)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_DELETE);
            PrepareCommand(command, zpusob_vytapeni);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }*/
        
        /*
        public static Collection<Zpusob_vytapeni> Select(Database Db = null)
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

            Collection<Zpusob_vytapeni> Zpusoby_vytapeni = Read(reader, false);
            reader.Close();

            if (Db == null)
            {
                db.Close();
            }

            return Zpusoby_vytapeni;
        }*/

        /*
        public static Zpusob_vytapeni Select_id(int idStavba, string zpusobVytapeni, Database Db = null)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue(":id", idStavba);
            command.Parameters.AddWithValue(":zpusob_vytapeni", zpusobVytapeni);
            OracleDataReader reader = db.Select(command);

            Collection<Zpusob_vytapeni> zpusoby_vytapeni = Read(reader, true);
            Zpusob_vytapeni zpusob_vytapeni = null;
            if (zpusoby_vytapeni.Count == 1)
            {
                zpusob_vytapeni = zpusoby_vytapeni[0];
            }
            reader.Close();
            db.Close();
            return zpusob_vytapeni;
        }*/
        
        private static void PrepareCommand(OracleCommand command, Zpusob_vytapeni Zpusob_vytapeni)
        {
            command.BindByName = true;
            command.Parameters.AddWithValue(":zpusob_vytapeni", Zpusob_vytapeni.Typ_vytapeni);
            command.Parameters.AddWithValue(":platnost_od", Zpusob_vytapeni.Platnost_od);
            command.Parameters.AddWithValue(":platnost_do", Zpusob_vytapeni.Platnost_do == null ? DBNull.Value : (object)Zpusob_vytapeni.Platnost_do);
            command.Parameters.AddWithValue(":id_stavby", Zpusob_vytapeni.Id_stavby);
        }

        private static Collection<Zpusob_vytapeni> Read(OracleDataReader reader, bool complete)
        {
            Collection<Zpusob_vytapeni> Zpusoby_vytapeni = new Collection<Zpusob_vytapeni>();

            while (reader.Read())
            {
                int i = -1;
                Zpusob_vytapeni Zpusob_vytapeni = new Zpusob_vytapeni();
                Zpusob_vytapeni.Typ_vytapeni = reader.GetString(++i);
                if (complete)
                {
                    Zpusob_vytapeni.Platnost_od = reader.GetDateTime(++i);
                    if (!reader.IsDBNull(++i))
                    {
                        Zpusob_vytapeni.Platnost_do = reader.GetDateTime(i);
                    }
                }
                Zpusob_vytapeni.Id_stavby = reader.GetInt32(++i);
                
                Zpusoby_vytapeni.Add(Zpusob_vytapeni);
            }
            return Zpusoby_vytapeni;
        }
    }
}
