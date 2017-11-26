using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.ObjectModel;
using EZV.Utils;
using EZV.DAOFactory;
using EZV.DTO;

namespace EZV.DataMapper
{
    public class Vlastnik_DataMapper : IVlastnik
    {

        public static String SQL_SELECT = "SELECT id_vlastnika, jmeno, prijmeni, datum_narozeni, datum_umrti, pohlavi, aktualni_vlastnik, jmeno || ', ' || prijmeni || ', ' || rodne_cislo AS vypis FROM Vlastnik";
        public static String SQL_SELECT_ID = "SELECT * FROM Vlastnik WHERE id_vlastnika=:id";
        public static String SQL_INSERT = "INSERT INTO Vlastnik (id_vlastnika, jmeno, prijmeni, datum_narozeni, datum_umrti, rodne_cislo, pohlavi, trvale_bydliste_ulice, trvale_bydliste_cislo_popisne, trvale_bydliste_mesto, trvale_bydliste_PSC, aktualni_vlastnik) "
            + " VALUES (:id, :jmeno, :prijmeni, :datum_narozeni, :datum_umrti, :rodne_cislo, :pohlavi, :ulice, :cislo_popisne, :mesto, :PSC, :aktualni_vlastnik)";
        public static String SQL_UPDATE = "UPDATE Vlastnik SET jmeno=:jmeno, prijmeni=:prijmeni, datum_narozeni=:datum_narozeni," +
            "datum_umrti=:datum_umrti, rodne_cislo=:rodne_cislo, pohlavi=:pohlavi, " + "trvale_bydliste_ulice=:ulice, trvale_bydliste_cislo_popisne=:cislo_popisne, trvale_bydliste_mesto=:mesto, " +
            "trvale_bydliste_PSC=:PSC, aktualni_vlastnik=:aktualni_vlastnik WHERE id_vlastnika=:id";
        public static String SQL_DELETE = "UPDATE Vlastnik SET aktualni_vlastnik=:aktualni_vlastnik " + "WHERE id_vlastnika=:id";
        public static String SQL_SEQUENCE = "SELECT Vlastnik_seq.NEXTVAL FROM DUAL";


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

        public void Insert(Vlastnik vlastnik)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, vlastnik);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
        }

        public void Update(Vlastnik vlastnik)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, vlastnik);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
        }

        public void Delete(Vlastnik vlastnik)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_DELETE);
            PrepareCommand(command, vlastnik);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
        }

        public Collection<Vlastnik> Select()
        {
            Database db;
            db = new Database();
            db.Connect();

            OracleCommand command = db.CreateCommand(SQL_SELECT);
            OracleDataReader reader = db.Select(command);

            Collection<Vlastnik> Vlastnici = Read(reader, false);
            reader.Close();

            db.Close();

            return Vlastnici;
        }

        public Vlastnik Select_id(int idVlastnik)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue(":id", idVlastnik);
            OracleDataReader reader = db.Select(command);

            Collection<Vlastnik> vlastnici = Read(reader, true);
            Vlastnik vlastnik = null;

            if (vlastnici.Count == 1)
            {
                vlastnik = vlastnici[0];
            }

            reader.Close();
            db.Close();

            return vlastnik;
        }

        /*
        public static int Insert(Vlastnik vlastnik)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, vlastnik);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }*/

        /*
        public static int Update(Vlastnik vlastnik)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, vlastnik);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }*/

        /*
        public static int Delete(Vlastnik vlastnik)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_DELETE);
            PrepareCommand(command, vlastnik);
            int ret = db.ExecuteNonQuery(command);
            db.Close();
            return ret;
        }*/

        /*
        public static Collection<Vlastnik> Select(Database Db = null)
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

            Collection<Vlastnik> Vlastnici = Read(reader, false);
            reader.Close();

            if (Db == null)
            {
                db.Close();
            }

            return Vlastnici;
        }*/

        /*
        public static Vlastnik Select_id(int idVlastnik, Database Db = null)
        {
            Database db = new Database();
            db.Connect();
            OracleCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue(":id", idVlastnik);
            OracleDataReader reader = db.Select(command);

            Collection<Vlastnik> vlastnici = Read(reader, true);
            Vlastnik vlastnik = null;
            if (vlastnici.Count == 1)
            {
                vlastnik = vlastnici[0];
            }
            reader.Close();
            db.Close();
            return vlastnik;
        }*/

        private static void PrepareCommand(OracleCommand command, Vlastnik Vlastnik)
        {
            command.BindByName = true;
            command.Parameters.AddWithValue(":id", Vlastnik.Id_vlastnika);
            command.Parameters.AddWithValue(":jmeno", Vlastnik.Jmeno);
            command.Parameters.AddWithValue(":prijmeni", Vlastnik.Prijmeni);
            command.Parameters.AddWithValue(":datum_narozeni", Vlastnik.Datum_narozeni);
            command.Parameters.AddWithValue(":datum_umrti", Vlastnik.Datum_umrti == null ? DBNull.Value : (object)Vlastnik.Datum_umrti);
            command.Parameters.AddWithValue(":rodne_cislo", Vlastnik.Rodne_cislo);
            command.Parameters.AddWithValue(":pohlavi", Vlastnik.Pohlavi);
            command.Parameters.AddWithValue(":ulice", Vlastnik.Trvale_bydliste_ulice);
            command.Parameters.AddWithValue(":cislo_popisne", Vlastnik.Trvale_bydliste_cislo_popisne);
            command.Parameters.AddWithValue(":mesto", Vlastnik.Trvale_bydliste_mesto);
            command.Parameters.AddWithValue(":PSC", Vlastnik.Trvale_bydliste_PSC);
            command.Parameters.AddWithValue(":aktualni_vlastnik", Vlastnik.Aktualni_vlastnik);
        }

        private static Collection<Vlastnik> Read(OracleDataReader reader, bool complete)
        {
            Collection<Vlastnik> Vlastnici = new Collection<Vlastnik>();

            while (reader.Read())
            {
                int i = -1;
                Vlastnik Vlastnik = new Vlastnik();
                Vlastnik.Id_vlastnika = reader.GetInt32(++i);
                Vlastnik.Jmeno = reader.GetString(++i);
                Vlastnik.Prijmeni = reader.GetString(++i);
                Vlastnik.Datum_narozeni = reader.GetDateTime(++i);
                if (!reader.IsDBNull(++i))
                {
                    Vlastnik.Datum_umrti = reader.GetDateTime(i);
                }
                if (complete)
                {
                    Vlastnik.Rodne_cislo = reader.GetString(++i);
                }
                Vlastnik.Pohlavi = reader.GetString(++i);
                if (complete)
                {
                    Vlastnik.Trvale_bydliste_ulice = reader.GetString(++i);
                    Vlastnik.Trvale_bydliste_cislo_popisne = reader.GetInt32(++i);
                    Vlastnik.Trvale_bydliste_mesto = reader.GetString(++i);
                    Vlastnik.Trvale_bydliste_PSC = reader.GetString(++i);
                }
                Vlastnik.Aktualni_vlastnik = reader.GetString(++i);
                if (!complete)
                {
                    Vlastnik.Vypis = reader.GetString(++i);
                }

                Vlastnici.Add(Vlastnik);
            }
            return Vlastnici;
        }
    }
}
