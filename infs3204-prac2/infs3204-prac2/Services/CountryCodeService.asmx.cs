using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;

namespace infs3204_prac2.Services
{
    /// <summary>
    /// Summary description for CountryCodeService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class CountryCodeService : System.Web.Services.WebService
    {
        private List<string> countryCodes;
        public CountryCodeService()
        {
            string text = File.ReadAllText("c:\\countryCode.txt").ToLower();
            countryCodes = text.Split('#').ToList();
        }

        [WebMethod]
        public string FindCountryCode(string input)
        {
            List<string> result = (from t in countryCodes
                                   where t.Contains(input.ToLower())
                                   select t).ToList();
            if (result.Count() == 0)
            {
                return "No Results Found";
            }

            else
            {
                string resultString = String.Join(" ", result);
                return resultString;
            }
        }
    }
}
