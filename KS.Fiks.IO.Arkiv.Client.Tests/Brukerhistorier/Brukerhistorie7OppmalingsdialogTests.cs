using System;
using System.Collections.Generic;
using KS.Fiks.IO.Arkiv.Client.ForenkletArkivering;
using no.ks.fiks.io.arkivmelding.sok;
using Xunit;

namespace KS.Fiks.IO.Arkiv.Client.Tests.Brukerhistorier
{
    public class Brukerhistorie7OppmalingsdialogTests
    {
        // Brukstilfellet søker frem alle dokumenter knyttet til sak og presenterer disse for bruker. Bruker velger et av av disse og knytter til saken i fagsystemet. 
        // I denne testen søker vi bare frem dokumenter for en sak
        [Fact]
        public void TestFinnDokumenterForsak()
        {
            var saksaar = 2020;
            var saksaksekvensnummer = 123;

            var arkivmeldingsok = new sok
            {
                respons = respons_type.dokumentbeskrivelse,
                meldingId = Guid.NewGuid().ToString(),
                system = "Fagsystem X",
                tidspunkt = DateTime.Now,
                skip = 0,
                take = 100
            };

            var paramlist = new List<parameter>
            {
                new parameter
                {
                    felt = field_type.saksaksaar,
                    @operator = operator_type.equal,
                    parameterverdier = new parameterverdier
                    {
                        Item = new intvalues
                        {
                            value =new[] {saksaar }
                            
                        }
                    }
                },
                new parameter
                {
                    felt = field_type.saksaksekvensnummer,
                    @operator = operator_type.equal,
                    parameterverdier = new parameterverdier
                    {
                        Item = new intvalues
                        {
                            value =new[] { saksaksekvensnummer }

                        }
                    }
                }

            };

            arkivmeldingsok.parameter = paramlist.ToArray();
            var payload = ArkivmeldingSerializeHelper.Serialize(arkivmeldingsok);
        }
    }
}
