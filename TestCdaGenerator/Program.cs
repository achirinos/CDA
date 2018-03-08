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
                SystemDocumentId = "d342c1b1-2262-4997-83b7-b7d1fd764e0f",
                SystemDocumentName = "systemDocumentName",
                HeaderDateTime = DateTime.Now
            };

            Patient patient = new Patient
            {
                PatientId = "V-11734823",
                PatientNationalIdentityCode = "ACHIR000000HASSMS00",
				PatientExpedientNumber = "A-123-456",
				PatientSocialSecurityNumber = "123456789012345",
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
                AuthorDoctorProfessionalLicense = "987654321",
                AuthorDoctorFirstName = "Rodrigo",
                AuthorDoctorMiddleName = "",
                AuthorDoctorLastName = "Diaz",
                AuthorDoctorSurname = "Concha",
                AuthorOidSpecialty = "0711",
                AuthorSpecialtyName = "MEDICINA GENERAL",
                AuthorDateTime = DateTime.Now,
                AuthorOidOrganization = "oidOrganization",
                AuthorOrganizationName = "Secretaria de Salud de Aguascalientes"
            };
            // Author

            Custodian custodian = new Custodian
            {
                OidCustodianOrganization = "oidCustodianOrganization",
                CustodianOrganizationName = "Centro Nacional de Excelencia Tecnológica en Salud (CENETEC)",
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
                AttentionCode = "09-12",
                ClinicalActId = "Clinica Calvillo",
                UserId = "userID",
                DoctorProfessionalLicense = "1234567",
                DoctorFirstName = "Luis",
                DoctorMiddleName = "Daniel",
                DoctorLastName = "Estrada",
                DoctorSurname = "Ramos",
                OidOrganization = "oidOrganization",
                OrganizationName = "Instituto de salud de Aguascalientes",
                Clues = "AGSCAL000152",
                LocationName = "Hospital General de Calvillo",
                LocationAddress = "Bloulevard Rodolfo Landeros SN",
                LocationPrecinct = "Calvillo",
                LocationCounty = "Calvillo",
                LocationState = "Aguascalientes",
                LocationPostalCode = "20800",
                LocationCountry = "MX",
				AttentionDateTime = new DateTime(2018,1,1,10,5,9),

			};


            // Software
            Software software = new Software
            {
                SoftwareName = "Lumed 1.2.0.0",
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
                    RecipientOrganizationName = "Servicios de Saud de Calvillo"
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
                ReasonOfReferal = "Motivo de la interconsulta",
                Allergies = "Alergias del paciente. En caso de que no se tengan registradas alergias, se debe mostrar 'Sin alergias registradas'.",
                Assesment = "Impresión Diagnóstica descrita por el médico",
                Interrogatory = "Resumen del interrogatorio. Narración del problema que es motivo de esta atención.",
                Procedures = "Procedimientos quirúrgicos y terapéuticos. En su caso indicar 'Sin procedimientos registrados'.",
                Medication = "Tratamiento farmacológico. En su caso indicar 'Sin tratamiento farmacológico registrado'.",
                PhysicalExam = "Exploración física y estado mental (en su caso)",
                Results = "Descripción de resultados relevenates de los servicios auxiliares de diangóstico y tratamiento que hayan sido solicitados previamente.En su caso indicar 'Sin resultados de estudios'.",
                VitalSigns = "Signos Vitales"
			};

            ComponentResponse componentResponse = new ComponentResponse
            {
                Interrogatory = "Resumen del interrogatorio. Narración del problema que es motivo de esta atención.",
                Diagnostic = "Impresión Diagnóstica descrita por el médico",
                Orders = "Sugerencia de estudios que se deberán realizar al paciente posterior a la interconsulta. (considerar que se incluye en Plan de tratamiento)",
				TreatmentPlan = "Sugerencia del Plan de tratamiento y recomendaciones terapéuticas a seguir."
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
			response.SaveResponsePdf();


            //cdaRequest.Patient.PatientFirstName;
            Cda request = new Cda(cdaRequest);
            request.Save("request.xml");
            request.SaveRequestPdf();

        }
    }
}
