using System.Collections.Generic;

namespace KS.Fiks.IO.Arkiv.Client.Models
{
    public static class ArkivintegrasjonMeldingTypeV1
    {
        // Arkivintegrasjon mottaksmelding og kvitteringsmelding
        public const string Mottatt = "no.ks.fiks.arkiv.v1.mottatt";
        public const string Kvittering = "no.ks.fiks.arkiv.v1.kvittering";
        
        // Basis
        public const string BasisArkivmelding = "no.ks.fiks.arkiv.v1.basis.arkivmelding";
        public const string BasisSaksmappeOppdater = "no.ks.fiks.arkiv.v1.basis.saksmappe.oppdater";
        public const string BasisMappeHent = "no.ks.fiks.arkiv.v1.basis.mappe.hent";
        public const string BasisMappeHentResultat = "no.ks.fiks.arkiv.v1.basis.mappe.hent.resultat";
        public const string BasisJournalpostHent = "no.ks.fiks.arkiv.v1.basis.journalpost.hent";
        public const string BasisJournalpostHentResultat = "no.ks.fiks.arkiv.v1.basis.journalpost.hent.resultat";
        public const string BasisDokumentfilHent = "no.ks.fiks.arkiv.v1.basis.dokumentfil.hent";
        public const string BasisDokumentfilHentResultat = "no.ks.fiks.arkiv.v1.basis.dokumentfil.hent.resultat";
        
        // Sok
        public const string Sok = "no.ks.fiks.arkiv.v1.sok";
        public const string SokResultatUtvidet = "no.ks.fiks.arkiv.v1.sok.resultat.utvidet";
        public const string SokResultatMinimum = "no.ks.fiks.arkiv.v1.sok.resultat.minimum";
        public const string SokResultatNoekler = "no.ks.fiks.arkiv.v1.sok.resultat.noekler";
        
        // Komplett
        public const string KomplettArkivmelding = "no.ks.fiks.arkiv.v1.komplett.arkivmelding";
        public const string KomplettArkivmeldingUtgaaende = "no.ks.fiks.arkiv.v1.komplett.arkivmeldingUtgaaende";
        
        public static readonly List<string> BasisTyper = new List<string>()
        {
            BasisArkivmelding,
            BasisMappeHent,
            BasisJournalpostHent,
            BasisDokumentfilHent,
            BasisSaksmappeOppdater
        };
            
        public static readonly List<string> SokTyper = new List<string>()
        {
            Sok,
            SokResultatUtvidet,
            SokResultatMinimum,
            SokResultatNoekler
        };

        public static readonly List<string> KompletteTyper = new List<string>()
        {
            KomplettArkivmelding,
            KomplettArkivmeldingUtgaaende
        };

        public static bool IsBasis(string meldingsType)
        {
            return BasisTyper.Contains(meldingsType);
        }

        public static bool IsSok(string meldingsType)
        {
            return SokTyper.Contains(meldingsType);
        }
        
        public static bool IsKomplett(string meldingsType)
        { 
            return KompletteTyper.Contains(meldingsType);
        }
    }
}