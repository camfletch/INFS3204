using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using infs3204_prac3.Services;

namespace infs3204_prac3
{
    public partial class SaveInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void save_Click(object sender, EventArgs e)
        {
            // Clear the old validation
            postCodeError.Text = "";
            generalErrorLbl.Text = "";


            // First check the postcode matches the state
            AusPostcodeValidationService postCodeValidator = new AusPostcodeValidationService();
            int postCode = Convert.ToInt32(postcode.Text);

            if (!postCodeValidator.PostcodeValidation(postCode, state.Text))
            {
                postCodeError.Text = "postcode does not match state";
                return;
            }

            ManagementService service = new ManagementService();
            bool result = false;
            try
            {
                result = service.SaveInfo(firstName.Text, lastName.Text, Convert.ToDateTime(dateBirth.Text),
                                 email.Text, street.Text, suburb.Text, state.Text, Convert.ToInt32(postcode.Text),
                                 new ManagementService.Job()
                                 {
                                     PositionNumber = Convert.ToInt32(jobPos.Text),
                                     PositionDescription = jobDesc.Text,
                                     PositionTitle = jobTitle.Text,
                                     CompanyName = companyName.Text
                                 });
            }
            catch (Exception excep)
            {
                // catch format errors
                generalErrorLbl.Text = "Could not save: " + excep.Message;
                return;
            }

            if (result)
            {
                generalErrorLbl.Text = "Saved successfully";
            }
            else
            {
                // catch service errors
                generalErrorLbl.Text = "Could not save";
            }
        }
    }
}