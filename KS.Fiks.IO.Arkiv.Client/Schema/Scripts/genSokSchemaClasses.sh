#!/bin/bash
#echo "Genererer klasser fra sok.xsd"
cd ./..
xsd sok.xsd /n:no.ks.fiks.io.arkivmelding.sok /o:Output /c

echo "Genererer klasser fra sokeresultatMinimum.xsd"
xsd sokeresultatMinimum.xsd arkivstrukturMinimum.xsd metadatakatalog.xsd /n:no.ks.fiks.io.arkivmelding.sok.resultat /o:Output /c

echo "Genererer klasser fra sokeresultatNoekler.xsd"
xsd sokeresultatNoekler.xsd arkivstrukturNoekler.xsd metadatakatalog.xsd /n:no.ks.fiks.io.arkivmelding.sok.resultat /o:Output /c

echo "Genererer klasser fra sokeresultatUtvidet.xsd"
xsd sokeresultatUtvidet.xsd arkivstruktur.xsd metadatakatalog.xsd /n:no.ks.fiks.io.arkivmelding.sok.resultat /o:Output /c