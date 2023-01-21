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
    public class DoktorDal : IDoktorDal
    {
        private string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\mazen\\source\\HastaneOtomasyonDb.mdb;";

        public void Add(Doktor doktor)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Doktorlar (DoktorAd, DoktorSoyad, Brans,TelNo) VALUES (@ad, @soyad, @brans,@telno)";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ad", doktor.Ad);
                    command.Parameters.AddWithValue("@soyad", doktor.Soyad);
                    command.Parameters.AddWithValue("@brans", doktor.Brans);
                    command.Parameters.AddWithValue("@telno", doktor.TelNo);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(Doktor doktor)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Doktorlar SET DoktorAd = @ad, DoktorSoyad = @soyad, Brans = @brans, TelNo= @telno WHERE Id = @id";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ad", doktor.Ad);
                    command.Parameters.AddWithValue("@soyad", doktor.Soyad);
                    command.Parameters.AddWithValue("@brans", doktor.Brans);
                    command.Parameters.AddWithValue("@telno", doktor.TelNo);
                    command.Parameters.AddWithValue("@id", doktor.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Doktorlar WHERE Id = @id";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Doktor> GetAllDoctors()
        {
            List<Doktor> doktorlar = new List<Doktor>();
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Doktorlar";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Doktor doktor = new Doktor
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Ad = reader["DoktorAd"].ToString(),
                                Soyad = reader["DoktorSoyad"].ToString(),
                                Brans = reader["Brans"].ToString(),
                                TelNo = reader["TelNo"].ToString()
                            };
                            doktorlar.Add(doktor);
                        }
                    }
                }
            }
            return doktorlar;
        }

        public List<string> GetBranches()
        {
            List<string> branslar = new List<string>();
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Branslar";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            branslar.Add(reader["Brans_Adi"].ToString());
                        }
                    }
                }
            }
            return branslar;
        }

        public Doktor GetDoctorById(int id)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Doktorlar WHERE Id = @id";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Doktor doktor = new Doktor
                            {
                                Id = (int)reader["Id"],
                                Ad = (string)reader["DoktorAd"],
                                Soyad = (string)reader["DoktorSoyad"],
                                Brans = (string)reader["Brans"],
                                TelNo = (string)reader["TelNo"]
                            };
                            return doktor;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public List<Doktor> GetDoctorsByBranch(string branch)
        {
            List<Doktor> doctors = new List<Doktor>();
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT id, DoktorAd, DoktorSoyad FROM Doktorlar WHERE Brans = @branch";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@branch", branch);
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string ad = reader.GetString(1);
                        string soyad = reader.GetString(2);

                        Doktor doktor = new Doktor
                        {
                            Id = id,
                            Ad = ad,
                            Soyad = soyad,
                            Brans = branch
                        };
                        doctors.Add(doktor);
                    }
                }
            }
            return doctors;
        }

        public bool CheckIfIdExistsDoctor(int idToCheck)
        {

            string query = "SELECT COUNT(*) FROM Doktorlar WHERE id = @Id";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", idToCheck);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        
    }
}
