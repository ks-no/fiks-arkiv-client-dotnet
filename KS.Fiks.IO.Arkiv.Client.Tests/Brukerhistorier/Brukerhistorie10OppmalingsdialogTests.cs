using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using KS.Fiks.IO.Arkiv.Client.ForenkletArkivering;
using KS.Fiks.IO.Arkiv.Client.Models.Innsyn.Sok;
using NUnit.Framework;

namespace KS.Fiks.IO.Arkiv.Client.Tests.Brukerhistorier 
{
    class Brukerhistorie10OppmalingsdialogTests
    {
        // Skal sjekke om det finnes en sak med angitt saksår og saksseksvensnummer i akrivet
        [Test]
        public void SjekkSakMedSaksnummerFinnesGirValidXml()
        {
            var saksaar = 2020;
            var saksaksekvensnummer = 123;

            var arkivmeldingsok = new Sok
            {
                Respons = Respons.Saksmappe,
                MeldingId = Guid.NewGuid().ToString(),
                System = "Fagsystem X",
                Tidspunkt = DateTime.Now,
                Skip = 0,
                Take = 100
            };

            arkivmeldingsok.Parameter.Add(
            new Parameter
                {
                    Felt = SokFelt.SakPeriodSaksaar,
                    Operator = OperatorType.Equal,
                    Parameterverdier = new Parameterverdier
                    {
                        Intvalues = { saksaar }
                    }
                });
            
            arkivmeldingsok.Parameter.Add(
            new Parameter
                {
                    Felt = SokFelt.SakPeriodSaksekvensnummer,
                    Operator = OperatorType.Equal,
                    Parameterverdier = new Parameterverdier
                    {
                        Intvalues = { saksaksekvensnummer }
                    }
                });

            var payload = ArkivmeldingSerializeHelper.Serialize(arkivmeldingsok);

            if (!Validator.IsValidSokXml(payload))
            {
                Assert.Fail("Validation errors");
            }
            
            Assert.Pass();
        }
    }
}