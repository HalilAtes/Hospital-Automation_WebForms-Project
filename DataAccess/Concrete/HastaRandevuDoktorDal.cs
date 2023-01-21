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
                string query = "SELECT h.HastaAd, h.HastaSoyad, h.Brans_Adi, h.TelNo , d.DoktorAd, d.DoktorSoyad, r.randevuId FROM ((Hastalar h " +
                               "INNER JOIN Randevular r ON h.id = r.HastaId)" +
                               "INNER JOIN Doktorlar d ON r.DoktorId = d.id)";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        hastaRandevuDoktorList.Add(new HastaRandevuDoktor
                        {
                            RandevuId = (int)reader["randevuId"],
                            HastaAd = reader["HastaAd"].ToString(),
                            HastaSoyad = reader["HastaSoyad"].ToString(),
                            Bolum = reader["Brans_Adi"].ToString(),
                            TelNo = reader["TelNo"].ToString(),
                            DoktorAd = reader["DoktorAd"].ToString(),
                            DoktorSoyad = reader["DoktorSoyad"].ToString()
                        });
                    }
                }
            }
            return hastaRandevuDoktorList;
        }
    }
}
