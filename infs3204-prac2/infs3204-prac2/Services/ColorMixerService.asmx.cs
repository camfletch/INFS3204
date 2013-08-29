using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace infs3204_prac2.Services
{
    /// <summary>
    /// Summary description for ColorMixerService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ColorMixerService : System.Web.Services.WebService
    {
        private Dictionary<KeyValuePair<string, string>, string> mixerDict;
        public ColorMixerService()
        {
            mixerDict = new Dictionary<KeyValuePair<string, string>, string>();
            mixerDict.Add(new KeyValuePair<string, string>("#FF0000", "#0000FF"), "purple");
            mixerDict.Add(new KeyValuePair<string, string>("#0000FF", "#FF0000"), "purple");
            mixerDict.Add(new KeyValuePair<string, string>("#FF0000", "#008000"), "brown");
            mixerDict.Add(new KeyValuePair<string, string>("#008000", "#FF0000"), "brown");
            mixerDict.Add(new KeyValuePair<string, string>("#0000FF", "#FFFF00"), "green");
            mixerDict.Add(new KeyValuePair<string, string>("#FFFF00", "#0000FF"), "green");
            mixerDict.Add(new KeyValuePair<string, string>("#FFFF00", "#FF0000"), "orange");
            mixerDict.Add(new KeyValuePair<string, string>("#FF0000", "#FFFF00"), "orange");
            mixerDict.Add(new KeyValuePair<string, string>("#008000", "#FFFF00"), "light green");
            mixerDict.Add(new KeyValuePair<string, string>("#FFFF00", "#008000"), "light green");
            mixerDict.Add(new KeyValuePair<string, string>("#FF0000", "#FFFFFF"), "pink");
            mixerDict.Add(new KeyValuePair<string, string>("#FFFFFF", "#FF0000"), "pink");
            mixerDict.Add(new KeyValuePair<string, string>("#000000", "#FFFFFF"), "gray");
            mixerDict.Add(new KeyValuePair<string, string>("#FFFFFF", "#000000"), "gray");
        }

        [WebMethod]
        public string MixCodes(string code1, string code2)
        {
            KeyValuePair<string, string> index = new KeyValuePair<string, string>(code1.ToUpper(), code2.ToUpper());
            if (this.mixerDict.Keys.Contains(index))
            {
                return this.mixerDict[index];
            }
            else
            {
                return "Not supported";
            }
        }
    }
}
