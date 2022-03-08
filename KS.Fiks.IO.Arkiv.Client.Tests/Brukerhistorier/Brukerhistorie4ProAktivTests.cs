using System;
using System.Collections.Generic;
using KS.Fiks.IO.Arkiv.Client.ForenkletArkivering;
using KS.Fiks.IO.Arkiv.Client.Models.Arkivstruktur;
using KS.Fiks.IO.Arkiv.Client.Models.Innsyn.Sok;
using NUnit.Framework;

namespace KS.Fiks.IO.Arkiv.Client.Tests.Brukerhistorier
{
    class Brukerhistorie4ProAktivTests
    {
        [SetUp]
        public void Setup()
        {
        }
        
        // Bruker en ekisterende sak dersom det finnes en sak av rett type hvis ikke opprettes ny sak
        [Test]
        public void TestNyttDokumentBrukEksisterendeSak()
        {
            var saker = FinnSakerMedMatrikkelnummer("21/400");
       
            SaksmappeForenklet sak = null;

            if (sak == null)
            {
                sak = OpprettNySak();
            }

            var jp = OpprettJournalpostMedDokument(sak);
            //TODO hva skal testes her?
            Assert.Pass();
        }
       
        private object OpprettJournalpostMedDokument(SaksmappeForenklet saksmappeForenklet)
        {
            //Fagsystem definerer ønsket struktur
            var utg = new ArkivmeldingForenkletUtgaaende
            {
                sluttbrukerIdentifikator = "ABC",
                nyUtgaaendeJournalpost = new UtgaaendeJournalpost(),
                referanseSaksmappeForenklet = saksmappeForenklet
            };

            utg.nyUtgaaendeJournalpost.tittel = "Vedtak etter tilsyn";
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
                    personid = new Personidentifikator() { personidentifikatorLandkode = "NO",  personidentifikatorNr = "12345678901"},
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
                filnavn = "vedtak.pdf",
                referanseDokumentFil = "/en/path"
            };

            //Konverterer til arkivmelding xml
            var arkivmelding = ArkivmeldingFactory.GetArkivmelding(utg);
            var payload = ArkivmeldingSerializeHelper.Serialize(arkivmelding);
            
            Assert.True(Validator.IsValidArkivmeldingXml(payload), "Validation errors");
            
            //TODO Dette gir ikke mening? Hva skal returneres her? Payload?
            return null;
        }

        private SaksmappeForenklet OpprettNySak()
        {
            var utg = new SaksmappeForenklet
            {
                tittel = "Tilsyn eiendom 21/400"
            };

            return utg;
        }

        private SaksmappeForenklet[] FinnSakerMedMatrikkelnummer(string matrikkelnummer)
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
                    Felt = SokFelt.MappePeriodTittel, // Aba kan dette være rett?
                    Operator = OperatorType.Equal,
                    Parameterverdier = new Parameterverdier
                    {
                        Klassifikasjonvalues = new Klassifikasjonvalues
                        {
                            Klassifikasjonssystem = { "GBNR" },
                            Klasse = { matrikkelnummer }
                        }
                    }
                });
            
            var payload = ArkivmeldingSerializeHelper.Serialize(arkivmeldingsok);
            
            //TODO returner saker? Det gir ikke mening å returnere null!
            return null;
        }
    }
}
