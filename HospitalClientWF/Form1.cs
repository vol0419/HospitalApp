using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HospitalClientWF.ServiceReference1;

namespace HospitalClientWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            Patient p = new Patient
            {
                Id = Convert.ToInt32(TBId.Text),
                Name = TBName.Text,
                Surname = TBSurname.Text,
                Birthday = Convert.ToDateTime(TBBirthday.Text),
                Pesel = Convert.ToInt32(TBPesel.Text)
            };


            Service1Client service = new Service1Client();

            if(service.InsertPatient(p) == 1)
            {
                MessageBox.Show("Patient inserted!");
            }
        }


        private void updateButton_Click(object sender, EventArgs e)
        {
            Patient p = new Patient
            {
                Id = Convert.ToInt32(TBId.Text),
                Name = TBName.Text,
                Surname = TBSurname.Text,
                Birthday = Convert.ToDateTime(TBBirthday.Text),
                Pesel = Convert.ToInt32(TBPesel.Text)
            };

            Service1Client service = new Service1Client();

            if(service.UpdatePatient(p) == 1)
            {
                MessageBox.Show("Updated the patient!");
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Patient p = new Patient
            {
                Id = Convert.ToInt32(TBId.Text)
            };

            Service1Client service = new Service1Client();

            if( service.DeletePatient(p) == 1)
            {
                MessageBox.Show("Patient deleted!");
            }
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            List<Patient> patientsList = new List<Patient>();
            Patient p = new Patient()
            {
                Id = Convert.ToInt32(TBId.Text)
            };
            Service1Client servcie = new Service1Client();
            patientsList.Add(servcie.GetPatient(p));
            dataGridViewPatients.DataSource = patientsList;
        }

        private void SelectAllButton_Click(object sender, EventArgs e)
        {

            Service1Client service = new Service1Client();

            dataGridViewPatients.DataSource = service.GetAllPatients();
        }
    }
}
