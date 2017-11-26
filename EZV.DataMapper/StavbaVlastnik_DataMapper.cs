using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZV.Utils;
using EZV.DAOFactory;
using EZV.DTO;

namespace EZV.DataMapper
{
    public class StavbaVlastnik_DataMapper : IStavbaVlastnik
    {
    
        public static String SQL_SELECT = "SELECT * FROM StavbaVlastnik";
        public static String SQL_INSERT = "INSERT INTO StavbaVlastnik (id_stavby, id_vlastnika) "
            + " VALUES (:id_stavby, :id_vlastnika)";
        public static String SQL_UPDATE = "BEGIN HistorieStavbaVlastnik(:id_vlastnika, :id_stavby); END;";

        public void Insert(StavbaVlastnik stavbaVlastnik)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, stavbaVlastnik);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
        }

        public void Update(StavbaVlastnik stavbaVlastnik)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, stavbaVlastnik);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
        }

        public Collection<StavbaVlastnik> Select()
        {
            Database db;
            db = new Database();
            db.Connect();

            OracleCommand command = db.CreateCommand(SQL_SELECT);
            OracleDataReader reader = db.Select(command);

            Collection<StavbaVlastnik> StavbyVlastnici = Read(reader);
            reader.Close();

            db.Close();

            return StavbyVlastnici;
        }

        /*
        public static int Insert(StavbaVlastnik stavbaVlastnik)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, stavbaVlastnik);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }*/

        /*
        public static int Update(StavbaVlastnik stavbaVlastnik)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, stavbaVlastnik);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }*/

        /*
        public static Collection<StavbaVlastnik> Select(Database Db = null)
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

            Collection<StavbaVlastnik> StavbyVlastnici = Read(reader);
            reader.Close();

            if (Db == null)
            {
                db.Close();
            }

            return StavbyVlastnici;
        }*/

        private static void PrepareCommand(OracleCommand command, StavbaVlastnik StavbaVlastnik)
        {
            command.BindByName = true;
            command.Parameters.AddWithValue(":id_stavby", StavbaVlastnik.Id_stavby);
            command.Parameters.AddWithValue(":id_vlastnika", StavbaVlastnik.Id_vlastnika);
        }

        private static Collection<StavbaVlastnik> Read(OracleDataReader reader)
        {
            Collection<StavbaVlastnik> StavbyVlastnici = new Collection<StavbaVlastnik>();

            while (reader.Read())
            {
                int i = -1;
                StavbaVlastnik StavbaVlastnik = new StavbaVlastnik();
                StavbaVlastnik.Id_stavby = reader.GetInt32(++i);
                StavbaVlastnik.Id_vlastnika = reader.GetInt32(++i);
        
                StavbyVlastnici.Add(StavbaVlastnik);
            }
            return StavbyVlastnici;
        }
    }
}
