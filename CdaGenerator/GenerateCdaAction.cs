using Lumed.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CdaGenerator
{
    public class GenerateCdaAction
    {

        //TODO: We must create an IConfigurable object in order to be able to edit
        //these OID's
        private const string OidInstitution = "2.16.840.1.113883.3.215.6.99.5";
        private const string OidSystemDocuments = "2.16.840.1.113883.3.215.6.99.5.1.1";
        private const string OidSystemPatients = "2.16.840.1.113883.3.215.6.99.5.1.2";
        private const string OidSystemUsers = "2.16.840.1.113883.3.215.6.99.5.1.3";
        private const string OidSystemInstance = "2.16.840.1.113883.3.215.6.99.5.1";

        public void Generate()
        {
            var systemName = "";
            var userId = "";
            var userFullName = "";
            var oidInstitution = "";
            var institutionName = "";
            var documentId = "";
            var documentName = "";
            var confidentialityCode = "";
            var date = DateTime.Now;

            var person = new Person();
            var doctor = new Doctor();

            var xdoc = CdaHelper.CreateCda();

            CdaHelper.UpdateHeader(xdoc, OidSystemDocuments, documentId, documentName, date, confidentialityCode);
            CdaHelper.UpdatePatient(xdoc, OidSystemPatients, person);
            CdaHelper.UpdateAuthor(xdoc, OidSystemUsers, doctor, date, oidInstitution, institutionName);
            CdaHelper.UpdateSoftware(xdoc, date, OidSystemInstance, systemName, oidInstitution, institutionName);
            CdaHelper.UpdateDataEnterer(xdoc, date, OidSystemUsers, userId, userFullName);
            CdaHelper.UpdateCustodian();
            CdaHelper.UpdateInformationRecipient();
            CdaHelper.UpdateLegalAuthenticator();
            CdaHelper.UpdateAuthenticator();
            CdaHelper.UpdateInFulfillmentOf();
            CdaHelper.UpdateComponent();
            CdaHelper.UpdateComponentOf();
        }


    }
}
}
