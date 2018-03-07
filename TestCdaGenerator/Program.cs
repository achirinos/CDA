using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CdaGenerator;

namespace TestCdaGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Header header = new Header
            {
                SystemDocumentId = "systemDocumentId",
                SystemDocumentName = "systemDocumentName",
                HeaderDateTime = DateTime.Now
            };

            Patient patient = new Patient
            {
                PatientId = "V-11734823",
                PatientNationalIdentityCode = "VE",
                PatientStreet = "Av Lazaro Cardenas",
                PatientExtrenalNumber = "14273114",
                PatientInternalNumber = "11734823",
                PatientNeighborhood = "Tlatelolco",
                PatientMunicipality = "Cuauhtemoc",
                PatientCity = "Ciudad de Mexico",
                PatientState = "Mexico DF",
                PatientZipCode = "90200",
                PatientPhoneNumber = "+555",
                PatientEmail = "achirinos@lumed.mx",
                PatientFirstName = "Asdrubal",
                PatientLastName = "Chirinos",
                PatientSurname = "Castillo",
                PatientGender = "MM",
                PatientBirthDate = new DateTime(1973,11,16),
                PatientCivilState = "MM",
                PatientReligion = "Jedi",
                PatientEthnicity = "Latin",
                PatientBirthPlaceState = "Zulia",
                PatientBirthPlaceCountry = "Venezuela"
            };
            // Patient

            Author author = new Author
            {
                AuthorDoctorId = "doctorId",
                AuthorDoctorProfessionalLicense = "doctorProfessionalLicense",
                AuthorDoctorFirstName = "doctorFirstName",
                AuthorDoctorMiddleName = "doctorMiddleName",
                AuthorDoctorLastName = "doctorLastName",
                AuthorDoctorSurname = "doctorSurname",
                AuthorOidSpecialty = "oidSpecialty",
                AuthorSpecialtyName = "specialtyName",
                AuthorDateTime = DateTime.Now,
                AuthorOidOrganization = "oidOrganization",
                AuthorOrganizationName = "organizationName"
            };
            // Author

            Custodian custodian = new Custodian
            {
                OidCustodianOrganization = "oidCustodianOrganization",
                CustodianOrganizationName = "CustodianOrganizationName",
                CustodianOrganizationTelecom = "CustodianOrganizationTelecom",
                CustodianOrganizationAddress = "CustodianOrganizationAddress",
                CustodianOrganizationPrecinct = "CustodianOrganizationPrecinct",
                CustodianOrganizationCounty = "CustodianOrganizationCounty",
                CustodianOrganizationState = "CustodianOrganizationState",
                CustodianOrganizationPostalCode = "CustodianOrganizationPostalCode",
                CustodianOrganizationCountry = "CustodianOrganizationCountry"
            };
            // custodian

            // ComponentOF
            ComponentOf componentOf = new ComponentOf
            {
                OidClinicalActs = "oidClinicalActs",
                ClinicalActId = "clinicalActId",
                UserId = "userID",
                DoctorProfessionalLicense = "doctorProfessionalLicense",
                DoctorFirstName = "doctorFirstName",
                DoctorMiddleName = "doctorMiddleName",
                DoctorLastName = "doctorLastName",
                DoctorSurname = "doctorSurname",
                OidOrganization = "oidOrganization",
                OrganizationName = "organizationName",
                Clues = "clues",
                LocationName = "locationName",
                OrganizationAddress = "organizationAddress",
                OrganizationPrecinct = "organizationPrecinct",
                OrganizationCounty = "organizationCounty",
                OrganizationState = "organizationState",
                OrganizationPostalCode = "organizationPostalCode",
                OrganizationCountry = "organizationCountry"
            };


            // Software
            Software software = new Software
            {
                SoftwareName = "Lumed",
                DateTime = DateTime.Now,
                SoftwareInstitutionName = "Netemedical"
            };


            // Data Enterer
            DataEnterer dataEnterer = new DataEnterer
            {
                UserFullName = "userFullName",
                Date = DateTime.Now,
                UserId = "User Id"
            };

            InformationRecipient informationRecipient =
                new InformationRecipient
                {
                    RecipientDoctorProfessionalLicense = "doctorProfessionalLicense",
                    RecipientDoctorFirstName = "doctorFirstName",
                    RecipientDoctorMiddleName = "doctorMiddleName",
                    RecipientDoctorLastName = "doctorLastName",
                    RecipientDoctorSurname = "doctorSurname",
                    RecipientDateTime = DateTime.Now,
                    RecipientOidOrganization = "2.16.840.1.113883.3.215.6.99.5",
                    RecipientOrganizationName = "organizationName"
                };
            // InformationRecipient            

            Authenticator authenticator = new Authenticator
            {
                DateTime = DateTime.Now,
                DoctorFirstName = "Doctor First Name",
                DoctorLastName = "Doctor Last Name",
                DoctorMiddleName = "Doctor Middle Name",
                DoctorProfessionalLicense = "Professional License",
                DoctorSurname = "Doctor Surname",
                OidOrganization = "organization Id",
                OidSpecialty = "Specialty Id",
                OrganizationName = "Organization Name",
                SpecialtyName = "Specialty Name",
                UserId = "UserId"
            };

            LegalAuthenticator legalAuthenticator = new LegalAuthenticator
            {
                OidSpecialty = "oidSpeialty",
                SpecialtyName = "specialtyName",
                DateTime = DateTime.Now,
                DoctorFirstName = "Doctor First Name",
                DoctorLastName = "Doctor Last Name",
                DoctorMiddleName = "Doctor Middle Name",
                DoctorProfessionalLicense = "Professional Lincense",
                DoctorSurname = "Surname",
                OidOrganization = "Organization Id",
                OrganizationName = "Organication Name",
                UserId = "User Id",
        };
            

            // Component
            ComponentRequest componentRequest = new ComponentRequest
            {
                ReasonOfReferal = "Reason of referal",
                Allergies = "Alergies",
                Assesment = "Assesment",
                Interrogatory = "interrogatory",
                Procedures = "procedures",
                Medication = "medication",
                PhysicalExam = "physical exam",
                Results = "Results",
                VitalSigns = "Vital Signs"
            };

            ComponentResponse componentResponse = new ComponentResponse
            {
                Interrogatory = "interrogatory",
                Diagnostic = "diagnostic",
                Orders = "orders",
                TreatmentPlan = "treatmenPlan"
            };

            InFulfillmentOf inFulfillmentOf = new InFulfillmentOf
            {
                OidOrders = "oidOrders",
                OrderId = "orderId"
            };
            // UpdateInFulfillmentOf

            CdaResponse cdaResponse = new CdaResponse
            {
                Header = header,
                Authenticator = authenticator,
                Author = author,
                Component = componentResponse,
                ComponentOf = componentOf,
                Custodian = custodian,
                DataEnterer = dataEnterer,
                InformationRecipient = informationRecipient,
                InFulfillmentOf = inFulfillmentOf,
                LegalAuthenticator = legalAuthenticator,
                Patient = patient,
                Software = software
            };

            CdaRequest cdaRequest = new CdaRequest
            {
                Header = header,
                Authenticator = authenticator,
                Author = author,
                Component = componentRequest,
                ComponentOf = componentOf,
                Custodian = custodian,
                DataEnterer = dataEnterer,
                InformationRecipient = informationRecipient,
                InFulfillmentOf = inFulfillmentOf,
                LegalAuthenticator = legalAuthenticator,
                Patient = patient,
                Software = software
            };

            Cda response = new Cda(cdaResponse);


            //cdaRequest.Patient.PatientFirstName;
            Cda request = new Cda(cdaRequest);


            request.Save("request.xml");
            request.Pdf();

        }
    }
}
