using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CdaGenerator
{
    public class ComponentOf
    {
        // ComponentOF

        public string OidClinicalActs { get; set; }

        public string ClinicalActId { get; set; }

        public string UserId { get; set; }

        public string DoctorProfessionalLicense { get; set; }

        public string DoctorFirstName { get; set; }

        public string DoctorMiddleName { get; set; }

        public string DoctorLastName { get; set; }

        public string DoctorSurname { get; set; }

        public string OidOrganization { get; set; }

        public string OrganizationName { get; set; }

        public string Clues { get; set; }

        public string LocationName { get; set; }

        public string OrganizationAddress { get; set; }

        public string OrganizationPrecinct { get; set; }

        public string OrganizationCounty { get; set; }

        public string OrganizationState { get; set; }

        public string OrganizationPostalCode { get; set; }

        public string OrganizationCountry { get; set; }

        public DateTime DateTime { get; set; }

        public ComponentOf()
        {
            
        }

        public ComponentOf(string oidClinicalActs, string clinicalActId, string userId, string doctorProfessionalLicense, string doctorFirstName, string doctorMiddleName, string doctorLastName, string doctorSurname, string oidOrganization, string organizationName, string clues, string locationName, string organizationAddress, string organizationPrecinct, string organizationCounty, string organizationState, string organizationPostalCode, string organizationCountry, DateTime dateTime)
        {
            OidClinicalActs = oidClinicalActs;
            ClinicalActId = clinicalActId;
            UserId = userId;
            DoctorProfessionalLicense = doctorProfessionalLicense;
            DoctorFirstName = doctorFirstName;
            DoctorMiddleName = doctorMiddleName;
            DoctorLastName = doctorLastName;
            DoctorSurname = doctorSurname;
            OidOrganization = oidOrganization;
            OrganizationName = organizationName;
            Clues = clues;
            LocationName = locationName;
            OrganizationAddress = organizationAddress;
            OrganizationPrecinct = organizationPrecinct;
            OrganizationCounty = organizationCounty;
            OrganizationState = organizationState;
            OrganizationPostalCode = organizationPostalCode;
            OrganizationCountry = organizationCountry;
            DateTime = dateTime;
        }
    }
}
