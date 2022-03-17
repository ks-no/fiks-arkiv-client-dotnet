using System.IO;
using System.Xml;
using System.Xml.Schema;

namespace KS.Fiks.IO.Arkiv.Client.Tests.Validering
{
    public class Validator
    {
        public static bool IsValidSokXml(string payload)
        {
            var validationHandler = new ValidationHandler();
            var xmlReaderSettings = new XmlReaderSettings();
            xmlReaderSettings.Schemas.Add("http://www.ks.no/standarder/fiks/arkiv/sok/v1", "Schema/sok.xsd");
            xmlReaderSettings.ValidationType = ValidationType.Schema;
            xmlReaderSettings.ValidationEventHandler +=
                new ValidationEventHandler(validationHandler.HandleValidationError);

            var xmlReader = XmlReader.Create(new StringReader(payload), xmlReaderSettings);

            while (xmlReader.Read())
            {
            }

            return !validationHandler.HasErrors();
        }

        public static bool IsValidArkivmeldingXml(string payload)
        {
            var validationHandler = new ValidationHandler();
            var xmlReaderSettings = new XmlReaderSettings();
            xmlReaderSettings.Schemas.Add("http://www.arkivverket.no/standarder/noark5/arkivmelding/v2", "Schema/arkivmelding.xsd");
            xmlReaderSettings.Schemas.Add("http://www.arkivverket.no/standarder/noark5/metadatakatalog/v2", "Schema/metadatakatalog.xsd");
            xmlReaderSettings.ValidationType = ValidationType.Schema;
            xmlReaderSettings.ValidationEventHandler +=
                new ValidationEventHandler(validationHandler.HandleValidationError);

            var xmlReader = XmlReader.Create(new StringReader(payload), xmlReaderSettings);

            while (xmlReader.Read())
            {
            }

            return !validationHandler.HasErrors();
        }
        
        
        public static bool IsValidArkivmeldingOppdateringXml(string payload)
        {
            var validationHandler = new ValidationHandler();
            var xmlReaderSettings = new XmlReaderSettings();
            xmlReaderSettings.Schemas.Add("http://www.arkivverket.no/standarder/noark5/arkivmeldingoppdatering/v2", "Schema/arkivmeldingOppdatering.xsd");
            xmlReaderSettings.Schemas.Add("http://www.arkivverket.no/standarder/noark5/arkivmelding/v2", "Schema/arkivmelding.xsd");
            xmlReaderSettings.Schemas.Add("http://www.arkivverket.no/standarder/noark5/metadatakatalog/v2", "Schema/metadatakatalog.xsd");
            xmlReaderSettings.ValidationType = ValidationType.Schema;
            xmlReaderSettings.ValidationEventHandler +=
                new ValidationEventHandler(validationHandler.HandleValidationError);

            var xmlReader = XmlReader.Create(new StringReader(payload), xmlReaderSettings);

            while (xmlReader.Read())
            {
            }

            return !validationHandler.HasErrors();
        }
    }
}