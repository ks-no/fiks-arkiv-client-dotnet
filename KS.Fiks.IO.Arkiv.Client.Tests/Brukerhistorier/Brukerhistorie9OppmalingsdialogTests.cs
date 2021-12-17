using System;
using System.Collections.Generic;
using KS.Fiks.IO.Arkiv.Client.ForenkletArkivering;
using KS.Fiks.IO.Arkiv.Client.Models.Arkivstruktur;
using KS.Fiks.IO.Arkiv.Client.Models.Innsyn.Sok;
using NUnit.Framework;

namespace KS.Fiks.IO.Arkiv.Client.Tests.Brukerhistorier
{
    class Brukerhistorie9OppmalingsdialogTests
    {
        [SetUp]
        public void Setup()
        {
        }

        // bruker skal legge inn et dokument på en journalpost med et gitt navn. Dersom journalposten finnes skal den brukes hvis ikke skal det opprettes en ny post
        [Test]
        public void LeggTilNotatPaJournalpost()
        {
            var saksaar = 2020;
            var saksaksekvensnummer = 123;
            var jpnavn = "Dokumentasjon 22/3";

            var sak = FinnSak(saksaar, saksaksekvensnummer);
            var jp = FinnJp(saksaar, saksaksekvensnummer, jpnavn);

            if(jp == null)
            {
                OpprettJournalpostMedDokument(sak, jpnavn);
            }
            else
            {
                //TODO Hva er dette?
                //er ikke dette lov?
                LeggDokumentPaJournalpost();
            }

            Assert.Pass();
        }

        private void LeggDokumentPaJournalpost()
        {
          
        }

        private void OpprettJournalpostMedDokument(SaksmappeForenklet mappe, string tittel)
        {
            //var messageRequest = new MeldingRequest(
            //                         mottakerKontoId: receiverId,
            //                         avsenderKontoId: senderId,
            //                         meldingType: "no.geointegrasjon.arkiv.oppdatering.arkivmeldingforenkletUtgaaende.v1"); // Message type as string
            //                                                                                                                //Se oversikt over meldingstyper på https://github.com/ks-no/fiks-io-meldingstype-katalog/tree/test/schema

            //Fagsystem definerer ønsket struktur
            var utg = new ArkivmeldingForenkletUtgaaende
            {
                sluttbrukerIdentifikator = "ABC",
                nyUtgaaendeJournalpost = new UtgaaendeJournalpost()
            };

            utg.referanseSaksmappeForenklet = mappe;
            utg.nyUtgaaendeJournalpost.tittel = tittel;
            utg.nyUtgaaendeJournalpost.referanseEksternNoekkelForenklet = new EksternNoekkelForenklet
            {
                fagsystem = "Fagsystem X",
                noekkel = new Guid().ToString()
            };

            utg.nyUtgaaendeJournalpost.internAvsender = new List<KorrespondansepartIntern>
            {
                new KorrespondansepartIntern() {
                    saksbehandler = "Birger Brannmann",
                    referanseSaksbehandler = "60577438-1f97-4c5f-b254-aa758c8786c4"
                }
            };

            utg.nyUtgaaendeJournalpost.mottaker = new List<KorrespondansepartForenklet>
            {
                new KorrespondansepartForenklet() {
                    navn = "Mons Mottaker",
                    personid = new Personidentifikator() { personidentifikatorType = "F",  personidentifikatorNr = "12345678901"},
                    postadresse = new EnkelAdresse() {
                        adresselinje1 = "Gate 1",
                        adresselinje2 = "Andre adresselinje",
                        adresselinje3 = "Tredje adresselinje",
                        postnr = "3801",
                        poststed = "Bø" },
                    forsendelsemåte = "SvarUt"
                }
            };

            utg.nyUtgaaendeJournalpost.hoveddokument = new ForenkletDokument
            {
                tittel = "Vedtak",
                filnavn = "vedtak.pdf"
            };

            //Konverterer til arkivmelding xml
            var arkivmelding = ArkivmeldingFactory.GetArkivmelding(utg);
            var payload = ArkivmeldingSerializeHelper.Serialize(arkivmelding);
            if (!Validator.IsValidArkivmeldingXml(payload))
            {
                Assert.Fail("Validation errors");
            }
        }

        public SaksmappeForenklet FinnSak(int saksaar, int saksaksekvensnummer)
        {
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

            return new SaksmappeForenklet();
        }

        private Journalpost FinnJp(int saksaar, int saksaksekvensnummer, string journalpostTittel)
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

            arkivmeldingsok.Parameter.Add(
                new Parameter
                {
                    Felt = SokFelt.RegistreringPeriodTittel,
                    Operator = OperatorType.Equal,
                    Parameterverdier = new Parameterverdier
                    {
                        Stringvalues = { journalpostTittel }
                    }
                });
            
            var payload = ArkivmeldingSerializeHelper.Serialize(arkivmeldingsok);
            
            if (!Validator.IsValidSokXml(payload))
            {
                Assert.Fail("Validation errors");
            }

            return new Journalpost();
        }
    }
}