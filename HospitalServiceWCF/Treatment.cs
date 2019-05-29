using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HospitalServiceWCF
{
    [DataContract]
    public class Treatment
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int PatientID { get; set; }
    }
}
