using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace infs3204_prac4.Models
{
    [DataContract]
    public class Patient
    {
        [DataMember]
        public string HealthInsuranceNo { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public int PhoneNumber { get; set; }
        [DataMember]
        public string Email { get; set; }
    }
}