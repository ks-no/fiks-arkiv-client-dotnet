﻿using System;
using KS.Fiks.IO.Arkiv.Client.ForenkletArkivering;
using KS.Fiks.IO.Arkiv.Client.Models.Arkivering.Arkivmelding;
using KS.Fiks.IO.Arkiv.Client.Models.Innsyn.Sok;
using KS.Fiks.IO.Arkiv.Client.Models.Metadatakatalog;
using NUnit.Framework;
using Dokumentbeskrivelse = KS.Fiks.IO.Arkiv.Client.Models.Arkivering.Arkivmelding.Dokumentbeskrivelse;
using Dokumentobjekt = KS.Fiks.IO.Arkiv.Client.Models.Arkivering.Arkivmelding.Dokumentobjekt;
using EksternNoekkel = KS.Fiks.IO.Arkiv.Client.Models.Arkivering.Arkivmelding.EksternNoekkel;
using Journalpost = KS.Fiks.IO.Arkiv.Client.Models.Arkivering.Arkivmelding.Journalpost;
using Korrespondansepart = KS.Fiks.IO.Arkiv.Client.Models.Arkivering.Arkivmelding.Korrespondansepart;
using Merknad = KS.Fiks.IO.Arkiv.Client.Models.Arkivering.Arkivmelding.Merknad;
using Part = KS.Fiks.IO.Arkiv.Client.Models.Arkivering.Arkivmelding.Part;
using Saksmappe = KS.Fiks.IO.Arkiv.Client.Models.Arkivering.Arkivmelding.Saksmappe;
using Skjerming = KS.Fiks.IO.Arkiv.Client.Models.Arkivering.Arkivmelding.Skjerming;

namespace KS.Fiks.IO.Arkiv.Client.Tests.Brukerhistorier
{
    class Brukerhistorie5ArkiverEbyggesakTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestEbyggesak()
        {
            // Name of system (eksternsystem)
            var ekstsys = "eByggesak";
            // Saksid in eByggesak
            var saksid = "123";

            // Finnes det sak fra før?
            var finnSak = new Sok
            {
                Respons = Respons.Mappe,
                MeldingId = Guid.NewGuid().ToString(),
                System = "eByggesak",
                Tidspunkt = DateTime.Now,
                Skip = 0,
                Take = 2
            };

            finnSak.Parameter.Add(
            new Parameter
                {
                    Felt = SokFelt.MappePeriodEksternId,
                    Operator = OperatorType.Equal,
                    Parameterverdier = new Parameterverdier
                    {
                        Stringvalues = { ekstsys, saksid }
                    }
                });

            var payload = ArkivmeldingSerializeHelper.Serialize(finnSak);
            Assert.True(Validator.IsValidSokXml(payload), "Validation errors");

            // Check if there was a case
            string systemid = null;

            //TODO Hva i alle dager er egentlig meningen her? Den vil jo alltid være null?
            // Det fantes ikke sak, lag
            if (systemid == null)
            {
                var gnr = new Klassifikasjon()
                {
                    KlasseID = "1234-12/1234",
                    Klassifikasjonssystem = "GNR"
                };
                // TODO: Mange manglende felt vs. GI 1.1
                var saksmappe = new Saksmappe
                {
                    Tittel = "Byggesak 123",
                    OffentligTittel = "Byggesak 123",
                    AdministrativEnhet = "Byggesaksavdelingen",
                    Saksansvarlig = "Byggesaksbehandler",
                    Saksdato = new DateTime(),
                    Saksstatus = new Saksstatus()
                    {
                        Verdi = "B"
                    },
                    Dokumentmedium = new Dokumentmedium()
                    {
                        Verdi = "elektronisk",
                        Beskrivelse = "" //TOOD
                    }, 
                    Journalenhet = "BYG",
                    // arkivdel = "BYGG", // Mangler og bør være kodeobjekt
                    ReferanseArkivdel = { "BYGG" },  // Dette er ikke tilhører arkivdel, men arkivdeler som er relatert!
                    // mappetype = new Kode
                    // { kodeverdi = "Saksmappe"}, // Standardiseres? Gitt av spesialiseringen?
                    Klassifikasjon = { gnr },
                    Part = 
                    {
                        new Part
                        {
                            PartNavn = "Fr Tiltakshaver"    // navn som for korrespondansepart?
                        }
                    },
                    Merknad = 
                    {
                        new Merknad
                        {
                            Merknadstype = new Merknadstype()
                            {
                                Verdi = "BYGG",
                                Beskrivelse = "", //TODO
                            },  // Kode?
                            Merknadstekst = "Saksnummer 20/123 i eByggesak"
                        }
                    },
                    // matrikkelnummer
                    // punkt
                    // bevaringstid
                    // kassasjonsvedtak
                    Skjerming = new Skjerming
                    {
                        Tilgangsrestriksjon = new Tilgangsrestriksjon()
                        {
                            Verdi = "13",
                            Beskrivelse = "" //TOOD
                        }, // Settes av server?
                        Skjermingshjemmel = "Ofl § 13, fvl § 123",
                        SkjermingMetadata = { new SkjermingMetadata()
                        {
                            Verdi = "tittel",
                            Beskrivelse = ""
                        }} //TODO Her må det være kodeverk
                    },
                    // prosjekt
                    // tilgangsgruppe
                    ReferanseEksternNoekkel = new EksternNoekkel
                    {
                        Fagsystem = ekstsys,
                        Noekkel = saksid
                    }
                };
                // payload = Arkivintegrasjon.Serialize(saksmappe);

                systemid = "12345"; // Nøkkel fra arkivering av saksmappen / søk
            }

            // Overfør nye journalposter
            // Løkke som går gjennom både I, U og X (og S), eksempler her

            // Inngående
            var inn = new Journalpost() // Beholde objekttyper for inn-, ut- etc.?
            {
                // Saksår
                // Sakssekvensnummer
                // referanseForelderMappe = "", // Ligger i xsd...
                Journalposttype = new Journalposttype()
                {
                    Verdi = "I",
                    Beskrivelse = ""
                }, //TODO Kodeobjekt?
                Journalstatus = new Journalstatus()
                {
                    Verdi = "J",
                    Beskrivelse = ""
                }, //TODO Kodeobjekt?
                DokumentetsDato = new DateTime(),
                Journaldato = new DateTime(),
                Forfallsdato = new DateTime(),
                Korrespondansepart =
                {
                    new Korrespondansepart
                    {
                        Korrespondanseparttype = new Korrespondanseparttype()
                        {
                            Verdi = "avsender",
                            Beskrivelse = ""
                        }, //TODO Kode?
                        Organisasjonid = "123456789",
                        KorrespondansepartNavn = "Testesen",
                        Postadresse = { "c/o Hei og hå", "Testveien 3" },
                        Postnummer = "1234",
                        Poststed = "Poststed",
                    },
                    new Korrespondansepart
                    {
                        Korrespondanseparttype = new Korrespondanseparttype()
                        {
                            Verdi = "kopimottager",
                            Beskrivelse = ""
                        }, //TODO Kode?
                        Personid = "12345612345",
                        KorrespondansepartNavn = "Advokat NN", // Hvordan skille person og organisasjon?
                        Postadresse = { "Krøsusveien 3" },
                        Postnummer = "2345",
                        Poststed = "Poststedet",
                    },
                    new Korrespondansepart
                    {
                        Saksbehandler = "SBBYGG",
                        AdministrativEnhet = "BYGG"
                    }
                },
                Merknad =
                {
                    new Merknad()
                    {
                        Merknadstype = new Merknadstype()
                        {
                            Verdi = "BYGG",
                            Beskrivelse = ""
                        }, //TODO Kode?
                        Merknadstekst = "Journalpostnummer 20/123-5 i eByggesak"
                    }
                },
                ReferanseEksternNoekkel = new EksternNoekkel
                {
                    Fagsystem = "eByggesak",
                    Noekkel = "20/1234-12"
                },
                Tittel = "Søknad om rammetillatelse 12/123",
                OffentligTittel = "Søknad om rammetillatelse 12/123",
                Skjerming = new Skjerming
                {
                    Tilgangsrestriksjon = new Tilgangsrestriksjon()
                    {
                        Verdi = "13",
                        Beskrivelse = ""
                    },
                    Skjermingshjemmel = "Off.loven § 13",
                    Skjermingsvarighet = "60" // Antall år bør ikke være string
                },
                // Dokumenter
                Dokumentbeskrivelse =
                {
                    new Dokumentbeskrivelse
                    {
                        TilknyttetRegistreringSom = new TilknyttetRegistreringSom()
                        {
                            Verdi = "H",
                            Beskrivelse = ""
                        }, //TODO Kodeobjekt?
                        Dokumentnummer = "1", // Tallfelt!
                        Dokumenttype = new Dokumenttype()
                        {
                            Verdi = "SØKNAD",
                            Beskrivelse = ""
                        }, //TODO Kodeobjekt?
                        Dokumentstatus = new Dokumentstatus()
                        {
                            Verdi = "F",
                            Beskrivelse = "",
                        }, //TODO Kodeobjekt?
                        Tittel = "Søknad om rammetillatelse",
                        Dokumentobjekt =
                        {
                            new Dokumentobjekt
                            {
                                Versjonsnummer = "1", // Tallfelt!
                                Variantformat = new Variantformat()
                                {
                                    Verdi = "A",
                                    Beskrivelse = ""
                                }, //TODO Kodefelt?
                                Format = new Format()
                                {
                                    Verdi = "PDF",
                                    Beskrivelse = ""
                                }, //TODO Arkade ønsker filtypen her...
                                MimeType = "application/pdf",
                                ReferanseDokumentfil = "https://ebyggesak.no/hentFil?id=12345&token=67890"
                            }
                        }
                    },
                    new Dokumentbeskrivelse
                    {
                        TilknyttetRegistreringSom = new TilknyttetRegistreringSom()
                        {
                            Verdi = "V",
                            Beskrivelse = ""
                        }, //TODO Kodeobjekt?
                        Dokumentnummer = "2", // Tallfelt!
                        Dokumenttype = new Dokumenttype()
                        {
                            Verdi = "KART",
                            Beskrivelse = "",
                        }, //TODO Kodeobjekt?
                        Dokumentstatus = new Dokumentstatus()
                        {
                            Verdi = "F",
                            Beskrivelse = ""
                        }, //TODO Kodeobjekt?
                        Tittel = "Situasjonskart",
                        Dokumentobjekt =
                        {
                            new Dokumentobjekt
                            {
                                Versjonsnummer = "1", // Tallfelt!
                                Variantformat = new Variantformat()
                                {
                                    Verdi = "A",
                                    Beskrivelse = ""
                                }, //TODO Kodefelt?
                                Format = new Format()
                                {
                                    Verdi = "PDF",
                                    Beskrivelse = ""
                                }, // Arkade ønsker filtypen her...
                                MimeType = "application/pdf",
                                ReferanseDokumentfil = "https://ebyggesak.no/hentFil?id=12345&token=67890"
                            }
                        }
                    },
                    new Dokumentbeskrivelse
                    {
                        TilknyttetRegistreringSom = new TilknyttetRegistreringSom()
                        {
                            Verdi = "V",
                            Beskrivelse = "",
                        }, //TODO Kodeobjekt?
                        Dokumentnummer = "3", // Tallfelt!
                        Dokumenttype = new Dokumenttype()
                        {
                            Verdi = "TEGNING",
                            Beskrivelse = ""
                        }, //TODO Kodeobjekt?
                        Dokumentstatus = new Dokumentstatus()
                        {
                            Verdi = "F",
                            Beskrivelse = ""
                        }, //TODO Kodeobjekt?
                        Tittel = "Fasade",
                        Dokumentobjekt =
                        {
                            new Dokumentobjekt
                            {
                                Versjonsnummer = "1", // Tallfelt!
                                Variantformat = new Variantformat()
                                {
                                    Verdi = "A",
                                    Beskrivelse = ""
                                }, //TODO Kodefelt?
                                Format = new Format()
                                {
                                    Verdi = "PDF",
                                    Beskrivelse = ""
                                }, // Arkade ønsker filtypen her...
                                MimeType = "application/pdf",
                                ReferanseDokumentfil = "https://ebyggesak.no/hentFil?id=12345&token=67890"
                            }
                        }
                    }
                }
            };
            
            //TODO Denne testen gjør ingenting for øyeblikket
            
            // Arkivere...

            // Gjenta for utgående

            // Gjenta for notater

            // Gjenta for saksfremlegg

            Assert.Pass();
        }
    }
}
