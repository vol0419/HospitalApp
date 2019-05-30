using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HospitalServiceWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {

        public Service1()
        {
            ConnectToDb();
        }

        SqlConnection conn;
        SqlCommand comm;

        SqlConnectionStringBuilder connStringBuilder;

        void ConnectToDb()
        {
            connStringBuilder = new SqlConnectionStringBuilder();
            connStringBuilder.DataSource = "(localdb)\\MSSQLLocalDB";
            connStringBuilder.InitialCatalog = "HospitalDb";
            connStringBuilder.TrustServerCertificate = true;
            connStringBuilder.ConnectTimeout = 30;
            connStringBuilder.AsynchronousProcessing = true;
            connStringBuilder.MultipleActiveResultSets = true;
            connStringBuilder.IntegratedSecurity = true;

            conn = new SqlConnection(connStringBuilder.ToString());
            comm = conn.CreateCommand();
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public int InsertPatient(Patient p)
        {
            try
            {
                comm.CommandText = "INSERT INTO Patients VALUES(@id, @name, @surname, @birthday, @pesel)";
                comm.Parameters.AddWithValue("id", p.Id);
                comm.Parameters.AddWithValue("name", p.Name);
                comm.Parameters.AddWithValue("surname", p.Surname);
                comm.Parameters.AddWithValue("birthday", p.Birthday);
                comm.Parameters.AddWithValue("pesel", p.Pesel);

                comm.CommandType = System.Data.CommandType.Text;
                conn.Open();
                    
                return comm.ExecuteNonQuery();

            }catch(Exception)
            {
                throw;
            }finally
            {
                if( conn != null)
                {
                    conn.Close();
                }
            }
        }

        public int UpdatePatient(Patient p)
        {
            try
            {
                comm.CommandText = "UPDATE Patients SET id=@id, name=@name, birthday=@birthday, pesel=@pesel, surname=@surname WHERE id=@id";
                comm.Parameters.AddWithValue("id", p.Id);
                comm.Parameters.AddWithValue("name", p.Name);
                comm.Parameters.AddWithValue("surname", p.Surname);
                comm.Parameters.AddWithValue("birthday", p.Birthday);
                comm.Parameters.AddWithValue("pesel", p.Pesel);

                conn.Open();

                return comm.ExecuteNonQuery();
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                if(conn != null)
                {
                    conn.Close();
                }
            }
        }

        public int DeletePatient(Patient p)
        {
            try
            {
                comm.CommandText = "DELETE Patients WHERE @id=id";
                comm.Parameters.AddWithValue("id", p.Id);

                conn.Open();

                return comm.ExecuteNonQuery();
            }
            catch(Exception)
            {
                throw;
            }finally
            {
                if( conn != null)
                {
                    conn.Close();
                }
            }
        }

        public Patient GetPatient(Patient p)
        {
            Patient patient = new Patient();

            try
            {
                comm.CommandText = "SELECT * FROM Patients WHERE @id=id";
                comm.Parameters.AddWithValue("id", p.Id);

                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    patient.Id = Convert.ToInt32(reader[0]);
                    patient.Name = reader[1].ToString();
                    patient.Surname = reader[2].ToString();
                    patient.Birthday = Convert.ToDateTime(reader[3]);//DateTime.ParseExact(reader[0].ToString(), "yyyy/MM/dd", CultureInfo.InvariantCulture);
                    patient.Pesel = Convert.ToInt32(reader[4]);
                }
                return patient;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if(conn != null)
                {
                    conn.Close();
                }
            }
        }

        public List<Patient> GetAllPatients()
        {
            List<Patient> patients = new List<Patient>();

            try
            {
                comm.CommandText = "SELECT * FROM Patients";           
                conn.Open();

                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    Patient patient = new Patient()
                    {
                        Id = Convert.ToInt32(reader[0]),
                        Name = reader[1].ToString(),
                        Surname = reader[2].ToString(),
                        Birthday = Convert.ToDateTime(reader[3]),//DateTime.ParseExact(reader[0].ToString(), "yyyy/MM/dd", CultureInfo.InvariantCulture);
                        Pesel = Convert.ToInt32(reader[4])
                    };
                    patients.Add(patient);
                }
                return patients;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}
