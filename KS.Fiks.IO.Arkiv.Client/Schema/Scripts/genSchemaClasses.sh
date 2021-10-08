#!/bin/bash
echo "Genererer klasser fra arkivmelding.xsd"
cd ./..
xsd arkivmelding.xsd metadatakatalog.xsd /c  /n:no.ks.fiks.io.arkivmelding /o:Output