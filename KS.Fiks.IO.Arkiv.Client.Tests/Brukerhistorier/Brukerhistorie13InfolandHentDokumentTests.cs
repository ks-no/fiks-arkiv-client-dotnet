using System;
using KS.Fiks.IO.Arkiv.Client.ForenkletArkivering;
using KS.Fiks.IO.Arkiv.Client.Models.Innsyn.Sok;
using NUnit.Framework;

namespace KS.Fiks.IO.Arkiv.Client.Tests.Brukerhistorier
{
    public class Brukerhistorie13InfolandHentDokumentTests
    {
        /// <summary>
        /// Goal: Fetch saksmappe based on cadastre
        /// Input: Kommunenummer, gårdsnummer and bruksnummer
        /// Expected output: Saksmappe
        /// </summary>
        [Test]
        public void testFinnSaksmappeFraMatrikkel()
        {
            // We want to get the casefolder based on KNR, GNR, and BNR
            
            // Kommunenummer, Gårdsnummer og Bruksnummer, Seksjonsnummer og Festenummer
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
            arkivmeldingsok.Parameter.Add(new Parameter
            {
                Felt = SokFelt.SakPeriodMatrikkelnummerPeriodKommunenummer,
                Operator = OperatorType.Equal,
                Parameterverdier = new Parameterverdier
                {
                    Intvalues = { KNR }
                }
            });

            arkivmeldingsok.Parameter.Add(new Parameter
            {
                Felt = SokFelt.SakPeriodMatrikkelnummerPeriodGaardsnummer,
                Operator = OperatorType.Equal,
                Parameterverdier = new Parameterverdier
                {
                    Intvalues = { GNR }
                }
            });
            
            arkivmeldingsok.Parameter.Add( new Parameter
            {
                Felt = SokFelt.SakPeriodMatrikkelnummerPeriodBruksnummer,
                Operator = OperatorType.Equal,
                Parameterverdier = new Parameterverdier
                {
                    Intvalues = { BNR }
                }
            });
            // PARAMETER DEFINITIONS END 

            var payload = ArkivmeldingSerializeHelper.Serialize(arkivmeldingsok);
            
            Assert.Pass();
        }
        
        /// <summary>
        /// Goal: Fetch saksmappe based on extended cadastre information
        /// Input: Kommunenummer, gårdsnummer, bruksnummer, seksjonsnummer and festenummer
        /// Expected output: Saksmappe (tegninger, ferdigattest, reguleringsplaner etc..) 
        /// </summary>
         [Test]
        public void testFinnSaksmappeFraMatrikkelMedSeksjonOgFeste()
        {
            // We want to get the casefolder based on KNR, GNR, and BNR
            
            // Kommunenummer, Gårdsnummer og Bruksnummer, Seksjonsnummer og Festenummer
            var KNR = 1149;
            var GNR = 43;
            var BNR = 271;
            var SNR = 123;
            var FNR = 321;
            
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
            
            // Kommunenummer
            arkivmeldingsok.Parameter.Add(new Parameter
            {
                Felt = SokFelt.SakPeriodMatrikkelnummerPeriodKommunenummer,
                Operator = OperatorType.Equal,
                Parameterverdier = new Parameterverdier
                {
                    Intvalues = { KNR }
                }
            });
            
            //Gårdsnummer
            arkivmeldingsok.Parameter.Add(new Parameter
            {
                Felt = SokFelt.SakPeriodMatrikkelnummerPeriodGaardsnummer,
                Operator = OperatorType.Equal,
                Parameterverdier = new Parameterverdier
                {
                    Intvalues = { GNR }
                }
            });
            
            // Bruksnummer
            arkivmeldingsok.Parameter.Add(new Parameter
            {
                Felt = SokFelt.SakPeriodMatrikkelnummerPeriodBruksnummer,
                Operator = OperatorType.Equal,
                Parameterverdier = new Parameterverdier
                {
                    Intvalues = { BNR }
                }
            });
            
            // Seksjonsnummer
            arkivmeldingsok.Parameter.Add(new Parameter
            {
                Felt = SokFelt.SakPeriodMatrikkelnummerPeriodSeksjonsnummer,
                Operator = OperatorType.Equal,
                Parameterverdier = new Parameterverdier
                {
                    Intvalues = { SNR }
                }
            });
             
            //Festenummer
            arkivmeldingsok.Parameter.Add(new Parameter
            {
                Felt = SokFelt.SakPeriodMatrikkelnummerPeriodFestenummer,
                Operator = OperatorType.Equal,
                Parameterverdier = new Parameterverdier
                {
                    Intvalues = { FNR }
                }
            });
             
            // PARAMETER DEFINITIONS END 
            
            // Create new search with the defined parameters 
            var payload = ArkivmeldingSerializeHelper.Serialize(arkivmeldingsok);
            
            Assert.Pass();
        }
    }
}