﻿using System;
 using KS.Fiks.IO.Arkiv.Client.ForenkletArkivering;
 using no.ks.fiks.io.arkivmelding.innsyn.sok;
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
        /// Goal: Fetch Saksmappe based on bygningsnummer
        /// Input: Bygningsnummer
        /// Output: Saksmappe
        /// </summary>
         [Test]
        public void testFinnSaksmappeFraBygningsnummer()
        {
            var bygningsnummer = 80486367;
            
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
            var bygNummerParam = new parameter
            {
                felt = sokFelt.sakbyggidentbygningsnummer,
                @operator = operatorType.equal,
                parameterverdier = new parameterverdier
                {
                    Item = new intvalues
                    {
                        value = new[] {bygningsnummer}
                    }
                }
            };
            // PARAMETER DEFINITIONS END 

            // Create new search with the defined parameters 
            var searchParams = new parameter[] {bygNummerParam};
            arkivmeldingsok.parameter = searchParams;

            var payload = ArkivmeldingSerializeHelper.Serialize(arkivmeldingsok);
            Assert.Pass();
        }
    }
}