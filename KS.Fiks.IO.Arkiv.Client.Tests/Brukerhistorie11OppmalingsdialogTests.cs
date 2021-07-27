using System;
using System.Collections.Generic;
using KS.Fiks.IO.Arkiv.Client.ForenkletArkivering;
using no.ks.fiks.io.arkivmelding.sok;
using NUnit.Framework;

namespace KS.Fiks.IO.Arkiv.Client.Tests
{
    class UnitTestBrukerhistorie11Oppmalingsdialog
    {

        public void Setup()
        {
        }

        // fagsystem har dokumentID til dokumentet skal finne dokumentet for visnign i klient
        [Test]
        public void TestFinnDokumentFraId()
        {
            var dokumentEkstenId  = "12345-ABCDE";
          
            var arkivmeldingsok = new sok
            {
                respons = respons_type.dokumentbeskrivelse,
                meldingId = Guid.NewGuid().ToString(),
                system = "Fagsystem X",
                tidspunkt = DateTime.Now,
                skip = 0,
                take = 100
            };
            // må søke på ekstenID finner ikke noe felt for dokument id.

            var paramlist = new List<parameter>
            {
                new parameter
                {
                    felt = field_type.dokumenteksternId,
                    @operator = operator_type.equal,
                    parameterverdier = new parameterverdier
                    {
                        Item = new eksternId
                        {
                            system = "Fagsystem X",
                            id = dokumentEkstenId
                        }
                    }
                }
            };

            arkivmeldingsok.parameter = paramlist.ToArray();
            var payload = ArkivmeldingSerializeHelper.Serialize(arkivmeldingsok);

            Assert.Pass();
        }
    }
}
