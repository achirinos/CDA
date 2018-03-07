using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CdaGenerator
{
    public class CdaRequest
    {
        public Header Header { get; set; }
        public Patient Patient { get; set; }
        public Author Author { get; set; }
        public Software Software { get; set; }
        public DataEnterer DataEnterer { get; set; }
        public Custodian Custodian { get; set; }
        public InformationRecipient InformationRecipient { get; set; }
        public LegalAuthenticator LegalAuthenticator { get; set; }
        public Authenticator Authenticator { get; set; }
        public InFulfillmentOf InFulfillmentOf { get; set; }
        public ComponentRequest Component { get; set; }
        public ComponentOf ComponentOf { get; set; }


        public CdaRequest()
        {
            
        }

        public CdaRequest(Header header, Patient patient, Author author, Software software, DataEnterer dataEnterer, Custodian custodian, InformationRecipient informationRecipient, LegalAuthenticator legalAuthenticator, Authenticator authenticator, InFulfillmentOf inFulfillmentOf, ComponentRequest component, ComponentOf componentOf)
        {
            Header = header;
            Patient = patient;
            Author = author;
            Software = software;
            DataEnterer = dataEnterer;
            Custodian = custodian;
            InformationRecipient = informationRecipient;
            LegalAuthenticator = legalAuthenticator;
            Authenticator = authenticator;
            InFulfillmentOf = inFulfillmentOf;
            Component = component;
            ComponentOf = componentOf;
        }
    }
}
