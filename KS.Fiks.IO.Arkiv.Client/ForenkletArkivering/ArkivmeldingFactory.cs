using System;
using System.Linq;
using KS.Fiks.IO.Arkiv.Client.Models.Arkivering.Arkivmelding;
using KS.Fiks.IO.Arkiv.Client.Models.Metadatakatalog;

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
            if (input.oppdaterSaksmappeForenklet == null)
            {
                throw new Exception("Badrequest - saksmappe må være angitt");    
            }
            
            var arkivmld = new Arkivmelding();
            var antFiler = 0;
            //var mappeliste = new List<Saksmappe> { ConvertSaksmappe(input.oppdaterSaksmappe) };
            
            arkivmld.Mappe.Add(ConvertSaksmappe(input.oppdaterSaksmappeForenklet));

            arkivmld.AntallFiler = antFiler;
            arkivmld.System = input.oppdaterSaksmappeForenklet.referanseEksternNoekkelForenklet?.fagsystem;
            arkivmld.MeldingId = input.oppdaterSaksmappeForenklet.referanseEksternNoekkelForenklet?.noekkel;
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
            Saksmappe saksmappe = null;
            if (input.referanseSaksmappeForenklet != null)
            {
                saksmappe = ConvertSaksmappe(input.referanseSaksmappeForenklet);
            }
           
            if (input.nyUtgaaendeJournalpost != null) {
                var journalpost = new Journalpost()
                {
                    Tittel = input.nyUtgaaendeJournalpost.tittel,

                    Journalposttype = "U",
                    Journalstatus = "X" //TODO Hva skal her?

                };

                if (input.nyUtgaaendeJournalpost.journalaar > 0)
                    journalpost.Journalaar = input.nyUtgaaendeJournalpost.journalaar.ToString();
                if (input.nyUtgaaendeJournalpost.journalsekvensnummer > 0)
                    journalpost.Journalsekvensnummer = input.nyUtgaaendeJournalpost.journalsekvensnummer.ToString();
                if (input.nyUtgaaendeJournalpost.journalpostnummer > 0) 
                    journalpost.Journalpostnummer = input.nyUtgaaendeJournalpost.journalpostnummer.ToString();

                if (input.nyUtgaaendeJournalpost.sendtDato.HasValue) {
                    journalpost.SendtDato = input.nyUtgaaendeJournalpost.sendtDato.Value;
                    journalpost.SendtDatoSpecified = true;
                }
                if (input.nyUtgaaendeJournalpost.dokumentetsDato != null)
                {
                    journalpost.DokumentetsDato = input.nyUtgaaendeJournalpost.dokumentetsDato.Value;
                    journalpost.DokumentetsDatoSpecified = true;
                }
                if (input.nyUtgaaendeJournalpost.offentlighetsvurdertDato != null)
                {
                    journalpost.OffentlighetsvurdertDato = input.nyUtgaaendeJournalpost.offentlighetsvurdertDato.Value;
                    journalpost.OffentlighetsvurdertDatoSpecified = true;
                }
                
                journalpost.OpprettetAv = input.sluttbrukerIdentifikator;
                journalpost.ArkivertAv = input.sluttbrukerIdentifikator; //TODO ?????
                
                // Skjerming
                if (input.nyUtgaaendeJournalpost.skjermetTittel)
                {
                    journalpost.Skjerming = new Skjerming()
                    {
                        Skjermingshjemmel = Skjermingshjemmel,
                        SkjermingMetadata = { "tittel", "korrespondansepart" }
                    };
                }

                // Håndtere alle filer
                if (input.nyUtgaaendeJournalpost.hoveddokument != null)
                {
                    var dokumentbeskrivelse = new Dokumentbeskrivelse
                    {
                        Dokumenttype = "TEST", //TODO Hva skal inn her?
                        Dokumentstatus = "F",
                        Tittel = input.nyUtgaaendeJournalpost.hoveddokument.tittel,
                        TilknyttetRegistreringSom = "H"
                    };

                    if (input.nyUtgaaendeJournalpost.hoveddokument.skjermetDokument) {
                        dokumentbeskrivelse.Skjerming = new Skjerming()
                        {
                            Skjermingshjemmel = Skjermingshjemmel,
                            SkjermingDokument = "Hele"
                        };
                    }
                    
                    var dok = new Dokumentobjekt
                    {
                        Format = "X", //TODO Her mangler noe eller det er noe som ikke stemmer.
                        Variantformat = "X", //TODO Her mangler noe eller det er noe som ikke stemmer.
                        Versjonsnummer = "1", //TODO Her mangler noe eller det er noe som ikke stemmer.
                        Filnavn = "", //TODO Her mangler noe eller det er noe som ikke stemmer.
                        ReferanseDokumentfil = input.nyUtgaaendeJournalpost.hoveddokument.filnavn
                    };
                    
                    dokumentbeskrivelse.Dokumentobjekt.Add(dok);

                    journalpost.Dokumentbeskrivelse.Add(dokumentbeskrivelse);
                    antFiler++;
                }
                foreach (var item in input.nyUtgaaendeJournalpost.vedlegg)
                {
                    var dokbesk = new Dokumentbeskrivelse
                    {
                        Dokumenttype = "TEST", //TODO Hva skal inn her?
                        Dokumentstatus = "F",
                        Tittel = item.tittel,
                        TilknyttetRegistreringSom = "V"
                    };

                    var dok = new Dokumentobjekt
                    {
                        Format = "X", //TODO Her mangler noe eller det er noe som ikke stemmer.
                        Variantformat = "X", //TODO Her mangler noe eller det er noe som ikke stemmer.
                        Versjonsnummer = "1", //TODO Her mangler noe eller det er noe som ikke stemmer.
                        Filnavn = "", //TODO Her mangler noe eller det er noe som ikke stemmer.
                        ReferanseDokumentfil = item.filnavn
                    };
                    
                    dokbesk.Dokumentobjekt.Add(dok);

                    journalpost.Dokumentbeskrivelse.Add(dokbesk);
                    antFiler++;

                }
                
                // Korrespondanseparter
                foreach (var mottaker in input.nyUtgaaendeJournalpost.mottaker)
                {
                    var korrespondansepart = KorrespondansepartToArkivPart(MottakerKode, mottaker);
                    journalpost.Korrespondansepart.Add(korrespondansepart);
                }

                foreach (var avsender in input.nyUtgaaendeJournalpost.avsender)
                {
                    var korrpart = KorrespondansepartToArkivPart(AvsenderKode, avsender);
                    journalpost.Korrespondansepart.Add(korrpart);
                }
                
                foreach (var internAvsender in input.nyUtgaaendeJournalpost.internAvsender)
                {
                    var korrpart = InternKorrespondansepartToArkivPart(InternavsenderKode, internAvsender);
                    journalpost.Korrespondansepart.Add(korrpart);
                }

                if (input.nyUtgaaendeJournalpost.referanseEksternNoekkelForenklet != null)
                {
                    journalpost.ReferanseEksternNoekkel = new EksternNoekkel
                    {
                        Fagsystem = input.nyUtgaaendeJournalpost.referanseEksternNoekkelForenklet.fagsystem,
                        Noekkel = input.nyUtgaaendeJournalpost.referanseEksternNoekkelForenklet.noekkel
                    };
                }

                // Arkivmelding -> Saksmappe -> Journalpost
                if (saksmappe != null)
                {
                    saksmappe.Registrering.Add(journalpost);
                    arkivmld.Mappe.Add(saksmappe);
                } else {
                    arkivmld.Registrering.Add(journalpost);
                }
            }
            
            arkivmld.AntallFiler = antFiler;
            arkivmld.System = input.nyUtgaaendeJournalpost.referanseEksternNoekkelForenklet?.fagsystem;
            arkivmld.MeldingId = input.nyUtgaaendeJournalpost.referanseEksternNoekkelForenklet?.noekkel;
            arkivmld.Tidspunkt = DateTime.Now;

            return arkivmld;
        }

        private static Korrespondansepart KorrespondansepartToArkivPart(string partRolle, KorrespondansepartForenklet mottaker)
        {
            var korrespondansepart = new Korrespondansepart()
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
                Epostadresse = mottaker.kontaktinformasjonForenklet?.epostadresse,
                Telefonnummer = {
                    mottaker.kontaktinformasjonForenklet?.mobiltelefon,
                    mottaker.kontaktinformasjonForenklet?.telefon
                },
                DeresReferanse = mottaker.deresReferanse,
                Forsendelsesmaate = mottaker.forsendelsemåte
            };

            if (mottaker.enhetsidentifikator?.organisasjonsnummer != null)
            {
                korrespondansepart.Organisasjonid = mottaker.enhetsidentifikator.organisasjonsnummer; 
                /*new Enhetsidentifikator()
                    {
                        Organisasjonsnummer = mottaker.enhetsidentifikator.organisasjonsnummer
                    };*/
            }
            
            if (mottaker.personid?.personidentifikatorNr != null) {
                korrespondansepart.Personid = mottaker.personid?.personidentifikatorNr;
                /*if (mottaker.personid?.personidentifikatorType == "F")
                {
                    korrespondansepart.Personid = mottaker.personid?.personidentifikatorNr;
                    
                    korrespondansepart.Item = new FoedselsnummerType() //TODO Hvor kom denne fra egentlig?
                    {
                        foedselsnummer = mottaker.personid?.personidentifikatorNr
                    };
                }
                else
                {

                    korrespondansepart.Personid = mottaker.personid?.personidentifikatorNr;
                    new DNummerType() //TODO Hvor kom denne fra egentlig?
                { 
                    DNummer = mottaker.personid?.personidentifikatorNr
                };*/
            }

            return korrespondansepart;
        }
        
        private static Korrespondansepart InternKorrespondansepartToArkivPart(string internKode, KorrespondansepartIntern intern)
        {
            return new Korrespondansepart
            {
                KorrespondansepartNavn = intern.saksbehandler ?? intern.administrativEnhet,
                Korrespondanseparttype = internKode,
                AdministrativEnhet = intern.administrativEnhet,
                Saksbehandler = intern.saksbehandler
            };
        }

        public static Arkivmelding GetArkivmelding(ArkivmeldingForenkletInnkommende input)
        {
            if (input.nyInnkommendeJournalpost == null) throw new Exception("Badrequest - journalpost må være angitt");

            var arkivmld = new Arkivmelding();
            var antFiler = 0;
            Saksmappe mappe = null;

            if (input.referanseSaksmappeForenklet != null)
            {
                mappe = ConvertSaksmappe(input.referanseSaksmappeForenklet);
            }

            if (input.nyInnkommendeJournalpost != null)
            {
                var journalpost = new Journalpost();
                journalpost.Tittel = input.nyInnkommendeJournalpost.tittel;

                journalpost.Journalposttype = "I";
                journalpost.Journalstatus = "X"; //TODO Hva skal her?
                
                if (input.nyInnkommendeJournalpost.mottattDato != null)
                {
                    journalpost.MottattDato = input.nyInnkommendeJournalpost.mottattDato.Value;
                    journalpost.MottattDatoSpecified = true;
                }
                if (input.nyInnkommendeJournalpost.dokumentetsDato != null)
                {
                    journalpost.DokumentetsDato = input.nyInnkommendeJournalpost.dokumentetsDato.Value;
                    journalpost.DokumentetsDatoSpecified = true;
                }
                if (input.nyInnkommendeJournalpost.offentlighetsvurdertDato != null)
                {
                    journalpost.OffentlighetsvurdertDato = input.nyInnkommendeJournalpost.offentlighetsvurdertDato.Value;
                    journalpost.OffentlighetsvurdertDatoSpecified = true;
                }

                journalpost.OffentligTittel = input.nyInnkommendeJournalpost.offentligTittel;
                journalpost.OpprettetAv = input.sluttbrukerIdentifikator;
                journalpost.ArkivertAv = input.sluttbrukerIdentifikator; //TODO ?????
                
                // Skjerming
                if (input.nyInnkommendeJournalpost.skjermetTittel)
                {
                    journalpost.Skjerming = new Skjerming()
                    {
                        Skjermingshjemmel = input.nyInnkommendeJournalpost.skjermingForenklet?.skjermingshjemmel,
                        SkjermingMetadata = { "tittel", "korrespondansepart" }
                    };
                }
                
                // Håndtere alle filer
                if (input.nyInnkommendeJournalpost.hoveddokument != null)
                {
                    var dokbesk = new Dokumentbeskrivelse()
                    {
                        Dokumenttype = "TEST", //TODO Hva skal inn her?
                        Dokumentstatus = "F",
                        TilknyttetRegistreringSom = "H",
                        Tittel = input.nyInnkommendeJournalpost.hoveddokument.tittel
                    };
                    
                    if (input.nyInnkommendeJournalpost.hoveddokument.skjermetDokument)
                    {
                        dokbesk.Skjerming = new Skjerming()
                        {
                            Skjermingshjemmel = input.nyInnkommendeJournalpost.skjermingForenklet?.skjermingshjemmel,
                            SkjermingDokument = "Hele"
                        };
                    }
                    var dok = new Dokumentobjekt()
                    {
                        Format = "X", //TODO Her mangler noe eller det er noe som ikke stemmer.
                        Variantformat = "X", //TODO Her mangler noe eller det er noe som ikke stemmer.
                        Versjonsnummer = "1", //TODO Her mangler noe eller det er noe som ikke stemmer.
                        Filnavn = "", //TODO Her mangler noe eller det er noe som ikke stemmer.
                        ReferanseDokumentfil = input.nyInnkommendeJournalpost.hoveddokument.filnavn
                    };

                    dokbesk.Dokumentobjekt.Add(dok);
                    journalpost.Dokumentbeskrivelse.Add(dokbesk);
                    antFiler++;
                }
                foreach (var item in input.nyInnkommendeJournalpost.vedlegg)
                {

                    var dokbesk = new Dokumentbeskrivelse
                    {
                        Dokumenttype = "", //TODO Hva skal inn her? item.dokumenttype.kodeverdi?
                        Dokumentstatus = "F",
                        TilknyttetRegistreringSom = "V",
                        Tittel = item.tittel
                    };

                    var dok = new Dokumentobjekt
                    {
                        Format = "X", //TODO Her mangler noe eller det er noe som ikke stemmer.
                        Variantformat = "X", //TODO Her mangler noe eller det er noe som ikke stemmer.
                        Versjonsnummer = "1", //TODO Her mangler noe eller det er noe som ikke stemmer.
                        Filnavn = "", //TODO Her mangler noe eller det er noe som ikke stemmer.
                        ReferanseDokumentfil = item.filnavn
                    };
                    
                    dokbesk.Dokumentobjekt.Add(dok);
                    journalpost.Dokumentbeskrivelse.Add(dokbesk);
                    antFiler++;
                }

                //Korrespondanseparter

                //Mottakere
                foreach (var korrpart in input.nyInnkommendeJournalpost.mottaker.Select(mottaker => KorrespondansepartToArkivPart(MottakerKode, mottaker)))
                {
                    journalpost.Korrespondansepart.Add(korrpart);
                }

                //Avsendere
                foreach (var korrpart in input.nyInnkommendeJournalpost.avsender.Select(avsender => KorrespondansepartToArkivPart(AvsenderKode, avsender)))
                {
                    journalpost.Korrespondansepart.Add(korrpart);
                }

                //Intern mottakere
                foreach (var internMottaker in input.nyInnkommendeJournalpost.internMottaker)
                {
                    var korrpart = InternKorrespondansepartToArkivPart(InternmottakerKode, internMottaker);
                    journalpost.Korrespondansepart.Add(korrpart);
                }

                if (input.nyInnkommendeJournalpost.referanseEksternNoekkelForenklet != null)
                {
                    journalpost.ReferanseEksternNoekkel = new EksternNoekkel
                    {
                        Fagsystem = input.nyInnkommendeJournalpost.referanseEksternNoekkelForenklet.fagsystem,
                        Noekkel = input.nyInnkommendeJournalpost.referanseEksternNoekkelForenklet.noekkel
                    };
                }
              
                // Arkivmelding -> Mappe -> Journalpost
                if (mappe != null)
                {
                    mappe.Registrering.Add(journalpost); 
                    arkivmld.Mappe.Add(mappe);
                }
                else // Arkivmelding -> Journalpost
                {
                    arkivmld.Registrering.Add(journalpost); 
                }

            }
            arkivmld.AntallFiler = antFiler;
            arkivmld.System = input.nyInnkommendeJournalpost.referanseEksternNoekkelForenklet.fagsystem;
            arkivmld.MeldingId = input.nyInnkommendeJournalpost.referanseEksternNoekkelForenklet.noekkel;
            arkivmld.Tidspunkt = DateTime.Now;

            return arkivmld;
        }

        public static Arkivmelding GetArkivmelding(ArkivmeldingForenkletNotat input)
        {
            if (input.nyttNotat == null) throw new Exception("Badrequest - notat må være angitt");

            var arkivmld = new Arkivmelding();
            var antFiler = 0;
            Saksmappe mappe = null;

            if (input.referanseSaksmappeForenklet != null)
            {
                mappe = ConvertSaksmappe(input.referanseSaksmappeForenklet);

            }

            if (input.nyttNotat != null)
            {
                var journalpost = new Journalpost();
                journalpost.Tittel = input.nyttNotat.tittel;

                journalpost.OpprettetAv = input.sluttbrukerIdentifikator;
                journalpost.ArkivertAv = input.sluttbrukerIdentifikator; //TODO ?????

                journalpost.Journalposttype = "N";
                journalpost.Journalstatus = "X"; //TODO Hva skal her?
       
                //if (input.nyttNotat.mottattDato != null)
                //{
                //    journalpst.mottattDato = input.nyttNotat.mottattDato.Value;
                //    journalpst.mottattDatoSpecified = true;
                //}
                if (input.nyttNotat.dokumentetsDato != null)
                {
                    journalpost.DokumentetsDato = input.nyttNotat.dokumentetsDato.Value;
                    journalpost.DokumentetsDatoSpecified = true;
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
                if (input.nyttNotat.hoveddokument != null)
                {
                    var dokumentbeskrivelse = new Dokumentbeskrivelse
                    {
                        Dokumenttype = "TEST", //TODO Hva skal inn her?
                        Dokumentstatus = "F",
                        TilknyttetRegistreringSom = "H",
                        Tittel = input.nyttNotat.hoveddokument.tittel
                    };

                    if (input.nyttNotat.hoveddokument.skjermetDokument)
                    {
                        dokumentbeskrivelse.Skjerming = new Skjerming()
                        {
                            //skjermingshjemmel = input.nyttNotat.skjerming?.skjermingshjemmel,
                            SkjermingDokument = "Hele"
                        };
                    }
                    var dokumentobjekt = new Dokumentobjekt
                    {
                        ReferanseDokumentfil = input.nyttNotat.hoveddokument.filnavn
                    };
                  
                    dokumentbeskrivelse.Dokumentobjekt.Add(dokumentobjekt);
                    journalpost.Dokumentbeskrivelse.Add(dokumentbeskrivelse);
                    antFiler++;
                }
                foreach (var item in input.nyttNotat.vedlegg)
                {
                    var dokumentbeskrivelse = new Dokumentbeskrivelse
                    {
                        Dokumenttype = "TEST", //TODO Hva skal inn her?
                        Dokumentstatus = "F",
                        TilknyttetRegistreringSom = "V",
                        Tittel = item.tittel
                    };

                    var dokumentobjekt = new Dokumentobjekt
                    {
                        Format = "X", //TODO Her mangler noe eller det er noe som ikke stemmer.
                        Variantformat = "X", //TODO Her mangler noe eller det er noe som ikke stemmer.
                        Versjonsnummer = "1", //TODO Her mangler noe eller det er noe som ikke stemmer.
                        Filnavn = "", //TODO Her mangler noe eller det er noe som ikke stemmer.
                        ReferanseDokumentfil = item.filnavn
                    };
       
                    dokumentbeskrivelse.Dokumentobjekt.Add(dokumentobjekt);

                    journalpost.Dokumentbeskrivelse.Add(dokumentbeskrivelse);
                    antFiler++;
                }

                //Korrespondanseparter
                foreach (var korrpart in input.nyttNotat.internAvsender.Select(internMottaker => InternKorrespondansepartToArkivPart(InternavsenderKode, internMottaker)))
                {
                    journalpost.Korrespondansepart.Add(korrpart);
                }

                foreach (var internMottaker in input.nyttNotat.internMottaker)
                {
                    var korrpart = InternKorrespondansepartToArkivPart(InternmottakerKode, internMottaker);
                    journalpost.Korrespondansepart.Add(korrpart);
                }

                if (input.nyttNotat.referanseEksternNoekkelForenklet != null)
                {
                    journalpost.ReferanseEksternNoekkel = new EksternNoekkel
                    {
                        Fagsystem = input.nyttNotat.referanseEksternNoekkelForenklet.fagsystem,
                        Noekkel = input.nyttNotat.referanseEksternNoekkelForenklet.noekkel
                    };
                }

                if (mappe != null)
                {
                    mappe.Registrering.Add(journalpost);
                    arkivmld.Mappe.Add(mappe);
                }
                else
                {
                    arkivmld.Registrering.Add(journalpost);
                }

            }
            arkivmld.AntallFiler = antFiler;
            arkivmld.System = input.nyttNotat.referanseEksternNoekkelForenklet.fagsystem;
            arkivmld.MeldingId = input.nyttNotat.referanseEksternNoekkelForenklet.noekkel;
            arkivmld.Tidspunkt = DateTime.Now;

            return arkivmld;
        }

        public static Saksmappe ConvertSaksmappe(SaksmappeForenklet input)
        {
            var mappe = new Saksmappe
            {
                Saksansvarlig = input.saksansvarlig,
                AdministrativEnhet = input.administrativEnhet,
                Tittel = input.tittel
            };
            if (input.saksaar > 0)
                mappe.Saksaar = input.saksaar.ToString();
            if (input.sakssekvensnummer > 0)
                mappe.Sakssekvensnummer = input.sakssekvensnummer.ToString();

            if (input.saksdato.HasValue)
            {
                mappe.Saksdato = input.saksdato.Value;
                mappe.SaksdatoSpecified = true;
            }

            if (input.klasse != null)
            {
                foreach (var kl in input.klasse)
                {
                    mappe.Klassifikasjon.Add(new Klassifikasjon() { Klassifikasjonssystem = kl.klassifikasjonssystem, KlasseID = kl.klasseID, Tittel = kl.tittel });
                }
            }
            if (input.referanseEksternNoekkelForenklet != null)
            {
                mappe.ReferanseEksternNoekkel = new EksternNoekkel
                {
                    Fagsystem = input.referanseEksternNoekkelForenklet.fagsystem,
                    Noekkel = input.referanseEksternNoekkelForenklet.noekkel
                };
            }

            return mappe;
        }
    }
}
