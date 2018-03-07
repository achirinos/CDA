using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CdaGenerator
{
    public class ComponentRequest
    {
        // Component

        // CdaRequest
        public string ReasonOfReferal { get; set; }
        public string Interrogatory { get; set; }
        public string Allergies { get; set; }
        public string Procedures { get; set; }
        public string Medication { get; set; }
        public string PhysicalExam { get; set; }
        public string VitalSigns { get; set; }
        public string Results { get; set; }
        public string Assesment { get; set; }

        public ComponentRequest()
        {
            
        }

        public ComponentRequest(string reasonOfReferal,string interrogatory, string allergies, string procedures, string medication,
            string physicalExam, string vitalSigns, string results, string assesment)
        {
            ReasonOfReferal = reasonOfReferal;
            Interrogatory = interrogatory;
            Allergies = allergies;
            Procedures = procedures;
            Medication = medication;
            PhysicalExam = physicalExam;
            VitalSigns = vitalSigns;
            Results = results;
            Assesment = assesment;
        }
    }
}
