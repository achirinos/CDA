using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CdaGenerator
{
    public class Header
    {
       
        public string SystemDocumentId { get; set; }

        public string SystemDocumentName { get; set; }

        public DateTime HeaderDateTime { get; set; }

        public Header()
        {
            
        }

        public Header(string systemDocumentId, string systemDocumentName, DateTime headerDateTime)
        {
            SystemDocumentId = systemDocumentId;
            SystemDocumentName = systemDocumentName;
            HeaderDateTime = headerDateTime;
        }

    }
}
