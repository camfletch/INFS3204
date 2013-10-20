using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Prac5ServiceWebRole
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class Prac5Service : IPrac5Service
    {
        public string GetStringBack()
        {
            return "this is the return string";
        }

        public string[][] AnagramsFinder(string[] words)
        {
            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();
            string[][] returnList;

            foreach (string word in words)
            {
                var ordered = word.ToLower().ToArray().Where(c => c >= 'a' && c <= 'z').OrderBy(c => c);
                string chars = new string(ordered.ToArray());
                if (map.ContainsKey(chars))
                {
                    map[chars].Add(word);
                }
                else
                {
                    List<string> anagrams = new List<string>();
                    anagrams.Add(word);
                    map.Add(chars, anagrams);
                }
            }

            returnList = new string[map.Keys.Count][];

            int group = 0;
            foreach (var pair in map)
            {
                returnList[group] = pair.Value.ToArray();
                group++;
            }

            return returnList;
        }

        public List<List<KeyValuePair<string, int>>> ASCIIFilter(string wordsString, int filter)
        {
            string[] words = wordsString.Split(' ');
            List<List<KeyValuePair<string, int>>> returnList = new List<List<KeyValuePair<string, int>>>();

            foreach (string word in words)
            {
                List<KeyValuePair<string, int>> ascii = new List<KeyValuePair<string, int>>();
                int total = 0;
                StringBuilder actual = new StringBuilder();
                foreach (char c in word)
                {
                    if (c >= 'A' && c <= 'z')
                    {
                        ascii.Add(new KeyValuePair<string, int>(c.ToString(), (int)c));
                        total += (int)c;

                        actual.Append(c);
                    }
                }

                ascii.Add(new KeyValuePair<string, int>(actual.ToString(), total));

                if (total > filter)
                {
                    returnList.Add(ascii);
                }
            }

            return returnList;
        }

    }
}
