using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CdaGenerator
{
    public class Author
    {
        // Author

        public string AuthorDoctorId { get; set; }

        public string AuthorDoctorProfessionalLicense { get; set; }

        public string AuthorDoctorFirstName { get; set; }

        public string AuthorDoctorMiddleName { get; set; }

        public string AuthorDoctorLastName { get; set; }

        public string AuthorDoctorSurname { get; set; }

        public string AuthorOidSpecialty { get; set; }

        public string AuthorSpecialtyName { get; set; }

        public DateTime AuthorDateTime { get; set; }

        public string AuthorOidOrganization { get; set; }

        public string AuthorOrganizationName { get; set; }

        public Author()
        {

        }

        public Author(string authorDoctorId, string authorDoctorProfessionalLicense, string authorDoctorFirstName, string authorDoctorMiddleName, string authorDoctorLastName, string authorDoctorSurname, string authorOidSpecialty, string authorSpecialtyName, DateTime authorDateTime, string authorOidOrganization, string authorOrganizationName)
        {
            AuthorDoctorId = authorDoctorId;
            AuthorDoctorProfessionalLicense = authorDoctorProfessionalLicense;
            AuthorDoctorFirstName = authorDoctorFirstName;
            AuthorDoctorMiddleName = authorDoctorMiddleName;
            AuthorDoctorLastName = authorDoctorLastName;
            AuthorDoctorSurname = authorDoctorSurname;
            AuthorOidSpecialty = authorOidSpecialty;
            AuthorSpecialtyName = authorSpecialtyName;
            AuthorDateTime = authorDateTime;
            AuthorOidOrganization = authorOidOrganization;
            AuthorOrganizationName = authorOrganizationName;
        }
    }
}
