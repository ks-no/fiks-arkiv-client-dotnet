# fiks-arkiv-client

## OBS: Dette repoet er deprecated!
Nytt repository for skjema og spesifikasjonen finnes her: https://github.com/ks-no/fiks-arkiv-specification

Nytt repository som genererer .NET kode basert på spesifikasjonen nevnt ovenfor og leverer nuget-pakken [KS.Fiks.Arkiv.Models.V1](https://www.nuget.org/packages/KS.Fiks.Arkiv.Models.V1) finnes her: https://github.com/ks-no/fiks-arkiv-models-dotnet

## Hva er dette?

Dette er koden for nuget-pakken [**KS.Fiks.IO.Arkiv.Client**](https://www.nuget.org/packages/KS.Fiks.IO.Arkiv.Client/).
Nuget pakken gir hjelp til å bygge **arkivmelding** for forenklet arkivering.

Eksempler på bruk kan man finne i [**fiks-arkiv**](https://github.com/ks-no/fiks-arkiv) repoet som demonstrerer implementasjon. 

## Tester
Brukerhistoriene som det refereres til i testene i **KS.Fiks.IO.Arkiv.Client.Tests/Brukerhistorier** er dokumentert i [**wiki**](https://github.com/ks-no/fiks-arkiv/wiki/Brukstilfeller) for [**fiks-arkiv**](https://github.com/ks-no/fiks-arkiv) repoet.

## Integration tests
Egen solution som ligger under KS.Fiks.IO.Arkiv.Client.Integration.Tests
Denne må oppdateres med siste versjon av nuget pakken for KS.Fiks.IO.Client og så brukes det som kommer med i pakken for testing.
Testene kan være mer avanserte, som f.eks. bruke xsd.exe for å sjekke at generering av kode fra xsd fungerer som det skal.
