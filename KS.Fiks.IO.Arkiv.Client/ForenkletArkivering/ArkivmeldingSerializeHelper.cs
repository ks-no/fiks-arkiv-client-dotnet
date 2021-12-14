using System.IO;
using System.Xml.Serialization;
using KS.Fiks.IO.Arkiv.Client.Models.Arkivering.Arkivmelding;

namespace KS.Fiks.IO.Arkiv.Client.ForenkletArkivering
{
    public class ArkivmeldingSerializeHelper
    {
        public static string Serialize(object arkivmelding)
        {
            var serializer = new XmlSerializer(arkivmelding.GetType());
            var stringWriter = new StringWriter();
            serializer.Serialize(stringWriter, arkivmelding);
            
            return stringWriter.ToString();
        }

        public static Arkivmelding DeSerialize(string arkivmelding)
        {
            var serializer = new XmlSerializer(typeof(Arkivmelding));
            Arkivmelding arkivmeldingDeserialized;
            using (TextReader reader = new StringReader(arkivmelding))
            {
                arkivmeldingDeserialized = (Arkivmelding) serializer.Deserialize(reader);
            }

            return arkivmeldingDeserialized;
        }
    }
}
