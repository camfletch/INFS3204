using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using infs3204_prac4.Services;

namespace infs3204_prac4.LINQView
{
    public partial class AppointmentBooking : System.Web.UI.Page
    {
        IDatabaseService service = new LINQDatabaseService();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void saveBtn_Click(object sender, EventArgs e)
        {
            bool res = false;

            try
            {
                string pName = patientFirstNameTxt.Text + " " + patientLastNameTxt.Text;
                string dName = doctorFirstNameTxt.Text + " " + doctorLastNameTxt.Text;

                DateTime time = Convert.ToDateTime(dateTxt.Text + " " + timeTxt.Text);
                res = service.AppointmentBooking(pName, dName, time, clinicNameTxt.Text);
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