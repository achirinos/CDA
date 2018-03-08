using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CdaGenerator
{
    public class Patient
    {
        // Patient

        public string PatientId { get; set; }

        public string PatientNationalIdentityCode { get; set; }

		public string PatientSocialSecurityNumber { get; set; }

		public string PatientExpedientNumber { get; set; }

		public string PatientStreet { get; set; }

        public string PatientExtrenalNumber { get; set; }

        public string PatientInternalNumber { get; set; }

        public string PatientNeighborhood { get; set; }

        public string PatientMunicipality { get; set; }

        public string PatientCity { get; set; }

        public string PatientState { get; set; }

        public string PatientZipCode { get; set; }

        public string PatientPhoneNumber { get; set; }

        public string PatientEmail { get; set; }

        public string PatientFirstName { get; set; }

        public string PatientLastName { get; set; }

        public string PatientSurname { get; set; }

        public string PatientGender { get; set; }

        public DateTime PatientBirthDate { get; set; }

        public string PatientCivilState { get; set; }

        public string PatientReligion { get; set; }

        public string PatientEthnicity { get; set; }

        public string PatientBirthPlaceState { get; set; }

        public string PatientBirthPlaceCountry { get; set; }

        public Patient()
        {
            
        }

		public Patient(string patientId,string patientNationalIdentityCode, string patientSocialSecurityNumber, string patientExpedientNumber, string patientStreet, string patientExtrenalNumber, string patientInternalNumber, string patientNeighborhood, string patientMunicipality, string patientCity, string patientState, string patientZipCode, string patientPhoneNumber, string patientEmail, string patientFirstName, string patientLastName, string patientSurname, string patientGender, DateTime patientBirthDate, string patientCivilState, string patientReligion, string patientEthnicity, string patientBirthPlaceState, string patientBirthPlaceCountry)
        {
            PatientId = patientId;
            PatientNationalIdentityCode = patientNationalIdentityCode;
			PatientSocialSecurityNumber = patientSocialSecurityNumber;
			PatientExpedientNumber = patientExpedientNumber;
            PatientStreet = patientStreet;
            PatientExtrenalNumber = patientExtrenalNumber;
            PatientInternalNumber = patientInternalNumber;
            PatientNeighborhood = patientNeighborhood;
            PatientMunicipality = patientMunicipality;
            PatientCity = patientCity;
            PatientState = patientState;
            PatientZipCode = patientZipCode;
            PatientPhoneNumber = patientPhoneNumber;
            PatientEmail = patientEmail;
            PatientFirstName = patientFirstName;
            PatientLastName = patientLastName;
            PatientSurname = patientSurname;
            PatientGender = patientGender;
            PatientBirthDate = patientBirthDate;
            PatientCivilState = patientCivilState;
            PatientReligion = patientReligion;
            PatientEthnicity = patientEthnicity;
            PatientBirthPlaceState = patientBirthPlaceState;
            PatientBirthPlaceCountry = patientBirthPlaceCountry;
        }


    }
}
