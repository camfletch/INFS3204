using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using infs3204_prac4.Models;

namespace infs3204_prac4.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LINQDatabaseService" in code, svc and config file together.
    public class LINQDatabaseService : IDatabaseService
    {
        MedicalDataClassesDataContext db = new MedicalDataClassesDataContext();

        public bool PatientRegistration(string healthInsuranceNo, string firstName, string lastName, int phoneNumber, string address, string email)
        {
            PatientData patient = new PatientData()
            {
                HealthInsuranceNo = healthInsuranceNo,
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                Address = address,
                Email = email
            };

            db.PatientDatas.InsertOnSubmit(patient);

            try
            {
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw new FaultException(e.Message);
            }

            return true;
        }

        public bool DoctorRegistration(string medicalRegistrationNo, string firstName, string lastName, int phoneNumber, string healthProfession, string email)
        {
            DoctorData doctor = new DoctorData()
            {
                MedicalRegistrationNo = medicalRegistrationNo,
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                HealthProfession = healthProfession,
                Email = email
            };

            db.DoctorDatas.InsertOnSubmit(doctor);

            try
            {
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw new FaultException(e.Message);
            }

            return true;
        }

        public Models.Patient GetPatientInfo(string firstName, string lastName)
        {
            PatientData pData = (from p in db.PatientDatas
                                 where p.FirstName == firstName
                                 && p.LastName == lastName
                                 select p).FirstOrDefault();

            if (pData == null)
            {
                return null;
            }

            Patient pModel = new Patient()
            {
                HealthInsuranceNo = pData.HealthInsuranceNo,
                FirstName = pData.FirstName,
                LastName = pData.LastName,
                PhoneNumber = pData.PhoneNumber,
                Address = pData.Address,
                Email = pData.Email
            };

            return pModel;
        }

        public Models.Doctor GetDoctorInfo(string firstName, string lastName)
        {
            DoctorData dData = (from d in db.DoctorDatas
                                 where d.FirstName == firstName
                                 && d.LastName == lastName
                                 select d).FirstOrDefault();

            if (dData == null)
            {
                return null;
            }

            Doctor dModel = new Doctor()
            {
                MedicalRegistrationNo = dData.MedicalRegistrationNo,
                FirstName = dData.FirstName,
                LastName = dData.LastName,
                PhoneNumber = dData.PhoneNumber,
                HealthProfession = dData.HealthProfession,
                Email = dData.Email
            };

            return dModel;
        }

        public bool AppointmentBooking(string patientName, string doctorName, DateTime appointmentTime, string clinicName)
        {
            string[] patientNames = patientName.Split(' ');
            string[] doctorNames = doctorName.Split(' ');

            if (patientNames.Length != 2 || doctorNames.Length != 2)
            {
                return false;
            }

            Patient patient = GetPatientInfo(patientNames[0], patientNames[1]);
            Doctor doctor = GetDoctorInfo(doctorNames[0], doctorNames[1]);

            AppointmentData appointment = new AppointmentData()
            {
                HealthInsuranceNo = patient.HealthInsuranceNo,
                MedicalRegistrationNo = doctor.MedicalRegistrationNo,
                AppointmentTime = appointmentTime,
                ClinicName = clinicName
            };

            db.AppointmentDatas.InsertOnSubmit(appointment);

            try
            {
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw new FaultException(e.Message);
            }

            return true;
        }

        public Models.Appointment GetAppointment(string patientName, string doctorName)
        {
            string[] patientNames = patientName.Split(' ');
            string[] doctorNames = doctorName.Split(' ');

            if (patientNames.Length != 2 || doctorNames.Length != 2)
            {
                return null;
            }

            Patient patient = GetPatientInfo(patientNames[0], patientNames[1]);
            Doctor doctor = GetDoctorInfo(doctorNames[0], doctorNames[1]);

            AppointmentData aData = (from a in db.AppointmentDatas
                                     where a.HealthInsuranceNo == patient.HealthInsuranceNo
                                     && a.MedicalRegistrationNo == doctor.MedicalRegistrationNo
                                     select a).FirstOrDefault();

            if (aData == null)
            {
                return null;
            }

            Appointment aModel = new Appointment()
            {
                HealthInsuranceNo = aData.HealthInsuranceNo,
                MedicalRegistrationNo = aData.MedicalRegistrationNo,
                AppointmentTime = aData.AppointmentTime,
                ClinicName = aData.ClinicName
            };

            return aModel;
        }

        public bool AppointmentReschedule(string patientName, string doctorName, DateTime newTime)
        {
            string[] patientNames = patientName.Split(' ');
            string[] doctorNames = doctorName.Split(' ');

            if (patientNames.Length != 2 || doctorNames.Length != 2)
            {
                return false;
            }

            Patient patient = GetPatientInfo(patientNames[0], patientNames[1]);
            Doctor doctor = GetDoctorInfo(doctorNames[0], doctorNames[1]);

            AppointmentData aData = (from a in db.AppointmentDatas
                                     where a.HealthInsuranceNo == patient.HealthInsuranceNo
                                     && a.MedicalRegistrationNo == doctor.MedicalRegistrationNo
                                     select a).FirstOrDefault();

            if (aData == null)
            {
                return false;
            }

            aData.AppointmentTime = newTime;

            try
            {
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                throw new FaultException(e.Message);
            }

            return true;
        }
    }
}
