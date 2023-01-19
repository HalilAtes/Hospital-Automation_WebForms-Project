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

                string query = "INSERT INTO Hastalar (Ad, Soyad, TelNo, Brans_Adi,Branch_Id,Doktor_Id) VALUES (@ad, @soyad, @telno, @gittigibolum,@bolumId,@doktorId)";
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
                string query = "UPDATE Hastalar SET Ad = @ad, Soyad = @soyad, TelNo = @telno, Brans_Adi = @gittigibolum WHERE Id = @id";
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
                                Ad = reader["Ad"].ToString(),
                                Soyad = reader["Soyad"].ToString(),
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
                                Ad = (string)reader["Ad"],
                                Soyad = (string)reader["Soyad"],
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
    }
}
