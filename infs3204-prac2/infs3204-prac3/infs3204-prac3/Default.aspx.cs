using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using infs3204_prac3.Services;

namespace infs3204_prac3
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_OnClick(object sender, EventArgs e)
        {
            ManagementService service = new ManagementService();
            var result = service.GetJobInfo(input1.Text, input2.Text);

            output.Text = result.ToString();
        }
    }
}
