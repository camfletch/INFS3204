using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace infs3204_prac3.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IManagementService" in both code and config file together.
    [ServiceContract]
    public interface IManagementService
    {
        [OperationContract]
        Boolean SaveInfo(string firstName, string lastName, DateTime dateOfBirth, string email, string streetAddress,
                    string suburb, string state, int postcode, ManagementService.Job job);
        ManagementService.Job GetJobInfo(string firstName, string lastName);
        List<ManagementService.Person> GetColleagues(string firstName, string lastName);
    }
}
