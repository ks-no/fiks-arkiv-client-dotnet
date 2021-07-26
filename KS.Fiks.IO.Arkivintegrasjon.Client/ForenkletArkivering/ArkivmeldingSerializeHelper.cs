using System.IO;
using System.Xml.Serialization;
using no.ks.fiks.io.arkivmelding;

namespace KS.Fiks.IO.Arkivintegrasjon.Client.ForenkletArkivering
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

        public static arkivmelding DeSerialize(string arkivmelding)
        {
            var serializer = new XmlSerializer(typeof(arkivmelding));
            arkivmelding arkivmeldingDeserialized;
            using (TextReader reader = new StringReader(arkivmelding))
            {
                arkivmeldingDeserialized = (arkivmelding) serializer.Deserialize(reader);
            }

            return arkivmeldingDeserialized;
        }
    }
}
