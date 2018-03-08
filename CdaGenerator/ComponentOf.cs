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

        public string ClinicalActId { get; set; }

		public string AttentionCode { get; set; }

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

        public string LocationAddress { get; set; }

        public string LocationPrecinct { get; set; }

        public string LocationCounty { get; set; }

        public string LocationState { get; set; }

        public string LocationPostalCode { get; set; }

        public string LocationCountry { get; set; }

        public DateTime AttentionDateTime { get; set; }

        public ComponentOf()
        {
            
        }

        public ComponentOf(string clinicalActId, string attentionCode, string userId, string doctorProfessionalLicense, string doctorFirstName, string doctorMiddleName, string doctorLastName, string doctorSurname, string oidOrganization, string organizationName, string clues, string locationName, string locationAddress, string locationPrecinct, string locationCounty, string locationnState, string locationPostalCode, string organizationCountry, DateTime attentionDateTime)
        {
            ClinicalActId = clinicalActId;
			AttentionCode = attentionCode;
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
            LocationAddress = locationAddress;
            LocationPrecinct = locationPrecinct;
            LocationCounty = locationCounty;
            LocationState = locationnState;
            LocationPostalCode = locationPostalCode;
            LocationCountry = organizationCountry;
            AttentionDateTime = attentionDateTime;
        }
    }
}
