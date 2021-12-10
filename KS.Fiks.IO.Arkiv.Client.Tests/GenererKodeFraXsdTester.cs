using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using NUnit.Framework;
using XmlSchemaClassGenerator;

namespace KS.Fiks.IO.Arkiv.Client.Integration.Tests.SchemaTester
{
    [TestFixture]
    public class GenererKodeFraXsdTester
    {
        [Test]
        //[Ignore("Kjøres manuelt ved behov da den ikke kan kjøres på Jenkins")]
        [TestCase("arkivmelding.xsd metadatakatalog.xsd /c /n:no.ks.fiks.arkiv.v1.arkivering.arkivmelding")]
        [TestCase("arkivmeldingKvittering.xsd metadatakatalog.xsd /c /n:no.ks.fiks.arkiv.v1.arkivering.arkivmelding.kvittering")]
        [TestCase("sok.xsd /c /n:no.ks.fiks.arkiv.v1.innsyn.sok")]
        [TestCase("sokeresultatMinimum.xsd arkivstrukturMinimum.xsd metadatakatalog.xsd /c /n:no.ks.fiks.arkiv.v1.innsyn.sok.resultat")]
        [TestCase("sokeresultatNoekler.xsd arkivstrukturNoekler.xsd metadatakatalog.xsd /c /n:no.ks.fiks.arkiv.v1.innsyn.sok.resultat")]
        [TestCase("sokeresultatUtvidet.xsd arkivstruktur.xsd metadatakatalog.xsd /c /n:no.ks.fiks.arkiv.v1.innsyn.sok.resultat")]
        [TestCase("dokumentfilHent.xsd metadatakatalog.xsd /c /n:no.ks.fiks.arkiv.v1.innsyn.dokumentfil.hent")]
        [TestCase("journalpostHent.xsd metadatakatalog.xsd /c /n:no.ks.fiks.arkiv.v1.innsyn.journalpost.hent")]
        [TestCase("journalpostHentResultat.xsd arkivmelding.xsd metadatakatalog.xsd /c /n:no.ks.fiks.arkiv.v1.innsyn.journalpost.hent.resultat")]
        [TestCase("mappeHent.xsd metadatakatalog.xsd /c /n:no.ks.fiks.arkiv.v1.innsyn.mappe.hent")]
        [TestCase("mappeHentResultat.xsd arkivmelding.xsd metadatakatalog.xsd /c /n:no.ks.fiks.arkiv.v1.innsyn.mappe.hent.resultat")]
        public void Generer_fra_xsd(string arguments)
        {
            //TODO Denne testen klarer ikke å bli kjørt på Jenkins. Mest sannsynlig fordi xsd.exe ikke er tilgjengelig som kommando. 
            //TODO Løsning:  Bygg en docker som har xsd.exe og kjører testen i docker. 
            var workingDir = Directory.GetCurrentDirectory() + "/Schema";
            var process = new Process
            {
                StartInfo =
                {
                    FileName = "xsd",
                    Arguments = arguments,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    ErrorDialog = false,
                    WorkingDirectory = workingDir
                },
                EnableRaisingEvents = true,
            };
            process.Start();
            
            var stdout = process.StandardOutput.ReadToEnd();
            
            process.StandardInput.Flush();
            process.StandardInput.Close();
            process.WaitForExit(5000);

            var exitCode = process.ExitCode;
            
            Console.Out.WriteLine(stdout);
           
            Assert.True(exitCode == 0, $"Feilet med exitCode {exitCode}. Se output for detaljer.");
            Assert.False(stdout.ToLower().Contains("exception"), $"Exception melding i output. Sjekk output for mer detaljer."); 
            Assert.False(stdout.Contains("Error"), $"Error melding i output. Sjekk output for mer detaljer."); 
            Assert.False(stdout.Contains("Warning"),$"Warning melding i output. Sjekk output for mer detaljer."); 
        }

        [Test]
        public void GenerateWithXmlSchemaClassGenerator()
        {

            var fileList = new List<string>
            {
                "metadatakatalog.xsd",
                "arkivmelding.xsd", 
                "arkivmeldingKvittering.xsd",
                "sok.xsd",
                "sokeresultatUtvidet.xsd", 
                "sokeresultatMinimum.xsd", 
                "sokeresultatNoekler.xsd", 
                "arkivstrukturMinimum.xsd", 
                "arkivstrukturNoekler.xsd",
                "arkivstruktur.xsd",
                "dokumentfilHent.xsd",
                "journalpostHent.xsd",
                "journalpostHentResultat.xsd",
                "mappeHent.xsd",
                "mappeHentResultat.xsd"
            };

            var workingDir = Directory.GetCurrentDirectory() + "/Schema/";
            
            // Legg til workingdir prefix for schema
            for (var i = 0; i < fileList.Count; i++)
            {
                fileList[i] = workingDir + fileList[i];
            }

            var outputDir = Directory.GetCurrentDirectory() + "/Schema/Output";

            var commonNamespace = "Fiks.Arkiv.v1";


            var generator = new Generator
            {
                OutputFolder = outputDir,
                Log = s => Console.Out.WriteLine(s),
                GenerateNullables = false,
                SeparateClasses = true,
                NamespaceProvider = new NamespaceProvider
                {
                    {new NamespaceKey("http://www.arkivverket.no/standarder/noark5/metadatakatalog/v2"), commonNamespace + ".Metadatakatalog"},
                    {new NamespaceKey("http://www.arkivverket.no/standarder/noark5/arkivmelding/v2"), commonNamespace + ".Arkivering.Arkivmelding"},
                    {new NamespaceKey("http://www.arkivverket.no/standarder/noark5/arkivmeldingkvittering/v2"), commonNamespace + ".Arkivering.Arkivmeldingkvittering"},
                    {new NamespaceKey("http://www.ks.no/standarder/fiks/arkiv/sok/v1"), commonNamespace + ".Innsyn.Sok"},
                    {new NamespaceKey("http://www.ks.no/standarder/fiks/arkiv/sokeresultat/v1"), commonNamespace + ".Innsyn.Sok"},
                    {new NamespaceKey("http://www.ks.no/standarder/fiks/arkiv/arkivstruktur/minimum/v1"), commonNamespace + ".Arkivstruktur"},
                    {new NamespaceKey("http://www.ks.no/standarder/fiks/arkiv/arkivstruktur/noekler/v1"), commonNamespace + ".Arkivstruktur"},
                    {new NamespaceKey("http://www.arkivverket.no/standarder/noark5/arkivstruktur"), commonNamespace + ".Arkivstruktur"},
                    {new NamespaceKey("http://www.arkivverket.no/standarder/noark5/dokumentfil/hent/v2"), commonNamespace + ".Innsyn.Hent"},
                    {new NamespaceKey("http://www.arkivverket.no/standarder/noark5/journalpost/hent/v2"), commonNamespace + ".Innsyn.Hent"},
                    {new NamespaceKey("http://www.arkivverket.no/standarder/noark5/journalpost/hent/resultat/v2"), commonNamespace + ".Innsyn.Hent"},
                    {new NamespaceKey("http://www.arkivverket.no/standarder/noark5/mappe/hent/v2"), commonNamespace + ".Innsyn.Hent"},
                }
            };
            generator.Generate(fileList);
        }
    }
}
