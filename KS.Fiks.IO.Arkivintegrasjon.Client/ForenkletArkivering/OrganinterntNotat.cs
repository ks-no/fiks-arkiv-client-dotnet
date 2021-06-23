using System;
using System.Collections.Generic;

namespace KS.Fiks.IO.Arkivintegrasjon.Client.ForenkletArkivering {
	public class OrganinterntNotat {

		public ForenkletDokument hoveddokument;
		public EksternNoekkel referanseEksternNoekkel;
		public string tittel;
		public DateTime? dokumentetsDato;
		public List<KorrespondansepartIntern> internMottaker;
		public List<KorrespondansepartIntern> internAvsender;
		
		public List<ForenkletDokument> vedlegg;

		public OrganinterntNotat(){
			vedlegg = new List<ForenkletDokument>();
			internAvsender = new List<KorrespondansepartIntern>();
			internMottaker = new List<KorrespondansepartIntern>();
		}
	}
}