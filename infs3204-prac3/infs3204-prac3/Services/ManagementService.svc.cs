using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;

namespace infs3204_prac3.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ManagementService" in code, svc and config file together.
    public class ManagementService : IManagementService
    {
        private const string PERSON_PATH = "C:\\infs3204\\Person.txt";
        private const string JOB_PATH = "C:\\infs3204\\Job.txt";

        [DataContract]
        public class Job
        {
            [DataMember]
            public int PositionNumber { get; set; }
            [DataMember]
            public string PositionTitle { get; set; }
            [DataMember]
            public string PositionDescription { get; set; }
            [DataMember]
            public string CompanyName { get; set; }

            public override string ToString() {
                return String.Format("NUM: {0}, TITLE: {1}, DESC: {2}, COMPANY: {3}",
                    PositionNumber, PositionTitle, PositionDescription, CompanyName);
            }
        }

        [DataContract]
        public class Person
        {
            [DataMember]
            public string FirstName { get; set; }
            [DataMember]
            public string LastName { get; set; }
            [DataMember]
            public DateTime DateOfBirth { get; set; }
            [DataMember]
            public string Email { get; set; }
            [DataMember]
            public string StreetAddress { get; set; }
            [DataMember]
            public string Suburb { get; set; }
            [DataMember]
            public string State { get; set; }
            [DataMember]
            public int Postcode { get; set; }
            [DataMember]
            public Job Job { get; set; }

            public override string ToString() {
                return String.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, JOB: [{8}]",
                    FirstName, LastName, DateOfBirth, Email, StreetAddress, Suburb, State, Postcode, Job.ToString());
            }
        }



        public bool SaveInfo(string firstName, string lastName, DateTime dateOfBirth, string email, string streetAddress,
            string suburb, string state, int postcode, ManagementService.Job job)
        {
            StreamWriter personWriter = File.AppendText(PERSON_PATH);
            StreamWriter jobWriter = File.AppendText(JOB_PATH);

            string personRecord = String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}",
                firstName, lastName, dateOfBirth, email, streetAddress, suburb, state, postcode, job.PositionNumber);

            string jobRecord = String.Format("{0},{1},{2},{3}",
                job.PositionNumber, job.PositionTitle, job.PositionDescription, job.CompanyName);

            try
            {
                personWriter.WriteLine(personRecord);
                personWriter.Close();
                jobWriter.WriteLine(jobRecord);
                jobWriter.Close();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public ManagementService.Job GetJobInfo(string firstName, string lastName)
        {
            var allPersons = File.ReadAllLines(PERSON_PATH).Select(a => a.Split(','));
            var allJobs = File.ReadAllLines(JOB_PATH).Select(a => a.Split(','));

            // get the matching person
            var jobNums = from p in allPersons
                          where p[0].Equals(firstName)
                          && p[1].Equals(lastName)
                          select p[8];

            // get the job
            var job = (from j in allJobs
                       where jobNums.Contains(j[0])
                       select j).FirstOrDefault();

            if (job == null)
            {
                return null;
            }
            else
            {
                // return the job object
                return new Job()
                {
                    PositionNumber = Convert.ToInt32(job[0]),
                    PositionTitle = job[1],
                    PositionDescription = job[2],
                    CompanyName = job[3]
                };
            }
        }

        public List<ManagementService.Person> GetColleagues(string firstName, string lastName)
        {
            var allPersons = File.ReadAllLines(PERSON_PATH).Select(a => a.Split(','));
            var allJobs = File.ReadAllLines(JOB_PATH).Select(a => a.Split(','));

            Job job = GetJobInfo(firstName, lastName);
            if (job == null)
            {
                return null;
            }

            List<ManagementService.Person> result = new List<Person>();
            var personArrays = from person in allPersons
                               where person[8].Equals(job.PositionNumber.ToString())
                               select person;
            foreach (var person in personArrays)
            {
                result.Add(new Person()
                {
                    FirstName = person[0],
                    LastName = person[1],
                    DateOfBirth = Convert.ToDateTime(person[2]),
                    Email = person[3],
                    StreetAddress = person[4],
                    Suburb = person[5],
                    State = person[6],
                    Postcode = Convert.ToInt32(person[7]),
                    Job = job
                });
            }

            return result;
        }
    }
}
