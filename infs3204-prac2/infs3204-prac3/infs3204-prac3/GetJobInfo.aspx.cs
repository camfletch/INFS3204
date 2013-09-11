using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using infs3204_prac3.Services;

namespace infs3204_prac3
{
    public partial class GetJobInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void search_Click(object sender, EventArgs e)
        {
            ManagementService service = new ManagementService();
            ManagementService.Job job = service.GetJobInfo(firstName.Text, lastName.Text);

            if (job == null)
            {
                result.Text = "Not Found";
            }

            else
            {
                result.Text = job.ToString();
            }
        }
    }
}