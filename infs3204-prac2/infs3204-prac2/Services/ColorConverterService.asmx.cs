using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace infs3204_prac2.Services
{
    /// <summary>
    /// Summary description for ColorConverterService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ColorConverterService : System.Web.Services.WebService
    {
        private Dictionary<string, string> codesDict;
        public ColorConverterService()
            : base()
        {
            codesDict = new Dictionary<string, string>();
            codesDict.Add("white", "#FFFFFF");
            codesDict.Add("red", "#FF0000");
            codesDict.Add("blue", "#0000FF");
            codesDict.Add("green", "#008000");
            codesDict.Add("yellow", "#FFFF00");
            codesDict.Add("black", "#000000");

        }

        [WebMethod]
        public string ColorToCode(string color)
        {
            if (this.codesDict.Keys.Contains(color.ToLower()))
            {
                return this.codesDict[color.ToLower()];
            }
            else
            {
                return "Not found";
            }
        }
    }
}