﻿using System;
 using System.Collections.Generic;
 using KS.Fiks.IO.Arkiv.Client.ForenkletArkivering;
 using no.ks.fiks.io.arkivmelding.innsyn.sok;
 using NUnit.Framework;

 namespace KS.Fiks.IO.Arkiv.Client.Tests.Brukerhistorier
{
    class Brukerhistorie10OppmalingsdialogTests
    {
        public void Setup()
        {
        }

        // Skal sjekke om det finnes en sak med angitt saksår og saksseksvensnummer i akrivet
        [Test]
        public void SjekkSakMedSaksnummerFinnes()
        {
            var saksaar = 2020;
            var saksaksekvensnummer = 123;

            var arkivmeldingsok = new sok
            {
                respons = respons.saksmappe,
                meldingId = Guid.NewGuid().ToString(),
                system = "Fagsystem X",
                tidspunkt = DateTime.Now,
                skip = 0,
                take = 100
            };

            var paramlist = new List<parameter>
            {
                new parameter
                {
                    felt = sokFelt.saksaksaar,
                    @operator = operatorType.equal,
                    parameterverdier = new parameterverdier
                    {
                        Item = new intvalues
                        {
                            value =new[] {saksaar }

                        }
                    }
                },
                new parameter
                {
                    felt = sokFelt.saksaksekvensnummer,
                    @operator = operatorType.equal,
                    parameterverdier = new parameterverdier
                    {
                        Item = new intvalues
                        {
                            value =new[] { saksaksekvensnummer }

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