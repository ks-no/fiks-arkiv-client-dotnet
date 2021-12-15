﻿using System;
 using System.Collections.Generic;
 using no.ks.fiks.io.arkiv;
 using no.ks.fiks.io.arkivmelding.innsyn.sok;
 using NUnit.Framework;

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
            var finnSak = new sok
            {
                respons = respons.mappe,
                meldingId = Guid.NewGuid().ToString(),
                system = "eByggesak",
                tidspunkt = DateTime.Now,
                skip = 0,
                take = 2
            };

            var paramlist = new List<parameter>
                {
                    new parameter
                    {
                        felt = sokFelt.mappeeksternId,
                        @operator = operatorType.equal,
                        parameterverdier = new parameterverdier
                        {
                            Item = new stringvalues {value = new[] {ekstsys, saksid}}
                        }
                    }
                };


            finnSak.parameter = paramlist.ToArray();

            //TODO Hva er dette?
            //var payload = Arkivintegrasjon.Serialize(finnSak);

            // Check if there was a case
            string systemid = null;

            // Det fantes ikke sak, lag
            if (systemid == null)
            {
                var gnr = new klassifikasjon()
                {
                    klasseID = "1234-12/1234",
                    klassifikasjonssystem = "GNR"
                };
                // TODO: Mange manglende felt vs. GI 1.1
                var saksmappe = new saksmappe
                {
                    tittel = "Byggesak 123",
                    offentligTittel = "Byggesak 123",
                    administrativEnhet = "Byggesaksavdelingen",
                    saksansvarlig = "Byggesaksbehandler",
                    saksdato = new DateTime(),
                    saksstatus = "B",
                    dokumentmedium = "elektronisk", // Kode?
                    journalenhet = "BYG",
                    // arkivdel = "BYGG", // Mangler og bør være kodeobjekt
                    referanseArkivdel = new string[] {"BYGG"},  // Dette er ikke tilhører arkivdel, men arkivdeler som er relatert!
                    // mappetype = new Kode
                    // { kodeverdi = "Saksmappe"}, // Standardiseres? Gitt av spesialiseringen?
                    klassifikasjon = new klassifikasjon[] { gnr },
                    part = new part[]
                    {
                        new part
                        {
                            partNavn = "Fr Tiltakshaver"    // navn som for korrespondansepart?
                        }
                    },
                    merknad = new merknad[]
                    {
                        new merknad
                        {
                            merknadstype = "BYGG",  // Kode?
                            merknadstekst = "Saksnummer 20/123 i eByggesak"
                        }
                    },
                    // matrikkelnummer
                    // punkt
                    // bevaringstid
                    // kassasjonsvedtak
                    skjerming = new skjerming
                    {
                        tilgangsrestriksjon = "13", // Settes av server?
                        skjermingshjemmel = "Ofl § 13, fvl § 123",
                        skjermingMetadata = new string[] {"tittel"} // Her må det være kodeverk
                    },
                    // prosjekt
                    // tilgangsgruppe
                    referanseEksternNoekkel = new eksternNoekkel
                    {
                        fagsystem = ekstsys,
                        noekkel = saksid
                    }
                };
                // payload = Arkivintegrasjon.Serialize(saksmappe);

                systemid = "12345"; // Nøkkel fra arkivering av saksmappen / søk
            }

            // Overfør nye journalposter
            // Løkke som går gjennom både I, U og X (og S), eksempler her

            // Inngående
            journalpost inn = new journalpost   // Beholde objekttyper for inn-, ut- etc.?
            {
                // Saksår
                // Sakssekvensnummer
                // referanseForelderMappe = "", // Ligger i xsd...
                journalposttype = "I",  // Kodeobjekt?
                journalstatus = "J",    // Kodeobjekt?
                dokumentetsDato = new DateTime(),
                journaldato = new DateTime(),
                forfallsdato = new DateTime(),
                korrespondansepart = new korrespondansepart[] {
                    new korrespondansepart
                    {
                        korrespondanseparttype = "avsender",    // Kode?
                        Item = "123456789",
                        korrespondansepartNavn = "Testesen",
                        postadresse = new string[] { "c/o Hei og hå", "Testveien 3" },
                        postnummer = "1234",
                        poststed = "Poststed",
                    },
                    new korrespondansepart
                    {
                        korrespondanseparttype = "kopimottager",    // Kode?
                        Item =  "12345612345",
                        korrespondansepartNavn = "Advokat NN",  // Hvordan skille person og organisasjon?
                        postadresse = new string[] { "Krøsusveien 3" },
                        postnummer = "2345",
                        poststed = "Poststedet",
                    },
                    new korrespondansepart
                    {
                        saksbehandler = "SBBYGG",
                        administrativEnhet = "BYGG"
                    }
                },
                merknad = new merknad[]
                    {
                        new merknad
                        {
                            merknadstype = "BYGG",  // Kode?
                            merknadstekst = "Journalpostnummer 20/123-5 i eByggesak"
                        }
                    },
                referanseEksternNoekkel = new eksternNoekkel
                {
                    fagsystem = "eByggesak",
                    noekkel = "20/1234-12"
                },
                tittel = "Søknad om rammetillatelse 12/123",
                offentligTittel = "Søknad om rammetillatelse 12/123",
                skjerming = new skjerming
                {
                   tilgangsrestriksjon = "13",
                    skjermingshjemmel = "Off.loven § 13",
                    skjermingsvarighet = "60"   // Antall år bør ikke være string
                },
                // Dokumenter
                dokumentbeskrivelse = new dokumentbeskrivelse[]
                {
                    new dokumentbeskrivelse
                    {
                        tilknyttetRegistreringSom = "H",    // Kodeobjekt?
                        dokumentnummer = "1",   // Tallfelt!
                        dokumenttype = "SØKNAD",  // Kodeobjekt?
                        dokumentstatus = "F",    // Kodeobjekt?
                        tittel = "Søknad om rammetillatelse",
                        dokumentobjekt = new dokumentobjekt[]
                        {
                            new dokumentobjekt
                            {
                                versjonsnummer = "1",   // Tallfelt!
                                variantformat = "A",    // Kodefelt?
                                format = "PDF",     // Arkade ønsker filtypen her...
                                mimeType = "application/pdf",
                                referanseDokumentfil = "https://ebyggesak.no/hentFil?id=12345&token=67890"
                            }
                        }
                    },
                    new dokumentbeskrivelse
                    {
                        tilknyttetRegistreringSom = "V",    // Kodeobjekt?
                        dokumentnummer = "2",   // Tallfelt!
                        dokumenttype = "KART",  // Kodeobjekt?
                        dokumentstatus = "F",    // Kodeobjekt?
                        tittel = "Situasjonskart",
                        dokumentobjekt = new dokumentobjekt[]
                        {
                            new dokumentobjekt
                            {
                                versjonsnummer = "1",   // Tallfelt!
                                variantformat = "A",    // Kodefelt?
                                format = "PDF",     // Arkade ønsker filtypen her...
                                mimeType = "application/pdf",
                                referanseDokumentfil = "https://ebyggesak.no/hentFil?id=12345&token=67890"
                            }
                        }
                    },
                    new dokumentbeskrivelse
                    {
                        tilknyttetRegistreringSom = "V",    // Kodeobjekt?
                        dokumentnummer = "3",   // Tallfelt!
                        dokumenttype = "TEGNING",  // Kodeobjekt?
                        dokumentstatus = "F",    // Kodeobjekt?
                        tittel = "Fasade",
                        dokumentobjekt = new dokumentobjekt[]
                        {
                            new dokumentobjekt
                            {
                                versjonsnummer = "1",   // Tallfelt!
                                variantformat = "A",    // Kodefelt?
                                format = "PDF",     // Arkade ønsker filtypen her...
                                mimeType = "application/pdf",
                                referanseDokumentfil = "https://ebyggesak.no/hentFil?id=12345&token=67890"
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
