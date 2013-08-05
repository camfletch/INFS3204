using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace infs3204_prac1
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void calculateBtn_Click(object sender, EventArgs e)
        {
            // reverse the input strings
            int input1 = reverseInputString(input1Txt.Text);
            int input2 = reverseInputString(input2Txt.Text);

            string base10Result = null;
            string base2Result = null;

            // perform the selected calculation
            switch (operationDropDown.SelectedIndex)
            {
                // Addition
                case 0:
                    base10Result = Convert.ToString(input1 + input2);
                    base2Result = Convert.ToString(input1 + input2, 2);
                    break;

                // Subtraction
                case 1:
                    base10Result = Convert.ToString(input1 - input2);
                    base2Result = Convert.ToString(input1 - input2, 2);
                    break;

                // Multiplication
                case 2:
                    base10Result = Convert.ToString(input1 * input2);
                    base2Result = Convert.ToString(input1 * input2, 2);
                    break;

                // Division
                case 3:
                    base10Result = Convert.ToString(input1 / input2);
                    base2Result = Convert.ToString(input1 / input2, 2);
                    break;
            }

            // print the result to the output text boxes
            if (!String.IsNullOrEmpty(base10Result))
                outputBase10Txt.Text = base10Result;

            if (!String.IsNullOrEmpty(base2Result))
                outputBase2Txt.Text = base2Result;
        }

        private int reverseInputString(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            string rString = new string(charArray);
            return Convert.ToInt32(rString);
        }
    }
}
