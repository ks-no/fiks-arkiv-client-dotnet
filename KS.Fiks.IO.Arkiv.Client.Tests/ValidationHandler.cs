using System;
using System.Xml.Schema;

namespace KS.Fiks.IO.Arkiv.Client.Tests
{
    public class ValidationHandler
    {
        public int numberOfErrors = 0;

        public void HandleValidationError(object sender, ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Warning)
            {
                Console.Write("WARNING: ");
                Console.WriteLine(e.Message);
            }
            else if (e.Severity == XmlSeverityType.Error)
            {
                numberOfErrors++;
                Console.Write("ERROR: ");
                Console.WriteLine(e.Message);
            }
        }

        public bool HasErrors()
        {
            return numberOfErrors > 0;
        } 
    }
}