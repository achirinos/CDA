using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CdaGenerator
{
    public class LegalAuthenticator
    {
        // LegalAuthenticator

        public string OidSpecialty { get; set; }

        public string SpecialtyName { get; set; }

        public DateTime DateTime { get; set; }

        public string UserId { get; set; }

        public string DoctorProfessionalLicense { get; set; }
        
        public string DoctorFirstName { get; set; }

        public string DoctorMiddleName { get; set; }

        public string DoctorLastName { get; set; }

        public string DoctorSurname { get; set; }

        public string OidOrganization { get; set; }

        public string OrganizationName { get; set; }

        public LegalAuthenticator()
        {
            
        }

        public LegalAuthenticator(string oidSpecialty, string specialtyName, DateTime dateTime, string userId, string doctorProfessionalLicense, string doctorFirstName, string doctorMiddleName, string doctorLastName, string doctorSurname, string oidOrganization, string organizationName)
        {
            OidSpecialty = oidSpecialty;
            SpecialtyName = specialtyName;
            DateTime = dateTime;
            UserId = userId;
            DoctorProfessionalLicense = doctorProfessionalLicense;
            DoctorFirstName = doctorFirstName;
            DoctorMiddleName = doctorMiddleName;
            DoctorLastName = doctorLastName;
            DoctorSurname = doctorSurname;
            OidOrganization = oidOrganization;
            OrganizationName = organizationName;
        }
    }
}
