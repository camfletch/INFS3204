using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using infs3204_prac4.Models;

namespace infs3204_prac4.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ADODatabaseService" in code, svc and config file together.
    public class ADODatabaseService : IDatabaseService
    {
        private SqlConnection conn;

        public ADODatabaseService() {
            string connString = "Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\Peter Gleeson\\Documents\\GitHub\\INFS3204\\infs3204-prac4\\infs3204-prac4\\App_Data\\MedicalDB.mdf;Integrated Security=True;User Instance=True";
            conn = new SqlConnection(connString);
        }


        public bool PatientRegistration(string healthInsuranceNo, string firstName, string lastName, int phoneNumber, string address, string email)
        {
            Patient p = new Patient()
            {
                HealthInsuranceNo = healthInsuranceNo,
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                Address = address,
                Email = email
            };

            string sql = String.Format("INSERT INTO Patients VALUES('{0}', '{1}', '{2}', {3}, '{4}', '{5}')", 
                p.HealthInsuranceNo, p.FirstName, p.LastName, p.PhoneNumber, p.Address, p.Email);
            SqlCommand command = new SqlCommand(sql, conn);
            conn.Open();

            int num;
            try
            {
                num = command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                throw new FaultException(e.Message);
            }

            if (num > 0) 
                return true;
            else
                return false;
        }

        public bool DoctorRegistration(string medicalRegistrationNo, string firstName, string lastName, int phoneNumber, string healthProfession, string email)
        {
            Doctor d = new Doctor()
            {
                MedicalRegistrationNo = medicalRegistrationNo,
                FirstName = firstName,
                LastName = lastName,
                HealthProfession = healthProfession,
                PhoneNumber = phoneNumber,
                Email = email
            };

            string sql = String.Format("INSERT INTO Doctors VALUES('{0}', '{1}', '{2}', '{3}', {4}, '{5}')", 
                d.MedicalRegistrationNo, d.FirstName, d.LastName, d.HealthProfession, d.PhoneNumber, d.Email);

            SqlCommand command = new SqlCommand(sql, conn);
            conn.Open();

            int num;
            try
            {
                num = command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                throw new FaultException(e.Message);
            }

            if (num > 0) 
                return true;
            else
                return false;
        }

        public Models.Patient GetPatientInfo(string firstName, string lastName)
        {
            string sql = String.Format("SELECT * FROM Patients WHERE FirstName = '{0}' AND LastName = '{1}'",
                firstName, lastName);
                                        

            SqlCommand command = new SqlCommand(sql, conn);
            conn.Open();

            SqlDataReader reader;
            try
            {
                reader = command.ExecuteReader();
            }
            catch (Exception e)
            {
                conn.Close();
                throw new FaultException(e.Message);
            }

            if (reader.HasRows)
            {
                reader.Read();

                Patient result = new Patient()
                {
                    HealthInsuranceNo = reader.GetString(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    PhoneNumber = reader.GetInt32(3),
                    Address = reader.GetString(4),
                    Email = reader.GetString(5)
                };

                reader.Close();
                conn.Close();
                return result;
            }
            else
                reader.Close();
                conn.Close();
                return null;
        }

        public Models.Doctor GetDoctorInfo(string firstName, string lastName)
        {
            string sql = String.Format("SELECT * FROM Doctors WHERE FirstName = '{0}' AND LastName = '{1}'",
                firstName, lastName);
                                        

            SqlCommand command = new SqlCommand(sql, conn);
            conn.Open();

            SqlDataReader reader;
            try
            {
                reader = command.ExecuteReader();
            }
            catch (Exception e)
            {
                conn.Close();
                throw new FaultException(e.Message);
            }

            if (reader.HasRows)
            {
                reader.Read();

                Doctor result = new Doctor()
                {
                    MedicalRegistrationNo = reader.GetString(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    HealthProfession = reader.GetString(3),
                    PhoneNumber = reader.GetInt32(4),
                    Email = reader.GetString(5)
                };

                reader.Close();
                conn.Close();
                return result;
            }
            else
                conn.Close();
                reader.Close();
                return null;
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

            Appointment a = new Appointment()
            {
                HealthInsuranceNo = patient.HealthInsuranceNo,
                MedicalRegistrationNo = doctor.MedicalRegistrationNo,
                AppointmentTime = appointmentTime,
                ClinicName = clinicName
            };

            string sql = String.Format("INSERT INTO Appointments VALUES('{0}', '{1}', '{2}', '{3}')",
                a.HealthInsuranceNo, a.MedicalRegistrationNo, a.AppointmentTime, a.ClinicName);

            SqlCommand command = new SqlCommand(sql, conn);
            conn.Open();

            int num;
            try
            {
                num = command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                throw new FaultException(e.Message);
            }

            if (num > 0) 
                return true;
            else
                return false;

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


            string sql = String.Format("SELECT * FROM Appointments WHERE HealthInsuranceNo = '{0}' AND MedicalRegistrationNo = '{1}'",
                patient.HealthInsuranceNo, doctor.MedicalRegistrationNo);

            SqlCommand command = new SqlCommand(sql, conn);
            conn.Open();

            SqlDataReader reader;
            try
            {
                reader = command.ExecuteReader();
            }
            catch (Exception e)
            {
                conn.Close();
                throw new FaultException(e.Message);
            }

            if (reader.HasRows)
            {
                reader.Read();

                Appointment result = new Appointment()
                {
                    HealthInsuranceNo = reader.GetString(0),
                    MedicalRegistrationNo = reader.GetString(1),
                    AppointmentTime = reader.GetDateTime(2),
                    ClinicName = reader.GetString(3)
                };

                reader.Close();
                conn.Close();
                return result;
            }
            else
                conn.Close();
                reader.Close();
                return null;
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

            Appointment a = new Appointment()
            {
                HealthInsuranceNo = patient.HealthInsuranceNo,
                MedicalRegistrationNo = doctor.MedicalRegistrationNo,
                AppointmentTime = newTime,
            };

            string sql = String.Format("UPDATE Appointments SET AppointmentTime='{0}' WHERE HealthInsuranceNo='{1}' AND MedicalRegistrationNo='{2}'",
                a.AppointmentTime, a.HealthInsuranceNo, a.MedicalRegistrationNo);

            SqlCommand command = new SqlCommand(sql, conn);
            conn.Open();

            int num;
            try
            {
                num = command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                conn.Close();
                throw new FaultException(e.Message);
            }

            if (num > 0) 
                return true;
            else
                return false;
        }
    }
}
