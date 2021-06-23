using FIKS.eMeldingArkiv.eMeldingForenkletArkiv;

namespace ks.fiks.io.arkivintegrasjon.client.ForenkletArkivering {
	public class ForenkletDokument {

		/// <summary>
		/// Definisjon: Navn på type dokument
		/// 
		/// Kilde: Registreres automatisk av systemet eller manuelt
		/// 
		/// Kommentarer: (ingen)
		/// 
		/// M083
		/// </summary>
		public Kode dokumenttype;
		/// <summary>
		/// veFilnavn i n4
		/// </summary>
		public string filnavn;
		/// <summary>
		/// Definisjon: Tittel eller navn på arkivenheten
		/// 
		/// Kilde: Registreres manuelt eller hentes automatisk fra innholdet i
		/// arkivdokumentet. Ja fra klassetittel dersom alle mapper skal ha samme tittel
		/// som klassen. Kan også hentes automatisk fra et fagsystem.
		/// 
		/// Kommentarer: For saksmappe og journalpost vil dette tilsvare "Sakstittel" og
		/// "Dokumentbeskrivelse". Disse navnene kan beholdes i grensesnittet.
		/// 
		/// M020
		/// </summary>
		public string tittel;
		public bool skjermetDokument;

		public ForenkletDokument(){

		}
	}
}