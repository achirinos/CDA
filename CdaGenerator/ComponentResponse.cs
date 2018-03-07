using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CdaGenerator
{
    public class ComponentResponse
    {
        // CdaResponse
        public string Interrogatory { get; set; }
        public string Diagnostic { get; set; }
        public string Orders { get; set; }
        public string TreatmentPlan { get; set; }

        public ComponentResponse()
        {
            
        }

        public ComponentResponse(string interrogatory, string diagnostic, string orders, string treatmentPlan)
        {
            Interrogatory = interrogatory;
            Diagnostic = diagnostic;
            Orders = orders;
            TreatmentPlan = treatmentPlan;
        }
    }
}
