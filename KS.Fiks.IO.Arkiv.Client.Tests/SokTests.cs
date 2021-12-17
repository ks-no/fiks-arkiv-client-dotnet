using System;
using System.Collections.Generic;
using System.Globalization;
using KS.Fiks.IO.Arkiv.Client.ForenkletArkivering;
using KS.Fiks.IO.Arkiv.Client.Models.Innsyn.Sok;
using KS.Fiks.IO.Arkiv.Client.Sample;
using NUnit.Framework;

namespace KS.Fiks.IO.Arkiv.Client.Tests
{
    public class SokTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestSok()
        {
            var arkivmeldingsok = MessageSamples.SokTittel("tittel*");
            var payload = ArkivmeldingSerializeHelper.Serialize(arkivmeldingsok);

            Assert.Pass();
        }

        [Test]
        public void TestSokFlereFelt()
        {
            var arkivmeldingsok = new Sok
            {
                Respons = Respons.Mappe,
                MeldingId = Guid.NewGuid().ToString(),
                System = "Fagsystem X",
                Tidspunkt = DateTime.Now,
                Skip = 0,
                Take = 100
            };

            arkivmeldingsok.Parameter.Add(
                new Parameter
                {
                    Felt = SokFelt.MappePeriodTittel,
                    Operator = OperatorType.Equal,
                    Parameterverdier = new Parameterverdier
                    {
                        Stringvalues = { "tittel*" }
                    }
                });
            
            arkivmeldingsok.Parameter.Add(
                new Parameter
                {
                    Felt = SokFelt.MappePeriodOpprettetDato,
                    Operator = OperatorType.Equal,
                    Parameterverdier = new Parameterverdier
                    {
                        Datevalues = { DateTime.ParseExact("2009-05-08", "yyyy-MM-dd", CultureInfo.InvariantCulture) }
                    }
                });
            
            var payload = ArkivmeldingSerializeHelper.Serialize(arkivmeldingsok);

            Assert.Pass();
        }

        [Test]
        public void TestSokDato()
        {
            var arkivmeldingsok = new Sok
            {
                Respons = Respons.Journalpost,
                MeldingId = Guid.NewGuid().ToString(),
                System = "Fagsystem X",
                Tidspunkt = DateTime.Now,
                Skip = 0,
                Take = 100
            };

            arkivmeldingsok.Parameter.Add(
                new Parameter
                {
                    Felt = SokFelt.JournalpostPeriodJournaldato,
                    Operator = OperatorType.Between,
                    Parameterverdier = new Parameterverdier
                    {
                        Datevalues =
                        {
                            DateTime.ParseExact("2009-05-08", "yyyy-MM-dd",
                                CultureInfo.InvariantCulture),
                            DateTime.ParseExact("2009-05-09", "yyyy-MM-dd",
                                CultureInfo.InvariantCulture)
                        }
                    }
                });
            
            var payload = ArkivmeldingSerializeHelper.Serialize(arkivmeldingsok);

            Assert.Pass();
        }


        [Test]
        public void TestSokEksternId()
        {
            var arkivmeldingsok = new Sok
            {
                Respons = Respons.Journalpost,
                MeldingId = Guid.NewGuid().ToString(),
                System = "Fagsystem X",
                Tidspunkt = DateTime.Now,
                Skip = 0,
                Take = 100
            };

            arkivmeldingsok.Parameter.Add(
                new Parameter
                {
                    Felt = SokFelt.RegistreringPeriodEksternId,
                    Operator = OperatorType.Equal,
                    Parameterverdier = new Parameterverdier
                    {
                        EksternId = new EksternId
                        {
                            System = "SikriElements",
                            Id = "85295a5e-6415-410c-8a2c-5b368f1ed06c"
                        }
                    }
                });

            var payload = ArkivmeldingSerializeHelper.Serialize(arkivmeldingsok);

            Assert.Pass();
        }

        [Test]
        public void TestSokKlassifikasjon()
        {
            var arkivmeldingsok = new Sok
            {
                Respons = Respons.Mappe,
                MeldingId = Guid.NewGuid().ToString(),
                System = "Fagsystem X",
                Tidspunkt = DateTime.Now,
                Skip = 0,
                Take = 100
            };

            arkivmeldingsok.Parameter.Add(
                new Parameter
                {
                    Felt = SokFelt.MappePeriodTittel,
                    Operator = OperatorType.Equal,
                    Parameterverdier = new Parameterverdier
                    {
                        Klassifikasjonvalues = new Klassifikasjonvalues
                        {
                            Klassifikasjonssystem = { "GBNR" },
                            Klasse = { "21/400" }
                        }
                    }
                });
            
            var payload = ArkivmeldingSerializeHelper.Serialize(arkivmeldingsok);

            Assert.Pass();
        }


        [Test]
        public void TestSøkVsm()
        {
            var arkivmeldingsok = new Sok
            {
                Respons = Respons.Mappe,
                MeldingId = Guid.NewGuid().ToString(),
                System = "Fagsystem X",
                Tidspunkt = DateTime.Now,
                Skip = 0,
                Take = 100
            };

            arkivmeldingsok.Parameter.Add(
                new Parameter
                {
                    Felt = SokFelt.MappePeriodVirksomhetsspesifikkeMetadata,
                    Operator = OperatorType.Equal,
                    Parameterverdier = new Parameterverdier
                    {
                        Virksomhetsspesifikkemetadata = new Vsmetadata()
                        {
                            Key = { "Kaffetype" }, Value = { "arabica" }
                        }
                    }
                });
            
            var payload = ArkivmeldingSerializeHelper.Serialize(arkivmeldingsok);

            Assert.Pass();
        }
    }
}
