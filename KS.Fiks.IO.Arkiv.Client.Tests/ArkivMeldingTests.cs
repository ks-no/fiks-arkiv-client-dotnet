using System;
using KS.Fiks.IO.Arkiv.Client.ForenkletArkivering;
using KS.Fiks.IO.Arkiv.Client.Models.Arkivering.Arkivmelding;
using KS.Fiks.IO.Arkiv.Client.Tests.Validering;
using NUnit.Framework;
using Part = KS.Fiks.IO.Arkiv.Client.Models.Arkivering.Arkivmelding.Part;
using Registrering = KS.Fiks.IO.Arkiv.Client.Models.Arkivering.Arkivmelding.Registrering;

namespace KS.Fiks.IO.Arkiv.Client.Tests
{
    public class ArkivMeldingTests
    {
        [Test]
        public void ArkivMelding_WithPersonId_IsValid()
        {
            var arkivMelding = new Arkivmelding
            {
                System = "system",
                MeldingId = "id",
                Tidspunkt = DateTime.Now,
                AntallFiler = 1,
                Registrering =
                {
                    new Registrering
                    {
                        Part =
                        {
                            new Part
                            {
                                PartNavn = "navn",
                                Personid = new PersonID
                                {
                                    Identifikator = "123456789",
                                    Landkode = "NO"
                                }
                            }
                        },
                        Tittel = "tittel",
                        ReferanseEksternNoekkel = new EksternNoekkel
                        {
                            Fagsystem = "system",
                            Noekkel = "noekkel"
                        }
                    }
                }
            };
            var serialized = ArkivmeldingSerializeHelper.Serialize(arkivMelding);
            Assert.True(Validator.IsValidArkivmeldingXml(serialized));
        }
        
        [Test]
        public void ArkivMelding_WithOrganisationId_IsValid()
        {
            var arkivMelding = new Arkivmelding
            {
                System = "system",
                MeldingId = "id",
                Tidspunkt = DateTime.Now,
                AntallFiler = 1,
                Registrering =
                {
                    new Registrering
                    {
                        Part =
                        {
                            new Part
                            {
                                PartNavn = "navn",
                                Organisasjonid = "0192:123456789"
                            }
                        },
                        Tittel = "tittel",
                        ReferanseEksternNoekkel = new EksternNoekkel
                        {
                            Fagsystem = "system",
                            Noekkel = "noekkel"
                        }
                    }
                }
            };
            var serialized = ArkivmeldingSerializeHelper.Serialize(arkivMelding);
            Assert.True(Validator.IsValidArkivmeldingXml(serialized));
        }
        
        [Test]
        public void ArkivMelding_WithPersonIdAndOrganisationId_IsInvalid()
        {
            var arkivMelding = new Arkivmelding
            {
                System = "system",
                MeldingId = "id",
                Tidspunkt = DateTime.Now,
                AntallFiler = 1,
                Registrering =
                {
                    new Registrering
                    {
                        Part =
                        {
                            new Part
                            {
                                PartNavn = "navn",
                                Personid = new PersonID
                                {
                                    Identifikator = "123456789",
                                    Landkode = "NO"
                                },
                                Organisasjonid = "0192:123456789"
                            }
                        },
                        Tittel = "tittel",
                        ReferanseEksternNoekkel = new EksternNoekkel
                        {
                            Fagsystem = "system",
                            Noekkel = "noekkel"
                        }
                    }
                }
            };
            var serialized = ArkivmeldingSerializeHelper.Serialize(arkivMelding);
            Assert.False(Validator.IsValidArkivmeldingXml(serialized));
        }
    }
}