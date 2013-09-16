using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using infs3204_prac3.Services;
using System.Text;

namespace infs3204_prac3
{
    public partial class GetColleagues : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void search_Click(object sender, EventArgs e)
        {
            ManagementService service = new ManagementService();
            List<ManagementService.Person> people = service.GetColleagues(firstName.Text, lastName.Text);

            if (people == null || people.Count == 0)
            {
                result.Text = "Not Found";
            }

            else
            {
                StringBuilder resultString = new StringBuilder();
                foreach (ManagementService.Person person in people)
                {
                    resultString.AppendLine(person.ToString());
                }
                result.Text = resultString.ToString();
            }
        }
    }
}