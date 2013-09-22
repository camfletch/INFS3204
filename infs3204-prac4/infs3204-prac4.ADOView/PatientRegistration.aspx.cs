using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using infs3204_prac4.Services;
using infs3204_prac4.Models;

namespace infs3204_prac4.ADOView
{
    public partial class PatientRegistration : System.Web.UI.Page
    {
        IDatabaseService service = new ADODatabaseService();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void searchBtn_Click(object sender, EventArgs e)
        {
            string[] patientNames = searchTxt.Text.Split(' ');
            if (patientNames.Length != 2)
            {
                outputLbl.Text = "please enter full name";
                return;
            }

            Patient p;
            try
            {
                p = service.GetPatientInfo(patientNames[0], patientNames[1]);
            }
            catch(Exception err)
            {
                outputLbl.Text = err.Message;
                return;
            }

            if (p == null)
            {
                outputLbl.Text = "not found";
                return;
            }

            // display the patient that was retrieved
            healthInsuranceNoTxt.Text = p.HealthInsuranceNo;
            firstNameTxt.Text = p.FirstName;
            lastNameTxt.Text = p.LastName;
            phoneNumberTxt.Text = p.PhoneNumber.ToString();
            addressTxt.Text = p.Address;
            emailTxt.Text = p.Email;
            outputLbl.Text = "";
        }

        protected void saveBtn_Click(object sender, EventArgs e)
        {
            bool res = false;

            try
            {
                res = service.PatientRegistration(healthInsuranceNoTxt.Text, firstNameTxt.Text, lastNameTxt.Text,
                    Convert.ToInt32(phoneNumberTxt.Text), addressTxt.Text, emailTxt.Text);
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