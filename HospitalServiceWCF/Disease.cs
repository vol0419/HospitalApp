using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HospitalServiceWCF
{
    [DataContract]
    public class Disease
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Recognition { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string Recommendations { get; set; }

        [DataMember]
        public int PatientID { get; set; }
        [DataMember]
        public int DoctorID { get; set; }
    }
}
