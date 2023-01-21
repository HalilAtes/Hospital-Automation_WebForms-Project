using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class KayitDal : IKayitDal
    {
        private string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\mazen\\source\\HastaneOtomasyonDb.mdb;";

        public void InsertGorus(int hastaId, string gorus, string sonuc)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Kayıtlar (Hasta_Id, Gorus, Sonuc) VALUES ( @hasta_ıd, @gorus,@sonuc)";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@hasta_ıd", hastaId);
                    command.Parameters.AddWithValue("@gorus", gorus);
                    command.Parameters.AddWithValue("@sonuc", sonuc);
                    command.ExecuteNonQuery();
                }
            }
        }

        public Kayit GetKayitByHastaId(int hastaId)
        {
            Kayit kayit = null;
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Kayıtlar WHERE Hasta_Id = @hastaId";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("@hastaId", hastaId);
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        kayit = new Kayit
                        {
                            HastaId = reader.GetInt32(0),
                            Gorus = reader.GetString(1),
                            Sonuc = reader.GetString(2)
                        };
                    }
                }
            }
            return kayit;
        }

        public void UpdateKayit(Kayit kayit)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Kayıtlar SET Gorus = @gorus, Sonuc = @sonuc WHERE Hasta_Id = @id";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ad", kayit.Gorus);
                    command.Parameters.AddWithValue("@soyad", kayit.Sonuc);
                    command.Parameters.AddWithValue("@id", kayit.HastaId);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
