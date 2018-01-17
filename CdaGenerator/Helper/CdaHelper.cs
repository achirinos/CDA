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

        public static string CustodianOrganizationIdPath = "ns:ClinicalDocument/ns:custodia/ns:assignedCustodian/ns:representedCustodianOrganization/ns:id";
        public static string CustodianOrganizationNamePath = "ns:ClinicalDocument/ns:custodia/ns:assignedCustodian/ns:representedCustodianOrganization/ns:name";
        public static string CustodianOrganizationTelecomPath = "ns:ClinicalDocument/ns:custodia/ns:assignedCustodian/ns:representedCustodianOrganization/ns:telecom";
        public static string CustodianOrganizationAddrPath = "ns:ClinicalDocument/ns:custodia/ns:assignedCustodian/ns:representedCustodianOrganization/ns:addr";
        public static string CustodianOrganizationPrecinctPath = "ns:ClinicalDocument/ns:custodia/ns:assignedCustodian/ns:representedCustodianOrganization/ns:addr/precinct";
        public static string CustodianOrganizationCountyPath = "ns:ClinicalDocument/ns:custodia/ns:assignedCustodian/ns:representedCustodianOrganization/ns:addr/county";
        public static string CustodianOrganizationStatePath = "ns:ClinicalDocument/ns:custodia/ns:assignedCustodian/ns:representedCustodianOrganization/ns:addr/state";
        public static string CustodianOrganizationPostalCodePath = "ns:ClinicalDocument/ns:custodia/ns:assignedCustodian/ns:representedCustodianOrganization/ns:addr/postalCode";
        public static string CustodianOrganizationCountryPath = "ns:ClinicalDocument/ns:custodia/ns:assignedCustodian/ns:representedCustodianOrganization/ns:addr/country";



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

        public static void UpdatePatient(XDocument xdoc, string oidSystemPatients, Person person)
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
            genderElement.Attribute("code").Value = person.GenderID; // ToDo

            var birthTimeElement = xdoc.XPathSelectElement(PatientBirthTimePath, XmlNamespaceManager);
            birthTimeElement.Attribute("value").Value = GetFormattedDateTime(person.BirthDate);

            var maritalStatusCodeElement = xdoc.XPathSelectElement(PatientMaritalStatusCodePath, XmlNamespaceManager);
            maritalStatusCodeElement.Attribute("code").Value = person.CivilStateID; // ToDo

            var religiousAffiliationCodeElement = xdoc.XPathSelectElement(PatientReligiousAffiliationCodePath,
                XmlNamespaceManager);
            religiousAffiliationCodeElement.Attribute("code").Value = person.ReligionID; // ToDo

            var ethnicGroupCodeElement = xdoc.XPathSelectElement(PatientEthnicGroupCodePath, XmlNamespaceManager);
            ethnicGroupCodeElement.Attribute("code").Value = person.EthnicityID; //ToDo

            var birthplaceStateElement = xdoc.XPathSelectElement(PatientBirthplaceStatePath, XmlNamespaceManager);
            birthplaceStateElement.Value = "Estado"; // ToDo

            var birthplaceCountryElement = xdoc.XPathSelectElement(PatientBirthplaceCountryPath, XmlNamespaceManager);
            birthplaceCountryElement.Value = person.NationalityID; // ToDo
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

        public static void UpdateCustodian(XDocument xdoc, string oidCustodianOrganization, string CustodianOrganizationName, string CustodianOrganizationTelecom, string CustodianOrganizationAddress, string CustodianOrganizationPrecinct, string CustodianOrganizationCounty, string CustodianOrganizationState, string CustodianOrganizationPostalCode, string CustodianOrganizationCountry)
        {
            var idElement = xdoc.XPathSelectElement(CustodianOrganizationIdPath, XmlNamespaceManager);
            idElement.Attribute("root").Value = oidCustodianOrganization;

            var nameElement = xdoc.XPathSelectElement(CustodianOrganizationNamePath, XmlNamespaceManager);
            nameElement.Value = CustodianOrganizationName;

            var telecomElement = xdoc.XPathSelectElement(CustodianOrganizationTelecomPath, XmlNamespaceManager);
            telecomElement.Attribute("value").Value = CustodianOrganizationTelecom;

            var addrElement = xdoc.XPathSelectElement(CustodianOrganizationAddrPath, XmlNamespaceManager);
            addrElement.Value = CustodianOrganizationAddress;

            var precinctElement = xdoc.XPathSelectElement(CustodianOrganizationPrecinctPath, XmlNamespaceManager);

            var countyElement = xdoc.XPathSelectElement(CustodianOrganizationCountyPath, XmlNamespaceManager);
            countyElement.Value = CustodianOrganizationCounty;

            var stateElement = xdoc.XPathSelectElement(CustodianOrganizationStatePath, XmlNamespaceManager);
            stateElement.Value = CustodianOrganizationState;

            var postalCodeElement = xdoc.XPathSelectElement(CustodianOrganizationPostalCodePath, XmlNamespaceManager);
            postalCodeElement.Value = CustodianOrganizationPostalCode;

            var countryElement = xdoc.XPathSelectElement(CustodianOrganizationCountyPath, XmlNamespaceManager);
            countryElement.Value = CustodianOrganizationCountry;
            

        }

        public static void UpdateInformationRecipient(XDocument xdoc)
        {
        }

        public static void UpdateLegalAuthenticator(XDocument xdoc)
        {
        }

        public static void UpdateAuthenticator(XDocument xdoc)
        {
        }
       
        public static void UpdateInFulfillmentOf(XDocument xdoc)
        {
        }


        public static string GetFormattedDateTime(DateTime dateTime)
        {           
            var year = dateTime.Year.ToString("0000");
            var month = dateTime.Month.ToString("00");
            var day = dateTime.Day.ToString("00");
            var hour = dateTime.Hour.ToString("00");
            var minute = dateTime.Minute.ToString("00");
            var second = dateTime.Second.ToString("00");

            return $"{year}{month}{day}{hour}{minute}{second}";
        }
    }
}