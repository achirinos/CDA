using Lumed.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Resolvers;
using System.Xml.XPath;

namespace CdaGenerator.Helper
{
    public static class CdaHelper
    {
        private static XNamespace defaultNs = "urn:hl7-org:v3";
        
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
        public static string CustodianOrganizationPrecinctPath = "ns:ClinicalDocument/ns:custodian/ns:assignedCustodian/ns:representedCustodianOrganization/ns:addr[@use='WP']/ns:precinct";


        public static string CustodianOrganizationCountyPath = "ns:ClinicalDocument/ns:custodian/ns:assignedCustodian/ns:representedCustodianOrganization/ns:addr[@use='WP']/ns:county";
        public static string CustodianOrganizationStatePath = "ns:ClinicalDocument/ns:custodian/ns:assignedCustodian/ns:representedCustodianOrganization/ns:addr/ns:state";
        public static string CustodianOrganizationPostalCodePath = "ns:ClinicalDocument/ns:custodian/ns:assignedCustodian/ns:representedCustodianOrganization/ns:addr/ns:postalCode";
        public static string CustodianOrganizationCountryPath = "ns:ClinicalDocument/ns:custodian/ns:assignedCustodian/ns:representedCustodianOrganization/ns:addr/ns:country";

        public static string LegalAuthenticatorTimePath = "ns:ClinicalDocument/ns:legalAuthenticator/ns:time";
        public static string LegalAuthenticatorUserIdPath = "ns:ClinicalDocument/ns:legalAuthenticator/ns:assignedEntity/ns:id[1]";
        public static string LegalAuthenticatorDoctorIdPath = "ns:ClinicalDocument/ns:legalAuthenticator/ns:assignedEntity/ns:id[2]";
        public static string LegalAuthenticatorCodePath = "ns:ClinicalDocument/ns:legalAuthenticator/ns:assignedEntity/ns:code";
        public static string LegalAuthenticatorFirstNamePath = "ns:ClinicalDocument/ns:legalAuthenticator/ns:assignedEntity/ns:assignedPerson/ns:name/ns:given";
        public static string LegalAuthenticatorLastNamePath = "ns:ClinicalDocument/ns:legalAuthenticator/ns:assignedEntity/ns:assignedPerson/ns:name/ns:family[1]";
        public static string LegalAuthenticatorSurNamePath = "ns:ClinicalDocument/ns:legalAuthenticator/ns:assignedEntity/ns:assignedPerson/ns:name/ns:family[2]";
        public static string LegalAuthenticatorRepresentedOrganizationIdPath = "ns:ClinicalDocument/ns:legalAuthenticator/ns:assignedEntity/ns:representedOrganization/ns:id";
        public static string LegalAuthenticatorRepresentedOrganizationNamePath = "ns:ClinicalDocument/ns:legalAuthenticator/ns:assignedEntity/ns:representedOrganization/ns:name";

        public static string InFulfillmentOfIdPath = "ns:ClinicalDocument/ns:inFulfillmentOf/ns:order/ns:id";

        public static string ComponentTextInterrogatoryPath = "ns:ClinicalDocument/ns:component/ns:structuredBody/ns:component[1]/ns:section/ns:text";
        public static string ComponentTextDiagnosticPath = "ns:ClinicalDocument/ns:component/ns:structuredBody/ns:component[2]/ns:section/ns:text";
        public static string ComponentOrdersPath = "ns:ClinicalDocument/ns:component/ns:structuredBody/ns:component[3]/ns:section/ns:text/ns:paragraph[1]";
        public static string ComponentTreatmentPlanPath = "ns:ClinicalDocument/ns:component/ns:structuredBody/ns:component[3]/ns:section/ns:text/ns:paragraph[2]";


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
        public static string AuthenticatorGivenNamePath = "ns:ClinicalDocument/ns:authenticator/ns:assignedEntity/ns:assignedPerson/ns:name/ns:given";
        public static string AuthenticatorLastNamePath = "ns:ClinicalDocument/ns:authenticator/ns:assignedEntity/ns:assignedPerson/ns:name/ns:family[1]";
        public static string AuthenticatorSurenamePath = "ns:ClinicalDocument/ns:authenticator/ns:assignedEntity/ns:assignedPerson/ns:name/ns:family[2]";
        public static string AuthenticatorOrganizationIdPath = "ns:ClinicalDocument/ns:authenticator/ns:assignedEntity/ns:representedOrganization/ns:id";
        public static string AuthenticatorOrganizationNamePath = "ns:ClinicalDocument/ns:authenticator/ns:assignedEntity/ns:representedOrganization/ns:name";
        
        //component request
        public static string ComponentReasonOfReferalPath = "ns:ClinicalDocument/ns:component/ns:structuredBody/ns:component[1]/ns:section/ns:text";
        public static string ComponentInterrogatoryPath = "ns:ClinicalDocument/ns:component/ns:structuredBody/ns:component[2]/ns:section/ns:text";
        public static string ComponentAllergiesPath = "ns:ClinicalDocument/ns:component/ns:structuredBody/ns:component[3]/ns:section/ns:text";
        public static string ComponentProceduresPath = "ns:ClinicalDocument/ns:component/ns:structuredBody/ns:component[4]/ns:section/ns:text";
        public static string ComponentMedicationsPath = "ns:ClinicalDocument/ns:component/ns:structuredBody/ns:component[5]/ns:section/ns:text";
        public static string ComponentPhysicalExamPath = "ns:ClinicalDocument/ns:component/ns:structuredBody/ns:component[6]/ns:section/ns:text";
        public static string ComponentVitalSignsPath = "ns:ClinicalDocument/ns:component/ns:structuredBody/ns:component[7]/ns:section/ns:text";
        public static string ComponentResultsPath = "ns:ClinicalDocument/ns:component/ns:structuredBody/ns:component[8]/ns:section/ns:text";
        public static string ComponentAssesmentPath = "ns:ClinicalDocument/ns:component/ns:structuredBody/ns:component[9]/ns:section/ns:text";

        // component response
        public static string ComponentResponseTextInterrogatoryPath = "ns:ClinicalDocument/ns:component/ns:structuredBody/ns:component[1]/ns:section/ns:text";
        public static string ComponentResponseTextDiagnosticPath = "ns:ClinicalDocument/ns:component/ns:structuredBody/ns:component[2]/ns:section/ns:text";
        public static string ComponentResponseOrdersPath = "ns:ClinicalDocument/ns:component/ns:structuredBody/ns:component[3]/ns:section/ns:text/ns:paragraph[1]";
        public static string ComponentResponseTreatmentPlanPath = "ns:ClinicalDocument/ns:component/ns:structuredBody/ns:component[3]/ns:section/ns:text/ns:paragraph[2]";

        // ComponentOf
        public static string ComponentOfClinicalActIdPath = "ns:ClinicalDocument/ns:componentOf/ns:encompassingEncounter/ns:id";
        public static string ComponentOfAttentionCodePath = "ns:ClinicalDocument/ns:componentOf/ns:encompassingEncounter/ns:code";
        public static string ComponentOfTimePath = "ns:ClinicalDocument/ns:componentOf/ns:encompassingEncounter/ns:effectiveTime/ns:low";


        public static string ComponentOfSystemIdPath = "ns:ClinicalDocument/ns:componentOf/ns:encompassingEncounter/ns:responsibleParty/ns:assignedEntity/ns:id[1]";
        public static string ComponentOfProfessionalLicensePath = "ns:ClinicalDocument/ns:componentOf/ns:encompassingEncounter/ns:responsibleParty/ns:assignedEntity/ns:id[2]";

        public static string ComponentOfResponseProfessionalLicensePath = "ns:ClinicalDocument/ns:componentOf/ns:encompassingEncounter/ns:responsibleParty/ns:assignedEntity/ns:id";

        public static string ComponentOfGivenNamePath = "ns:ClinicalDocument/ns:componentOf/ns:encompassingEncounter/ns:responsibleParty/ns:assignedEntity/ns:assignedPerson/ns:name/ns:given";
        public static string ComponentOfLastNamePath = "ns:ClinicalDocument/ns:componentOf/ns:encompassingEncounter/ns:responsibleParty/ns:assignedEntity/ns:assignedPerson/ns:name/ns:family[1]";
        public static string ComponentOfurenamePath = "ns:ClinicalDocument/ns:componentOf/ns:encompassingEncounter/ns:responsibleParty/ns:assignedEntity/ns:assignedPerson/ns:name/ns:family[2]";

        public static string ComponentOfOrganizationIdPath = "ns:ClinicalDocument/ns:componentOf/ns:encompassingEncounter/ns:responsibleParty/ns:assignedEntity/ns:representedOrganization/ns:id";
        public static string ComponentOfOrganizationNamePath = "ns:ClinicalDocument/ns:componentOf/ns:encompassingEncounter/ns:responsibleParty/ns:assignedEntity/ns:representedOrganization/ns:name";
        public static string ComponentOfLocationIdPath = "ns:ClinicalDocument/ns:componentOf/ns:encompassingEncounter/ns:location/ns:healthCareFacility/ns:id";
        public static string ComponentOfLocationNamePath = "ns:ClinicalDocument/ns:componentOf/ns:encompassingEncounter/ns:location/ns:healthCareFacility/ns:location/ns:name";
        public static string ComponentOfLocationAddrPath = "ns:ClinicalDocument/ns:componentOf/ns:encompassingEncounter/ns:location/ns:healthCareFacility/ns:location/ns:addr";
        public static string ComponentOfLocationPrecinctPath = "ns:ClinicalDocument/ns:componentOf/ns:encompassingEncounter/ns:location/ns:healthCareFacility/ns:location/ns:addr/ns:precinct";
        public static string ComponentOfLocationCountyPath = "ns:ClinicalDocument/ns:componentOf/ns:encompassingEncounter/ns:location/ns:healthCareFacility/ns:location/ns:addr/ns:county";
        public static string ComponentOfLocationStatePath = "ns:ClinicalDocument/ns:componentOf/ns:encompassingEncounter/ns:location/ns:healthCareFacility/ns:location/ns:addr/ns:state";
        public static string ComponentOfLocationPostalCodePath = "ns:ClinicalDocument/ns:componentOf/ns:encompassingEncounter/ns:location/ns:healthCareFacility/ns:location/ns:addr/ns:postalCode";
        public static string ComponentOfLocationCountryPath = "ns:ClinicalDocument/ns:componentOf/ns:encompassingEncounter/ns:location/ns:healthCareFacility/ns:location/ns:addr/ns:counrty";

        
        public static XmlNamespaceManager XmlNamespaceManager { get; private set; }

        public static XDocument CreateCda(string template)
        {
            string curFile = @"C:\Source\CdaGenerator\CdaGenerator\" + template;

            if (!File.Exists(curFile))
            {
                return null;
            }

            var stream = File.Open(curFile, FileMode.Open);

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

            xdoc.Declaration = new XDeclaration("1.0", "utf-8", null);
            xdoc.Save(fileName);
        }

        public static void UpdateHeader(XDocument xdoc, string oidSystemDocuments, string systemDocumentId, string systemDocumentTitle,
            DateTime effectiveTime, string confidentialityCode)
        {
            var idElement = xdoc.XPathSelectElement(HeaderIdPath, XmlNamespaceManager);
            idElement.Attribute(XName.Get("root")).Value = oidSystemDocuments;
            idElement.Attribute(XName.Get("extension")).Value = systemDocumentId;

            var setIdElement = xdoc.XPathSelectElement(HeaderSetIdPath, XmlNamespaceManager);
            setIdElement.Attribute(XName.Get("root")).Value = oidSystemDocuments;
            setIdElement.Attribute(XName.Get("extension")).Value = systemDocumentId;

            var titleElement = xdoc.XPathSelectElement(HeaderTitlePath, XmlNamespaceManager);
            titleElement.Value = systemDocumentTitle;

            var effectiveTimeElement = xdoc.XPathSelectElement(HeaderEffectiveTimePath, XmlNamespaceManager);
            effectiveTimeElement.Attribute(XName.Get("value")).Value = GetFormattedDateTime(effectiveTime);

            var confidentialityCodeElement = xdoc.XPathSelectElement(HeaderConfidentialityCodePath, XmlNamespaceManager);
            confidentialityCodeElement.Attribute(XName.Get("code")).Value = confidentialityCode;
        }

        public static void UpdatePatient(XDocument xdoc, string oidSystemPatients, string patientId, string patientNationalIdentityCode, 
            string patientStreet, string patientExtrenalNumber, string patientInternalNumber, string patientNeighborhood, string patientMunicipality, string patientCity, string patientState, string patientZipCode, string patientPhoneNumber,
            string patientEmail, string patientFirstName, string patientLastName, string patientSurname, string patientGender, DateTime patientBirthDate, string patientCivilState,
            string patientReligion, string patientEthnicity, string patientBirthPlaceState, string patientBirthPlaceCountry)
        {
            var idElement = xdoc.XPathSelectElement(PatientIdPath, XmlNamespaceManager);
            idElement.Attribute("root").Value = oidSystemPatients;
            idElement.Attribute("extension").Value = patientId;
            idElement.Attribute("assigningAuthorityName").Value = patientId;

            var nationalIdentifierElement = xdoc.XPathSelectElement(PatientNationalIdentifierPath, XmlNamespaceManager);
            nationalIdentifierElement.Attribute("extension").Value = patientNationalIdentityCode;

            var addressElement = xdoc.XPathSelectElement(PatientAddressPath, XmlNamespaceManager);
            addressElement.Value = string.Format("{0} {1}, {2}, {3}, {4}, {5}, {6}, {7}", patientStreet, patientExtrenalNumber, patientInternalNumber, patientNeighborhood, patientMunicipality, patientCity, patientState, patientZipCode);

            var phoneNumberElement = xdoc.XPathSelectElement(PatientPhoneNumberPath, XmlNamespaceManager);
            phoneNumberElement.Attribute("value").Value = patientPhoneNumber;

            var emailElement = xdoc.XPathSelectElement(PatientEmailPath, XmlNamespaceManager);
            emailElement.Attribute("value").Value = patientEmail;

            var firstNameElement = xdoc.XPathSelectElement(PatientFirstNamePath, XmlNamespaceManager);
            firstNameElement.Value = patientFirstName;

            var lastNameElement = xdoc.XPathSelectElement(PatientLastNamePath, XmlNamespaceManager);
            lastNameElement.Value = patientLastName;

            var surnameElement = xdoc.XPathSelectElement(PatientSurnamePath, XmlNamespaceManager);
            surnameElement.Value = patientSurname;

            var genderElement = xdoc.XPathSelectElement(PatientGenderPath, XmlNamespaceManager);
            genderElement.Attribute("code").Value = patientGender;

            var birthTimeElement = xdoc.XPathSelectElement(PatientBirthTimePath, XmlNamespaceManager);
            birthTimeElement.Attribute("value").Value = GetFormattedDateTime(patientBirthDate);

            var maritalStatusCodeElement = xdoc.XPathSelectElement(PatientMaritalStatusCodePath, XmlNamespaceManager);
            maritalStatusCodeElement.Attribute("code").Value = patientCivilState;

            var religiousAffiliationCodeElement = xdoc.XPathSelectElement(PatientReligiousAffiliationCodePath,
                XmlNamespaceManager);
            religiousAffiliationCodeElement.Attribute("code").Value = patientReligion;

            var ethnicGroupCodeElement = xdoc.XPathSelectElement(PatientEthnicGroupCodePath, XmlNamespaceManager);
            ethnicGroupCodeElement.Attribute("code").Value = patientEthnicity;

            var birthplaceStateElement = xdoc.XPathSelectElement(PatientBirthplaceStatePath, XmlNamespaceManager);
            birthplaceStateElement.Value = patientBirthPlaceState;

            var birthplaceCountryElement = xdoc.XPathSelectElement(PatientBirthplaceCountryPath, XmlNamespaceManager);
            birthplaceCountryElement.Value = patientBirthPlaceCountry;
        }

        // Doctor Solicitante
        public static void UpdateAuthor(XDocument xdoc, string oidSystemUsers, string doctorId, string doctorProfessionalLicense, string doctorFirstName, string doctorMiddleName, string doctorLastName, string doctorSurname, string oidSpecialty, string specialtyName, DateTime dateTime, string oidInstitution, string authorOrganizationName)
        {
            var timeElement = xdoc.XPathSelectElement(AuthorTimePath, XmlNamespaceManager);
            timeElement.Attribute(XName.Get("value")).Value = GetFormattedDateTime(dateTime);

            var authorIdElement = xdoc.XPathSelectElement(AuthorIdPath, XmlNamespaceManager);
            authorIdElement.Attribute(XName.Get("root")).Value = oidSystemUsers;
            authorIdElement.Attribute(XName.Get("extension")).Value = doctorId;

            var authorProfessionalDocumentElement = xdoc.XPathSelectElement(AuthorProfessionalDocumentPath,
                XmlNamespaceManager);
            authorProfessionalDocumentElement.Attribute(XName.Get("extension")).Value = doctorProfessionalLicense;

            var authorSpecialtyElement = xdoc.XPathSelectElement(AuthorSpecialtyPath, XmlNamespaceManager);
            authorSpecialtyElement.Attribute(XName.Get("code")).Value = oidSpecialty;
            authorSpecialtyElement.Attribute(XName.Get("displayName")).Value = specialtyName;

            var authorNameElement = xdoc.XPathSelectElement(AuthorNamePath, XmlNamespaceManager);
            authorNameElement.Value = string.Format("{0} {1} {2} {3}", doctorFirstName, doctorMiddleName, doctorLastName, doctorSurname);

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
        
        public static void UpdateCustodian(XDocument xdoc, string oidCustodianOrganization, string CustodianOrganizationName, 
            string custodianOrganizationTelecom, string custodianOrganizationAddress, string custodianOrganizationPrecinct, 
            string custodianOrganizationCounty, string custodianOrganizationState, string custodianOrganizationPostalCode, string custodianOrganizationCountry)
        {
            var idElement = xdoc.XPathSelectElement(CustodianOrganizationIdPath, XmlNamespaceManager);
            idElement.Attribute("root").Value = oidCustodianOrganization;

            var nameElement = xdoc.XPathSelectElement(CustodianOrganizationNamePath, XmlNamespaceManager);
            nameElement.Value = CustodianOrganizationName;

            var telecomElement = xdoc.XPathSelectElement(CustodianOrganizationTelecomPath, XmlNamespaceManager);
            telecomElement.Attribute("value").Value = custodianOrganizationTelecom;

            var addrElement = xdoc.XPathSelectElement(CustodianOrganizationAddrPath, XmlNamespaceManager);
            addrElement.Value = custodianOrganizationAddress;

            addrElement.SetElementValue(defaultNs + "precinct", custodianOrganizationPrecinct);
            addrElement.SetElementValue(defaultNs + "county", custodianOrganizationCounty);
            addrElement.SetElementValue(defaultNs + "state", custodianOrganizationState);
            addrElement.SetElementValue(defaultNs + "postalCode", custodianOrganizationPostalCode);
            addrElement.SetElementValue(defaultNs + "country", custodianOrganizationPrecinct);
        }

        // Doctor Remoto
        public static void UpdateInformationRecipient(XDocument xdoc, string doctorProfessionalLicense, string doctorFirstName, string doctorMiddleName,
            string doctorLastName, string doctorSurname, string oidOrganization , string organizationName)
        {
            var idElement = xdoc.XPathSelectElement(RecipientIdPath, XmlNamespaceManager);
            idElement.Attribute("extension").Value = doctorProfessionalLicense;

            var givenElement = xdoc.XPathSelectElement(RecipientGivenNamePath, XmlNamespaceManager);
            givenElement.Value = string.Format("{0} {1}", doctorFirstName, doctorMiddleName);

            var lastNameElement = xdoc.XPathSelectElement(RecipientLastNamePath, XmlNamespaceManager);
            lastNameElement.Value = doctorLastName;

            var surenameElement = xdoc.XPathSelectElement(RecipientSurenamePath, XmlNamespaceManager);
            surenameElement.Value = doctorSurname;


            var organizationIdElement = xdoc.XPathSelectElement(RecipientOrganizationIdPath, XmlNamespaceManager);
            organizationIdElement.Attribute("root").Value = oidOrganization;

            var organizationNameElement = xdoc.XPathSelectElement(RecipientOrganizationNamePath, XmlNamespaceManager);
            organizationNameElement.Value = organizationName;
        }
        
        // Doctor Solicitante
        public static void UpdateLegalAuthenticator(XDocument xdoc, DateTime dateTime, string oidSystemUsers, string userId,
            string doctorProfessionalLicense, string oidSpecialty, string specialtyName, string doctorFirstName, string doctorMiddleName,
            string doctorLastName, string doctorSurname, string oidOrganization, string organizationName)
        {

            var timeElement = xdoc.XPathSelectElement(LegalAuthenticatorTimePath, XmlNamespaceManager);
            timeElement.Attribute("value").Value = GetFormattedDateTime(dateTime);

            var useridElement = xdoc.XPathSelectElement(LegalAuthenticatorUserIdPath, XmlNamespaceManager);
            useridElement.Attribute("root").Value = oidSystemUsers;
            useridElement.Attribute("extension").Value = userId;

            var doctoridElement = xdoc.XPathSelectElement(LegalAuthenticatorDoctorIdPath, XmlNamespaceManager);
            doctoridElement.Attribute("extension").Value = doctorProfessionalLicense;

            var codeElement = xdoc.XPathSelectElement(LegalAuthenticatorCodePath, XmlNamespaceManager);
            codeElement.Attribute("code").Value = oidSpecialty;
            codeElement.Attribute("displayName").Value = specialtyName;

            var firstnameElement = xdoc.XPathSelectElement(LegalAuthenticatorFirstNamePath, XmlNamespaceManager);
            firstnameElement.Value = doctorFirstName;

            var lastNameElement = xdoc.XPathSelectElement(LegalAuthenticatorLastNamePath, XmlNamespaceManager);
            lastNameElement.Value = doctorLastName;

            var surNameElement = xdoc.XPathSelectElement(LegalAuthenticatorSurNamePath, XmlNamespaceManager);
            lastNameElement.Value = doctorSurname;

            var idOrganizationElement = xdoc.XPathSelectElement(LegalAuthenticatorRepresentedOrganizationIdPath, XmlNamespaceManager);
            idOrganizationElement.Attribute("root").Value = oidOrganization;

            var nameOrganizationElement = xdoc.XPathSelectElement(LegalAuthenticatorRepresentedOrganizationNamePath, XmlNamespaceManager);
            nameOrganizationElement.Value = organizationName;
        }
        
        // Medico Solicitante
        public static void UpdateAuthenticator(XDocument xdoc, DateTime dateTime, string oidSystemUsers, string userID, 
            string doctorProfessionalLicense, string oidSpecialty, string specialtyName, string doctorFirstName, string doctorMiddleName,
            string doctorLastName, string doctorSurname, string oidOrganization, string organizationName)
        {
            var timeElement = xdoc.XPathSelectElement(AuthenticatorTimePath, XmlNamespaceManager);
            timeElement.Attribute("value").Value = GetFormattedDateTime(dateTime);

            var idElement = xdoc.XPathSelectElement(AuthenticatorAssignedSystemIdPath, XmlNamespaceManager);
            idElement.Attribute("root").Value = oidSystemUsers;
            idElement.Attribute("extension").Value = userID;

            var licenseElement = xdoc.XPathSelectElement(AuthenticatorProfessionalLicensePath, XmlNamespaceManager);
            licenseElement.Attribute("extension").Value = doctorProfessionalLicense;

            var specialtyElement = xdoc.XPathSelectElement(AuthenticarotSpecialtyPath, XmlNamespaceManager);
            specialtyElement.Attribute("code").Value = oidSpecialty;
            specialtyElement.Attribute("displayName").Value = specialtyName;            

            var givenElement = xdoc.XPathSelectElement(AuthenticatorGivenNamePath, XmlNamespaceManager);
            givenElement.Value = string.Format("{0} {1}", doctorFirstName, doctorMiddleName);

            var lastNameElement = xdoc.XPathSelectElement(AuthenticatorLastNamePath, XmlNamespaceManager);
            lastNameElement.Value = doctorLastName;

            var surenameElement = xdoc.XPathSelectElement(AuthenticatorSurenamePath, XmlNamespaceManager);
            surenameElement.Value = doctorSurname;

            var organizationIdElement = xdoc.XPathSelectElement(AuthenticatorOrganizationIdPath, XmlNamespaceManager);
            organizationIdElement.Attribute("root").Value = oidOrganization;

            var organizationNameElement = xdoc.XPathSelectElement(AuthenticatorOrganizationNamePath, XmlNamespaceManager);
            organizationNameElement.Value = organizationName;
        }

        public static void UpdateInFulfillmentOf(XDocument xdoc, string oidOrders, string orderId)
        {
            var idElement = xdoc.XPathSelectElement(InFulfillmentOfIdPath, XmlNamespaceManager);
            idElement.Attribute("root").Value = oidOrders;
            idElement.Attribute("extension").Value = orderId;
        }

        // Request
        public static void UpdateComponent(XDocument xdoc, string reasonOfReferal, string interrogatory, 
            string allergies, string procedures, string medication, string physicalExam,
            string vitalSigns, string results, string assesment)
        {

            var reasonElement = xdoc.XPathSelectElement(ComponentReasonOfReferalPath, XmlNamespaceManager);
            reasonElement.Value = reasonOfReferal;

            var textinterrogatoryElement = xdoc.XPathSelectElement(ComponentInterrogatoryPath, XmlNamespaceManager);
            textinterrogatoryElement.Value = interrogatory;

            var allergiesElement = xdoc.XPathSelectElement(ComponentAllergiesPath, XmlNamespaceManager);
            allergiesElement.Value = allergies;

            var proceduresElement = xdoc.XPathSelectElement(ComponentProceduresPath, XmlNamespaceManager);
            proceduresElement.Value = procedures;

            var medicationElement = xdoc.XPathSelectElement(ComponentMedicationsPath, XmlNamespaceManager);
            medicationElement.Value = medication;

            var physicalexamElement = xdoc.XPathSelectElement(ComponentPhysicalExamPath, XmlNamespaceManager);
            physicalexamElement.Value = physicalExam;

            var vitalsignsElement = xdoc.XPathSelectElement(ComponentVitalSignsPath, XmlNamespaceManager);
            vitalsignsElement.Value = vitalSigns;

            var resultsElement = xdoc.XPathSelectElement(ComponentResultsPath, XmlNamespaceManager);
            resultsElement.Value = results;

            var assesmentElement = xdoc.XPathSelectElement(ComponentAssesmentPath, XmlNamespaceManager);
            assesmentElement.Value = assesment;

        }
        
        // Response
        public static void UpdateComponent(XDocument xdoc, string ComponentInterrogatoryText, string ComponentDiagnosticText, string ComponentOrdersText, string ComponentTreatmentText)
        {
            var textinterrogatoryElement = xdoc.XPathSelectElement(ComponentResponseTextInterrogatoryPath, XmlNamespaceManager);
            textinterrogatoryElement.Value = ComponentInterrogatoryText;

            var textdiagnosticElement = xdoc.XPathSelectElement(ComponentResponseTextDiagnosticPath, XmlNamespaceManager);
            textdiagnosticElement.Value = ComponentDiagnosticText;

            var ordersElement = xdoc.XPathSelectElement(ComponentResponseOrdersPath, XmlNamespaceManager);
            ordersElement.Value = ComponentOrdersText;

            var treatmentElement = xdoc.XPathSelectElement(ComponentResponseTreatmentPlanPath, XmlNamespaceManager);
            treatmentElement.Value = ComponentTreatmentText;
        }

        // Doctor solicitante
        public static void UpdateComponentOf(XDocument xdoc, string oidClinicalActs, string clinicalActId, string oidSystemUsers, 
            string userID, DateTime dateTime, string doctorProfessionalLicense, string doctorFirstName, string doctorMiddleName,
            string doctorLastName, string doctorSurname, string oidOrganization, string organizationName, 
            string clues, string locationName, string organizationAddress, string organizationPrecinct, 
            string organizationCounty, string organizationState, string organizationPostalCode, string organizationCountry)
        {
            var idElement = xdoc.XPathSelectElement(ComponentOfClinicalActIdPath, XmlNamespaceManager);
            idElement.Attribute("root").Value = oidClinicalActs;
            idElement.Attribute("extension").Value = clinicalActId;

            var timeElement = xdoc.XPathSelectElement(ComponentOfTimePath, XmlNamespaceManager);
            timeElement.Attribute("value").Value = GetFormattedDateTime(dateTime);

            var systemIdElement = xdoc.XPathSelectElement(ComponentOfSystemIdPath, XmlNamespaceManager);
            systemIdElement.Attribute("root").Value = oidSystemUsers;
            systemIdElement.Attribute("extension").Value = userID;

            var professionalLicensePath = xdoc.XPathSelectElement(ComponentOfProfessionalLicensePath, XmlNamespaceManager);
            if(professionalLicensePath!=null)
                professionalLicensePath.Attribute("extension").Value = doctorProfessionalLicense;

            var givenElement = xdoc.XPathSelectElement(ComponentOfGivenNamePath, XmlNamespaceManager);
            givenElement.Value = string.Format("{0} {1}", doctorFirstName, doctorMiddleName);

            var lastNameElement = xdoc.XPathSelectElement(ComponentOfLastNamePath, XmlNamespaceManager);
            lastNameElement.Value = doctorLastName;

            var surenameElement = xdoc.XPathSelectElement(ComponentOfurenamePath, XmlNamespaceManager);
            surenameElement.Value = doctorSurname;

            var organizationIdElement = xdoc.XPathSelectElement(ComponentOfOrganizationIdPath, XmlNamespaceManager);
            organizationIdElement.Attribute("root").Value = oidOrganization;

            var organizationNameElement = xdoc.XPathSelectElement(ComponentOfOrganizationNamePath, XmlNamespaceManager);
            organizationNameElement.Value = organizationName;

            var locationIdElment = xdoc.XPathSelectElement(ComponentOfLocationIdPath, XmlNamespaceManager);
            locationIdElment.Attribute("extension").Value = clues;

            var locationNameElement = xdoc.XPathSelectElement(ComponentOfLocationNamePath, XmlNamespaceManager);
            locationIdElment.Value = locationName;

            var locationAddrElement = xdoc.XPathSelectElement(ComponentOfLocationAddrPath, XmlNamespaceManager);
            locationAddrElement.Value = organizationAddress;
            
            locationAddrElement.SetElementValue(defaultNs + "precinct", organizationPrecinct);
            locationAddrElement.SetElementValue(defaultNs + "county", organizationCounty);
            locationAddrElement.SetElementValue(defaultNs + "state", organizationState);
            locationAddrElement.SetElementValue(defaultNs + "postalCode", organizationPostalCode);
            locationAddrElement.SetElementValue(defaultNs + "country", organizationPrecinct);
        }

        /*
        public static void UpdateComponentOf(XDocument xdoc, string oidClinicalActs, string clinicalActId, DateTime dateTime, 
            string doctorProfessionalLicense, string doctorFirstName, string doctorMiddleName,
            string doctorLastName, string doctorSurname, string oidOrganization, string organizationName,
            string clues, string locationName, string organizationAddress, string organizationPrecinct,
            string organizationCounty, string organizationState, string organizationPostalCode, string organizationCountry)
        {
            var idElement = xdoc.XPathSelectElement(ComponentOfClinicalActIdPath, XmlNamespaceManager);
            idElement.Attribute("root").Value = oidClinicalActs;
            idElement.Attribute("extension").Value = clinicalActId;

            var timeElement = xdoc.XPathSelectElement(ComponentOfTimePath, XmlNamespaceManager);
            timeElement.Attribute("value").Value = GetFormattedDateTime(dateTime);
                        
            var professionalLicensePath = xdoc.XPathSelectElement(ComponentOfResponseProfessionalLicensePath, XmlNamespaceManager);
            professionalLicensePath.Attribute("extension").Value = doctorProfessionalLicense;

            var givenElement = xdoc.XPathSelectElement(ComponentOfGivenNamePath, XmlNamespaceManager);
            givenElement.Value = string.Format("{0} {1}", doctorFirstName, doctorMiddleName);

            var lastNameElement = xdoc.XPathSelectElement(ComponentOfLastNamePath, XmlNamespaceManager);
            lastNameElement.Value = doctorLastName;

            var surenameElement = xdoc.XPathSelectElement(ComponentOfurenamePath, XmlNamespaceManager);
            surenameElement.Value = doctorSurname;

            var organizationIdElement = xdoc.XPathSelectElement(ComponentOfOrganizationIdPath, XmlNamespaceManager);
            organizationIdElement.Attribute("root").Value = oidOrganization;

            var organizationNameElement = xdoc.XPathSelectElement(ComponentOfOrganizationNamePath, XmlNamespaceManager);
            organizationNameElement.Value = organizationName;

            var locationIdElment = xdoc.XPathSelectElement(ComponentOfLocationIdPath, XmlNamespaceManager);
            locationIdElment.Attribute("extension").Value = clues;

            var locationNameElement = xdoc.XPathSelectElement(ComponentOfLocationNamePath, XmlNamespaceManager);
            locationIdElment.Value = locationName;

            var locationAddrElement = xdoc.XPathSelectElement(ComponentOfLocationAddrPath, XmlNamespaceManager);
            locationAddrElement.Value = organizationAddress;

            locationAddrElement.SetElementValue(defaultNs + "precinct", organizationPrecinct);
            locationAddrElement.SetElementValue(defaultNs + "county", organizationCounty);
            locationAddrElement.SetElementValue(defaultNs + "state", organizationState);
            locationAddrElement.SetElementValue(defaultNs + "postalCode", organizationPostalCode);
            locationAddrElement.SetElementValue(defaultNs + "country", organizationPrecinct);
        }
        */


        public static string GetFormattedDateTime(DateTime? dateTime)
        {
            string value = string.Empty;

            if (dateTime.HasValue)
            {
                var year = dateTime.Value.Year.ToString("0000");
                var month = dateTime.Value.Month.ToString("00");
                var day = dateTime.Value.Day.ToString("00");
                var hour = dateTime.Value.Hour.ToString("00");
                var minute = dateTime.Value.Minute.ToString("00");
                var second = dateTime.Value.Second.ToString("00");

                value = $"{year}{month}{day}{hour}{minute}{second}";

                // [0-9]{1,8}|([0-9]{9,14}|[0-9]{14,14}\.[0-9]+)([+\-][0-9]{1,4})?' 
            }

            return value;            
        }
    }
}