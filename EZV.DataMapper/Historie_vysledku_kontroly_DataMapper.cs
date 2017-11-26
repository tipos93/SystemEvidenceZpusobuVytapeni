using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.ObjectModel;
using EZV.Utils;
using EZV.DAOFactory;
using EZV.DTO;

namespace EZV.DataMapper
{
    public class Historie_vysledku_kontroly_DataMapper : IHistorie_vysledku_kontroly
    {

        public static String SQL_SELECT = "SELECT id_zmeny, vysledek_kontroly, id_vysledku FROM Historie_vysledku_kontroly";
        public static String SQL_SELECT_ID = "SELECT * FROM Historie_vysledku_kontroly WHERE id_zmeny=:id";
        public static String SQL_SEQUENCE = "SELECT Historie_vysledku_kontroly_seq.NEXTVAL FROM DUAL";


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

        public Collection<Historie_vysledku_kontroly> Select()
        {
            Database db;
            db = new Database();
            db.Connect();
          
            OracleCommand command = db.CreateCommand(SQL_SELECT);
            OracleDataReader reader = db.Select(command);

            Collection<Historie_vysledku_kontroly> Historie_vsech_vysledku = Read(reader, false);
            reader.Close();
            
            db.Close();
            
            return Historie_vsech_vysledku;
        }

        public Historie_vysledku_kontroly Select_id(int idZmeny)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue(":id", idZmeny);
            OracleDataReader reader = db.Select(command);

            Collection<Historie_vysledku_kontroly> historie_vsech_vysledku = Read(reader, true);
            Historie_vysledku_kontroly historie_vysledku = null;

            if (historie_vsech_vysledku.Count == 1)
            {
                historie_vysledku = historie_vsech_vysledku[0];
            }

            reader.Close();
            db.Close();

            return historie_vysledku;
        }

        /*
        public static Collection<Historie_vysledku_kontroly> Select(Database Db = null)
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

            Collection<Historie_vysledku_kontroly> Historie_vsech_vysledku = Read(reader, false);
            reader.Close();

            if (Db == null)
            {
                db.Close();
            }

            return Historie_vsech_vysledku;
        }*/

        /*
        public static Historie_vysledku_kontroly Select_id(int idZmeny, Database Db = null)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue(":id", idZmeny);
            OracleDataReader reader = db.Select(command);

            Collection<Historie_vysledku_kontroly> historie_vsech_vysledku = Read(reader, true);
            Historie_vysledku_kontroly historie_vysledku = null;
            if (historie_vsech_vysledku.Count == 1)
            {
                historie_vysledku = historie_vsech_vysledku[0];
            }
            reader.Close();
            db.Close();
            return historie_vysledku;
        }*/

        private static Collection<Historie_vysledku_kontroly> Read(OracleDataReader reader, bool complete)
        {
            Collection<Historie_vysledku_kontroly> Historie_vsech_vysledku = new Collection<Historie_vysledku_kontroly>();

            while (reader.Read())
            {
                int i = -1;
                Historie_vysledku_kontroly Historie_vysledku = new Historie_vysledku_kontroly();
                Historie_vysledku.Id_zmeny = reader.GetInt32(++i);
                Historie_vysledku.Vysledek_kontroly = reader.GetString(++i);
                if (complete)
                {
                    if (!reader.IsDBNull(++i))
                    {
                        Historie_vysledku.Prijata_opatreni = reader.GetString(i);
                    }
                    Historie_vysledku.Casovy_okamzik_zmeny = reader.GetDateTime(++i);
                }
                Historie_vysledku.Id_vysledku = reader.GetInt32(++i);

                Historie_vsech_vysledku.Add(Historie_vysledku);
            }
            return Historie_vsech_vysledku;
        }
    }
}
