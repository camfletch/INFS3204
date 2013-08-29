using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using infs3204_prac2.ColorConverterServiceReference;
using infs3204_prac2.ColorMixerServiceReference;

namespace infs3204_prac2
{
    public partial class ColorMixer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void calculateBtn_Click(object sender, EventArgs e)
        {
            ColorConverterServiceSoapClient colorConverter = new ColorConverterServiceSoapClient();
            ColorMixerServiceSoapClient colorMixer = new ColorMixerServiceSoapClient();

            string result = colorMixer.MixCodes(
                colorConverter.ColorToCode(input1Txt.Text),
                colorConverter.ColorToCode(input2Txt.Text));

            outputTxt.Text = result;
        }
    }
}
