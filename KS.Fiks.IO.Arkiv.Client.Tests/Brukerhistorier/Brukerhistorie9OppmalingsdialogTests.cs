﻿using System;
using System.Collections.Generic;
using KS.Fiks.IO.Arkiv.Client.ForenkletArkivering;
using no.ks.fiks.io.arkiv.arkivering.arkivmelding;
using no.ks.fiks.io.arkiv.innsyn.sok;
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

            Saksmappe sak = FinnSak(saksaar, saksaksekvensnummer);
            journalpost jp = FinnJp(saksaar, saksaksekvensnummer,jpnavn);

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

        private void OpprettJournalpostMedDokument(Saksmappe mappe, string tittel)
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

            utg.referanseSaksmappe = mappe;
            utg.nyUtgaaendeJournalpost.tittel = tittel;
            utg.nyUtgaaendeJournalpost.referanseEksternNoekkel = new EksternNoekkel
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

            utg.nyUtgaaendeJournalpost.mottaker = new List<Korrespondansepart>
            {
                new Korrespondansepart() {
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

            ////Lager FIKS IO melding
            //List<IPayload> payloads = new List<IPayload>();
            //payloads.Add(new StringPayload(payload, "utgaaendejournalpost.xml"));
            //payloads.Add(new FilePayload(@"samples\vedtak.pdf"));
            //payloads.Add(new FilePayload(@"samples\vedlegg.pdf"));

            ////Sender til FIKS IO (arkiv løsning)
            //var msg = client.Send(messageRequest, payloads).Result;

           //TODO Hva er meningen her? Skal det sendes noe data? Er ikke det en integrasjonstest da?
        }

        public Saksmappe FinnSak(int saksaar, int saksaksekvensnummer)
        {
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

            return new Saksmappe();
        }
        
        public journalpost FinnJp(int saksaar, int saksaksekvensnummer, string journalpostTittel)
        {
            var arkivmeldingsok = new sok
            {
                respons = respons.journalpost,
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
                ,
                new parameter
                {
                    felt = sokFelt.registreringtittel,
                    @operator = operatorType.equal,
                    parameterverdier = new parameterverdier
                    {
                        Item = new stringvalues
                        {
                            value =new[] { journalpostTittel }
                        }
                    }
                }
            };

            arkivmeldingsok.parameter = paramlist.ToArray();
            var payload = ArkivmeldingSerializeHelper.Serialize(arkivmeldingsok);
            return new journalpost();
        }
    }
}
