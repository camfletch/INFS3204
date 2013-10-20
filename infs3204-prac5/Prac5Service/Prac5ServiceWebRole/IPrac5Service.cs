using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Prac5ServiceWebRole
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IPrac5Service
    {
        [OperationContract]
        string GetStringBack();

        [OperationContract]
        string[][] AnagramsFinder(string[] words);

        [OperationContract]
        List<List<KeyValuePair<string, int>>> ASCIIFilter(string wordsString, int filter);
    }
}
