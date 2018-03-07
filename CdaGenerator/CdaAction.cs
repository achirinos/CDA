using CdaGenerator.Helper;
using Lumed.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CdaGenerator
{
    public partial class Cda
    {

        

        public static void GenerateResponse()
        {

            

            /*#region

            CDA cda = new CDA();

            // Header
            cda.SystemDocumentId = "systemDocumentId";
            cda.SystemDocumentName = "systemDocumentName";
            cda.HeaderDateTime = DateTime.Now;

            // Patient
            cda.PatientId = "patientId";
            cda.PatientNationalIdentityCode = "patientNationalIdentityCode";
            cda.PatientStreet = "patientStree";
            cda.PatientExtrenalNumber = "patientExtrenalNumber";
            cda.PatientInternalNumber = "patientInternalNumber";
            cda.PatientNeighborhood = "patientNeighborhood";
            cda.PatientMunicipality = "patientMunicipality";
            cda.PatientCity = "patientCity";
            cda.PatientState = "patientState";
            cda.PatientZipCode = "patientZipCode";
            cda.PatientPhoneNumber = "patientPhoneNumber";
            cda.PatientEmail = "patientEmail";
            cda.PatientFirstName = "patientFirstName";
            cda.PatientLastName = "patientLastName";
            cda.PatientSurname = "patientSurname";
            cda.PatientGender = "patientGender";
            cda.PatientBirthDate = DateTime.Now;
            cda.PatientCivilState = "patientCivilState";
            cda.PatientReligion = "patientReligion";
            cda.PatientEthnicity = "patientEthnicity";
            cda.PatientBirthPlaceState = "patientBirthPlaceState";
            cda.PatientBirthPlaceCountry = "patientBirthPlaceCountry";

            // Author
            cda.AuthorDoctorId = "doctorId";
            cda.AuthorDoctorProfessionalLicense = "doctorProfessionalLicense";
            cda.AuthorDoctorFirstName = "doctorFirstName";
            cda.AuthorDoctorMiddleName = "doctorMiddleName";
            cda.AuthorDoctorLastName = "doctorLastName";
            cda.AuthorDoctorSurname = "doctorSurname";
            cda.AuthorOidSpecialty = "oidSpecialty";
            cda.AuthorSpecialtyName = "specialtyName";
            cda.AuthorDateTime = DateTime.Now;
            cda.AuthorOidOrganization = "oidOrganization";
            cda.AuthorOrganizationName = "organizationName";

            // custodian
            cda.OidCustodianOrganization = "oidCustodianOrganization";
            cda.CustodianOrganizationName = "CustodianOrganizationName";
            cda.CustodianOrganizationTelecom = "CustodianOrganizationTelecom";
            cda.CustodianOrganizationAddress = "CustodianOrganizationAddress";
            cda.CustodianOrganizationPrecinct = "CustodianOrganizationPrecinct";
            cda.CustodianOrganizationCounty = "CustodianOrganizationCounty";
            cda.CustodianOrganizationState = "CustodianOrganizationState";
            cda.CustodianOrganizationPostalCode = "CustodianOrganizationPostalCode";
            cda.CustodianOrganizationCountry = "CustodianOrganizationCountry";

            // ComponentOF

            cda.OidClinicalActs = "oidClinicalActs";
            cda.ClinicalActId = "clinicalActId";
            cda.UserId = "userID";
            cda.DoctorProfessionalLicense = "doctorProfessionalLicense";
            cda.DoctorFirstName = "doctorFirstName";
            cda.DoctorMiddleName = "doctorMiddleName";
            cda.DoctorLastName = "doctorLastName";
            cda.DoctorSurname = "doctorSurname";
            cda.OidOrganization = "oidOrganization";
            cda.OrganizationName = "organizationName";
            cda.Clues = "clues";
            cda.LocationName = "locationName";
            cda.OrganizationAddress = "organizationAddress";
            cda.OrganizationPrecinct = "organizationPrecinct";
            cda.OrganizationCounty = "organizationCounty";
            cda.OrganizationState = "organizationState";
            cda.OrganizationPostalCode = "organizationPostalCode";
            cda.OrganizationCountry = "organizationCountry";


            // Software
           cda.SoftwareName = "Lumed";
           cda.DateTime = DateTime.Now;
           cda.SoftwareInstitutionName = "Netemedical";

            // Data Enterer
            cda.UserFullName = "userFullName";

            // InformationRecipient            
            cda.RecipientDoctorProfessionalLicense = "doctorProfessionalLicense";
            cda.RecipientDoctorFirstName = "doctorFirstName";
            cda.RecipientDoctorMiddleName = "doctorMiddleName";
            cda.RecipientDoctorLastName = "doctorLastName";
            cda.RecipientDoctorSurname = "doctorSurname";
            cda.RecipientDateTime = DateTime.Now;
            cda.RecipientOidOrganization = "2.16.840.1.113883.3.215.6.99.5";

            cda.RecipientOrganizationName = "organizationName";

            // LegalAuthenticator
            cda.OidSpecialty = "oidSpeialty";
            cda.SpecialtyName = "specialtyName";

            // Component
            cda.Interrogatory = "interrogatory";
            cda.Diagnostic = "diagnostic";
            cda.Orders = "orders";
            cda.TreatmentPlan = "treatmenPlan";

            // UpdateInFulfillmentOf
            cda.OidOrders = "oidOrders";
            cda.OrderId = "orderId";

            #endregion

            var fileName = Path.GetTempFileName();
            var xdoc = CdaHelper.CreateCda(TemplateResponse);



            if (xdoc != null)
            {
                CdaHelper.UpdateHeader(xdoc, OidSystemDocuments, cda.SystemDocumentId, cda.SystemDocumentName, cda.HeaderDateTime, "N");
                CdaHelper.UpdatePatient(xdoc, OidSystemPatients, patientId, patientNationalIdentityCode, patientStreet, patientExtrenalNumber, patientInternalNumber, patientNeighborhood, patientMunicipality, patientCity, patientState, patientZipCode, patientPhoneNumber, patientEmail, patientFirstName, patientLastName, patientSurname, patientGender, patientBirthDate, patientCivilState, patientReligion, patientEthnicity, patientBirthPlaceState, patientBirthPlaceCountry);

                CdaHelper.UpdateAuthor(xdoc, OidSystemUsers, authorDoctorId, authorDoctorProfessionalLicense, authorDoctorFirstName, authorDoctorMiddleName, authorDoctorLastName, authorDoctorSurname, authorOidSpecialty, authorSpecialtyName, authorDateTime, authorOidOrganization, authorOrganizationName);

                CdaHelper.UpdateSoftware(xdoc, dateTime, OidSystemInstance, softwareName, OidInstitution, softwareInstitutionName);

                CdaHelper.UpdateDataEnterer(xdoc, dateTime, OidSystemUsers, userId, userFullName);

                CdaHelper.UpdateCustodian(xdoc, oidCustodianOrganization, custodianOrganizationName, custodianOrganizationTelecom, custodianOrganizationAddress, custodianOrganizationPrecinct, custodianOrganizationCounty, custodianOrganizationState, custodianOrganizationPostalCode, custodianOrganizationCountry);

                CdaHelper.UpdateInformationRecipient(xdoc, recipientDoctorProfessionalLicense, recipientDoctorFirstName, recipientDoctorMiddleName, recipientDoctorLastName, recipientDoctorSurname, recipientOidOrganization, recipientOrganizationName);

                CdaHelper.LegalAuthenticator(xdoc, dateTime, OidSystemUsers, userId, doctorProfessionalLicense, oidSpecialty, specialtyName, doctorFirstName, doctorMiddleName, doctorLastName, doctorSurname, oidOrganization, organizationName);

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

        public void GenerateRequest()
        {

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

            // LegalAuthenticator
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

                CdaHelper.LegalAuthenticator(xdoc, dateTime, OidSystemUsers, userId, doctorProfessionalLicense, oidSpecialty, specialtyName, doctorFirstName, doctorMiddleName, doctorLastName, doctorSurname, oidOrganization, organizationName);

                CdaHelper.UpdateAuthenticator(xdoc, dateTime, OidSystemUsers, userId, doctorProfessionalLicense, oidSpecialty, specialtyName, doctorFirstName, doctorMiddleName, doctorLastName, doctorSurname, oidOrganization, organizationName);

                CdaHelper.UpdateInFulfillmentOf(xdoc, oidOrders, orderId);

                CdaHelper.UpdateComponent(xdoc, reasonOfReferal, interrogatory, allergies, procedures, medication, physicalExam, vitalSigns, results, assesment);

                CdaHelper.UpdateComponentOf(xdoc, oidClinicalActs, clinicalActId, OidSystemUsers, userId, dateTime, doctorProfessionalLicense, doctorFirstName, doctorMiddleName, doctorLastName, doctorSurname, oidOrganization, organizationName, clues, locationName, organizationAddress, organizationPrecinct, organizationCounty, organizationState, organizationPostalCode, organizationCountry);

                //Saves the file
                Console.WriteLine(fileName);
                CdaHelper.SaveCda(xdoc, fileName);
                Console.ReadLine();
            }*/
        }
    }
}