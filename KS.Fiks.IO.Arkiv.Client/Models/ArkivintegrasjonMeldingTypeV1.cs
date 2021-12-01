using System.Collections.Generic;

namespace KS.Fiks.IO.Arkiv.Client.Models
{
    public static class ArkivintegrasjonMeldingTypeV1
    {
        // Arkivintegrasjon mottaksmelding og kvitteringsmelding
        public const string Mottatt = "no.ks.fiks.arkiv.v1.mottatt";
        public const string Kvittering = "no.ks.fiks.arkiv.v1.kvittering";
        
        // Arkivmeldinger
        public const string Arkivmelding = "no.ks.fiks.arkiv.v1.arkivmelding";
        public const string MappeHent = "no.ks.fiks.arkiv.v1.mappe.hent";
        public const string MappeHentResultat = "no.ks.fiks.arkiv.v1.mappe.hent.resultat";
        public const string JournalpostHent = "no.ks.fiks.arkiv.v1.journalpost.hent";
        public const string JournalpostHentResultat = "no.ks.fiks.arkiv.v1.journalpost.hent.resultat";
        public const string DokumentfilHent = "no.ks.fiks.arkiv.v1.dokumentfil.hent";
        public const string DokumentfilHentResultat = "no.ks.fiks.arkiv.v1.dokumentfil.hent.resultat";
        
        // Sok
        public const string Sok = "no.ks.fiks.arkiv.v1.innsyn.sok";
        public const string SokResultatUtvidet = "no.ks.fiks.arkiv.v1.innsyn.sok.resultat.utvidet";
        public const string SokResultatMinimum = "no.ks.fiks.arkiv.v1.innsyn.sok.resultat.minimum";
        public const string SokResultatNoekler = "no.ks.fiks.arkiv.v1.innsyn.sok.resultat.noekler";
          
        public static readonly List<string> ArkivmeldingTyper = new List<string>()
        {
            Arkivmelding,
            MappeHent,
            MappeHentResultat,
            JournalpostHent,
            JournalpostHentResultat,
            DokumentfilHent,
            DokumentfilHentResultat
        };
            
        public static readonly List<string> SokTyper = new List<string>()
        {
            Sok,
            SokResultatUtvidet,
            SokResultatMinimum,
            SokResultatNoekler
        };

        public static bool IsArkivmeldingType(string meldingsType)
        {
            return ArkivmeldingTyper.Contains(meldingsType);
        }

        public static bool IsSokType(string meldingsType)
        {
            return SokTyper.Contains(meldingsType);
        }
    }
}