using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CdaGenerator.Helper;
using GenerateReport;
using Telerik.Reporting;
using Telerik.Reporting.Processing;

namespace CdaGenerator
{
    public partial class Cda
    {
        #region Const
        private const string OidInstitution = "2.16.840.1.113883.3.215.6.99.5";
        private const string OidSystemDocuments = "2.16.840.1.113883.3.215.6.99.5.1.1";
        private const string OidSystemPatients = "2.16.840.1.113883.3.215.6.99.5.1.2";
        private const string OidSystemUsers = "2.16.840.1.113883.3.215.6.99.5.1.3";
        private const string OidSystemInstance = "2.16.840.1.113883.3.215.6.99.5.1";

        private const string TemplateRequest = "plantilla_nota_solicitud.xml";
        private const string TemplateResponse = "plantilla_nota_respuesta.xml";

        private CdaRequest cdaRequest;
        private CdaResponse cdaResponse;

        private Header header;
        private Patient patient;
        private Author author;
        private Software software;
        private DataEnterer dataEnterer;
        private Custodian custodian;
        private InformationRecipient informationRecipient;
        private LegalAuthenticator legalAuthenticator;
        private Authenticator authenticator;
        private InFulfillmentOf inFulfillmentOf;
        private ComponentRequest componentRequest;
        private ComponentResponse componentResponse;
        private ComponentOf componentOf;

        private XDocument xdoc;
        #endregion

        public Cda(CdaResponse cda)
        {
            var fileName = Path.GetTempFileName();

            cdaResponse = cda;

            header = cda.Header;
            patient = cda.Patient;
            author = cda.Author;
            software = cda.Software;
            dataEnterer = cda.DataEnterer;
            custodian = cda.Custodian;
            informationRecipient = cda.InformationRecipient;
            legalAuthenticator = cda.LegalAuthenticator;
            authenticator = cda.Authenticator;
            inFulfillmentOf = cda.InFulfillmentOf;
            componentResponse = cda.Component;
            componentOf = cda.ComponentOf;

            xdoc = CdaHelper.CreateCda(TemplateResponse);
            Update("response");
        }

        public Cda(CdaRequest cda)
        {
            var fileName = Path.GetTempFileName();

            cdaRequest = cda;

            header = cda.Header;
            patient = cda.Patient;
            author = cda.Author;
            software = cda.Software;
            dataEnterer = cda.DataEnterer;
            custodian = cda.Custodian;
            informationRecipient = cda.InformationRecipient;
            legalAuthenticator = cda.LegalAuthenticator;
            authenticator = cda.Authenticator;
            inFulfillmentOf = cda.InFulfillmentOf;
            componentRequest = cda.Component;
            componentOf = cda.ComponentOf;

            xdoc = CdaHelper.CreateCda(TemplateRequest);
            Update("request");
        }


        public void SaveRequestPdf()
        {

            var cda = cdaRequest;

            var instaceReportSource = new InstanceReportSource();

            var report = new RequestTemplate(cda);

            instaceReportSource.ReportDocument = report;

            SaveReport(report, @"C:\Users\luisd\source\repos\CDA-Version_nueva\Request.pdf");
			
		}

		public void SaveResponsePdf()
		{

			var cda = cdaResponse;

			var instaceReportSource = new InstanceReportSource();

			var report = new ResponseTemplate(cda);

			instaceReportSource.ReportDocument = report;

			SaveReport(report, @"C:\Users\luisd\source\repos\CDA-Version_nueva\Response.pdf");

		}

		private void SaveReport(Telerik.Reporting.Report report, string fileName)
        {
            var reportProcessor = new ReportProcessor();

            var instanceReportSource = new InstanceReportSource
            {
                ReportDocument = report
            };

            var result = reportProcessor.RenderReport("PDF", instanceReportSource, null);


            using (var fs = new FileStream(fileName, FileMode.Create))
            {
                fs.Write(result.DocumentBytes, 0, result.DocumentBytes.Length);
            }
        }

        private void Update(string type)
        {
            if (xdoc != null)
            {
                CdaHelper.UpdateHeader(xdoc, OidSystemDocuments, header.SystemDocumentId, header.SystemDocumentName, header.HeaderDateTime, "N");

                CdaHelper.UpdatePatient(xdoc, OidSystemPatients, patient.PatientId, patient.PatientNationalIdentityCode, patient.PatientStreet, patient.PatientExtrenalNumber, patient.PatientInternalNumber, patient.PatientNeighborhood, patient.PatientMunicipality, patient.PatientCity, patient.PatientState, patient.PatientZipCode, patient.PatientPhoneNumber, patient.PatientEmail, patient.PatientFirstName, patient.PatientLastName, patient.PatientSurname, patient.PatientGender, patient.PatientBirthDate, patient.PatientCivilState, patient.PatientReligion, patient.PatientEthnicity, patient.PatientBirthPlaceState, patient.PatientBirthPlaceCountry);

                CdaHelper.UpdateAuthor(xdoc, OidSystemUsers, author.AuthorDoctorId, author.AuthorDoctorProfessionalLicense, author.AuthorDoctorFirstName, author.AuthorDoctorMiddleName, author.AuthorDoctorLastName, author.AuthorDoctorSurname, author.AuthorOidSpecialty, author.AuthorSpecialtyName, author.AuthorDateTime, author.AuthorOidOrganization, author.AuthorOrganizationName);

                CdaHelper.UpdateSoftware(xdoc, software.DateTime, OidSystemInstance, software.SoftwareName, OidInstitution, software.SoftwareInstitutionName);

                CdaHelper.UpdateDataEnterer(xdoc, dataEnterer.Date, OidSystemUsers, dataEnterer.UserId, dataEnterer.UserFullName);

                CdaHelper.UpdateCustodian(xdoc, custodian.OidCustodianOrganization, custodian.CustodianOrganizationName, custodian.CustodianOrganizationTelecom, custodian.CustodianOrganizationAddress, custodian.CustodianOrganizationPrecinct, custodian.CustodianOrganizationCounty, custodian.CustodianOrganizationState, custodian.CustodianOrganizationPostalCode, custodian.CustodianOrganizationCountry);

                CdaHelper.UpdateInformationRecipient(xdoc, informationRecipient.RecipientDoctorProfessionalLicense, informationRecipient.RecipientDoctorFirstName, informationRecipient.RecipientDoctorMiddleName, informationRecipient.RecipientDoctorLastName, informationRecipient.RecipientDoctorSurname, informationRecipient.RecipientOidOrganization, informationRecipient.RecipientOrganizationName);

                CdaHelper.UpdateLegalAuthenticator(xdoc, legalAuthenticator.DateTime, OidSystemUsers, legalAuthenticator.UserId, legalAuthenticator.DoctorProfessionalLicense, legalAuthenticator.OidSpecialty, legalAuthenticator.SpecialtyName, legalAuthenticator.DoctorFirstName, legalAuthenticator.DoctorMiddleName, legalAuthenticator.DoctorLastName, legalAuthenticator.DoctorSurname, legalAuthenticator.OidOrganization, legalAuthenticator.OrganizationName);

                CdaHelper.UpdateAuthenticator(xdoc, authenticator.DateTime, OidSystemUsers, authenticator.UserId, authenticator.DoctorProfessionalLicense, authenticator.OidSpecialty, authenticator.SpecialtyName, authenticator.DoctorFirstName, authenticator.DoctorMiddleName, authenticator.DoctorLastName, authenticator.DoctorSurname, authenticator.OidOrganization, authenticator.OrganizationName);

                CdaHelper.UpdateInFulfillmentOf(xdoc, inFulfillmentOf.OidOrders, inFulfillmentOf.OrderId);
                
                switch (type)
                {
                    case "response":
                        CdaHelper.UpdateComponent(xdoc, componentResponse.Interrogatory, componentResponse.Diagnostic, componentResponse.Orders, componentResponse.TreatmentPlan);
                        break;
                    case "request":
                        CdaHelper.UpdateComponent(xdoc, componentRequest.ReasonOfReferal, componentRequest.Interrogatory,
                            componentRequest.Allergies, componentRequest.Procedures, componentRequest.Medication,
                            componentRequest.PhysicalExam, componentRequest.VitalSigns, componentRequest.Results,
                            componentRequest.Assesment);
                        break;
                }


                CdaHelper.UpdateComponentOf(xdoc, componentOf.AttentionCode, componentOf.ClinicalActId, OidSystemUsers, componentOf.UserId, componentOf.AttentionDateTime, componentOf.DoctorProfessionalLicense, componentOf.DoctorFirstName, componentOf.DoctorMiddleName, componentOf.DoctorLastName, componentOf.DoctorSurname, componentOf.OidOrganization, componentOf.OrganizationName, componentOf.Clues, componentOf.LocationName, componentOf.LocationAddress, componentOf.LocationPrecinct, componentOf.LocationCounty, componentOf.LocationState, componentOf.LocationPostalCode, componentOf.LocationCountry);

            }
        }

        

        public void Save(string filename)
        {
            if (xdoc == null || filename == null)
            {
                return;
            }

            xdoc.Declaration = new XDeclaration("1.0", "utf-8", null);
            xdoc.Save(filename);
        }
    }
}
