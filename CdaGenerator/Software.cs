using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CdaGenerator
{
    public class Software
    {
        // Software

        public string SoftwareName { get; set; }

        public DateTime DateTime { get; set; }

        public string SoftwareInstitutionName { get; set; }

        public Software()
        {
            
        }

        public Software(string softwareName, DateTime dateTime, string softwareInstitutionName)
        {
            SoftwareName = softwareName;
            DateTime = dateTime;
            SoftwareInstitutionName = softwareInstitutionName;
        }
    }
}
