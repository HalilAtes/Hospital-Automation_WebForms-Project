using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class HastaRandevuDoktorDal
    {
        private string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\mazen\\source\\HastaneOtomasyonDb.mdb;";

        public List<HastaRandevuDoktor> GetHastaRandevuDoktor()
        {
            List<HastaRandevuDoktor> hastaRandevuDoktorList = new List<HastaRandevuDoktor>();
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT h.Ad, h.Soyad, h.GittigiBolum, h.TelNo , d.Ad, d.Soyad, r.randevuId FROM Hastalar h " +
                               "INNER JOIN Randevular r ON h.id = r.HastaId " +
                               "INNER JOIN Doktorlar d ON r.DoktorId = d.id";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        hastaRandevuDoktorList.Add(new HastaRandevuDoktor
                        {
                            HastaAd = reader["Ad"].ToString(),
                            HastaSoyad = reader["Soyad"].ToString(),
                            Bolum = reader["GittigiBolum"].ToString(),
                            TelNo = reader["TelNo"].ToString(),
                            DoktorAd = reader["Ad"].ToString(),
                            DoktorSoyad = reader["Soyad"].ToString(),
                            RandevuId = (int)reader["randevu_Id"]
                        });
                    }
                }
            }
            return hastaRandevuDoktorList;
        }
    }
}
