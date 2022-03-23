namespace KS.Fiks.IO.Arkiv.Client.Models.Kodelister
{
    public static class DokumenttypeKoder
    {
        //TODO Disse er hentet herfra: http://arkivverket.metakat.no/Diagram/Index/EAID_CC654F7F_60CA_4240_A003_B6557201F2BC
        public static readonly Kode Brev = new Kode("B", "Brev");
        public static readonly Kode Rundskriv = new Kode("R", "Rundskriv");
        public static readonly Kode Faktura = new Kode("F", "Faktura");
        public static readonly Kode Ordrebekreftelse = new Kode("O", "Ordrebekreftelse");
        
        //TODO Og disse er hentet herfra: https://www.ks.no/fagomrader/digitalisering/felleslosninger/verktoykasse-plan--og-byggesak/verktoy/nasjonal-veileder-for-dokumenttyper-og--kategorier/
        public static readonly Kode Soeknad = new Kode("SØKNAD", "Søknad");
        public static readonly Kode Melding = new Kode("MELDING", "Melding");
        public static readonly Kode Korrespondanse = new Kode("KORR", "Korrespondanse");
        public static readonly Kode Kart = new Kode("KART", "Kart");
        public static readonly Kode Foto = new Kode("FOTO", "Foto");
        public static readonly Kode Tegning = new Kode("TEGNING", "Tegning");
        public static readonly Kode AnsvarOgKontroll = new Kode("ANSVKONTO", "Ansvar og kontroll");
        public static readonly Kode Tilsyn = new Kode("TILSYN", "Tilsyn");
        public static readonly Kode Avtale = new Kode("Avtale", "Avtale");
        public static readonly Kode Vedtak = new Kode("VEDTAK", "Vedtak");
    }
}