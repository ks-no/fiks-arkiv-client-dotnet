using System;
using System.Collections.Generic;
using KS.Fiks.IO.Arkiv.Client.ForenkletArkivering;
using KS.Fiks.IO.Arkiv.Client.Models.Innsyn.Sok;

namespace KS.Fiks.IO.Arkiv.Client.Sample
{
    /// <summary>
    /// Felles bibliotek for å hente ut predefinert meldinger
    /// </summary>
    public class MessageSamples
    {
        public static ArkivmeldingForenkletInnkommende GetForenkletArkivmeldingInngåendeMedSaksreferanse()
        {
            //Fagsystem definerer ønsket struktur
            ArkivmeldingForenkletInnkommende inng = new ArkivmeldingForenkletInnkommende();
            inng.sluttbrukerIdentifikator = "Fagsystemets brukerid";

            inng.referanseSaksmappeForenklet = new SaksmappeForenklet()
            {
                saksaar = 2018,
                sakssekvensnummer = 123456
            };

            inng.nyInnkommendeJournalpost = new InnkommendeJournalpost
            {
                tittel = "Tittel journalpost",
                mottattDato = DateTime.Today,
                dokumentetsDato = DateTime.Today.AddDays(-2),
                offentlighetsvurdertDato = DateTime.Today,
            };

            inng.nyInnkommendeJournalpost.referanseEksternNoekkelForenklet = new EksternNoekkelForenklet
            {
                fagsystem = "Fagsystem X",
                noekkel = "e4712424-883c-4068-9cb7-97ac679d7232"
            };

            inng.nyInnkommendeJournalpost.internMottaker = new List<KorrespondansepartIntern>
            {
                new KorrespondansepartIntern() {
                    administrativEnhet = "Oppmålingsetaten",
                    referanseAdministrativEnhet = "b631f24b-48fb-4b5c-838e-6a1f7d56fae2"
                }
            };

            inng.nyInnkommendeJournalpost.mottaker = new List<KorrespondansepartForenklet>
            {
                new KorrespondansepartForenklet() {
                    navn = "Test kommune",
                    enhetsidentifikator = new Enhetsidentifikator() {
                        organisasjonsnummer = "123456789"
                    },
                    postadresse = new EnkelAdresse() {
                        adresselinje1 = "Oppmålingsetaten",
                        adresselinje2 = "Rådhusgate 1",
                        postnr = "3801",
                        poststed = "Bø"
                    }
                }
            };


            inng.nyInnkommendeJournalpost.avsender = new List<KorrespondansepartForenklet>
            {
                new KorrespondansepartForenklet() {
                    navn = "Anita Avsender",
                    personid = new Personidentifikator() { personidentifikatorLandkode = "NO",  personidentifikatorNr = "12345678901"},
                    postadresse = new EnkelAdresse() {
                        adresselinje1 = "Gate 1",
                        postnr = "3801",
                        poststed = "Bø" }
                }
            };


            inng.nyInnkommendeJournalpost.hoveddokument = new ForenkletDokument
            {
                tittel = "Rekvisisjon av oppmålingsforretning",
                filnavn = "rekvisisjon.pdf"
            };

            inng.nyInnkommendeJournalpost.vedlegg = new List<ForenkletDokument>
            {
                new ForenkletDokument(){
                    tittel = "Vedlegg 1",
                    filnavn = "vedlegg.pdf"
                }
            };
           
            return inng;
        }

        public static OppdaterSaksmappe GetOppdaterSaksmappeAnsvarligPaaFagsystemnoekkel(string fagsystem, string nøkkel, string saksansvarlig, string idSaksansvarlig)
        {
            var saksmappe = new OppdaterSaksmappe
            {
                oppdaterSaksmappeForenklet = new SaksmappeForenklet()
                {
                    saksansvarlig = saksansvarlig,
                    referanseSaksansvarlig = idSaksansvarlig,
                    referanseEksternNoekkelForenklet = new EksternNoekkelForenklet
                    {
                        fagsystem = fagsystem,
                        noekkel = nøkkel
                    }
                }
            };
            
            
            return saksmappe;
        }

        public static OppdaterSaksmappe GetOppdaterSaksmappeAnsvarligPaaSaksnummer(int saksaar, int sekvensnr, string saksansvarlig, string idSaksansvarlig)
        {
            var saksmappe = new OppdaterSaksmappe();

            saksmappe.oppdaterSaksmappeForenklet = new SaksmappeForenklet
            {
                saksaar = saksaar,
                sakssekvensnummer = sekvensnr,
                saksansvarlig = saksansvarlig,
                referanseSaksansvarlig = idSaksansvarlig
            };

            return saksmappe;
        }

        public static Sok SokTittel(string tittel)
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

            var parameter = new Parameter
            {
                Felt = SokFelt.MappePeriodTittel,
                Operator = OperatorType.Equal,
                Parameterverdier = new Parameterverdier
                {
                    Stringvalues = { tittel }
                }
            };

            arkivmeldingsok.Parameter.Add(parameter);
            return arkivmeldingsok;
        }

        public static string GetOppdaterJournalpostAnsvarlig() {



            return "";
        }

    }
}
