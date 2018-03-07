using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CdaGenerator
{
    public class Custodian
    {
        // custodian

        public string OidCustodianOrganization { get; set; }

        public string CustodianOrganizationName { get; set; }

        public string CustodianOrganizationTelecom { get; set; }

        public string CustodianOrganizationAddress { get; set; }

        public string CustodianOrganizationPrecinct { get; set; }

        public string CustodianOrganizationCounty { get; set; }

        public string CustodianOrganizationState { get; set; }

        public string CustodianOrganizationPostalCode { get; set; }

        public string CustodianOrganizationCountry { get; set; }

        public Custodian()
        {
            
        }

        public Custodian(string oidCustodianOrganization, string custodianOrganizationName, string custodianOrganizationTelecom, string custodianOrganizationAddress, string custodianOrganizationPrecinct, string custodianOrganizationCounty, string custodianOrganizationState, string custodianOrganizationPostalCode, string custodianOrganizationCountry)
        {
            OidCustodianOrganization = oidCustodianOrganization;
            CustodianOrganizationName = custodianOrganizationName;
            CustodianOrganizationTelecom = custodianOrganizationTelecom;
            CustodianOrganizationAddress = custodianOrganizationAddress;
            CustodianOrganizationPrecinct = custodianOrganizationPrecinct;
            CustodianOrganizationCounty = custodianOrganizationCounty;
            CustodianOrganizationState = custodianOrganizationState;
            CustodianOrganizationPostalCode = custodianOrganizationPostalCode;
            CustodianOrganizationCountry = custodianOrganizationCountry;
        }
    }
}
