﻿using System;
using System.Diagnostics;
using System.IO;
using NUnit.Framework;

namespace KS.Fiks.IO.Arkiv.Client.Integration.Tests.SchemaTester
{
    [TestFixture]
    public class GenererKodeFraXsdTester
    {
        [Test] 
        [TestCase("arkivmelding.xsd metadatakatalog.xsd /c /n:no.ks.fiks.io.arkivmelding")]
        [TestCase("arkivmeldingKvittering.xsd metadatakatalog.xsd /c /n:no.ks.fiks.io.arkivmelding.kvittering")]
        [TestCase("sok.xsd /c /n:no.ks.fiks.io.arkivmelding.sok")]
        [TestCase("sokeresultatMinimum.xsd arkivstrukturMinimum.xsd metadatakatalog.xsd /c /n:no.ks.fiks.io.arkivmelding.sok.resultat")]
        [TestCase("sokeresultatNoekler.xsd arkivstrukturNoekler.xsd metadatakatalog.xsd /c /n:no.ks.fiks.io.arkivmelding.sok.resultat")]
        [TestCase("sokeresultatUtvidet.xsd arkivstruktur.xsd metadatakatalog.xsd /c /n:no.ks.fiks.io.arkivmelding.sok.resultat")]
        [TestCase("dokumentfilHent.xsd metadatakatalog.xsd /c /n:no.ks.fiks.io.arkivmelding.dokument.hent")]
        [TestCase("journalpostHent.xsd metadatakatalog.xsd /c /n:no.ks.fiks.io.arkivmelding.journalpost.hent")]
        [TestCase("mappeHent.xsd metadatakatalog.xsd /c /n:no.ks.fiks.io.arkivmelding.mappe.hent")]
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
    }
}