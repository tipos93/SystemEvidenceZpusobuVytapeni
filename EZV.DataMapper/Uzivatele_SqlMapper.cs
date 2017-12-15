using EZV.DAOFactory;
using EZV.DTO;
using EZV.Utils;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZV.DataMapper
{
    public class Uzivatele_SqlMapper : IUzivatele
    {
        public static String SQL_SELECT = "SELECT * FROM Uzivatele";
        public static String SQL_SELECT_ID = "SELECT * FROM Uzivatele WHERE login=:login";
        public static String SQL_INSERT = "INSERT INTO Uzivatele (login, heslo, postaveni, aktualnost, id_vlastnika) "
            + " VALUES (:login, :heslo, :postaveni, :aktualnost, :id_vlastnika)";
        public static String SQL_UPDATE = "UPDATE Uzivatele SET heslo=:heslo, postaveni=:postaveni," +
            "aktualnost=:aktualnost, id_vlastnika=:id_vlastnika WHERE login=:login";
        public static String SQL_DELETE = "UPDATE Uzivatele SET aktualnost=:aktualnost " + "WHERE login=:login";


        public void Insert(Uzivatele uzivatele)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, uzivatele);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
        }

        public void Update(Uzivatele uzivatele)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, uzivatele);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
        }

        public void Delete(Uzivatele uzivatele)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_DELETE);
            PrepareCommand(command, uzivatele);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
        }

        public Collection<Uzivatele> Select()
        {
            Database db;
            db = new Database();
            db.Connect();

            OracleCommand command = db.CreateCommand(SQL_SELECT);
            OracleDataReader reader = db.Select(command);

            Collection<Uzivatele> uzivateleCollection = Read(reader);
            reader.Close();

            db.Close();

            return uzivateleCollection;
        }

        public Uzivatele Select_id(string loginUzivatele)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue(":login", loginUzivatele);
            OracleDataReader reader = db.Select(command);

            Collection<Uzivatele> uzivateleCollection = Read(reader);
            Uzivatele uzivatele = null;

            if (uzivateleCollection.Count == 1)
            {
                uzivatele = uzivateleCollection[0];
            }

            reader.Close();
            db.Close();

            return uzivatele;
        }

        private static void PrepareCommand(OracleCommand command, Uzivatele uzivatele)
        {
            command.BindByName = true;
            command.Parameters.AddWithValue(":login", uzivatele.Login);
            command.Parameters.AddWithValue(":heslo", uzivatele.Heslo);
            command.Parameters.AddWithValue(":postaveni", uzivatele.Postaveni);
            command.Parameters.AddWithValue(":aktualnost", uzivatele.Aktualnost);
            command.Parameters.AddWithValue(":id_vlastnika", uzivatele.Id_vlastnika);
        }

        private static Collection<Uzivatele> Read(OracleDataReader reader)
        {
            Collection<Uzivatele> uzivateleCollection = new Collection<Uzivatele>();

            while (reader.Read())
            {
                int i = -1;
                Uzivatele uzivatele = new Uzivatele();
                uzivatele.Login = reader.GetString(++i);
                uzivatele.Heslo = reader.GetString(++i);
                uzivatele.Postaveni = reader.GetString(++i);
                uzivatele.Aktualnost = reader.GetString(++i);
                uzivatele.Id_vlastnika = reader.GetInt32(++i);

                uzivateleCollection.Add(uzivatele);
            }
            return uzivateleCollection;
        }
    }
}
