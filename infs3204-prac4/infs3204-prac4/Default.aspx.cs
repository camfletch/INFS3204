using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using infs3204_prac4.Services;
using System.ServiceModel;
using infs3204_prac4.Models;

namespace infs3204_prac4
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void test_Click(object sender, EventArgs e)
        {

            IDatabaseService service = new ADODatabaseService();
            try
            {
                //service.PatientRegistration("1", "john", "smith", 123456, "123 fake street", "e@gmail.com");
                //Patient p = service.GetPatientInfo("john", "smith");
                //service.DoctorRegistration("1", "bob", "dole", 123456, "gp", "f@gmail.com");
                //Doctor d = service.GetDoctorInfo("bob", "dole");
                //bool res = service.AppointmentBooking("john smith", "bob dole", DateTime.Now, "logan");
                //Appointment a = service.GetAppointment("john smith", "bob dole");
                bool res = service.AppointmentReschedule("john smith", "bob dole", DateTime.Now);
            }
            catch (FaultException err)
            {

            }

        }
    }
}
