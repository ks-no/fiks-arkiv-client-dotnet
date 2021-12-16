﻿using System;
using KS.Fiks.IO.Arkiv.Client.ForenkletArkivering;
using no.ks.fiks.io.arkiv.innsyn.sok;
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
           
            var arkivmeldingsok = new sok
            {
                respons = respons.saksmappe,
                meldingId = Guid.NewGuid().ToString(),
                system = "Fagsystem X",
                tidspunkt = DateTime.Now,
                skip = 0,
                take = 100
            };
            
            // PARAMETER DEFINITIONS START
            var knrParam = new parameter
            {
                felt = sokFelt.sakmatrikkelnummerkommunenummer,
                @operator = operatorType.equal,
                parameterverdier = new parameterverdier
                {
                    Item = new intvalues
                    {
                        value = new[] {KNR}
                    }
                }
            };
            
            var gnrParam = new parameter
            {
                felt = sokFelt.sakmatrikkelnummergaardsnummer,
                @operator = operatorType.equal,
                parameterverdier = new parameterverdier
                {
                    Item = new intvalues
                    {
                        value = new[] {GNR}
                    }
                }
            };
            
            var bnrParam = new parameter
            {
                felt = sokFelt.sakmatrikkelnummerbruksnummer,
                @operator = operatorType.equal,
                parameterverdier = new parameterverdier
                {
                    Item = new intvalues
                    {
                        value = new[] {BNR}
                    }
                }
            };
            // PARAMETER DEFINITIONS END 

            // Create new search with the defined parameters 
            var searchParams = new parameter[] {knrParam, gnrParam, bnrParam};
            arkivmeldingsok.parameter = searchParams;
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
            
            var arkivmeldingsok = new sok
            {
                respons = respons.saksmappe,
                meldingId = Guid.NewGuid().ToString(),
                system = "Fagsystem X",
                tidspunkt = DateTime.Now,
                skip = 0,
                take = 100
            };
            
            // PARAMETER DEFINITIONS START
            
            // Kommunenummer
            var knrParam = new parameter
            {
                felt = sokFelt.sakmatrikkelnummerkommunenummer,
                @operator = operatorType.equal,
                parameterverdier = new parameterverdier
                {
                    Item = new intvalues
                    {
                        value = new[] {KNR}
                    }
                }
            };
            
            //Gårdsnummer
            var gnrParam = new parameter
            {
                felt = sokFelt.sakmatrikkelnummergaardsnummer,
                @operator = operatorType.equal,
                parameterverdier = new parameterverdier
                {
                    Item = new intvalues
                    {
                        value = new[] {GNR}
                    }
                }
            };
            
            // Bruksnummer
            var bnrParam = new parameter
            {
                felt = sokFelt.sakmatrikkelnummerbruksnummer,
                @operator = operatorType.equal,
                parameterverdier = new parameterverdier
                {
                    Item = new intvalues
                    {
                        value = new[] {BNR}
                    }
                }
            };
            
            // Seksjonsnummer
            var snrParam = new parameter
            {
                felt = sokFelt.sakmatrikkelnummerseksjonsnummer,
                @operator = operatorType.equal,
                parameterverdier = new parameterverdier
                {
                    Item = new intvalues
                    {
                        value = new[] {SNR}
                    }
                }
            };
             
            //Festenummer
            var fnrParam = new parameter
            {
                felt = sokFelt.sakmatrikkelnummerfestenummer,
                @operator = operatorType.equal,
                parameterverdier = new parameterverdier
                {
                    Item = new intvalues
                    {
                        value = new[] {FNR}
                    }
                }
            };
             
            // PARAMETER DEFINITIONS END 
            
            // Create new search with the defined parameters 
            var searchParams = new parameter[] {knrParam, gnrParam, bnrParam, snrParam, fnrParam};
            arkivmeldingsok.parameter = searchParams;
            var payload = ArkivmeldingSerializeHelper.Serialize(arkivmeldingsok);
            
            Assert.Pass();
        }
    }
}