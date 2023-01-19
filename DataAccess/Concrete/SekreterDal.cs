﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAccess.Concrete
{
    public class SekreterDal : ISekreterDal
    {
        private string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\mazen\\source\\HastaneOtomasyonDb.mdb;";
        public void Add(Sekreter sekreter)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                string check = "SELECT COUNT(*) FROM Sekreterler";
                OleDbCommand cmd = new OleDbCommand(check, connection);
                int count = (int)cmd.ExecuteScalar();

                if (count == 0)
                    sekreter.Id = 1;

                string query = "INSERT INTO Sekreterler (Ad, Soyad, TelNo) VALUES (@ad, @soyad, @telno)";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ad", sekreter.Ad);
                    command.Parameters.AddWithValue("@soyad", sekreter.Soyad);
                    command.Parameters.AddWithValue("@telno", sekreter.TelNo);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Sekreterler WHERE Id = @id";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Sekreter> GetAllSekreter()
        {

            List<Sekreter> sekreterler = new List<Sekreter>();
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Sekreterler";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Sekreter sekreter = new Sekreter
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Ad = reader["Ad"].ToString(),
                                Soyad = reader["Soyad"].ToString(),
                                TelNo = reader["TelNo"].ToString(),

                            };
                            sekreterler.Add(sekreter);
                        }
                    }
                }
            }
            return sekreterler;
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
        public Dictionary<int, int> GetPatientCountByDoctor()
        {
            Dictionary<int, int> patientCount = new Dictionary<int, int>();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                using (OleDbCommand command = new OleDbCommand("SELECT Doktor_Id, COUNT(*) FROM Hastalar GROUP BY Doktor_Id", connection))
                {
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            patientCount.Add(reader.GetInt32(0), reader.GetInt32(1));
                        }
                    }
                }
            }

            return patientCount;
        }


        public int GetPatientCountByBranch(int branchId)
        {
            int patientCount = 0;
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Hastalar WHERE Branch_Id = ?";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("Branch_Id", branchId);
                    patientCount = (int)command.ExecuteScalar();
                }
            }
            return patientCount;
        }

        public Sekreter GetSekreterById(int id)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Sekreterler WHERE Id = @id";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Sekreter sekreter = new Sekreter
                            {
                                Id = (int)reader["Id"],
                                Ad = (string)reader["Ad"],
                                Soyad = (string)reader["Soyad"],
                                TelNo = (string)reader["TelNo"]


                            };
                            return sekreter;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public void UpdateSekreter(Sekreter sekreter)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Sekreterler SET Ad = @ad, Soyad = @soyad, TelNo = @telno WHERE Id = @id";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ad", sekreter.Ad);
                    command.Parameters.AddWithValue("@soyad", sekreter.Soyad);
                    command.Parameters.AddWithValue("@telno", sekreter.TelNo);
                    command.Parameters.AddWithValue("@id", sekreter.Id);
                    command.ExecuteNonQuery();
                }
            }
        }


        public List<string> GetPatientsByDoctorId(int doctorId)
        {
            List<string> patients = new List<string>();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                using (OleDbCommand command = new OleDbCommand("SELECT Hastalar.Ad,Hastalar.Soyad,Hastalar.TelNo,Hastalar.Brans_Adi FROM Doktorlar JOIN Hastalar ON Doktorlar.id = Hastalar.Doktor_Id WHERE Doktorlar.id = @doctorId", connection))
                {
                    command.Parameters.AddWithValue("@doctorId", doctorId);
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string patient = reader.GetString(0) + " " + reader.GetString(1) + " " + reader.GetString(2) + " " + reader.GetString(3);
                            patients.Add(patient);
                        }
                    }
                }
            }
            return patients;
        }

        public ComboBox GetBranches(ComboBox comboBox)
        {
            try
            {
                using (var connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    var command = new OleDbCommand("SELECT * FROM Branslar", connection);
                    var reader = command.ExecuteReader();
                    var patients = new List<Hasta>();
                    while (reader.Read())
                    {
                        patients.Add(new Hasta
                        {
                            bransId = reader.GetInt32(0),
                            GittigiBolum = reader.GetString(1)
                        });
                    }
                    comboBox.DataSource = patients;
                    comboBox.DisplayMember = "GittigiBolum";
                    comboBox.ValueMember = ("bransId").ToString();
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return comboBox;
        }

        public ComboBox GetDoktors(ComboBox comboBox)
        {
            try
            {
                using (var connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    var command = new OleDbCommand("SELECT * FROM Branslar", connection);
                    var reader = command.ExecuteReader();
                    var patients = new List<Hasta>();
                    while (reader.Read())
                    {
                        patients.Add(new Hasta
                        {
                            bransId = reader.GetInt32(0),
                            GittigiBolum = reader.GetString(1)
                        });
                    }
                    comboBox.DataSource = patients;
                    comboBox.DisplayMember = "GittigiBolum";
                    comboBox.ValueMember = ("bransId").ToString();
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return comboBox;
        }

    }


}


