using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace infs3204_prac4.Models
{
    [DataContract]
    public class Appointment
    {
        [DataMember]
        public string HealthInsuranceNo { get; set; }
        [DataMember]
        public string MedicalRegistrationNo { get; set; }
        [DataMember]
        public DateTime AppointmentTime { get; set; }
        [DataMember]
        public string ClinicName { get; set; }
    }
}