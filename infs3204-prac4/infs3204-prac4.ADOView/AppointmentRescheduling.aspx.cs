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
    public partial class AppointmentRescheduling : System.Web.UI.Page
    {
        IDatabaseService service = new ADODatabaseService();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void searchBtn_Click(object sender, EventArgs e)
        {
            Appointment a;
            string patientName = patientFirstNameTxt.Text + " " + patientLastNameTxt.Text;
            string doctorName = doctorFirstNameTxt.Text + " " + doctorLastNameTxt.Text;
            try
            {
                a = service.GetAppointment(patientName, doctorName);
            }
            catch(Exception err)
            {
                outputLbl.Text = err.Message;
                return;
            }

            if (a == null)
            {
                outputLbl.Text = "not found";
                return;
            }

            // display the doctor that was retrieved
            dateTxt.Text = a.AppointmentTime.ToShortDateString();
            timeTxt.Text = a.AppointmentTime.ToShortTimeString();
            clinicNameTxt.Text = a.ClinicName;

            outputLbl.Text = "";
        }

        protected void saveBtn_Click(object sender, EventArgs e)
        {
            bool res = false;

            try
            {
                string patientName = patientFirstNameTxt.Text + " " + patientLastNameTxt.Text;
                string doctorName = doctorFirstNameTxt.Text + " " + doctorLastNameTxt.Text;

                DateTime newTime = Convert.ToDateTime(dateTxt.Text + " " + timeTxt.Text);
                res = service.AppointmentReschedule(patientName, doctorName, newTime);
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