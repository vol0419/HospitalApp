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
                Id = 1,
                Name = "John",
                Surname = "Snow",
                Birthday = Convert.ToDateTime("10/05/1995"),
                Pesel = 123456789
            };

            Service1Client service = new Service1Client();

            if(service.insertPatient(p) == 1)
            {
                MessageBox.Show("Patient inserted!");
            }
        }
    }
}
