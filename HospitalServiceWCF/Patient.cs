using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HospitalServiceWCF
{
    [DataContract]
    public class Patient
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        [DataMember]
        public int Pesel { get; set; }
    }
}
