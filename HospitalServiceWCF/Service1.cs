using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            connectToDb();
        }

        SqlConnection conn;
        SqlCommand comm;

        SqlConnectionStringBuilder connStringBuilder;

        void connectToDb()
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

        public int insertPatient(Patient p)
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
    }
}
