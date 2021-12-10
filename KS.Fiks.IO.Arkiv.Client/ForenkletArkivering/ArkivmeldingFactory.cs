using System;
using System.Collections.Generic;
using no.ks.fiks.arkiv.v1.arkivering.arkivmelding;
using no.ks.fiks.io.arkivmelding;

namespace KS.Fiks.IO.Arkiv.Client.ForenkletArkivering
{
    public class ArkivmeldingFactory
    {
        private static readonly string Skjermingshjemmel = "Offl. § 26.1";
        const string MottakerKode = "EM";
        const string AvsenderKode = "EA";
        const string InternavsenderKode = "IA";
        const string InternmottakerKode = "IM";

        public static Arkivmelding GetArkivmelding(OppdaterSaksmappe input)
        {
            if (input.oppdaterSaksmappe == null)
            {
                throw new Exception("Badrequest - saksmappe må være angitt");    
            }
            
            var arkivmld = new Arkivmelding();
            var antFiler = 0;
            //var mappeliste = new List<Saksmappe> { ConvertSaksmappe(input.oppdaterSaksmappe) };
            
            arkivmld.Mappe.Add(ConvertSaksmappe(input.oppdaterSaksmappe));

            arkivmld.AntallFiler = antFiler;
            arkivmld.System = input.oppdaterSaksmappe.referanseEksternNoekkel?.fagsystem;
            arkivmld.MeldingId = input.oppdaterSaksmappe.referanseEksternNoekkel?.noekkel;
            arkivmld.Tidspunkt = DateTime.Now;

            return arkivmld;
        }
        public static Arkivmelding GetArkivmelding(ArkivmeldingForenkletUtgaaende input) {

            if (input.nyUtgaaendeJournalpost == null)
            {
                throw new Exception("Badrequest - journalpost må være angitt");
            }

            var arkivmld = new Arkivmelding();
            var antFiler = 0;
            Saksmappe mappe = null;
            if (input.referanseSaksmappe != null)
            {
                mappe = ConvertSaksmappe(input.referanseSaksmappe);

            }
           
            if (input.nyUtgaaendeJournalpost != null) {
                var journalpst = new journalpost
                {
                    tittel = input.nyUtgaaendeJournalpost.tittel,
                    journalposttype = "U"
                };

                if (input.nyUtgaaendeJournalpost.journalaar > 0)
                    journalpst.journalaar = input.nyUtgaaendeJournalpost.journalaar.ToString();
                if (input.nyUtgaaendeJournalpost.journalsekvensnummer > 0)
                    journalpst.journalsekvensnummer = input.nyUtgaaendeJournalpost.journalsekvensnummer.ToString();
                if (input.nyUtgaaendeJournalpost.journalpostnummer > 0) 
                    journalpst.journalpostnummer = input.nyUtgaaendeJournalpost.journalpostnummer.ToString();

                if (input.nyUtgaaendeJournalpost.sendtDato.HasValue) {
                    journalpst.sendtDato = input.nyUtgaaendeJournalpost.sendtDato.Value;
                    journalpst.sendtDatoSpecified = true;
                }
                if (input.nyUtgaaendeJournalpost.dokumentetsDato != null)
                {
                    journalpst.dokumentetsDato = input.nyUtgaaendeJournalpost.dokumentetsDato.Value;
                    journalpst.dokumentetsDatoSpecified = true;
                }
                if (input.nyUtgaaendeJournalpost.offentlighetsvurdertDato != null)
                {
                    journalpst.offentlighetsvurdertDato = input.nyUtgaaendeJournalpost.offentlighetsvurdertDato.Value;
                    journalpst.offentlighetsvurdertDatoSpecified = true;
                }
                
                journalpst.opprettetAv = input.sluttbrukerIdentifikator;
                journalpst.arkivertAv = input.sluttbrukerIdentifikator; //TODO ?????
                
                // Skjerming
                if (input.nyUtgaaendeJournalpost.skjermetTittel)
                {
                    journalpst.skjerming = new skjerming()
                    {
                        skjermingshjemmel = Skjermingshjemmel,
                        skjermingMetadata = new List<string> { "tittel", "korrespondansepart" }.ToArray()
                    };
                }

                // Håndtere alle filer
                List<dokumentbeskrivelse> dokbliste = new List<dokumentbeskrivelse>();

                if (input.nyUtgaaendeJournalpost.hoveddokument != null)
                {
                    var dokbesk = new dokumentbeskrivelse
                    {
                        dokumentstatus = "F",
                        tilknyttetRegistreringSom = "H",
                        tittel = input.nyUtgaaendeJournalpost.hoveddokument.tittel
                    };

                    if (input.nyUtgaaendeJournalpost.hoveddokument.skjermetDokument) {
                        dokbesk.skjerming = new skjerming()
                        {
                            skjermingshjemmel = Skjermingshjemmel,
                            skjermingDokument = "Hele"
                        };
                    }
                    
                    var dok = new dokumentobjekt
                    {
                        referanseDokumentfil = input.nyUtgaaendeJournalpost.hoveddokument.filnavn
                    };
                    List<dokumentobjekt> dokliste = new List<dokumentobjekt>
                    {
                        dok
                    };

                    dokbesk.dokumentobjekt = dokliste.ToArray();

                    dokbliste.Add(dokbesk);
                    antFiler++;
                }
                foreach (var item in input.nyUtgaaendeJournalpost.vedlegg)
                {
                    var dokbesk = new dokumentbeskrivelse
                    {
                        dokumentstatus = "F",
                        tilknyttetRegistreringSom = "V",
                        tittel = item.tittel
                        
                    };

                    var dok = new dokumentobjekt
                    {
                        referanseDokumentfil = item.filnavn
                    };
                    List<dokumentobjekt> dokliste = new List<dokumentobjekt>
                    {
                        dok
                    };

                    dokbesk.dokumentobjekt = dokliste.ToArray();

                    dokbliste.Add(dokbesk);
                    antFiler++;

                }
                journalpst.dokumentbeskrivelse = dokbliste.ToArray();

                // Korrespondanseparter
                List<korrespondansepart> partsListe = new List<korrespondansepart>();

                foreach (var mottaker in input.nyUtgaaendeJournalpost.mottaker)
                {
                    korrespondansepart korrpart = KorrespondansepartToArkivPart(MottakerKode, mottaker);
                    partsListe.Add(korrpart);
                }

                foreach (var avsender in input.nyUtgaaendeJournalpost.avsender)
                {
                    korrespondansepart korrpart = KorrespondansepartToArkivPart(AvsenderKode, avsender);
                    partsListe.Add(korrpart);
                }
                
                foreach (var internAvsender in input.nyUtgaaendeJournalpost.internAvsender)
                {
                    korrespondansepart korrpart = InternKorrespondansepartToArkivPart(InternavsenderKode, internAvsender);
                    partsListe.Add(korrpart);
                }

                journalpst.korrespondansepart = partsListe.ToArray();

                if (input.nyUtgaaendeJournalpost.referanseEksternNoekkel != null)
                {
                    journalpst.referanseEksternNoekkel = new eksternNoekkel();
                    journalpst.referanseEksternNoekkel.fagsystem = input.nyUtgaaendeJournalpost.referanseEksternNoekkel.fagsystem;
                    journalpst.referanseEksternNoekkel.noekkel = input.nyUtgaaendeJournalpost.referanseEksternNoekkel.noekkel;
                }

                List<journalpost> jliste = new List<journalpost>
                {
                    journalpst
                };

                if (mappe != null)
                {
                    var mappeliste = new List<Saksmappe>();
                    mappe.Items = jliste.ToArray();
                    mappeliste.Add(mappe);
                    arkivmld.Items = mappeliste.ToArray();
                }
                else {
                    arkivmld.Items = jliste.ToArray();
                }
            }
            
            arkivmld.antallFiler = antFiler;
            arkivmld.system = input.nyUtgaaendeJournalpost.referanseEksternNoekkel?.fagsystem;
            arkivmld.meldingId = input.nyUtgaaendeJournalpost.referanseEksternNoekkel?.noekkel;
            arkivmld.tidspunkt = DateTime.Now;

            return arkivmld;
        }

        private static Korrespondansepart KorrespondansepartToArkivPart(string partRolle, Korrespondansepart mottaker)
        {
            var part= new no.ks.fiks.arkiv.v1.arkivstruktur.Korrespondansepart()
            {
                KorrespondansepartNavn = mottaker.navn,
                Korrespondanseparttype = partRolle,
                Postadresse =  {
                    mottaker.postadresse?.adresselinje1,
                    mottaker.postadresse?.adresselinje2,
                    mottaker.postadresse?.adresselinje3
                },
                Land = mottaker.postadresse?.landkode,
                Postnummer = mottaker.postadresse?.postnr,
                Poststed = mottaker.postadresse?.poststed,
                Kontaktperson = mottaker.kontaktperson,
                Epostadresse = mottaker.kontaktinformasjon?.epostadresse,
                Telefonnummer = {
                    mottaker.kontaktinformasjon?.mobiltelefon,
                    mottaker.kontaktinformasjon?.telefon
                },
                deresReferanse = mottaker.deresReferanse,
                forsendelsesmaate = mottaker.forsendelsemåte
            };

            if (mottaker.enhetsidentifikator?.organisasjonsnummer != null) {
                part.Item = new EnhetsidentifikatorType()
                    {
                        organisasjonsnummer = mottaker.enhetsidentifikator.organisasjonsnummer
                    };
            }
            
            if (mottaker.personid?.personidentifikatorNr != null) {
                if (mottaker.personid?.personidentifikatorType == "F")
                {
                    part.Item = new FoedselsnummerType()
                    {
                        foedselsnummer = mottaker.personid?.personidentifikatorNr
                    };
                }
                else {
                    part.Item = new DNummerType()
                    {
                        DNummer = mottaker.personid?.personidentifikatorNr
                    };
                }
            }

            return part;
        }
        
        private static korrespondansepart InternKorrespondansepartToArkivPart(string internKode, KorrespondansepartIntern intern)
        {
            return  new korrespondansepart
            {
                korrespondansepartNavn = intern.saksbehandler ?? intern.administrativEnhet,
                korrespondanseparttype = internKode,
                administrativEnhet = intern.administrativEnhet,
                saksbehandler = intern.saksbehandler
            };
        }

        public static Arkivmelding GetArkivmelding(ArkivmeldingForenkletInnkommende input)
        {
            if (input.nyInnkommendeJournalpost == null) throw new Exception("Badrequest - journalpost må være angitt");

            var arkivmld = new Arkivmelding();
            int antFiler = 0;
            Saksmappe mappe = null;

            if (input.referanseSaksmappe != null)
            {
                mappe = ConvertSaksmappe(input.referanseSaksmappe);
            }

            if (input.nyInnkommendeJournalpost != null)
            {
                var journalpst = new Journalpost();
                journalpst.Tittel = input.nyInnkommendeJournalpost.tittel;

                journalpst.Journalposttype = "I";
                if (input.nyInnkommendeJournalpost.mottattDato != null)
                {
                    journalpst.MottattDato = input.nyInnkommendeJournalpost.mottattDato.Value;
                    journalpst.MottattDatoSpecified = true;
                }
                if (input.nyInnkommendeJournalpost.dokumentetsDato != null)
                {
                    journalpst.DokumentetsDato = input.nyInnkommendeJournalpost.dokumentetsDato.Value;
                    journalpst.DokumentetsDatoSpecified = true;
                }
                if (input.nyInnkommendeJournalpost.offentlighetsvurdertDato != null)
                {
                    journalpst.OffentlighetsvurdertDato = input.nyInnkommendeJournalpost.offentlighetsvurdertDato.Value;
                    journalpst.OffentlighetsvurdertDatoSpecified = true;
                }

                journalpst.OffentligTittel = input.nyInnkommendeJournalpost.offentligTittel;
                journalpst.OpprettetAv = input.sluttbrukerIdentifikator;
                journalpst.ArkivertAv = input.sluttbrukerIdentifikator; //TODO ?????
                
                // Skjerming
                if (input.nyInnkommendeJournalpost.skjermetTittel)
                {
                    journalpst.Skjerming = new no.ks.fiks.arkiv.v1.arkivering.arkivmelding.Skjerming()
                    {
                        Skjermingshjemmel = input.nyInnkommendeJournalpost.skjerming?.skjermingshjemmel,
                        SkjermingMetadata = { "tittel", "korrespondansepart" }
                    };
                }
                
                // Håndtere alle filer
                List<Dokumentbeskrivelse> dokbliste = new List<Dokumentbeskrivelse>();
                
                if (input.nyInnkommendeJournalpost.hoveddokument != null)
                {
                    var dokbesk = new Dokumentbeskrivelse()
                    {
                        Dokumentstatus = "F",
                        TilknyttetRegistreringSom = "H",
                        Tittel = input.nyInnkommendeJournalpost.hoveddokument.tittel
                    };
                    
                    if (input.nyInnkommendeJournalpost.hoveddokument.skjermetDokument)
                    {
                        dokbesk.Skjerming = new no.ks.fiks.arkiv.v1.arkivering.arkivmelding.Skjerming()
                        {
                            Skjermingshjemmel = input.nyInnkommendeJournalpost.skjerming?.skjermingshjemmel,
                            SkjermingDokument = "Hele"
                        };
                    }
                    var dok = new Dokumentobjekt()
                    {
                        ReferanseDokumentfil = input.nyInnkommendeJournalpost.hoveddokument.filnavn
                    };
                    List<Dokumentobjekt> dokliste = new List<Dokumentobjekt>();
                    dokliste.Add(dok);

                    dokbesk.Dokumentobjekt = dokliste.ToArray();
                    
                    dokbliste.Add(dokbesk);
                    antFiler++;
                }
                foreach (var item in input.nyInnkommendeJournalpost.vedlegg)
                {
                    var dokbesk = new Dokumentbeskrivelse();
                    dokbesk.Dokumentstatus = "F";
                    dokbesk.TilknyttetRegistreringSom = "V";
                    dokbesk.Tittel = item.tittel;

                    var dok = new Dokumentobjekt();
                    dok.ReferanseDokumentfil = item.filnavn;
                    List<Dokumentobjekt> dokliste = new List<Dokumentobjekt>();
                    dokliste.Add(dok);

                    dokbesk.Dokumentobjekt = dokliste.ToArray();
                    
                    dokbliste.Add(dokbesk);
                    antFiler++;

                }
                journalpst.Dokumentbeskrivelse = dokbliste.ToArray();

                //Korrespondanseparter
                List<no.ks.fiks.arkiv.v1.arkivering.arkivmelding.Korrespondansepart> partsListe = new List<no.ks.fiks.arkiv.v1.arkivering.arkivmelding.Korrespondansepart>();

                foreach (var mottaker in input.nyInnkommendeJournalpost.mottaker)
                {
                    Korrespondansepart korrpart = KorrespondansepartToArkivPart(MottakerKode, mottaker);
                    partsListe.Add(korrpart);
                }

                foreach (var avsender in input.nyInnkommendeJournalpost.avsender)
                {
                    korrespondansepart korrpart = KorrespondansepartToArkivPart(AvsenderKode, avsender);
                    partsListe.Add(korrpart);
                }

                foreach (var internMottaker in input.nyInnkommendeJournalpost.internMottaker)
                {
                    korrespondansepart korrpart = InternKorrespondansepartToArkivPart(InternmottakerKode, internMottaker);
                    partsListe.Add(korrpart);
                }

                journalpst.korrespondansepart = partsListe.ToArray();

                if (input.nyInnkommendeJournalpost.referanseEksternNoekkel != null)
                {
                    journalpst.referanseEksternNoekkel = new eksternNoekkel();
                    journalpst.referanseEksternNoekkel.fagsystem = input.nyInnkommendeJournalpost.referanseEksternNoekkel.fagsystem;
                    journalpst.referanseEksternNoekkel.noekkel = input.nyInnkommendeJournalpost.referanseEksternNoekkel.noekkel;
                }

                List<journalpost> jliste = new List<journalpost>
                {
                    journalpst
                };

                if (mappe != null)
                {
                    var mappeliste = new List<Saksmappe>();
                    mappe.Items = jliste.ToArray();
                    mappeliste.Add(mappe);
                    arkivmld.Items = mappeliste.ToArray();
                }
                else
                {
                    arkivmld.Items = jliste.ToArray();
                }

            }
            arkivmld.antallFiler = antFiler;
            arkivmld.system = input.nyInnkommendeJournalpost.referanseEksternNoekkel.fagsystem;
            arkivmld.meldingId = input.nyInnkommendeJournalpost.referanseEksternNoekkel.noekkel;
            arkivmld.tidspunkt = DateTime.Now;

            return arkivmld;
        }

        public static Arkivmelding GetArkivmelding(ArkivmeldingForenkletNotat input)
        {
            if (input.nyttNotat == null) throw new Exception("Badrequest -notat må være angitt");

            var arkivmld = new Arkivmelding();
            int antFiler = 0;
            Saksmappe mappe = null;

            if (input.referanseSaksmappe != null)
            {
                mappe = ConvertSaksmappe(input.referanseSaksmappe);

            }

            if (input.nyttNotat != null)
            {
                var journalpst = new journalpost();
                journalpst.tittel = input.nyttNotat.tittel;

                journalpst.opprettetAv = input.sluttbrukerIdentifikator;
                journalpst.arkivertAv = input.sluttbrukerIdentifikator; //TODO ?????

                journalpst.journalposttype = "N";
                //if (input.nyttNotat.mottattDato != null)
                //{
                //    journalpst.mottattDato = input.nyttNotat.mottattDato.Value;
                //    journalpst.mottattDatoSpecified = true;
                //}
                if (input.nyttNotat.dokumentetsDato != null)
                {
                    journalpst.dokumentetsDato = input.nyttNotat.dokumentetsDato.Value;
                    journalpst.dokumentetsDatoSpecified = true;
                }
                //if (input.nyttNotat.offentlighetsvurdertDato != null)
                //{
                //    journalpst.offentlighetsvurdertDato = input.nyttNotat.offentlighetsvurdertDato.Value;
                //    journalpst.offentlighetsvurdertDatoSpecified = true;
                //}

                //journalpst.offentligTittel = input.nyttNotat.offentligTittel;

                ////skjerming
                //if (input.nyttNotat.skjermetTittel)
                //{
                //    journalpst.skjerming = new skjerming()
                //    {
                //        skjermingshjemmel = input.nyttNotat.skjerming?.skjermingshjemmel,
                //        skjermingMetadata = new List<string> { "tittel", "korrespondansepart" }.ToArray()
                //    };
                //}
                //Håndtere alle filer
                List<dokumentbeskrivelse> dokbliste = new List<dokumentbeskrivelse>();

                if (input.nyttNotat.hoveddokument != null)
                {
                    var dokbesk = new dokumentbeskrivelse
                    {
                        dokumentstatus = "F",
                        tilknyttetRegistreringSom = "H",
                        tittel = input.nyttNotat.hoveddokument.tittel
                    };

                    if (input.nyttNotat.hoveddokument.skjermetDokument)
                    {
                        dokbesk.skjerming = new skjerming()
                        {
                            //skjermingshjemmel = input.nyttNotat.skjerming?.skjermingshjemmel,
                            skjermingDokument = "Hele"
                        };
                    }
                    var dok = new dokumentobjekt
                    {
                        referanseDokumentfil = input.nyttNotat.hoveddokument.filnavn
                    };
                    List<dokumentobjekt> dokliste = new List<dokumentobjekt>();
                    dokliste.Add(dok);

                    dokbesk.dokumentobjekt = dokliste.ToArray();

                    dokbliste.Add(dokbesk);
                    antFiler++;
                }
                foreach (var item in input.nyttNotat.vedlegg)
                {
                    var dokbesk = new dokumentbeskrivelse();
                    dokbesk.dokumentstatus = "F";
                    dokbesk.tilknyttetRegistreringSom = "V";
                    dokbesk.tittel = item.tittel;

                    var dok = new dokumentobjekt();
                    dok.referanseDokumentfil = item.filnavn;
                    List<dokumentobjekt> dokliste = new List<dokumentobjekt>();
                    dokliste.Add(dok);

                    dokbesk.dokumentobjekt = dokliste.ToArray();

                    dokbliste.Add(dokbesk);
                    antFiler++;

                }
                journalpst.dokumentbeskrivelse = dokbliste.ToArray();

                //Korrespondanseparter
                List<korrespondansepart> partsListe = new List<korrespondansepart>();
                
                foreach (var internMottaker in input.nyttNotat.internAvsender)
                {
                    korrespondansepart korrpart = InternKorrespondansepartToArkivPart(InternavsenderKode, internMottaker);
                    partsListe.Add(korrpart);
                }

                foreach (var internMottaker in input.nyttNotat.internMottaker)
                {
                    korrespondansepart korrpart = InternKorrespondansepartToArkivPart(InternmottakerKode, internMottaker);
                    partsListe.Add(korrpart);
                }

                journalpst.korrespondansepart = partsListe.ToArray();

                if (input.nyttNotat.referanseEksternNoekkel != null)
                {
                    journalpst.referanseEksternNoekkel = new eksternNoekkel();
                    journalpst.referanseEksternNoekkel.fagsystem = input.nyttNotat.referanseEksternNoekkel.fagsystem;
                    journalpst.referanseEksternNoekkel.noekkel = input.nyttNotat.referanseEksternNoekkel.noekkel;
                }

                List<journalpost> jliste = new List<journalpost>
                {
                    journalpst
                };

                if (mappe != null)
                {
                    var mappeliste = new List<Saksmappe>();
                    mappe.Items = jliste.ToArray();
                    mappeliste.Add(mappe);
                    arkivmld.Items = mappeliste.ToArray();
                }
                else
                {
                    arkivmld.Items = jliste.ToArray();
                }

            }
            arkivmld.antallFiler = antFiler;
            arkivmld.system = input.nyttNotat.referanseEksternNoekkel.fagsystem;
            arkivmld.meldingId = input.nyttNotat.referanseEksternNoekkel.noekkel;
            arkivmld.tidspunkt = DateTime.Now;

            return arkivmld;
        }

        private static Saksmappe ConvertSaksmappe(Saksmappe input)
        {
            var mappe = new Saksmappe
            {
                saksansvarlig = input.saksansvarlig,
                administrativEnhet = input.administrativEnhet,
                tittel = input.tittel
            };
            if (input.saksaar > 0)
                mappe.saksaar = input.saksaar.ToString();
            if (input.sakssekvensnummer > 0)
                mappe.sakssekvensnummer = input.sakssekvensnummer.ToString();

            if (input.saksdato.HasValue)
            {
                mappe.saksdato = input.saksdato.Value;
                mappe.saksdatoSpecified = true;
            }

            if (input.klasse != null)
            {
                List<Klasse> klasser = new List<Klasse>(); 
                foreach (var kl in input.klasse)
                {
                    klasser.Add(new Klasse() { klassifikasjonssystem = kl.klassifikasjonssystem, klasseID = kl.klasseID, tittel = kl.tittel });
                }
                mappe.klasse = klasser.ToArray();
            }
            if (input.referanseEksternNoekkel != null)
            {
                mappe.referanseEksternNoekkel = new EksternNoekkel();
                mappe.referanseEksternNoekkel.fagsystem = input.referanseEksternNoekkel.fagsystem;
                mappe.referanseEksternNoekkel.noekkel = input.referanseEksternNoekkel.noekkel;
            }

            return mappe;
        }
    }
}
