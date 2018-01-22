using CdaGenerator.Helper;
using Lumed.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CdaGenerator
{
    public class CdaAction
    {
        
        private const string OidInstitution = "2.16.840.1.113883.3.215.6.99.5";
        private const string OidSystemDocuments = "2.16.840.1.113883.3.215.6.99.5.1.1";
        private const string OidSystemPatients = "2.16.840.1.113883.3.215.6.99.5.1.2";
        private const string OidSystemUsers = "2.16.840.1.113883.3.215.6.99.5.1.3";
        private const string OidSystemInstance = "2.16.840.1.113883.3.215.6.99.5.1";

        private const string TemplateRequest = "plantilla_nota_solicitud.xml";
        private const string TemplateResponse = "plantilla_nota_respuesta.xml";

        public void GenerateResponse() {

            #region

            // Header
            string systemDocumentId = "systemDocumentId";
            string systemDocumentName = "systemDocumentName";
            DateTime headerDateTime = DateTime.Now;

            // Patient
            string patientId = "patientId";
            string patientNationalIdentityCode = "patientNationalIdentityCode";
            string patientStreet = "patientStree";
            string patientExtrenalNumber = "patientExtrenalNumber";
            string patientInternalNumber = "patientInternalNumber";
            string patientNeighborhood = "patientNeighborhood";
            string patientMunicipality = "patientMunicipality";
            string patientCity = "patientCity";
            string patientState = "patientState";
            string patientZipCode = "patientZipCode";
            string patientPhoneNumber = "patientPhoneNumber";
            string patientEmail = "patientEmail";
            string patientFirstName = "patientFirstName";
            string patientLastName = "patientLastName";
            string patientSurname = "patientSurname";
            string patientGender = "patientGender";
            DateTime patientBirthDate = DateTime.Now;
            string patientCivilState = "patientCivilState";
            string patientReligion = "patientReligion";
            string patientEthnicity = "patientEthnicity";
            string patientBirthPlaceState = "patientBirthPlaceState";
            string patientBirthPlaceCountry = "patientBirthPlaceCountry";

            // Author
            string authorDoctorId = "doctorId";
            string authorDoctorProfessionalLicense = "doctorProfessionalLicense";
            string authorDoctorFirstName = "doctorFirstName";
            string authorDoctorMiddleName = "doctorMiddleName";
            string authorDoctorLastName = "doctorLastName";
            string authorDoctorSurname = "doctorSurname";
            string authorOidSpecialty = "oidSpecialty";
            string authorSpecialtyName = "specialtyName";
            DateTime authorDateTime = DateTime.Now;
            string authorOidOrganization = "oidOrganization";
            string authorOrganizationName = "organizationName";

            // custodian
            string oidCustodianOrganization = "oidCustodianOrganization";
            string custodianOrganizationName = "CustodianOrganizationName";
            string custodianOrganizationTelecom = "CustodianOrganizationTelecom";
            string custodianOrganizationAddress = "CustodianOrganizationAddress";
            string custodianOrganizationPrecinct = "CustodianOrganizationPrecinct";
            string custodianOrganizationCounty = "CustodianOrganizationCounty";
            string custodianOrganizationState = "CustodianOrganizationState";
            string custodianOrganizationPostalCode = "CustodianOrganizationPostalCode";
            string custodianOrganizationCountry = "CustodianOrganizationCountry";

            // ComponentOF

            string oidClinicalActs = "oidClinicalActs";
            string clinicalActId = "clinicalActId";
            string userId = "userID";
            string doctorProfessionalLicense = "doctorProfessionalLicense";
            string doctorFirstName = "doctorFirstName";
            string doctorMiddleName = "doctorMiddleName";
            string doctorLastName = "doctorLastName";
            string doctorSurname = "doctorSurname";
            string oidOrganization = "oidOrganization";
            string organizationName = "organizationName";
            string clues = "clues";
            string locationName = "locationName";
            string organizationAddress = "organizationAddress";
            string organizationPrecinct = "organizationPrecinct";
            string organizationCounty = "organizationCounty";
            string organizationState = "organizationState";
            string organizationPostalCode = "organizationPostalCode";
            string organizationCountry = "organizationCountry";


            // Software
            var softwareName = "Lumed";
            var dateTime = DateTime.Now;
            var softwareInstitutionName = "Netemedical";

            // Data Enterer
            var userFullName = "userFullName";

            // InformationRecipient            
            string recipientDoctorProfessionalLicense = "doctorProfessionalLicense";
            string recipientDoctorFirstName = "doctorFirstName";
            string recipientDoctorMiddleName = "doctorMiddleName";
            string recipientDoctorLastName = "doctorLastName";
            string recipientDoctorSurname = "doctorSurname";
            DateTime recipientDateTime = DateTime.Now;
            string recipientOidOrganization = "2.16.840.1.113883.3.215.6.99.5";
            
            string recipientOrganizationName = "organizationName";

            // UpdateLegalAuthenticator
            var oidSpecialty = "oidSpeialty";
            var specialtyName = "specialtyName";

            // Component
            string interrogatory = "interrogatory";
            string diagnostic = "diagnostic";
            string orders = "orders";
            string treatmentPlan = "treatmenPlan";

            // UpdateInFulfillmentOf
            var oidOrders = "oidOrders";
            var orderId = "orderId";

            #endregion

            var fileName = Path.GetTempFileName();
            var xdoc = CdaHelper.CreateCda(TemplateResponse);

            if (xdoc != null)
            {
                CdaHelper.UpdateHeader(xdoc, OidSystemDocuments, systemDocumentId, systemDocumentName, headerDateTime, "N");
                CdaHelper.UpdatePatient(xdoc, OidSystemPatients, patientId, patientNationalIdentityCode, patientStreet, patientExtrenalNumber, patientInternalNumber, patientNeighborhood, patientMunicipality, patientCity, patientState, patientZipCode, patientPhoneNumber, patientEmail, patientFirstName, patientLastName, patientSurname, patientGender, patientBirthDate, patientCivilState, patientReligion, patientEthnicity, patientBirthPlaceState, patientBirthPlaceCountry);

                CdaHelper.UpdateAuthor(xdoc, OidSystemUsers, authorDoctorId, authorDoctorProfessionalLicense, authorDoctorFirstName, authorDoctorMiddleName, authorDoctorLastName, authorDoctorSurname, authorOidSpecialty, authorSpecialtyName, authorDateTime, authorOidOrganization, authorOrganizationName);

                CdaHelper.UpdateSoftware(xdoc, dateTime, OidSystemInstance, softwareName, OidInstitution, softwareInstitutionName);

                CdaHelper.UpdateDataEnterer(xdoc, dateTime, OidSystemUsers, userId, userFullName);

                CdaHelper.UpdateCustodian(xdoc, oidCustodianOrganization, custodianOrganizationName, custodianOrganizationTelecom, custodianOrganizationAddress, custodianOrganizationPrecinct, custodianOrganizationCounty, custodianOrganizationState, custodianOrganizationPostalCode, custodianOrganizationCountry);

                CdaHelper.UpdateInformationRecipient(xdoc, recipientDoctorProfessionalLicense, recipientDoctorFirstName, recipientDoctorMiddleName, recipientDoctorLastName, recipientDoctorSurname, recipientOidOrganization, recipientOrganizationName);

                CdaHelper.UpdateLegalAuthenticator(xdoc, dateTime, OidSystemUsers, userId, doctorProfessionalLicense, oidSpecialty, specialtyName, doctorFirstName, doctorMiddleName, doctorLastName, doctorSurname, oidOrganization, organizationName);

                CdaHelper.UpdateAuthenticator(xdoc, dateTime, OidSystemUsers, userId, doctorProfessionalLicense, oidSpecialty, specialtyName, doctorFirstName, doctorMiddleName, doctorLastName, doctorSurname, oidOrganization, organizationName);

                CdaHelper.UpdateInFulfillmentOf(xdoc, oidOrders, orderId);

                CdaHelper.UpdateComponent(xdoc, interrogatory, diagnostic, orders, treatmentPlan);

                CdaHelper.UpdateComponentOf(xdoc, oidClinicalActs, clinicalActId, OidSystemUsers, userId, dateTime, doctorProfessionalLicense, doctorFirstName, doctorMiddleName, doctorLastName, doctorSurname, oidOrganization, organizationName, clues, locationName, organizationAddress, organizationPrecinct, organizationCounty, organizationState, organizationPostalCode, organizationCountry);

                //Saves the file
                Console.WriteLine(fileName);
                CdaHelper.SaveCda(xdoc, fileName);
                Console.ReadLine();
            }
        }
    
        public void GenerateRequest() {

            #region

            // Header
            string systemDocumentId = "systemDocumentId";
            string systemDocumentName = "systemDocumentName";
            DateTime headerDateTime = DateTime.Now;

            // Patient
            string patientId = "patientId";
            string patientNationalIdentityCode = "patientNationalIdentityCode";
            string patientStreet = "patientStree";
            string patientExtrenalNumber = "patientExtrenalNumber";
            string patientInternalNumber = "patientInternalNumber";
            string patientNeighborhood = "patientNeighborhood";
            string patientMunicipality = "patientMunicipality";
            string patientCity = "patientCity";
            string patientState = "patientState";
            string patientZipCode = "patientZipCode";
            string patientPhoneNumber = "patientPhoneNumber";
            string patientEmail = "patientEmail";
            string patientFirstName = "patientFirstName";
            string patientLastName = "patientLastName";
            string patientSurname = "patientSurname";
            string patientGender = "patientGender";
            DateTime patientBirthDate = DateTime.Now;
            string patientCivilState = "patientCivilState";
            string patientReligion = "patientReligion";
            string patientEthnicity = "patientEthnicity";
            string patientBirthPlaceState = "patientBirthPlaceState";
            string patientBirthPlaceCountry = "patientBirthPlaceCountry";

            // Author
            string authorDoctorId = "doctorId";
            string authorDoctorProfessionalLicense = "doctorProfessionalLicense";
            string authorDoctorFirstName = "doctorFirstName";
            string authorDoctorMiddleName = "doctorMiddleName";
            string authorDoctorLastName = "doctorLastName";
            string authorDoctorSurname = "doctorSurname";
            string authorOidSpecialty = "oidSpecialty";
            string authorSpecialtyName = "specialtyName";
            DateTime authorDateTime = DateTime.Now;
            string authorOidOrganization = "oidOrganization";
            string authorOrganizationName = "organizationName";

            // custodian
            string oidCustodianOrganization = "oidCustodianOrganization";
            string custodianOrganizationName = "CustodianOrganizationName";
            string custodianOrganizationTelecom = "CustodianOrganizationTelecom";
            string custodianOrganizationAddress = "CustodianOrganizationAddress";
            string custodianOrganizationPrecinct = "CustodianOrganizationPrecinct";
            string custodianOrganizationCounty = "CustodianOrganizationCounty";
            string custodianOrganizationState = "CustodianOrganizationState";
            string custodianOrganizationPostalCode = "CustodianOrganizationPostalCode";
            string custodianOrganizationCountry = "CustodianOrganizationCountry";

            // ComponentOF

            string oidClinicalActs = "oidClinicalActs";
            string clinicalActId = "clinicalActId";
            string userId = "userID";
            string doctorProfessionalLicense = "doctorProfessionalLicense";
            string doctorFirstName = "doctorFirstName";
            string doctorMiddleName = "doctorMiddleName";
            string doctorLastName = "doctorLastName";
            string doctorSurname = "doctorSurname";
            string oidOrganization = "oidOrganization";
            string organizationName = "organizationName";
            string clues = "clues";
            string locationName = "locationName";
            string organizationAddress = "organizationAddress";
            string organizationPrecinct = "organizationPrecinct";
            string organizationCounty = "organizationCounty";
            string organizationState = "organizationState";
            string organizationPostalCode = "organizationPostalCode";
            string organizationCountry = "organizationCountry";


            // Software
            var softwareName = "Lumed";
            var dateTime = DateTime.Now;
            var softwareInstitutionName = "Netemedical";

            // Data Enterer
            var userFullName = "userFullName";

            // InformationRecipient            
            string recipientDoctorProfessionalLicense = "doctorProfessionalLicense";
            string recipientDoctorFirstName = "doctorFirstName";
            string recipientDoctorMiddleName = "doctorMiddleName";
            string recipientDoctorLastName = "doctorLastName";
            string recipientDoctorSurname = "doctorSurname";
            DateTime recipientDateTime = DateTime.Now;
            string recipientOidOrganization = "oidOrganization";
            string recipientOrganizationName = "organizationName";

            // UpdateLegalAuthenticator
            var oidSpecialty = "oidSpeialty";
            var specialtyName = "specialtyName";

            // Component
            string reasonOfReferal = "reasonOfReferal";
            string interrogatory = "interrogatory";
            string allergies = "allergies";
            string procedures = "procedures";
            string medication = "medication";
            string physicalExam = "physicalExam";
            string vitalSigns = "vitalSigns";
            string results = "results";
            string assesment = "assesment";

            // UpdateInFulfillmentOf
            var oidOrders = "oidOrders";
            var orderId = "orderId";

            #endregion

            var fileName = Path.GetTempFileName();
            var xdoc = CdaHelper.CreateCda(TemplateRequest);

            if (xdoc != null)
            {
                CdaHelper.UpdateHeader(xdoc, OidSystemDocuments, systemDocumentId, systemDocumentName, headerDateTime, "N");

                CdaHelper.UpdatePatient(xdoc, OidSystemPatients, patientId, patientNationalIdentityCode, patientStreet, patientExtrenalNumber, patientInternalNumber, patientNeighborhood, patientMunicipality, patientCity, patientState, patientZipCode, patientPhoneNumber, patientEmail, patientFirstName, patientLastName, patientSurname, patientGender, patientBirthDate, patientCivilState, patientReligion, patientEthnicity, patientBirthPlaceState, patientBirthPlaceCountry);

                CdaHelper.UpdateAuthor(xdoc, OidSystemUsers, authorDoctorId, authorDoctorProfessionalLicense, authorDoctorFirstName, authorDoctorMiddleName, authorDoctorLastName, authorDoctorSurname, authorOidSpecialty, authorSpecialtyName, authorDateTime, authorOidOrganization, authorOrganizationName);

                CdaHelper.UpdateSoftware(xdoc, dateTime, OidSystemInstance, softwareName, OidInstitution, softwareInstitutionName);

                CdaHelper.UpdateDataEnterer(xdoc, dateTime, OidSystemUsers, userId, userFullName);

                CdaHelper.UpdateCustodian(xdoc, oidCustodianOrganization, custodianOrganizationName, custodianOrganizationTelecom, custodianOrganizationAddress, custodianOrganizationPrecinct, custodianOrganizationCounty, custodianOrganizationState, custodianOrganizationPostalCode, custodianOrganizationCountry);

                CdaHelper.UpdateInformationRecipient(xdoc, recipientDoctorProfessionalLicense, recipientDoctorFirstName, recipientDoctorMiddleName, recipientDoctorLastName, recipientDoctorSurname, recipientOidOrganization, recipientOrganizationName);

                CdaHelper.UpdateLegalAuthenticator(xdoc, dateTime, OidSystemUsers, userId, doctorProfessionalLicense, oidSpecialty, specialtyName, doctorFirstName, doctorMiddleName, doctorLastName, doctorSurname, oidOrganization, organizationName);

                CdaHelper.UpdateAuthenticator(xdoc, dateTime, OidSystemUsers, userId, doctorProfessionalLicense, oidSpecialty, specialtyName, doctorFirstName, doctorMiddleName, doctorLastName, doctorSurname, oidOrganization, organizationName);

                CdaHelper.UpdateInFulfillmentOf(xdoc, oidOrders, orderId);

                CdaHelper.UpdateComponent(xdoc, reasonOfReferal, interrogatory, allergies, procedures, medication, physicalExam, vitalSigns, results, assesment);

                CdaHelper.UpdateComponentOf(xdoc, oidClinicalActs, clinicalActId, OidSystemUsers, userId, dateTime, doctorProfessionalLicense, doctorFirstName, doctorMiddleName, doctorLastName, doctorSurname, oidOrganization, organizationName, clues, locationName, organizationAddress, organizationPrecinct, organizationCounty, organizationState, organizationPostalCode, organizationCountry);

                //Saves the file
                Console.WriteLine(fileName);
                CdaHelper.SaveCda(xdoc, fileName);
                Console.ReadLine();
            }
        }
    }
}
