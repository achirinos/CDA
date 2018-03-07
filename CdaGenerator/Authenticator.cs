using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CdaGenerator
{
    public class Authenticator
    {
        public DateTime DateTime { get; set; }

        public string UserId { get; set; }

        public string DoctorProfessionalLicense { get; set; }

        public string OidSpecialty { get; set; }

        public string SpecialtyName { get; set; }

        public string DoctorFirstName { get; set; }

        public string DoctorMiddleName { get; set; }

        public string DoctorLastName { get; set; }

        public string DoctorSurname { get; set; }

        public string OidOrganization { get; set; }

        public string OrganizationName { get; set; }

        public Authenticator()
        {
            
        }

        public Authenticator(DateTime dateTime, string userId, string doctorProfessionalLicense, string oidSpecialty, string specialtyName, string doctorFirstName, string doctorMiddleName, string doctorLastName, string doctorSurname, string oidOrganization, string organizationName)
        {
            DateTime = dateTime;
            UserId = userId;
            DoctorProfessionalLicense = doctorProfessionalLicense;
            OidSpecialty = oidSpecialty;
            SpecialtyName = specialtyName;
            DoctorFirstName = doctorFirstName;
            DoctorMiddleName = doctorMiddleName;
            DoctorLastName = doctorLastName;
            DoctorSurname = doctorSurname;
            OidOrganization = oidOrganization;
            OrganizationName = organizationName;
        }
    }
}
