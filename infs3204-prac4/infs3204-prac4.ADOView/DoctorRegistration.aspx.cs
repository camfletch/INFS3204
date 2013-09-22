using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using infs3204_prac4.Models;
using infs3204_prac4.Services;

namespace infs3204_prac4.ADOView
{
    public partial class DoctorRegistration : System.Web.UI.Page
    {
        IDatabaseService service = new ADODatabaseService();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void searchBtn_Click(object sender, EventArgs e)
        {
            string[] doctorNames = searchTxt.Text.Split(' ');
            if (doctorNames.Length != 2)
            {
                outputLbl.Text = "please enter full name";
                return;
            }

            Doctor d;
            try
            {
                d = service.GetDoctorInfo(doctorNames[0], doctorNames[1]);
            }
            catch(Exception err)
            {
                outputLbl.Text = err.Message;
                return;
            }

            if (d == null)
            {
                outputLbl.Text = "not found";
                return;
            }

            // display the doctor that was retrieved
            medicalRegistrationNoTxt.Text = d.MedicalRegistrationNo;
            firstNameTxt.Text = d.FirstName;
            lastNameTxt.Text = d.LastName;
            phoneNumberTxt.Text = d.PhoneNumber.ToString();
            healthProfessionBox.Text = d.HealthProfession;
            emailTxt.Text = d.Email;

            outputLbl.Text = "";
        }

        protected void saveBtn_Click(object sender, EventArgs e)
        {
            bool res = false;

            try
            {
                res = service.DoctorRegistration(medicalRegistrationNoTxt.Text, firstNameTxt.Text, lastNameTxt.Text, 
                    Convert.ToInt32(phoneNumberTxt.Text), healthProfessionBox.Text, emailTxt.Text);
            }
            catch (Exception err)
            {
                outputLbl.Text = err.Message;
            }

            if (res)
            {
                outputLbl.Text = "Saved Successfully";
            }

        }
    }
}