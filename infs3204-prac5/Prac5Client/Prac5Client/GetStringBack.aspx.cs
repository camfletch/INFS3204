using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Prac5Client
{
    public partial class GetStringBack : System.Web.UI.Page
    {
        Prac5ServiceReference.Prac5ServiceClient service = new Prac5ServiceReference.Prac5ServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            outputLbl.Text = service.GetStringBack();
        }
    }
}