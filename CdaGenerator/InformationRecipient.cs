using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CdaGenerator
{
    public class InformationRecipient
    {
        // InformationRecipient            

        public string RecipientDoctorProfessionalLicense { get; set; }

        public string RecipientDoctorFirstName { get; set; }

        public string RecipientDoctorMiddleName { get; set; }

        public string RecipientDoctorLastName { get; set; }

        public string RecipientDoctorSurname { get; set; }

        public DateTime RecipientDateTime { get; set; }

        public string RecipientOidOrganization { get; set; }

        public string RecipientOrganizationName { get; set; }

        public InformationRecipient()
        {
            
        }

        public InformationRecipient(string recipientDoctorProfessionalLicense, string recipientDoctorFirstName, string recipientDoctorMiddleName, string recipientDoctorLastName, string recipientDoctorSurname, DateTime recipientDateTime, string recipientOidOrganization, string recipientOrganizationName)
        {
            RecipientDoctorProfessionalLicense = recipientDoctorProfessionalLicense;
            RecipientDoctorFirstName = recipientDoctorFirstName;
            RecipientDoctorMiddleName = recipientDoctorMiddleName;
            RecipientDoctorLastName = recipientDoctorLastName;
            RecipientDoctorSurname = recipientDoctorSurname;
            RecipientDateTime = recipientDateTime;
            RecipientOidOrganization = recipientOidOrganization;
            RecipientOrganizationName = recipientOrganizationName;
        }
    }
}
