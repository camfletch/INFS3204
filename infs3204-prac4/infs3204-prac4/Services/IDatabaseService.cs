using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using infs3204_prac4.Models;

namespace infs3204_prac4.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IADODatabaseService" in both code and config file together.
    [ServiceContract]
    public interface IDatabaseService
    {
        [OperationContract]
        bool PatientRegistration(string healthInsuranceNo, string firstName, string lastName, 
            int phoneNumber, string address, string email);

        bool DoctorRegistration(string medicalRegistrationNo, string firstName, string lastName, 
            int phoneNumber, string healthProfession, string email);

        Patient GetPatientInfo(string firstName, string lastName);

        Doctor GetDoctorInfo(string firstName, string lastName);

        bool AppointmentBooking(string patientName, string doctorName, DateTime appointmentTime, 
            string clinicName);

        Appointment GetAppointment(string patientName, string doctorName);

        bool AppointmentReschedule(string patientName, string doctorName, DateTime newTime);
        
    }
}
