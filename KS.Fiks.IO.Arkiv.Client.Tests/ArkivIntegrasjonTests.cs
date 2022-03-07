﻿using System;
 using System.Collections.Generic;
 using KS.Fiks.IO.Arkiv.Client.ForenkletArkivering;
using KS.Fiks.IO.Arkiv.Client.Models.Arkivering.Arkivmelding;
using KS.Fiks.IO.Arkiv.Client.Models.Metadatakatalog;
using KS.Fiks.IO.Arkiv.Client.Sample;
 using NUnit.Framework;

 namespace KS.Fiks.IO.Arkiv.Client.Tests
{
    public class ArkivintegrasjonTests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void TestOppdaterSaksmappe1()
        {

            var inng = MessageSamples.GetOppdaterSaksmappeAnsvarligPaaSaksnummer(2020,1234,"Testing Testesen", "id343463346"  );

            //Konverterer til arkivmelding xml
            var arkivmelding = ArkivmeldingFactory.GetArkivmelding(inng);
            var payload = ArkivmeldingSerializeHelper.Serialize(arkivmelding);

            Assert.Pass();
        }

        [Test]
        public void TestOppdaterSaksmappe2()
        {

            var inng = MessageSamples.GetOppdaterSaksmappeAnsvarligPaaFagsystemnoekkel("Fagsystem X", "1234", "Testing Testesen", "id343463346");

            //Konverterer til arkivmelding xml
            var arkivmelding = ArkivmeldingFactory.GetArkivmelding(inng);
            var payload = ArkivmeldingSerializeHelper.Serialize(arkivmelding);

            Assert.Pass();
        }


        [Test]
        public void TestSaksmappereferanse()
        {
            
            var inng = MessageSamples.GetForenkletArkivmeldingInngåendeMedSaksreferanse();

            //Konverterer til arkivmelding xml
            var arkivmelding = ArkivmeldingFactory.GetArkivmelding(inng);
            var payload = ArkivmeldingSerializeHelper.Serialize(arkivmelding);

            Assert.Pass();
        }

        [Test]
        public void TestnyInnkommendeJournalpostBrukerhistorie3_1()
        {

            //Fagsystem definerer ønsket struktur
            var inng = new ArkivmeldingForenkletInnkommende();
            inng.sluttbrukerIdentifikator = "9hs2ir";

            inng.referanseSaksmappeForenklet = new SaksmappeForenklet()
            {
                tittel = "Tittel mappe",
                referanseEksternNoekkelForenklet = new EksternNoekkelForenklet
                {
                    fagsystem = "Fagsystem X",
                    noekkel = "e4reke"
                }
            };

            inng.nyInnkommendeJournalpost = new InnkommendeJournalpost
            {
                tittel = "Startlån søknad(Ref=e4reke, SakId=e4reke)",
                mottattDato = DateTime.Today,
                dokumentetsDato = DateTime.Today.AddDays(-2),
                offentlighetsvurdertDato = DateTime.Today
            };

            inng.nyInnkommendeJournalpost.referanseEksternNoekkelForenklet = new EksternNoekkelForenklet
            {
                fagsystem = "Fagsystem X",
                noekkel = "e4reke"
            };

            inng.nyInnkommendeJournalpost.mottaker = new List<KorrespondansepartForenklet>
            {
                new KorrespondansepartForenklet() {
                    navn = "Test kommune",
                    enhetsidentifikator = new Enhetsidentifikator() {
                        organisasjonsnummer = "123456789"
                    },
                    postadresse = new EnkelAdresse() {
                        adresselinje1 = "Startlån avd",
                        adresselinje2 = "Rådhusgate 1",
                        postnr = "3801",
                        poststed = "Bø"
                    }
                }
            };

            inng.nyInnkommendeJournalpost.avsender = new List<KorrespondansepartForenklet>
            {
                new KorrespondansepartForenklet() {
                    navn = "Anita Søker",
                    personid = new Personidentifikator() { personidentifikatorLandkode = "NO",  personidentifikatorNr = "12345678901"},
                    postadresse = new EnkelAdresse() {
                        adresselinje1 = "Gate 1",
                        postnr = "3801",
                        poststed = "Bø" }
                }
            };

            inng.nyInnkommendeJournalpost.hoveddokument = new ForenkletDokument
            {
                tittel = "Søknad om startlån",
                filnavn = "søknad.pdf"
            };

            inng.nyInnkommendeJournalpost.vedlegg = new List<ForenkletDokument>
            {
                new ForenkletDokument(){
                    tittel = "Vedlegg 1",
                    filnavn = "vedlegg.pdf"
                }
            };

            //Konverterer til arkivmelding xml
            var arkivmelding = ArkivmeldingFactory.GetArkivmelding(inng);
            var payload = ArkivmeldingSerializeHelper.Serialize(arkivmelding);

            Assert.Pass();
        }

        [Test]
        public void TestnyInnkommendeJournalpostEttersendingBrukerhistorie3_2()
        {

            //Fagsystem definerer ønsket struktur
            var inng = new ArkivmeldingForenkletInnkommende();
            inng.sluttbrukerIdentifikator = "9hs2ir";

            inng.referanseSaksmappeForenklet = new SaksmappeForenklet()
            {
                referanseEksternNoekkelForenklet = new EksternNoekkelForenklet
                {
                    fagsystem = "Fagsystem X",
                    noekkel = "e4reke"
                }
            };

            inng.nyInnkommendeJournalpost = new InnkommendeJournalpost
            {
                tittel = "Startlån ettersendt vedlegg(Ref=e4reke, SakId=e4reke)",
                mottattDato = DateTime.Today,
                dokumentetsDato = DateTime.Today.AddDays(-2),
                offentlighetsvurdertDato = DateTime.Today
            };

            inng.nyInnkommendeJournalpost.referanseEksternNoekkelForenklet = new EksternNoekkelForenklet
            {
                fagsystem = "Fagsystem X",
                noekkel = "e4reke"
            };

            inng.nyInnkommendeJournalpost.mottaker = new List<KorrespondansepartForenklet>
            {
                new KorrespondansepartForenklet() {
                    navn = "Test kommune",
                    enhetsidentifikator = new Enhetsidentifikator() {
                        organisasjonsnummer = "123456789"
                    },
                    postadresse = new EnkelAdresse() {
                        adresselinje1 = "Startlån avd",
                        adresselinje2 = "Rådhusgate 1",
                        postnr = "3801",
                        poststed = "Bø"
                    }
                }
            };

            inng.nyInnkommendeJournalpost.avsender = new List<KorrespondansepartForenklet>
            {
                new KorrespondansepartForenklet() {
                    navn = "Anita Søker",
                    personid = new Personidentifikator() { personidentifikatorLandkode = "NO",  personidentifikatorNr = "12345678901"},
                    postadresse = new EnkelAdresse() {
                        adresselinje1 = "Gate 1",
                        postnr = "3801",
                        poststed = "Bø" }
                }
            };

            inng.nyInnkommendeJournalpost.hoveddokument = new ForenkletDokument
            {
                tittel = "Beskrivelse av ettersendte vedlegg",
                filnavn = "vedleggbeskrivelse.pdf"
            };

            inng.nyInnkommendeJournalpost.vedlegg = new List<ForenkletDokument>
            {
                new ForenkletDokument(){
                    tittel = "Vedlegg 2",
                    filnavn = "vedlegg.pdf"
                }
            };

            //Konverterer til arkivmelding xml
            var arkivmelding = ArkivmeldingFactory.GetArkivmelding(inng);
            var payload = ArkivmeldingSerializeHelper.Serialize(arkivmelding);

            Assert.Pass();
        }

        [Test]
        public void TestnyUtgaaendeJournalpostBrukerhistorie3_3()
        {
            //var messageRequest = new MeldingRequest(
            //                         mottakerKontoId: receiverId,
            //                         avsenderKontoId: senderId,
            //                         meldingType: "no.geointegrasjon.arkiv.oppdatering.arkivmeldingforenkletUtgaaende.v1"); // Message type as string
            //                                                                                                                //Se oversikt over meldingstyper på https://github.com/ks-no/fiks-io-meldingstype-katalog/tree/test/schema

            //Fagsystem definerer ønsket struktur
            var utg = new ArkivmeldingForenkletUtgaaende
            {
                sluttbrukerIdentifikator = "9hs2ir",
                nyUtgaaendeJournalpost = new UtgaaendeJournalpost()
            };

            utg.referanseSaksmappeForenklet = new SaksmappeForenklet()
            {
                referanseEksternNoekkelForenklet = new EksternNoekkelForenklet
                {
                    fagsystem = "Fagsystem X",
                    noekkel = "e4reke"
                }
            };

            utg.nyUtgaaendeJournalpost.tittel = "Vedtak og vedtaksgrunnlag for vedtaket(Ref=e4reke, SakId=e4reke)";
            utg.nyUtgaaendeJournalpost.referanseEksternNoekkelForenklet = new EksternNoekkelForenklet
            {
                fagsystem = "SvarUt.forsendelseId",
                noekkel = "BBBBBB-BBBB-CCCC-BBBB-BBBBBBBBB"
            };

            utg.nyUtgaaendeJournalpost.internAvsender = new List<KorrespondansepartIntern>
            {
                new KorrespondansepartIntern() {
                    saksbehandler = "Sigve Saksbehandler",
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
                    forsendelsemåte = "SvarUt",
                    deresReferanse = "SvarUt.forsendelseId - BBBBBB-BBBB-CCCC-BBBB-BBBBBBBBBB"
                },
                new KorrespondansepartForenklet() {
                    navn = "Foretak Mottaker",
                    enhetsidentifikator = new Enhetsidentifikator() {
                        organisasjonsnummer = "123456789"
                    },
                    kontaktperson = "Kris Kontakt",
                    postadresse = new EnkelAdresse() {
                        adresselinje1 = "Forretningsgate 1",
                        postnr = "3801",
                        poststed = "Bø" },
                    forsendelsemåte = "SvarUt",
                    deresReferanse = "SvarUt.forsendelseId - AAAAAAA-AAAA-AAAA-AAAA-AAAAAAAAAAAA"
                }
            };

            utg.nyUtgaaendeJournalpost.hoveddokument = new ForenkletDokument
            {
                tittel = "Vedtak om startlån",
                filnavn = "vedtak.pdf"
            };

            utg.nyUtgaaendeJournalpost.vedlegg = new List<ForenkletDokument>
            {
                new ForenkletDokument
                {
                    tittel = "Vedlegg 1",
                    filnavn = "vedlegg.pdf"
                }
            };

            //osv...

            //Konverterer til arkivmelding xml
            var arkivmelding = ArkivmeldingFactory.GetArkivmelding(utg);
            var payload = ArkivmeldingSerializeHelper.Serialize(arkivmelding);

            ////Lager FIKS IO melding
            //List<IPayload> payloads = new List<IPayload>();
            //payloads.Add(new StringPayload(payload, "utgaaendejournalpost.xml"));
            //payloads.Add(new FilePayload(@"samples\vedtak.pdf"));
            //payloads.Add(new FilePayload(@"samples\vedlegg.pdf"));

            ////Sender til FIKS IO (arkiv løsning)
            //var msg = client.Send(messageRequest, payloads).Result;

            Assert.Pass();
        }

        [Test]
        public void TestnyttNotatBrukerhistorie3_4()
        {
            //var messageRequest = new MeldingRequest(
            //                         mottakerKontoId: receiverId,
            //                         avsenderKontoId: senderId,
            //                         meldingType: "no.geointegrasjon.arkiv.oppdatering.arkivmeldingforenkletnotat.v1"); // Message type as string
            //                                                                                                                //Se oversikt over meldingstyper på https://github.com/ks-no/fiks-io-meldingstype-katalog/tree/test/schema


            //Fagsystem definerer ønsket struktur
            var notat = new ArkivmeldingForenkletNotat
            {
                sluttbrukerIdentifikator = "9hs2ir",
                nyttNotat = new OrganinterntNotat()
               
            };

            notat.referanseSaksmappeForenklet = new SaksmappeForenklet()
            {
                referanseEksternNoekkelForenklet = new EksternNoekkelForenklet
                {
                    fagsystem = "Fagsystem X",
                    noekkel = "e4reke"
                }
                ,
                klasse = new List<KlasseForenklet>
                {
                    new KlasseForenklet(){
                        klassifikasjonssystem = "Søknadsreferanse",
                        klasseID = "9hs2ir"

                    }
                },
            };

            notat.nyttNotat.tittel = "Internt notat ved innstilling(Ref=e4reke, SakId=e4reke)";
            notat.nyttNotat.referanseEksternNoekkelForenklet = new EksternNoekkelForenklet
            {
                fagsystem = "Fagsystem X",
                noekkel = "e4reke"
            };

            notat.nyttNotat.internAvsender = new List<KorrespondansepartIntern>
            {
                new KorrespondansepartIntern() {
                    saksbehandler = "Ståle Låne",
                    referanseSaksbehandler = "325abaf3-f607-4fe1-9413-91145db22d1f"
                }
            };
            
            notat.nyttNotat.internMottaker = new List<KorrespondansepartIntern>
            {
                new KorrespondansepartIntern() {
                    saksbehandler = "Sigve Saksbehandler",
                    referanseSaksbehandler = "60577438-1f97-4c5f-b254-aa758c8786c4"
                }
            };

            notat.nyttNotat.hoveddokument = new ForenkletDokument
            {
                tittel = "Internt notat ved innstilling",
                filnavn = "notat.pdf"
            };

            //Konverterer til arkivmelding xml
            var arkivmelding = ArkivmeldingFactory.GetArkivmelding(notat);
            var payload = ArkivmeldingSerializeHelper.Serialize(arkivmelding);

            ////Lager FIKS IO melding
            //List<IPayload> payloads = new List<IPayload>();
            //payloads.Add(new StringPayload(payload, "notat.xml"));
            //payloads.Add(new FilePayload(@"samples\notat.pdf"));
            //payloads.Add(new FilePayload(@"samples\vedlegg.pdf"));

            ////Sender til FIKS IO (arkiv løsning)
            //var msg = client.Send(messageRequest, payloads).Result;

            Assert.Pass();
        }

        [Test]
        public void TestSaksmappeKlasse()
        {

            //Fagsystem definerer ønsket struktur
            var inng = new ArkivmeldingForenkletInnkommende();
            inng.sluttbrukerIdentifikator = "Fagsystemets brukerid";

            inng.referanseSaksmappeForenklet = new SaksmappeForenklet()
            {
                tittel ="Tittel mappe",
                klasse = new List<KlasseForenklet>
                { 
                    new KlasseForenklet(){ 
                        klassifikasjonssystem = "GID", 
                        klasseID = "0822-1/23"
                       
                    },
                    new KlasseForenklet(){
                        klassifikasjonssystem = "Personnummer",
                        klasseID = "19085830948",
                        tittel = "Hans Hansen"
                    },
                    new KlasseForenklet(){
                        klassifikasjonssystem = "KK",
                        klasseID = "L3",
                        tittel = "Byggesaksbehandling"
                    },
                },
                referanseEksternNoekkelForenklet = new EksternNoekkelForenklet
                {
                    fagsystem = "Fagsystem X",
                    noekkel = "752f5e31-75e0-4359-bdcb-c612ba7a04eb"
                }

                //Ny matrikkel og Ny bygning
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

            //Konverterer til arkivmelding xml
            var arkivmelding = ArkivmeldingFactory.GetArkivmelding(inng);
            var payload = ArkivmeldingSerializeHelper.Serialize(arkivmelding);

            Assert.Pass();
        }

        [Test]
        public void TestSkjerming()
        {

            //Fagsystem definerer ønsket struktur
            var inng = new ArkivmeldingForenkletInnkommende();
            inng.sluttbrukerIdentifikator = "Fagsystemets brukerid";

            inng.nyInnkommendeJournalpost = new InnkommendeJournalpost
            {
                tittel = "Tittel som skal skjermes",
                mottattDato = DateTime.Today,
                dokumentetsDato = DateTime.Today.AddDays(-2),
                offentlighetsvurdertDato = DateTime.Today,
                skjermetTittel = true,
                offentligTittel = "Skjermet tittel som kan offentliggjøres",
                skjermingForenklet = new SkjermingForenklet()
                {
                     skjermingshjemmel= "Offl. § 26.1"
                }
                   
            };
            //Begrunnelse for skjerming må hjemles - Offentleglova kapittel 3 https://lovdata.no/dokument/NL/lov/2006-05-19-16/KAPITTEL_3#KAPITTEL_3

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
                    skjermetKorrespondansepart = true,
                    personid = new Personidentifikator() { personidentifikatorLandkode = "NO",  personidentifikatorNr = "12345678901"},
                    postadresse = new EnkelAdresse() {
                        adresselinje1 = "Gate 1",
                        postnr = "3801",
                        poststed = "Bø" }
                }
            };

            inng.nyInnkommendeJournalpost.hoveddokument = new ForenkletDokument
            {
                tittel = "Sensitiv info",
                filnavn = "brev.pdf",
                skjermetDokument = true
            };

            inng.nyInnkommendeJournalpost.vedlegg = new List<ForenkletDokument>
            {
                new ForenkletDokument(){
                    tittel = "Vedlegg 1",
                    filnavn = "vedlegg.pdf"
                }
            };

            //osv...

            //Konverterer til arkivmelding xml
            var arkivmelding = ArkivmeldingFactory.GetArkivmelding(inng);
            var payload = ArkivmeldingSerializeHelper.Serialize(arkivmelding);

            Assert.Pass();
        }

        [Test]
        public void TestMapperIMappe()
        {

            //Fagsystem definerer ønsket struktur
            var inng = new ArkivmeldingForenkletInnkommende();
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
                offentlighetsvurdertDato = DateTime.Today
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

            //Konverterer til arkivmelding xml
            var arkivmelding = ArkivmeldingFactory.GetArkivmelding(inng);

            //Legge til basismappe
            var basismappe = new Mappe();
            basismappe.MappeID = "2020/12345";
            basismappe.SystemID = new SystemID
            {
                Value = "f3fd5a87-8703-4771-834f-5bba65df0223"
            };

            //basismappe.saksbehandler //ligger på saksmappe  
            basismappe.Tittel = "Hovedmappe tittel";

            foreach (var item in arkivmelding.Mappe) {
                item.ReferanseForeldermappe = new SystemID {Value = "f3fd5a87-8703-4771-834f-5bba65df0223"};
            }

            var payload = ArkivmeldingSerializeHelper.Serialize(arkivmelding);

            Assert.Pass();
        }
    }
}