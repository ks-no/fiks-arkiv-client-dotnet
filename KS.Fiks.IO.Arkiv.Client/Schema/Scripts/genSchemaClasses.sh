#!/bin/bash
echo "Genererer klasser fra arkivmelding.xsd"
cd ./..
xsd arkivmelding.xsd arkivmeldingKvittering.xsd dokumentfilHent.xsd journalpostHent.xsd journalpostHentResultat.xsd mappeHent.xsd mappeHentResultat.xsd metadatakatalog.xsd sokeresultatMinimum.xsd arkivstrukturMinimum.xsd sokeresultatNoekler.xsd arkivstrukturNoekler.xsd sokeresultatUtvidet.xsd /c /n:no.ks.fiks.io.arkiv /o:Output