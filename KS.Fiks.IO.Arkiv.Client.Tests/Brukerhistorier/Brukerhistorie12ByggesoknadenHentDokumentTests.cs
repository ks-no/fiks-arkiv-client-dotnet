using System;
using KS.Fiks.IO.Arkiv.Client.ForenkletArkivering;
using KS.Fiks.IO.Arkiv.Client.Models.Innsyn.Sok;
using Microsoft.VisualBasic.FileIO;
using NUnit.Framework;

namespace KS.Fiks.IO.Arkiv.Client.Tests.Brukerhistorier
{
    public class Brukerhistorie12ByggesoknadHentDokumentTests
    {
        /// <summary>
        /// Goal: Fetch saksmappe using cadastre information
        /// Input: Kommunenr, gårdsnummer and bruksnummer
        /// Expected output: Saksmappe 
        /// </summary>
        [Test]
        public void testFinnSaksmappeFraMatrikkel()
        {
            var KNR = 1149;
            var GNR = 43;
            var BNR = 271;
            
            var arkivmeldingsok = new Sok
            {
                Respons = Respons.Saksmappe,
                MeldingId = Guid.NewGuid().ToString(),
                System = "Fagsystem X",
                Tidspunkt = DateTime.Now,
                Skip = 0,
                Take = 100
            };
            
            // PARAMETER DEFINITIONS START
            var knrParam = new Parameter
            {
                Felt = SokFelt.SakPeriodMatrikkelnummerPeriodKommunenummer,
                Operator = OperatorType.Equal,
                Parameterverdier = new Parameterverdier
                {
                    Intvalues = {KNR}
                }
            };
            
            var gnrParam = new Parameter
            {
                Felt = SokFelt.SakPeriodMatrikkelnummerPeriodGaardsnummer,
                Operator = OperatorType.Equal,
                Parameterverdier = new Parameterverdier
                {
                    Intvalues = { GNR }
                }
            };
            
            var bnrParam = new Parameter
            {
                Felt = SokFelt.SakPeriodMatrikkelnummerPeriodBruksnummer,
                Operator = OperatorType.Equal,
                Parameterverdier = new Parameterverdier
                {
                    Intvalues = { BNR }
                }
            };
            // PARAMETER DEFINITIONS END 
            
            // Create new search with the defined parameters 
            arkivmeldingsok.Parameter.Add(knrParam); 
            arkivmeldingsok.Parameter.Add(gnrParam);
            arkivmeldingsok.Parameter.Add(bnrParam);
            var payload = ArkivmeldingSerializeHelper.Serialize(arkivmeldingsok);
            
            if (!Validator.IsValidSokXml(payload))
            {
                Assert.Fail("Validation errors");
            }
            
            Assert.Pass();
        }
        
        /// <summary>
        /// Goal: Fetch Saksmappe based on bygningsnummer
        /// Input: Bygningsnummer
        /// Output: Saksmappe
        /// </summary>
         [Test]
        public void testFinnSaksmappeFraBygningsnummer()
        {
            var bygningsnummer = 80486367;
            
            var arkivmeldingsok = new Sok
            {
                Respons = Respons.Saksmappe,
                MeldingId = Guid.NewGuid().ToString(),
                System = "Fagsystem X",
                Tidspunkt = DateTime.Now,
                Skip = 0,
                Take = 100
            };
            
            // PARAMETER DEFINITIONS START
            var bygNummerParam = new Parameter
            {
                Felt = SokFelt.SakPeriodByggidentPeriodBygningsnummer,
                Operator = OperatorType.Equal,
                Parameterverdier = new Parameterverdier
                {
                    Intvalues = { bygningsnummer }
                }
            };
            // PARAMETER DEFINITIONS END 

            // Create new search with the defined parameters 
            arkivmeldingsok.Parameter.Add(bygNummerParam);

            var payload = ArkivmeldingSerializeHelper.Serialize(arkivmeldingsok);
            
            if (!Validator.IsValidSokXml(payload))
            {
                Assert.Fail("Validation errors");
            }
            
            Assert.Pass();
        }
    }
}