using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace infs3204_prac3.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAusPostcodeValidationService" in both code and config file together.
    [ServiceContract]
    public interface IAusPostcodeValidationService
    {
        [OperationContract]
        Boolean PostcodeValidation(int postcode, string state);
    }
}
