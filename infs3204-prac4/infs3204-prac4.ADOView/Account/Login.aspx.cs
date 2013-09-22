using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace infs3204_prac4.ADOView.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }
    }
}
