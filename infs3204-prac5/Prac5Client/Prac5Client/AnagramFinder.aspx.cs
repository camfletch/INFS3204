using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace Prac5Client
{
    public partial class AnagramFinder : System.Web.UI.Page
    {
        Prac5ServiceReference.Prac5ServiceClient service = new Prac5ServiceReference.Prac5ServiceClient();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void find_Click(object sender, EventArgs e)
        {
            int nonChars = (from c in input.Text
                            where (c < 'A' || c > 'z')
                            select c).Count();
            if (nonChars > 0)
            {
                errors.Text = "only words allowed (no numbers/symbols)";
                return;
            }

            string[] words = input.Text.Split(' ');
            string[][] result = service.AnagramsFinder(words);

            StringBuilder sb = new StringBuilder();
            foreach (string[] group in result)
            {
                sb.Append("[");
                foreach (string word in group)
                {
                    sb.AppendFormat("'{0}'", word);
                }
                sb.Append("]");
                sb.Append(Environment.NewLine);
            }


            output.Text = sb.ToString();
        }
    }
}