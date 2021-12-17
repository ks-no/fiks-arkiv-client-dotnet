﻿using System;
 using System.Collections.Generic;
 using KS.Fiks.IO.Arkiv.Client.ForenkletArkivering;
 using KS.Fiks.IO.Arkiv.Client.Models.Innsyn.Sok;
 using NUnit.Framework;

 namespace KS.Fiks.IO.Arkiv.Client.Tests.Brukerhistorier
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
          
            var arkivmeldingsok = new Sok
            {
                Respons = Respons.Dokumentbeskrivelse,
                MeldingId = Guid.NewGuid().ToString(),
                System = "Fagsystem X",
                Tidspunkt = DateTime.Now,
                Skip = 0,
                Take = 100
            };
            // må søke på ekstenID finner ikke noe felt for dokument id.

            var parameter = new Parameter
            {
                Felt = SokFelt.DokumentbeskrivelsePeriodEksternId,
                Operator = OperatorType.Equal,
                Parameterverdier = new Parameterverdier
                {
                    EksternId = new EksternId()
                    {
                        System = "Fagsystem X",
                        Id = dokumentEkstenId
                    }
                }
            };

            arkivmeldingsok.Parameter.Add(parameter);
            var payload = ArkivmeldingSerializeHelper.Serialize(arkivmeldingsok);

            if (!Validator.IsValidSokXml(payload))
            {
                Assert.Fail("Validation errors");
            }
            
            Assert.Pass();
        }
    }
}
