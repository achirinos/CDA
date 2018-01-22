using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CdaGenerator;

namespace TestCdaGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            CdaAction cda = new CdaAction();

           
            Console.Write("Response");
            cda.GenerateResponse();
        }
    }
}
