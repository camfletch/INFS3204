using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace infs3204_prac4.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LINQDatabaseService" in code, svc and config file together.
    public class LINQDatabaseService : IDatabaseService
    {
        public bool PatientRegistration(string healthInsuranceNo, string firstName, string lastName, int phoneNumber, string address, string email)
        {
            throw new NotImplementedException();
        }

        public bool DoctorRegistration(string medicalRegistrationNo, string firstName, string lastName, int phoneNumber, string healthProfession, string email)
        {
            throw new NotImplementedException();
        }

        public Models.Patient GetPatientInfo(string firstName, string lastName)
        {
            throw new NotImplementedException();
        }

        public Models.Doctor GetDoctorInfo(string firstName, string lastName)
        {
            throw new NotImplementedException();
        }

        public bool AppointmentBooking(string patientName, string doctorName, DateTime appointmentTime, string clinicName)
        {
            throw new NotImplementedException();
        }

        public Models.Appointment GetAppointment(string patientName, string doctorName)
        {
            throw new NotImplementedException();
        }

        public bool AppointmentReschedule(string patientName, string doctorName, DateTime newTime)
        {
            throw new NotImplementedException();
        }
    }
}
