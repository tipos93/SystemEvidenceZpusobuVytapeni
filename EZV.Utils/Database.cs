using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZV.Utils
{
    public class Database
    {

        private OracleConnection Connection { get; set; }
        private OracleTransaction SqlTransaction { get; set; }
        public string Language { get; set; }

        public Database()
        {
            Connection = new OracleConnection();
            Language = "en";
        }

        public bool Connect(String conString)
        {
            if (Connection.State != System.Data.ConnectionState.Open)
            {
                Connection.ConnectionString = conString;
                Connection.Open();
            }
            return true;
        }

        public bool Connect()
        {
            bool ret = true;

            if (Connection.State != System.Data.ConnectionState.Open)
            {
                ret = Connect(ConfigurationManager.ConnectionStrings["ConnectionStringOracle"].ConnectionString);
            }

            return ret;
        }

        public void Close()
        {
            Connection.Close();
        }

        public void BeginTransaction()
        {
            SqlTransaction = Connection.BeginTransaction(IsolationLevel.Serializable);
        }

        public void EndTransaction()
        {
            SqlTransaction.Commit();
            Close();
        }

        public void Rollback()
        {
            SqlTransaction.Rollback();
        }

        public int ExecuteNonQuery(OracleCommand command)
        {
            int rowNumber = 0;
            try
            {
                rowNumber = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Close();
            }
            return rowNumber;
        }

        public OracleCommand CreateCommand(string strCommand)
        {
            OracleCommand command = new OracleCommand(strCommand, Connection);

            if (SqlTransaction != null)
            {
                command.Transaction = SqlTransaction;
            }
            return command;
        }

        public OracleDataReader Select(OracleCommand command)
        {
            OracleDataReader sqlReader = command.ExecuteReader();
            return sqlReader;
        }

    }
}
