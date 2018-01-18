using Lumed.Entities;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Resolvers;
using System.Xml.XPath;

namespace Lumed.Interop.Cenetec.Helpers
{
    public class CdaHelper
    {
        private static string TemplateFileName = "plantilla_nota_solicitud.xml";

        public static string HeaderIdPath = "ns:ClinicalDocument/ns:id";
        public static string HeaderSetIdPath = "ns:ClinicalDocument/ns:setId";
        public static string HeaderTitlePath = "ns:ClinicalDocument/ns:title";
        public static string HeaderEffectiveTimePath = "ns:ClinicalDocument/ns:effectiveTime";
        public static string HeaderConfidentialityCodePath = "ns:ClinicalDocument/ns:confidentialityCode";
        public static string PatientIdPath = "ns:ClinicalDocument/ns:recordTarget/ns:patientRole/ns:id[1]";

        public static string PatientNationalIdentifierPath =
            "ns:ClinicalDocument/ns:recordTarget/ns:patientRole/ns:id[2]";

        public static string PatientAddressPath = "ns:ClinicalDocument/ns:recordTarget/ns:patientRole/ns:addr";
        public static string PatientPhoneNumberPath = "ns:ClinicalDocument/ns:recordTarget/ns:patientRole/ns:telecom[1]";
        public static string PatientEmailPath = "ns:ClinicalDocument/ns:recordTarget/ns:patientRole/ns:telecom[2]";

        public static string PatientFirstNamePath =
            "ns:ClinicalDocument/ns:recordTarget/ns:patientRole/ns:patient/ns:name/ns:given";

        public static string PatientLastNamePath =
            "ns:ClinicalDocument/ns:recordTarget/ns:patientRole/ns:patient/ns:name/ns:family[1]";

        public static string PatientSurnamePath =
            "ns:ClinicalDocument/ns:recordTarget/ns:patientRole/ns:patient/ns:name/ns:family[2]";

        public static string PatientGenderPath =
            "ns:ClinicalDocument/ns:recordTarget/ns:patientRole/ns:patient/ns:administrativeGenderCode";

        public static string PatientBirthTimePath =
            "ns:ClinicalDocument/ns:recordTarget/ns:patientRole/ns:patient/ns:birthTime";

        public static string PatientMaritalStatusCodePath =
            "ns:ClinicalDocument/ns:recordTarget/ns:patientRole/ns:patient/ns:maritalStatusCode";

        public static string PatientReligiousAffiliationCodePath =
            "ns:ClinicalDocument/ns:recordTarget/ns:patientRole/ns:patient/ns:religiousAffiliationCode";

        public static string PatientEthnicGroupCodePath =
            "ns:ClinicalDocument/ns:recordTarget/ns:patientRole/ns:patient/ns:ethnicGroupCode";

        public static string PatientBirthplaceStatePath =
            "ns:ClinicalDocument/ns:recordTarget/ns:patientRole/ns:patient/ns:birthplace/ns:place/ns:addr/ns:state";

        public static string PatientBirthplaceCountryPath =
            "ns:ClinicalDocument/ns:recordTarget/ns:patientRole/ns:patient/ns:birthplace/ns:place/ns:addr/ns:country";

        public static string AuthorTimePath = "ns:ClinicalDocument/ns:author/ns:time";
        public static string AuthorIdPath = "ns:ClinicalDocument/ns:author/ns:assignedAuthor/ns:id[1]";
        public static string AuthorProfessionalDocumentPath = "ns:ClinicalDocument/ns:author/ns:assignedAuthor/ns:id[2]";
        public static string AuthorSpecialtyPath = "ns:ClinicalDocument/ns:author/ns:assignedAuthor/ns:code";
        public static string AuthorNamePath = "ns:ClinicalDocument/ns:author/ns:assignedAuthor/ns:assignedPerson/ns:name/ns:given";
        public static string AuthorOrganizationIdPath = "ns:ClinicalDocument/ns:author/ns:assignedAuthor/ns:representedOrganization/ns:id";
        public static string AuthorOrganizationNamePath = "ns:ClinicalDocument/ns:author/ns:assignedAuthor/ns:representedOrganization/ns:name";

        public static string SoftwareTimePath = "ns:ClinicalDocument/ns:author[2]/ns:time";
        public static string SoftwareIdPath = "ns:ClinicalDocument/ns:author[2]/ns:assignedAuthor/ns:id";

        public static string SoftwareNamePath =
            "ns:ClinicalDocument/ns:author[2]/ns:assignedAuthor/ns:assignedAuthoringDevice/ns:softwareName";

        public static string SoftwareOrganizationIdPath =
            "ns:ClinicalDocument/ns:author[2]/ns:assignedAuthor/ns:representedOrganization/ns:id";
        public static string SoftwareOrganizationNamePath =
            "ns:ClinicalDocument/ns:author[2]/ns:assignedAuthor/ns:representedOrganization/ns:name";

        public static string DataEntererTimePath = "ns:ClinicalDocument/ns:dataEnterer/ns:time";
        public static string DataEntererIdPath = "ns:ClinicalDocument/ns:dataEnterer/ns:assignedEntity/ns:id";

        public static string DataEntererNamePath =
            "ns:ClinicalDocument/ns:dataEnterer/ns:assignedEntity/ns:assignedPerson/ns:name/ns:given";

        public static string CustodianOrganizationIdPath = "ns:ClinicalDocument/ns:custodian/ns:assignedCustodian/ns:representedCustodianOrganization/ns:id";
        public static string CustodianOrganizationNamePath = "ns:ClinicalDocument/ns:custodian/ns:assignedCustodian/ns:representedCustodianOrganization/ns:name";
        public static string CustodianOrganizationTelecomPath = "ns:ClinicalDocument/ns:custodian/ns:assignedCustodian/ns:representedCustodianOrganization/ns:telecom";
        public static string CustodianOrganizationAddrPath = "ns:ClinicalDocument/ns:custodian/ns:assignedCustodian/ns:representedCustodianOrganization/ns:addr";
        public static string CustodianOrganizationPrecinctPath = "ns:ClinicalDocument/ns:custodian/ns:assignedCustodian/ns:representedCustodianOrganization/ns:addr/precinct";
        public static string CustodianOrganizationCountyPath = "ns:ClinicalDocument/ns:custodian/ns:assignedCustodian/ns:representedCustodianOrganization/ns:addr/county";
        public static string CustodianOrganizationStatePath = "ns:ClinicalDocument/ns:custodian/ns:assignedCustodian/ns:representedCustodianOrganization/ns:addr/state";
        public static string CustodianOrganizationPostalCodePath = "ns:ClinicalDocument/ns:custodian/ns:assignedCustodian/ns:representedCustodianOrganization/ns:addr/postalCode";
        public static string CustodianOrganizationCountryPath = "ns:ClinicalDocument/ns:custodian/ns:assignedCustodian/ns:representedCustodianOrganization/ns:addr/country";

        // InformationRecipient
        public static string RecipientIdPath = "ns:ClinicalDocument/ns:informationRecipient/ns:intendedRecipient/ns:id";
        public static string RecipientGivenNamePath = "ns:ClinicalDocument/ns:informationRecipient/ns:intendedRecipient/ns:informationRecipient/ns:name/ns:given";
        public static string RecipientLastNamePath = "ns:ClinicalDocument/ns:informationRecipient/ns:intendedRecipient/ns:informationRecipient/ns:name/ns:family[1]";
        public static string RecipientSurenamePath = "ns:ClinicalDocument/ns:informationRecipient/ns:intendedRecipient/ns:informationRecipient/ns:name/ns:family[2]";
        public static string RecipientOrganizationIdPath = "ns:ClinicalDocument/ns:informationRecipient/ns:intendedRecipient/ns:receivedOrganization/ns:id";
        public static string RecipientOrganizationNamePath = "ns:ClinicalDocument/ns:informationRecipient/ns:intendedRecipient/ns:receivedOrganization/ns:name";
        
        // Authenticator
        public static string AuthenticatorTimePath = "ns:ClinicalDocument/ns:authenticator/ns:time";
        public static string AuthenticatorAssignedSystemIdPath = "ns:ClinicalDocument/ns:authenticator/ns:assignedEntity/ns:id[1]";
        public static string AuthenticatorProfessionalLicensePath = "ns:ClinicalDocument/ns:authenticator/ns:assignedEntity/ns:id[2]";
        public static string AuthenticarotSpecialtyPath = "ns:ClinicalDocument/ns:authenticator/ns:assignedEntity/ns:code";
        public static string AuthenticatorGivenNamePath = "ns:ClinicalDocument/ns:authenticator/ns:assignedEntity/ns:assignedPerson/ns:given";
        public static string AuthenticatorLastNamePath = "ns:ClinicalDocument/ns:authenticator/ns:assignedEntity/ns:assignedPerson/ns:name/ns:family[1]";
        public static string AuthenticatorSurenamePath = "ns:ClinicalDocument/ns:authenticator/ns:assignedEntity/ns:assignedPerson/ns:name/ns:family[2]";
        public static string AuthenticatorOrganizationIdPath = "ns:ClinicalDocument/ns:authenticator/ns:assignedEntity/ns:representedOrganization/ns:id";
        public static string AuthenticatorOrganizationNamePath = "ns:ClinicalDocument/ns:authenticator/ns:assignedEntity/ns:representedOrganization/ns:name";
        
        // ComponentOf
        public static string ComponentOfClinicalActIdPath = "ns:ClinicalDocument/ns:componentOf/ns:encompassingEncounter/ns:id";
        public static string ComponentOfAttentionCodePath = "ns:ClinicalDocument/ns:componentOf/ns:encompassingEncounter/ns:code";
        public static string ComponentOfTimePath = "ns:ClinicalDocument/ns:componentOf/ns:encompassingEncounter/ns:effectiveTime/ns:low";
        public static string ComponentOfSystemIdPath = "ns:ClinicalDocument/ns:componentOf/ns:encompassingEncounter/ns:responsibleParty/ns:assignedEntity/ns:id[1]";
        public static string ComponentOfProfessionalLicensePath = "ns:ClinicalDocument/ns:componentOf/ns:encompassingEncounter/ns:responsibleParty/ns:assignedEntity/ns:id[2]";
        public static string ComponentOfGivenNamePath = "ns:ClinicalDocument/ns:componentOf/ns:encompassingEncounter/ns:responsibleParty/ns:assignedEntity/assignedPerson/ns:name/ns:given";
        public static string ComponentOfLastNamePath = "ns:ClinicalDocument/ns:componentOf/ns:encompassingEncounter/ns:responsibleParty/ns:assignedEntity/assignedPerson/ns:name/ns:family[1]";
        public static string ComponentOfurenamePath = "ns:ClinicalDocument/ns:componentOf/ns:encompassingEncounter/ns:responsibleParty/ns:assignedEntity/assignedPerson/ns:name/ns:family[2]";
        public static string ComponentOfOrganizationIdPath = "ns:ClinicalDocument/ns:componentOf/ns:encompassingEncounter/ns:responsibleParty/ns:assignedEntity/representedOrganization/id";
        public static string ComponentOfOrganizationNamePath = "ns:ClinicalDocument/ns:componentOf/ns:encompassingEncounter/ns:responsibleParty/ns:assignedEntity/representedOrganization/name";
        public static string ComponentOfLocationIdPath = "ns:ClinicalDocument/ns:componentOf/ns:encompassingEncounter/ns:location/ns:healthCareFacility/id";
        public static string ComponentOfLocationNamePath = "ns:ClinicalDocument/ns:componentOf/ns:encompassingEncounter/ns:location/ns:healthCareFacility//location/name";
        public static string ComponentOfLocationAddrPath = "ns:ClinicalDocument/ns:componentOf/ns:encompassingEncounter/ns:location/ns:healthCareFacility/location/addr";
        public static string ComponentOfLocationPrecinctPath = "ns:ClinicalDocument/ns:componentOf/ns:encompassingEncounter/ns:location/ns:healthCareFacility/location/addr/precinct";
        public static string ComponentOfLocationCountyPath = "ns:ClinicalDocument/ns:componentOf/ns:encompassingEncounter/ns:location/ns:healthCareFacility/location/addr/county";
        public static string ComponentOfLocationStatePath = "ns:ClinicalDocument/ns:componentOf/ns:encompassingEncounter/ns:location/ns:healthCareFacility/location/addr/state";
        public static string ComponentOfLocationPostalCodePath = "ns:ClinicalDocument/ns:componentOf/ns:encompassingEncounter/ns:location/ns:healthCareFacility/location/addr/postalCode";
        public static string ComponentOfLocationCountryPath = "ns:ClinicalDocument/ns:componentOf/ns:encompassingEncounter/ns:location/ns:healthCareFacility/location/addr/counrty";



        public static XmlNamespaceManager XmlNamespaceManager { get; private set; }

        /// <summary>
        ///     Rerturns a XDocument based on the Cenetec template
        /// </summary>
        /// <returns></returns>
        public static XDocument CreateCda()
        {
            if (!File.Exists(TemplateFileName))
            {
                return null;
            }

            var stream = File.Open(TemplateFileName, FileMode.Open);

            var xdoc = XDocument.Load(stream);

            XmlNamespaceManager = new XmlNamespaceManager(xdoc.CreateReader().NameTable);
            XmlNamespaceManager.AddNamespace("ns", "urn:hl7-org:v3");

            return xdoc;
        }

        public static void SaveCda(XDocument xdoc, string fileName)
        {
            if (xdoc == null || fileName == null)
            {
                return;
            }

            xdoc.Save(fileName);
        }

        public static void UpdateHeader(XDocument xdoc, string oidSystemDocuments, string extension, string title,
            DateTime effectiveTime, string confidentialityCode)
        {
            var idElement = xdoc.XPathSelectElement(HeaderIdPath, XmlNamespaceManager);
            idElement.Attribute(XName.Get("root")).Value = oidSystemDocuments;
            idElement.Attribute(XName.Get("extension")).Value = extension;

            var setIdElement = xdoc.XPathSelectElement(HeaderSetIdPath, XmlNamespaceManager);
            setIdElement.Attribute(XName.Get("root")).Value = oidSystemDocuments;
            setIdElement.Attribute(XName.Get("extension")).Value = extension;

            var titleElement = xdoc.XPathSelectElement(HeaderTitlePath, XmlNamespaceManager);
            titleElement.Value = title;

            var effectiveTimeElement = xdoc.XPathSelectElement(HeaderEffectiveTimePath, XmlNamespaceManager);
            effectiveTimeElement.Attribute(XName.Get("value")).Value = GetFormattedDateTime(effectiveTime);

            var confidentialityCodeElement = xdoc.XPathSelectElement(HeaderConfidentialityCodePath, XmlNamespaceManager);
            confidentialityCodeElement.Attribute(XName.Get("code")).Value = confidentialityCode;
        }

        public static void UpdatePatient(XDocument xdoc, string oidSystemPatients, Person person, string gender, string civilState, string religion, string ethnicity, string state, string nationality)
        {
            var idElement = xdoc.XPathSelectElement(PatientIdPath, XmlNamespaceManager);
            idElement.Attribute("root").Value = oidSystemPatients;
            idElement.Attribute("extension").Value = person.ID.ToString();
            idElement.Attribute("assigningAuthorityName").Value = person.ID.ToString();

            var nationalIdentifierElement = xdoc.XPathSelectElement(PatientNationalIdentifierPath, XmlNamespaceManager);
            nationalIdentifierElement.Attribute("extension").Value = person.NationalIdentityCode;

            var addressElement = xdoc.XPathSelectElement(PatientAddressPath, XmlNamespaceManager);
            addressElement.Value = string.Format("{0} {1}, {2}, {3}, {4}, {5}, {6}, {7}", person.Street, person.ExternalNumber, person.InternalNumber, person.Neighborhood, person.Municipality, person.City, person.StateID, person.ZipCode); // ToDO

            var phoneNumberElement = xdoc.XPathSelectElement(PatientPhoneNumberPath, XmlNamespaceManager);
            phoneNumberElement.Attribute("value").Value = "Phone Number";

            var emailElement = xdoc.XPathSelectElement(PatientEmailPath, XmlNamespaceManager);
            emailElement.Attribute("value").Value = "email";

            var firstNameElement = xdoc.XPathSelectElement(PatientFirstNamePath, XmlNamespaceManager);
            firstNameElement.Value = person.FirstName;

            var lastNameElement = xdoc.XPathSelectElement(PatientLastNamePath, XmlNamespaceManager);
            lastNameElement.Value = person.LastName;

            var surnameElement = xdoc.XPathSelectElement(PatientSurnamePath, XmlNamespaceManager);
            surnameElement.Value = person.Surname;

            var genderElement = xdoc.XPathSelectElement(PatientGenderPath, XmlNamespaceManager);
            genderElement.Attribute("code").Value = gender;

            var birthTimeElement = xdoc.XPathSelectElement(PatientBirthTimePath, XmlNamespaceManager);
            birthTimeElement.Attribute("value").Value = GetFormattedDateTime(person.BirthDate);

            var maritalStatusCodeElement = xdoc.XPathSelectElement(PatientMaritalStatusCodePath, XmlNamespaceManager);
            maritalStatusCodeElement.Attribute("code").Value = civilState;

            var religiousAffiliationCodeElement = xdoc.XPathSelectElement(PatientReligiousAffiliationCodePath,
                XmlNamespaceManager);
            religiousAffiliationCodeElement.Attribute("code").Value = religion;

            var ethnicGroupCodeElement = xdoc.XPathSelectElement(PatientEthnicGroupCodePath, XmlNamespaceManager);
            ethnicGroupCodeElement.Attribute("code").Value = ethnicity;

            var birthplaceStateElement = xdoc.XPathSelectElement(PatientBirthplaceStatePath, XmlNamespaceManager);
            birthplaceStateElement.Value = state;

            var birthplaceCountryElement = xdoc.XPathSelectElement(PatientBirthplaceCountryPath, XmlNamespaceManager);
            birthplaceCountryElement.Value = nationality;
        }

        public static void UpdateAuthor(XDocument xdoc, string oidSystemUsers, Doctor doctor, DateTime dateTime, string oidInstitution, string authorOrganizationName)
        {
            var timeElement = xdoc.XPathSelectElement(AuthorTimePath, XmlNamespaceManager);
            timeElement.Attribute(XName.Get("value")).Value = GetFormattedDateTime(dateTime);

            var authorIdElement = xdoc.XPathSelectElement(AuthorIdPath, XmlNamespaceManager);
            authorIdElement.Attribute(XName.Get("root")).Value = oidSystemUsers;
            authorIdElement.Attribute(XName.Get("extension")).Value = doctor.ID.ToString();

            var authorProfessionalDocumentElement = xdoc.XPathSelectElement(AuthorProfessionalDocumentPath,
                XmlNamespaceManager);
            authorProfessionalDocumentElement.Attribute(XName.Get("extension")).Value = doctor.ProfessionalLicense;

            var authorSpecialtyElement = xdoc.XPathSelectElement(AuthorSpecialtyPath, XmlNamespaceManager);
            authorSpecialtyElement.Attribute(XName.Get("code")).Value = doctor.SpecialtyID;
            authorSpecialtyElement.Attribute(XName.Get("displayName")).Value = doctor.SpecialtyID; //ToDO

            var authorNameElement = xdoc.XPathSelectElement(AuthorNamePath, XmlNamespaceManager);
            authorNameElement.Value = string.Format("{0} {1} {2} {3}", doctor.FirstName, doctor.MiddleName, doctor.LastName, doctor.Surname);

            var authorOrganizationIdElement = xdoc.XPathSelectElement(AuthorOrganizationIdPath, XmlNamespaceManager);
            authorOrganizationIdElement.Attribute(XName.Get("root")).Value = oidInstitution;

            var authorOrganizationNameElement = xdoc.XPathSelectElement(AuthorOrganizationNamePath, XmlNamespaceManager);
            authorOrganizationNameElement.Value = authorOrganizationName;
        }

        public static void UpdateSoftware(XDocument xdoc, DateTime dateTime, string oidSystemInstance,
            string softwareName, string oidOrganization, string organizationName)
        {
            var timeElement = xdoc.XPathSelectElement(SoftwareTimePath, XmlNamespaceManager);
            timeElement.Attribute("value").Value = GetFormattedDateTime(dateTime);

            var softwareIdElement = xdoc.XPathSelectElement(SoftwareIdPath, XmlNamespaceManager);
            softwareIdElement.Attribute("root").Value = oidSystemInstance;

            var softwareNameElement = xdoc.XPathSelectElement(SoftwareNamePath, XmlNamespaceManager);
            softwareNameElement.Value = softwareName;

            var organizationIdElement = xdoc.XPathSelectElement(SoftwareOrganizationIdPath, XmlNamespaceManager);
            organizationIdElement.Attribute("root").Value = oidOrganization;

            var organizationNameElement = xdoc.XPathSelectElement(SoftwareOrganizationNamePath, XmlNamespaceManager);
            organizationNameElement.Value = organizationName;
        }

        public static void UpdateDataEnterer(XDocument xdoc, DateTime dateTime, string oidSystemUsers, string userID, string userFullName)
        {
            var timeElement = xdoc.XPathSelectElement(DataEntererTimePath, XmlNamespaceManager);
            timeElement.Attribute("value").Value = GetFormattedDateTime(dateTime);

            var idElement = xdoc.XPathSelectElement(DataEntererIdPath, XmlNamespaceManager);
            idElement.Attribute("root").Value = oidSystemUsers;
            idElement.Attribute("extension").Value = userID;

            var nameElement = xdoc.XPathSelectElement(DataEntererNamePath, XmlNamespaceManager);
            nameElement.Value = userFullName;
        }

        public static void UpdateCustodian(XDocument xdoc, string oidCustodianOrganization, string custodianOrganizationName, string custodianOrganizationTelecom, string custodianOrganizationAddress, string custodianOrganizationPrecinct, string custodianOrganizationCounty, string custodianOrganizationState, string custodianOrganizationPostalCode, string custodianOrganizationCountry)
        {
            var idElement = xdoc.XPathSelectElement(CustodianOrganizationIdPath, XmlNamespaceManager);
            idElement.Attribute("root").Value = oidCustodianOrganization;

            var nameElement = xdoc.XPathSelectElement(CustodianOrganizationNamePath, XmlNamespaceManager);
            nameElement.Value = custodianOrganizationName;

            var telecomElement = xdoc.XPathSelectElement(CustodianOrganizationTelecomPath, XmlNamespaceManager);
            telecomElement.Attribute("value").Value = custodianOrganizationTelecom;

            var addrElement = xdoc.XPathSelectElement(CustodianOrganizationAddrPath, XmlNamespaceManager);
            addrElement.Value = custodianOrganizationAddress;

            var precinctElement = xdoc.XPathSelectElement(CustodianOrganizationPrecinctPath, XmlNamespaceManager);

            var countyElement = xdoc.XPathSelectElement(CustodianOrganizationCountyPath, XmlNamespaceManager);
            countyElement.Value = custodianOrganizationCounty;

            var stateElement = xdoc.XPathSelectElement(CustodianOrganizationStatePath, XmlNamespaceManager);
            stateElement.Value = custodianOrganizationState;

            var postalCodeElement = xdoc.XPathSelectElement(CustodianOrganizationPostalCodePath, XmlNamespaceManager);
            postalCodeElement.Value = custodianOrganizationPostalCode;

            var countryElement = xdoc.XPathSelectElement(CustodianOrganizationCountyPath, XmlNamespaceManager);
            countryElement.Value = custodianOrganizationCountry;           

        }

        public static void UpdateInformationRecipient(XDocument xdoc, Doctor recipientDoctor, string recipientOrganizationName)
        {
            var idElement = xdoc.XPathSelectElement(RecipientIdPath, XmlNamespaceManager);
            idElement.Attribute("extension").Value = recipientDoctor.ProfessionalLicense;

            var givenElement = xdoc.XPathSelectElement(RecipientGivenNamePath, XmlNamespaceManager);
            givenElement.Value = string.Format("{0} {1}", recipientDoctor.FirstName, recipientDoctor.MiddleName);

            var lastNameElement = xdoc.XPathSelectElement(RecipientLastNamePath, XmlNamespaceManager);
            lastNameElement.Value = recipientDoctor.LastName;

            var surenameElement = xdoc.XPathSelectElement(RecipientSurenamePath, XmlNamespaceManager);
            surenameElement.Value = recipientDoctor.Surname;

            var organizationIdElement = xdoc.XPathSelectElement(RecipientOrganizationIdPath, XmlNamespaceManager);
            organizationIdElement.Value = recipientDoctor.ClinicID;

            var organizationNameElement = xdoc.XPathSelectElement(RecipientOrganizationNamePath, XmlNamespaceManager);
            organizationIdElement.Value = recipientOrganizationName;
        }

        public static void UpdateLegalAuthenticator(XDocument xdoc)
        {
            // TODO LDE
        }

        public static void UpdateAuthenticator(XDocument xdoc, DateTime dateTime, string oidSystemUsers, string userID, Doctor authenticator, string organizationId, string organizationName)
        {
            var timeElement = xdoc.XPathSelectElement(AuthenticatorTimePath, XmlNamespaceManager);
            timeElement.Attribute("value").Value = GetFormattedDateTime(dateTime);

            var idElement = xdoc.XPathSelectElement(AuthenticatorOrganizationIdPath, XmlNamespaceManager);
            idElement.Attribute("root").Value = oidSystemUsers;
            idElement.Attribute("extension").Value = userID;

            var licenseElement = xdoc.XPathSelectElement(AuthenticatorProfessionalLicensePath, XmlNamespaceManager);
            licenseElement.Attribute("root").Value = authenticator.ProfessionalLicense;

            var givenElement = xdoc.XPathSelectElement(AuthenticatorGivenNamePath, XmlNamespaceManager);
            givenElement.Value = string.Format("{0} {1}", authenticator.FirstName, authenticator.MiddleName);

            var lastNameElement = xdoc.XPathSelectElement(AuthenticatorLastNamePath, XmlNamespaceManager);
            lastNameElement.Value = authenticator.LastName;

            var surenameElement = xdoc.XPathSelectElement(AuthenticatorSurenamePath, XmlNamespaceManager);
            surenameElement.Value = authenticator.Surname;

            var organizationIdElement = xdoc.XPathSelectElement(AuthenticatorOrganizationIdPath, XmlNamespaceManager);
            organizationIdElement.Attribute("root").Value = organizationId;

            var organizationNameElement = xdoc.XPathSelectElement(AuthenticatorOrganizationNamePath, XmlNamespaceManager);
            organizationNameElement.Value = organizationName;
        }
       
        public static void UpdateInFulfillmentOf(XDocument xdoc)
        {
            // TODO LDE
        }

        public static void UpdateComponentOf(XDocument xdoc, string oidClinicalActs, string clinicalActID, string oidSystemUsers, string userID, DateTime dateTime, Doctor doctor, string organizationID, string organizationName, string clues, string locationName,string organizationAddress, string organizationPrecinct, string organizationCounty, string organizationState, string organizationPostalCode, string organizationCountry)
        {
            var idElement = xdoc.XPathSelectElement(ComponentOfClinicalActIdPath, XmlNamespaceManager);
            idElement.Attribute("root").Value = oidClinicalActs;
            idElement.Attribute("extension").Value = clinicalActID;

            var timeElement = xdoc.XPathSelectElement(ComponentOfTimePath, XmlNamespaceManager);
            timeElement.Attribute("value").Value = GetFormattedDateTime(dateTime);

            var systemIdElement = xdoc.XPathSelectElement(ComponentOfSystemIdPath, XmlNamespaceManager);
            systemIdElement.Attribute("root").Value = oidSystemUsers;
            systemIdElement.Attribute("extension").Value = userID;

            var professionalLicensePath = xdoc.XPathSelectElement(ComponentOfProfessionalLicensePath, XmlNamespaceManager);
            professionalLicensePath.Attribute("extension").Value = doctor.ProfessionalLicense;

            var givenElement = xdoc.XPathSelectElement(ComponentOfGivenNamePath,XmlNamespaceManager);
            givenElement.Value = string.Format("{0} {1}", doctor.FirstName, doctor.MiddleName);

            var lastNameElement = xdoc.XPathSelectElement(ComponentOfLastNamePath, XmlNamespaceManager);
            lastNameElement.Value = doctor.LastName;

            var surenameElement = xdoc.XPathSelectElement(ComponentOfurenamePath, XmlNamespaceManager);
            surenameElement.Value = doctor.Surname;

            var organizationIdElement = xdoc.XPathSelectElement(ComponentOfOrganizationIdPath, XmlNamespaceManager);
            organizationIdElement.Attribute("root").Value = organizationID;

            var organizationNameElement = xdoc.XPathSelectElement(ComponentOfOrganizationNamePath, XmlNamespaceManager);
            organizationNameElement.Value = organizationName;

            var locationIdElment = xdoc.XPathSelectElement(ComponentOfLocationIdPath, XmlNamespaceManager);
            locationIdElment.Attribute("extension").Value = clues;

            var locationNameElement = xdoc.XPathSelectElement(ComponentOfLocationNamePath, XmlNamespaceManager);
            locationIdElment.Value = locationName;

            var locationAddr = xdoc.XPathSelectElement(ComponentOfLocationAddrPath, XmlNamespaceManager);
            locationAddr.Value = organizationAddress;

            var locationPrecinctElement = xdoc.XPathSelectElement(ComponentOfLocationPrecinctPath, XmlNamespaceManager);
            locationNameElement.Value = organizationPrecinct;

            var locationCountyElement = xdoc.XPathSelectElement(ComponentOfLocationCountryPath, XmlNamespaceManager);
            locationCountyElement.Value = organizationCounty;

            var locationStateElelemt = xdoc.XPathSelectElement(ComponentOfLocationStatePath, XmlNamespaceManager);
            locationStateElelemt.Value = organizationState;

            var locationPostalCodeElement = xdoc.XPathSelectElement(ComponentOfLocationPostalCodePath, XmlNamespaceManager);
            locationPostalCodeElement.Value = organizationPostalCode;

            var locationCountryElement = xdoc.XPathSelectElement(ComponentOfLocationCountryPath, XmlNamespaceManager);
            locationCountryElement.Value = organizationCountry;

        }

        public static string GetFormattedDateTime(DateTime? dateTime)
        {
            string value = "";
            if (dateTime.HasValue)
            {
                var year = dateTime.Value.Year.ToString("0000");
                var month = dateTime.Value.Month.ToString("00");
                var day = dateTime.Value.Day.ToString("00");
                var hour = dateTime.Value.Hour.ToString("00");
                var minute = dateTime.Value.Minute.ToString("00");
                var second = dateTime.Value.Second.ToString("00");

                value = $"{year}{month}{day}{hour}{minute}{second}";
            }

            return value;
        }
    }
}