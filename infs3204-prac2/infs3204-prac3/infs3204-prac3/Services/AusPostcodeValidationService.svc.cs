using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace infs3204_prac3.Services
{
    public class AusPostcodeValidationService : IAusPostcodeValidationService
    {
        private Dictionary<string, List<Tuple<int, int>>> _postCodes;

        public AusPostcodeValidationService()
        {
            // add the ranges for each state
            _postCodes = new Dictionary<string, List<Tuple<int, int>>>();
            _postCodes.Add("NSW", new List<Tuple<int, int>> { 
                new Tuple<int, int>(2000, 2599),
                new Tuple<int, int>(2619, 2898),
                new Tuple<int, int>(2921, 2999)});
            _postCodes.Add("ACT", new List<Tuple<int, int>> { 
                new Tuple<int, int>(2600, 2618),
                new Tuple<int, int>(2900, 2920)});
            _postCodes.Add("VIC", new List<Tuple<int, int>> { 
                new Tuple<int, int>(3000, 3999)});
            _postCodes.Add("QLD", new List<Tuple<int, int>> { 
                new Tuple<int, int>(4000, 4999)});
            _postCodes.Add("SA", new List<Tuple<int, int>> { 
                new Tuple<int, int>(5000, 5799)});
            _postCodes.Add("WA", new List<Tuple<int, int>> { 
                new Tuple<int, int>(6000, 6797)});
            _postCodes.Add("TAS", new List<Tuple<int, int>> { 
                new Tuple<int, int>(7000, 7799)});
            _postCodes.Add("NT", new List<Tuple<int, int>> { 
                new Tuple<int, int>(0800, 0899)});
        }

        public bool PostcodeValidation(int postcode, string state)
        {
            // get the codes matching the state code
            List<Tuple<int, int>> codes = new List<Tuple<int, int>>();
            codes.AddRange(_postCodes[state]);
            if (codes.Count > 0)
            {
                // check if the postcode is in the range
                foreach (var range in codes)
                {
                    if (postcode >= range.Item1 && postcode <= range.Item2)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
