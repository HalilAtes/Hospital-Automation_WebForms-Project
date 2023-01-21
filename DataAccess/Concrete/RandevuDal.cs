using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class RandevuDal
    {
        private string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\mazen\\source\\HastaneOtomasyonDb.mdb;";


        public void Insert(int hastaId, int doktorId, DateTime randevuTarihi)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Randevular (Hasta_Id, DoktorId, Tarih) VALUES ( @hasta_ıd, @doktor_ıd,@tarih)";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@hasta_ıd", hastaId);
                    command.Parameters.AddWithValue("@doktor_ıd", doktorId);
                    command.Parameters.AddWithValue("@tarih", randevuTarihi);
                    command.ExecuteNonQuery();
                }
            }
        }

       
        public void UpdatePatient(int hastaId, string gorus, string sonuc)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Kayıtlar SET (Hasta_Id, Gorus , Sonuc) VALUES ( @hasta_ıd, @gorus,@sonuc) WHERE Hasta_Id = @hastaId";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@gorus", hastaId);
                    command.Parameters.AddWithValue("@soyad", gorus);
                    command.Parameters.AddWithValue("@sonuc", sonuc);
                    command.Parameters.AddWithValue("@id", hastaId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Randevu> GetRandevus()
        {
            List<Randevu> randevus = new List<Randevu>();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT randevuId, HastaId, Tarih, DoktorId FROM Randevular";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Randevu randevu = new Randevu();
                            randevu.randevuId = Convert.ToInt32(reader["randevuId"]);
                            randevu.HastaId = Convert.ToInt32(reader["HastaId"]);
                            randevu.Tarih = Convert.ToDateTime(reader["Tarih"]);
                            randevu.DoktorId = Convert.ToInt32(reader["DoktorId"]);
                            randevus.Add(randevu);
                        }
                    }
                }
            }
            return randevus;
        }




    }
}
