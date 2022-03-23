using System;
using System.Linq;
using KS.Fiks.IO.Arkiv.Client.Models.Arkivering.Arkivmelding;
using KS.Fiks.IO.Arkiv.Client.Models.Kodelister;
using KS.Fiks.IO.Arkiv.Client.Models.Metadatakatalog;

namespace KS.Fiks.IO.Arkiv.Client.ForenkletArkivering
{
    public class ArkivmeldingFactory
    {
        private static readonly string Skjermingshjemmel = "Offl. § 26.1";
        private const string MottakerKode = "EM";
        private const string AvsenderKode = "EA";
        private const string InternavsenderKode = "IA";
        private const string InternmottakerKode = "IM";
        private const string JournalstatusDefault = "J";
        private const string VariantformatProduksjonsformat = "P";
        private const string VersjonsnummerDefault = "1";
        private const string SkjermingDokumentHele = "Hele";
        private readonly Models.Kodelister.Kode _dokumentstatusKodeDefault;
        private readonly Models.Kodelister.Kode _dokumenttypeKodeDefault;
        private readonly Models.Kodelister.Kode _journalposttypeUtgaaende;

        public ArkivmeldingFactory()
        {
            _dokumenttypeKodeDefault = DokumenttypeKoder.Korrespondanse;
            _dokumentstatusKodeDefault = DokumentstatusKoder.Ferdig;
            _journalposttypeUtgaaende = JournalposttypeKoder.UtgaaendeDokument;
        }

        public Arkivmelding GetArkivmelding(OppdaterSaksmappe input)
        {
            var test = DokumenttypeKoder.Korrespondanse.Verdi;
            if (input.oppdaterSaksmappeForenklet == null)
            {
                throw new Exception("Badrequest - saksmappe må være angitt");    
            }
            
            var arkivmelding = new Arkivmelding();
            const int antFiler = 0;
            
            arkivmelding.Mappe.Add(ConvertSaksmappe(input.oppdaterSaksmappeForenklet));

            arkivmelding.AntallFiler = antFiler;
            arkivmelding.System = input.oppdaterSaksmappeForenklet.referanseEksternNoekkelForenklet?.fagsystem;
            arkivmelding.MeldingId = input.oppdaterSaksmappeForenklet.referanseEksternNoekkelForenklet?.noekkel;
            arkivmelding.Tidspunkt = DateTime.Now;

            return arkivmelding;
        }
        public Arkivmelding GetArkivmelding(ArkivmeldingForenkletUtgaaende input) {

            if (input.nyUtgaaendeJournalpost == null)
            {
                throw new Exception("Badrequest - journalpost må være angitt");
            }

            var arkivmelding = new Arkivmelding();
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

                    Journalposttype = new Journalposttype()
                    {
                        Verdi = _journalposttypeUtgaaende.Verdi,
                        Beskrivelse = _journalposttypeUtgaaende.Beskrivelse
                    },
                    Journalstatus = new Journalstatus()
                    {
                        Verdi = JournalstatusDefault,
                        Beskrivelse = ""
                    }

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
                journalpost.ArkivertAv = input.sluttbrukerIdentifikator; 
                
                // Skjerming
                if (input.nyUtgaaendeJournalpost.skjermetTittel)
                {
                    journalpost.Skjerming = new Skjerming
                    {
                        Skjermingshjemmel = Skjermingshjemmel,
                        SkjermingMetadata =
                        {
                            new SkjermingMetadata
                            {
                                Verdi = "tittel",
                                Beskrivelse = ""
                            },
                            new SkjermingMetadata 
                            {
                                Verdi = "korrespondansepart",
                                Beskrivelse = ""
                            }
                        }
                    };
                }

                // Håndtere alle filer
                if (input.nyUtgaaendeJournalpost.hoveddokument != null)
                {
                    var dokumentbeskrivelse = new Dokumentbeskrivelse
                    {
                        Dokumenttype = new Dokumenttype
                        {
                            Verdi = input.nyUtgaaendeJournalpost.hoveddokument.dokumenttype != null ? input.nyUtgaaendeJournalpost.hoveddokument.dokumenttype.kodeverdi : _dokumenttypeKodeDefault.Verdi,
                            Beskrivelse = input.nyUtgaaendeJournalpost.hoveddokument.dokumenttype != null ? input.nyUtgaaendeJournalpost.hoveddokument.dokumenttype.kodebeskrivelse : _dokumenttypeKodeDefault.Beskrivelse
                        },
                        Dokumentstatus = new Dokumentstatus
                        {
                            Verdi = _dokumentstatusKodeDefault.Verdi,
                            Beskrivelse = _dokumentstatusKodeDefault.Beskrivelse
                        },
                        Tittel = input.nyUtgaaendeJournalpost.hoveddokument.tittel,
                        TilknyttetRegistreringSom = new TilknyttetRegistreringSom
                        {
                            Verdi = "H",
                            Beskrivelse = "" //TODO Finn en defaultbeskrivelse
                        }
                    };

                    if (input.nyUtgaaendeJournalpost.hoveddokument.skjermetDokument) {
                        dokumentbeskrivelse.Skjerming = new Skjerming()
                        {
                            Skjermingshjemmel = Skjermingshjemmel,
                            SkjermingDokument = new SkjermingDokument
                            {
                                Verdi = SkjermingDokumentHele,
                                Beskrivelse = ""
                            }
                        };
                    }

                    var filnavn = input.nyUtgaaendeJournalpost.hoveddokument.filnavn;
                    
                    var dok = new Dokumentobjekt
                    {
                        Format = new Format
                        {
                            Verdi = filnavn.Substring(filnavn.LastIndexOf('.')),
                            Beskrivelse = "",
                        },
                        Variantformat = new Variantformat()
                        {
                            Verdi = VariantformatProduksjonsformat,
                            Beskrivelse = ""
                        },
                        Versjonsnummer = VersjonsnummerDefault, 
                        Filnavn = filnavn,
                        ReferanseDokumentfil = input.nyUtgaaendeJournalpost.hoveddokument.referanseDokumentFil
                    };
                    
                    dokumentbeskrivelse.Dokumentobjekt.Add(dok);

                    journalpost.Dokumentbeskrivelse.Add(dokumentbeskrivelse);
                    antFiler++;
                }
                foreach (var item in input.nyUtgaaendeJournalpost.vedlegg)
                {
                    var dokbesk = new Dokumentbeskrivelse
                    {
                        Dokumenttype = new Dokumenttype()
                        {
                            Verdi = item.dokumenttype != null ? item.dokumenttype.kodeverdi : _dokumenttypeKodeDefault.Verdi,
                            Beskrivelse = item.dokumenttype != null ? item.dokumenttype.kodebeskrivelse : _dokumenttypeKodeDefault.Beskrivelse
                        },
                        Dokumentstatus = new Dokumentstatus()
                        {
                            Verdi = _dokumentstatusKodeDefault.Verdi,
                            Beskrivelse = _dokumentstatusKodeDefault.Beskrivelse
                        },
                        Tittel = item.tittel,
                        TilknyttetRegistreringSom = new TilknyttetRegistreringSom()
                        {
                            Verdi = "V",
                            Beskrivelse = "" //TODO 
                        }
                    };

                    var filnavn = item.filnavn;

                    var dok = new Dokumentobjekt
                    {
                        Format = new Format()
                        {
                            Verdi = filnavn.Substring(filnavn.LastIndexOf('.')), //TODO
                            Beskrivelse = "" //TODO
                        },
                        Variantformat = new Variantformat()
                        {
                            Verdi = VariantformatProduksjonsformat,
                            Beskrivelse = "" //TODO
                        },
                        Versjonsnummer = VersjonsnummerDefault,
                        Filnavn = filnavn, 
                        ReferanseDokumentfil = item.referanseDokumentFil
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
                    arkivmelding.Mappe.Add(saksmappe);
                } else {
                    arkivmelding.Registrering.Add(journalpost);
                }
            }
            
            arkivmelding.AntallFiler = antFiler;
            arkivmelding.System = input.nyUtgaaendeJournalpost.referanseEksternNoekkelForenklet?.fagsystem;
            arkivmelding.MeldingId = input.nyUtgaaendeJournalpost.referanseEksternNoekkelForenklet?.noekkel;
            arkivmelding.Tidspunkt = DateTime.Now;

            return arkivmelding;
        }

        private Korrespondansepart KorrespondansepartToArkivPart(string partRolle, KorrespondansepartForenklet mottaker)
        {
            var korrespondansepart = new Korrespondansepart()
            {
                KorrespondansepartNavn = mottaker.navn,
                Korrespondanseparttype = new Korrespondanseparttype()
                {
                    Verdi = partRolle,
                    Beskrivelse = ""
                },
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
                korrespondansepart.Land = mottaker.enhetsidentifikator.landkode;
            }
            
            if (mottaker.personid?.personidentifikatorNr != null) {
                korrespondansepart.Personid = mottaker.personid?.personidentifikatorNr;
                korrespondansepart.Land = mottaker.personid?.personidentifikatorLandkode;
            }

            return korrespondansepart;
        }
        
        private static Korrespondansepart InternKorrespondansepartToArkivPart(string internKode, KorrespondansepartIntern intern)
        {
            return new Korrespondansepart
            {
                KorrespondansepartNavn = intern.saksbehandler ?? intern.administrativEnhet,
                Korrespondanseparttype = new Korrespondanseparttype()
                {
                    Verdi = internKode,
                    Beskrivelse = "" //TODO
                },
                AdministrativEnhet = intern.administrativEnhet,
                Saksbehandler = intern.saksbehandler
            };
        }

        public Arkivmelding GetArkivmelding(ArkivmeldingForenkletInnkommende input)
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

                journalpost.Journalposttype = new Journalposttype()
                {
                    Verdi = "I",
                    Beskrivelse = "" //TODO
                };
                journalpost.Journalstatus = new Journalstatus()
                {
                    Verdi = JournalstatusDefault,
                    Beskrivelse = "" //TODO
                };
                
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
                journalpost.ArkivertAv = input.sluttbrukerIdentifikator; //TODO ????? Hva er egentlig problemet her? Samme bruker ikke bra?
                
                // Skjerming
                if (input.nyInnkommendeJournalpost.skjermetTittel)
                {
                    journalpost.Skjerming = new Skjerming()
                    {
                        Skjermingshjemmel = input.nyInnkommendeJournalpost.skjermingForenklet?.skjermingshjemmel,
                        SkjermingMetadata = { 
                            new SkjermingMetadata()
                            {
                                Verdi = "tittel",
                                Beskrivelse = "",
                            },
                            new SkjermingMetadata()
                            {
                                Verdi = "korrespondansepart",
                                Beskrivelse = ""
                            }
                        }
                    };
                }
                
                // Håndtere alle filer
                if (input.nyInnkommendeJournalpost.hoveddokument != null)
                {
                    var filnavn = input.nyInnkommendeJournalpost.hoveddokument.filnavn;
                    var dokbesk = new Dokumentbeskrivelse()
                    {
                        Dokumenttype = new Dokumenttype()
                        {
                            Verdi = input.nyInnkommendeJournalpost.hoveddokument.dokumenttype != null ? input.nyInnkommendeJournalpost.hoveddokument.dokumenttype.kodeverdi : _dokumenttypeKodeDefault.Verdi,
                            Beskrivelse = input.nyInnkommendeJournalpost.hoveddokument.dokumenttype != null ? input.nyInnkommendeJournalpost.hoveddokument.dokumenttype.kodebeskrivelse : _dokumenttypeKodeDefault.Beskrivelse,
                        },
                        Dokumentstatus = new Dokumentstatus()
                        {
                            Verdi = _dokumentstatusKodeDefault.Verdi,
                            Beskrivelse = _dokumentstatusKodeDefault.Beskrivelse
                        },
                        TilknyttetRegistreringSom = new TilknyttetRegistreringSom()
                        {
                            Verdi = "H",
                            Beskrivelse = "" //TODO
                        },
                        Tittel = input.nyInnkommendeJournalpost.hoveddokument.tittel
                    };
                    
                    if (input.nyInnkommendeJournalpost.hoveddokument.skjermetDokument)
                    {
                        dokbesk.Skjerming = new Skjerming()
                        {
                            Skjermingshjemmel = input.nyInnkommendeJournalpost.skjermingForenklet?.skjermingshjemmel,
                            SkjermingDokument = new SkjermingDokument()
                            {
                                Verdi = "Hele",
                                Beskrivelse = "" //TODO
                            }
                        };
                    }
                    var dok = new Dokumentobjekt()
                    {
                        Format = new Format()
                        {
                            Verdi = filnavn.Substring(filnavn.LastIndexOf('.')),
                            Beskrivelse = "" //TODO
                        },
                        Variantformat = new Variantformat()
                        {
                            Verdi = VariantformatProduksjonsformat,
                            Beskrivelse = ""
                        },
                        Versjonsnummer = VersjonsnummerDefault,
                        Filnavn = filnavn,
                        ReferanseDokumentfil = input.nyInnkommendeJournalpost.hoveddokument.referanseDokumentFil
                    };

                    dokbesk.Dokumentobjekt.Add(dok);
                    journalpost.Dokumentbeskrivelse.Add(dokbesk);
                    antFiler++;
                }
                foreach (var item in input.nyInnkommendeJournalpost.vedlegg)
                {
                    var dokbesk = new Dokumentbeskrivelse
                    {
                        Dokumenttype = new Dokumenttype()
                        {
                            Verdi = item.dokumenttype != null ? item.dokumenttype.kodeverdi : _dokumenttypeKodeDefault.Verdi,
                            Beskrivelse = item.dokumenttype != null ? item.dokumenttype.kodebeskrivelse : _dokumenttypeKodeDefault.Beskrivelse
                        },
                        Dokumentstatus = new Dokumentstatus()
                        {
                            Verdi = _dokumentstatusKodeDefault.Verdi,
                            Beskrivelse = _dokumentstatusKodeDefault.Beskrivelse
                        },
                        TilknyttetRegistreringSom = new TilknyttetRegistreringSom()
                        {
                            Verdi = "V",
                            Beskrivelse = "" //TODO
                        },
                        Tittel = item.tittel
                    };

                    var filnavn = item.filnavn;
                    
                    var dok = new Dokumentobjekt
                    {
                        Format = new Format()
                        {
                            Verdi = filnavn.Substring(filnavn.LastIndexOf('.')),
                            Beskrivelse = "" //TODO
                        },
                        Variantformat = new Variantformat()
                        {
                            Verdi = VariantformatProduksjonsformat,
                            Beskrivelse = "" //TODO
                        },
                        Versjonsnummer = VersjonsnummerDefault,
                        Filnavn = filnavn,
                        ReferanseDokumentfil = item.referanseDokumentFil
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

        public Arkivmelding GetArkivmelding(ArkivmeldingForenkletNotat input)
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
                journalpost.ArkivertAv = input.sluttbrukerIdentifikator;

                journalpost.Journalposttype = new Journalposttype()
                {
                    Verdi = "N",
                    Beskrivelse = "" //TODO
                };
                journalpost.Journalstatus = new Journalstatus()
                {
                    Verdi = JournalstatusDefault,
                    Beskrivelse = "" //TODO
                };
                
                if (input.nyttNotat.dokumentetsDato != null)
                {
                    journalpost.DokumentetsDato = input.nyttNotat.dokumentetsDato.Value;
                    journalpost.DokumentetsDatoSpecified = true;
                }
                
                //Håndtere alle filer
                if (input.nyttNotat.hoveddokument != null)
                {
                    var dokumentbeskrivelse = new Dokumentbeskrivelse
                    {
                        Dokumenttype = new Dokumenttype()
                        {
                            Verdi = input.nyttNotat.hoveddokument.dokumenttype != null ? input.nyttNotat.hoveddokument.dokumenttype.kodeverdi : _dokumenttypeKodeDefault.Verdi,
                            Beskrivelse = input.nyttNotat.hoveddokument.dokumenttype != null ? input.nyttNotat.hoveddokument.dokumenttype.kodebeskrivelse : _dokumenttypeKodeDefault.Beskrivelse
                        }, 
                        Dokumentstatus = new Dokumentstatus()
                        {
                            Verdi = _dokumentstatusKodeDefault.Verdi,
                            Beskrivelse = _dokumentstatusKodeDefault.Beskrivelse
                        },
                        TilknyttetRegistreringSom = new TilknyttetRegistreringSom()
                        {
                            Verdi = "H",
                            Beskrivelse = ""
                        },
                        Tittel = input.nyttNotat.hoveddokument.tittel
                    };

                    if (input.nyttNotat.hoveddokument.skjermetDokument)
                    {
                        dokumentbeskrivelse.Skjerming = new Skjerming()
                        {
                            SkjermingDokument = new SkjermingDokument()
                            {
                                Verdi = SkjermingDokumentHele,
                                Beskrivelse = "" //TODO
                            }
                        };
                    }
                    
                    var filnavn = input.nyttNotat.hoveddokument.filnavn;
                    
                    var dokumentobjekt = new Dokumentobjekt
                    {
                        Format = new Format()
                        {
                            Verdi = filnavn.Substring(filnavn.LastIndexOf('.')),
                            Beskrivelse = "" //TODO
                        },
                        Variantformat = new Variantformat()
                        {
                            Verdi = VariantformatProduksjonsformat,
                            Beskrivelse = "" //TODO
                        },
                        Versjonsnummer = VersjonsnummerDefault,
                        Filnavn = filnavn,
                        ReferanseDokumentfil = input.nyttNotat.hoveddokument.referanseDokumentFil
                    };
                  
                    dokumentbeskrivelse.Dokumentobjekt.Add(dokumentobjekt);
                    journalpost.Dokumentbeskrivelse.Add(dokumentbeskrivelse);
                    antFiler++;
                }
                foreach (var item in input.nyttNotat.vedlegg)
                {
                    var dokumentbeskrivelse = new Dokumentbeskrivelse
                    {
                        Dokumenttype = new Dokumenttype()
                        {
                            Verdi  = item.dokumenttype.kodeverdi,
                            Beskrivelse = "" //TODO
                        },
                        Dokumentstatus = new Dokumentstatus()
                        {
                            Verdi  = _dokumentstatusKodeDefault.Verdi,
                            Beskrivelse = _dokumentstatusKodeDefault.Beskrivelse
                        },
                        TilknyttetRegistreringSom = new TilknyttetRegistreringSom()
                        {
                           Verdi = "V",
                           Beskrivelse = "" //TODO
                        },
                        Tittel = item.tittel
                    };

                    var filnavn = item.filnavn;
                    var dokumentobjekt = new Dokumentobjekt
                    {
                        Format = new Format()
                        {
                            Verdi = filnavn.Substring(filnavn.LastIndexOf('.')),
                            Beskrivelse = "" //TODO
                        },
                        Variantformat = new Variantformat()
                        {
                            Verdi   = VariantformatProduksjonsformat,
                            Beskrivelse = "" //TODO
                        },
                        Versjonsnummer = VersjonsnummerDefault,
                        Filnavn = filnavn,
                        ReferanseDokumentfil = item.referanseDokumentFil
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
