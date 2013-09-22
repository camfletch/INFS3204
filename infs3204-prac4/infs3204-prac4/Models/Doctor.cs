using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;

namespace infs3204_prac4.Models
{
    [DataContract]
    public class Doctor
    {
        [DataMember]
        public string MedicalRegistrationNo { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string HealthProfession { get; set; }
        [DataMember]
        public int PhoneNumber { get; set; }
        [DataMember]
        public string Email { get; set; }
    }
}