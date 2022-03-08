using System;
using KS.Fiks.IO.Arkiv.Client.ForenkletArkivering;
using KS.Fiks.IO.Arkiv.Client.Models.Innsyn.Sok;
using NUnit.Framework;

namespace KS.Fiks.IO.Arkiv.Client.Tests.Brukerhistorier
{
    class Brukerhistorie7OppmalingsdialogTests
    {
        [SetUp]
        public void Setup()
        {
        }
        // Brukstilfellet søker frem alle dokumenter knyttet til sak og presenterer disse for bruker. Bruker velger et av av disse og knytter til saken i fagsystemet. 
        // I denne testen søker vi bare frem dokumenter for en sak
        [Test]
        public void TestFinnDokumenterForsak()
        {
            var saksaar = 2020;
            var saksaksekvensnummer = 123;

            var arkivmeldingsok = new Sok
            {
                Respons = Respons.Dokumentbeskrivelse,
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
            
            Assert.True(Validator.IsValidSokXml(payload), "Validation errors");
        }
    }
}
