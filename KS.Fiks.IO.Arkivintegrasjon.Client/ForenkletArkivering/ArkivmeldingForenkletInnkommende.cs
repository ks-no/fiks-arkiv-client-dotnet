using FIKS.eMeldingArkiv.eMeldingForenkletArkiv;

namespace ks.fiks.io.arkivintegrasjon.client.ForenkletArkivering { 
	public class ArkivmeldingForenkletInnkommende {

		public Saksmappe referanseSaksmappe;
		public InnkommendeJournalpost nyInnkommendeJournalpost;
		public string sluttbrukerIdentifikator;
		
		public ArkivmeldingForenkletInnkommende(){
		}
	}
}