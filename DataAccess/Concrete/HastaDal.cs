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
    public class HastaDal : IHastaDal
    {
        private string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\mazen\\source\\HastaneOtomasyonDb.mdb;";

        public void Add(Hasta hasta)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                string check = "SELECT COUNT(*) FROM Hastalar";
                OleDbCommand cmd = new OleDbCommand(check, connection);
                int count = (int)cmd.ExecuteScalar();

                if (count == 0)
                    hasta.Id = 1;

                string query = "INSERT INTO Hastalar (HastaAd, HastaSoyad, TelNo, Brans_Adi,Branch_Id,Doktor_Id) VALUES (@ad, @soyad, @telno, @gittigibolum,@bolumId,@doktorId)";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ad", hasta.Ad);
                    command.Parameters.AddWithValue("@soyad", hasta.Soyad);
                    command.Parameters.AddWithValue("@telno", hasta.TelNo);
                    command.Parameters.AddWithValue("@Brans_Adi", hasta.GittigiBolum);
                    command.Parameters.AddWithValue("@bolumId", hasta.bransId);
                    command.Parameters.AddWithValue("@doktorId", hasta.doktorId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdatePatient(Hasta hasta)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Hastalar SET HastaAd = @ad, HastaSoyad = @soyad, TelNo = @telno, Brans_Adi = @gittigibolum WHERE Id = @id";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ad", hasta.Ad);
                    command.Parameters.AddWithValue("@soyad", hasta.Soyad);
                    command.Parameters.AddWithValue("@telno", hasta.TelNo);
                    command.Parameters.AddWithValue("@gittigibolum", hasta.GittigiBolum);
                    command.Parameters.AddWithValue("@id", hasta.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Hastalar WHERE Id = @id";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Hasta> GetAllPatients()
        {
            List<Hasta> hastalar = new List<Hasta>();
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Hastalar";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Hasta hasta = new Hasta
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Ad = reader["HastaAd"].ToString(),
                                Soyad = reader["HastaSoyad"].ToString(),
                                TelNo = reader["TelNo"].ToString(),
                                GittigiBolum = reader["Brans_Adi"].ToString()

                            };
                            hastalar.Add(hasta);
                        }
                    }
                }
            }
            return hastalar;
        }

        public Hasta GetPatientById(int id)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Hastalar WHERE Id = @id";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Hasta hasta = new Hasta
                            {
                                Id = (int)reader["Id"],
                                Ad = (string)reader["HastaAd"],
                                Soyad = (string)reader["HastaSoyad"],
                                TelNo = (string)reader["TelNo"],
                                GittigiBolum = (string)reader["Brans_Adi"]


                            };
                            return hasta;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
        public Dictionary<string, int> GetPatientCountByDoctor()
        {
            Dictionary<string, int> patientCount = new Dictionary<string, int>();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                using (OleDbCommand command = new OleDbCommand("SELECT Doktorlar.DoktorAd, COUNT(*) FROM( Hastalar INNER JOIN Doktorlar ON Doktorlar.id = Hastalar.Doktor_Id) GROUP BY Doktorlar.DoktorAd", connection))
                {
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            patientCount.Add(reader.GetString(0), reader.GetInt32(1));
                        }
                    }
                }
            }

            return patientCount;
        }
        public List<Hasta> GetPatientsByDoctorId(int doctorId)
        {

            List<Hasta> patients = new List<Hasta>();
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query1 = "SELECT * FROM Doktorlar WHERE id = @Doktor_id";
                using (OleDbCommand command1 = new OleDbCommand(query1, connection))
                {
                    command1.Parameters.AddWithValue("@doctorId", doctorId);
                    using (OleDbDataReader reader1 = command1.ExecuteReader())
                    {
                        while (reader1.Read())
                        {
                            int Doktor_id = (int)reader1["id"];
                            string query2 = "SELECT Hastalar.HastaAd,Hastalar.HastaSoyad,Hastalar.TelNo,Hastalar.Brans_Adi FROM Hastalar WHERE Doktor_Id = @doctorId";
                            using (OleDbCommand command2 = new OleDbCommand(query2, connection))
                            {
                                command2.Parameters.AddWithValue("@Doktor_id", Doktor_id);
                                using (OleDbDataReader reader2 = command2.ExecuteReader())
                                {
                                    while (reader2.Read())
                                    {
                                        Hasta hasta = new Hasta
                                        {
                                            Ad = reader2["HastaAd"].ToString(),
                                            Soyad = reader2["HastaSoyad"].ToString(),
                                            TelNo = reader2["TelNo"].ToString(),
                                            GittigiBolum = reader2["Brans_Adi"].ToString()

                                        };
                                        patients.Add(hasta);
                                    }
                                }
                            }
                        }
                    }
                    return patients;
                }

            }
        }

        public Dictionary<string, int> GetPatientCountByBranch()
        {

            Dictionary<string, int> patientCount = new Dictionary<string, int>();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                using (OleDbCommand command = new OleDbCommand("SELECT Brans_Adi, COUNT(*) FROM Hastalar GROUP BY Brans_Adi", connection))
                {
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            patientCount.Add(reader.GetString(0), reader.GetInt32(1));
                        }
                    }
                }
            }

            return patientCount;
        }



        public bool CheckIfIdExistsPatient(int idToCheck)
        {

            string query = "SELECT COUNT(*) FROM Hastalar WHERE Id = @Id";

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
