using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace Prac5Client
{
    public partial class ASCIIFilter : System.Web.UI.Page
    {
        Prac5ServiceReference.Prac5ServiceClient service = new Prac5ServiceReference.Prac5ServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void filter_Click(object sender, EventArgs e)
        {
            errors.Text = "";

            int filter;
            try
            {
                filter = Convert.ToInt32(inputFilter.Text);
            }
            catch
            {
                errors.Text = "filter must be an integer";
                return;
            }

            string words = inputWords.Text;

            var result = service.ASCIIFilter(words, filter);

            StringBuilder sb = new StringBuilder();
            foreach (var group in result)
            {
                sb.Append("{");
                foreach (var pair in group)
                {
                    sb.AppendFormat("[{0}:{1}]", pair.Key, pair.Value);
                }
                sb.Append("}");
                sb.Append(Environment.NewLine);
            }

            output.Text = sb.ToString();
        }
    }
}