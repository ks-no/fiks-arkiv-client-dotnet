using System;
using System.Collections.Generic;
using System.Globalization;
using KS.Fiks.IO.Arkiv.Client.ForenkletArkivering;
using KS.Fiks.IO.Arkiv.Client.Sample;
using no.ks.fiks.io.arkivmelding.sok;
using Xunit;

namespace KS.Fiks.IO.Arkiv.Client.Tests
{
    public class SokTests
    {
  
        [Fact]
        public void TestSok()
        {
            var arkivmeldingsok = MessageSamples.SokTittel("tittel*");
            var payload = ArkivmeldingSerializeHelper.Serialize(arkivmeldingsok);

            
        }

        [Fact]
        public void TestSokFlereFelt()
        {
            var arkivmeldingsok = new sok
            {
                respons = respons_type.mappe,
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
                    felt = field_type.mappetittel,
                    @operator = operator_type.equal,
                    parameterverdier = new parameterverdier
                    {
                        Item = new stringvalues {value = new[] {"tittel*"}}
                    }
                },
                new parameter
                {
                    felt = field_type.mappeopprettetDato,
                    @operator = operator_type.equal,
                    parameterverdier = new parameterverdier
                    {
                        Item = new datevalues
                        {
                            value = new[]
                            {
                                DateTime.ParseExact("2009-05-08", "yyyy-MM-dd", CultureInfo.InvariantCulture)
                            }
                        }
                    }
                }
            };

            arkivmeldingsok.parameter = paramlist.ToArray();
            var payload = ArkivmeldingSerializeHelper.Serialize(arkivmeldingsok);

            
        }

        [Fact]
        public void TestSokDato()
        {
            var arkivmeldingsok = new sok
            {
                respons = respons_type.journalpost,
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
                    felt = field_type.journalpostjournaldato,
                    @operator = operator_type.between,
                    parameterverdier = new parameterverdier
                    {
                        Item = new datevalues
                        {
                            value = new[]
                            {
                                DateTime.ParseExact("2009-05-08", "yyyy-MM-dd",
                                    CultureInfo.InvariantCulture),
                                DateTime.ParseExact("2009-05-09", "yyyy-MM-dd",
                                    CultureInfo.InvariantCulture)
                            }
                        }
                    }
                }
            };

            arkivmeldingsok.parameter = paramlist.ToArray();
            var payload = ArkivmeldingSerializeHelper.Serialize(arkivmeldingsok);

            
        }


        [Fact]
        public void TestSokEksternId()
        {
            var arkivmeldingsok = new sok
            {
                respons = respons_type.journalpost,
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
                    felt = field_type.registreringeksternId,
                    @operator = operator_type.equal,
                    parameterverdier = new parameterverdier
                    {
                        Item = new eksternId
                        {
                            system = "SikriElements",
                            id = "85295a5e-6415-410c-8a2c-5b368f1ed06c"
                        }
                    }
                }
            };

            arkivmeldingsok.parameter = paramlist.ToArray();
            var payload = ArkivmeldingSerializeHelper.Serialize(arkivmeldingsok);

            
        }

        [Fact]
        public void TestSokKlassifikasjon()
        {
            var arkivmeldingsok = new sok
            {
                respons = respons_type.mappe,
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
                    felt = field_type.mappetittel,
                    @operator = operator_type.equal,
                    parameterverdier = new parameterverdier
                    {
                        Item = new klassifikasjonvalues
                        {
                            klassifikasjonssystem = new[] {"GBNR"},
                            klasse = new[] {"21/400"}
                        }
                    }
                }
            };

            arkivmeldingsok.parameter = paramlist.ToArray();
            var payload = ArkivmeldingSerializeHelper.Serialize(arkivmeldingsok);

            
        }


        [Fact]
        public void TestSøkVsm()
        {
            var arkivmeldingsok = new sok
            {
                respons = respons_type.mappe,
                meldingId = Guid.NewGuid().ToString(),
                system = "Fagsystem X",
                tidspunkt = DateTime.Now,
                skip = 0,
                take = 100
            };

            List<parameter> paramlist = new List<parameter>
            {
                new parameter
                {
                    felt = field_type.mappevirksomhetsspesifikkeMetadata,
                    @operator = operator_type.equal,
                    parameterverdier = new parameterverdier
                    {
                        Item = new vsmetadata
                        {
                            key = new[] {"Kaffetype"}, value = new[] {"arabica"}
                        }
                    }
                }
            };

            arkivmeldingsok.parameter = paramlist.ToArray();
            var payload = ArkivmeldingSerializeHelper.Serialize(arkivmeldingsok);

            
        }
    }
}
