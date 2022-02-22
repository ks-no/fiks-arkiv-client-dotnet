using System;
using KS.Fiks.IO.Arkiv.Client.ForenkletArkivering;
using KS.Fiks.IO.Arkiv.Client.Models.Arkivering.Arkivmelding.Oppdatering;
using KS.Fiks.IO.Arkiv.Client.Models.Metadatakatalog;
using NUnit.Framework;
using Part = KS.Fiks.IO.Arkiv.Client.Models.Arkivering.Arkivmelding.Part;

namespace KS.Fiks.IO.Arkiv.Client.Tests
{
    public class ArkivmeldingOppdateringTests
    {
        [Test]
        public void CreateArkivmeldingOppdatering_RegistreringOgPartOppdateringer()
        {
            var arkivmeldingOppdatering = new ArkivmeldingOppdatering()
            {
                MeldingId = "",
                Tidspunkt = DateTime.Now,
                RegistreringOppdateringer =
                {
                    new RegistreringOppdatering()
                    {
                        SystemID = new SystemID() { Label = "", Value = Guid.NewGuid().ToString() },
                        PartOppdatering = new PartOppdateringer()
                        {
                            Oppdatering =
                            {
                                new PartOppdatering()
                                {
                                    PartID = "en_part_id", 
                                    Epostadresse = "ny_oppdatert_epostadresse"
                                },
                                new PartOppdatering()
                                {
                                    PartID = "en_part_id_2", 
                                    Kontaktperson = "ny_oppdatert_kontaktperson"
                                }
                            },
                            Ny = 
                            { 
                                new Part()
                                {
                                    PartNavn = "partnavn",
                                } 
                            },
                            Slett = 
                            { 
                                new PartSlett()
                                {
                                    PartID = "denne_skal_slettes"
                                } 
                            }
                        }
                    }
                }
            };
            
            var payload = ArkivmeldingSerializeHelper.Serialize(arkivmeldingOppdatering);
            
            if (!Validator.IsValidArkivmeldingOppdateringXml(payload))
            {
                Assert.Fail("Validation errors");
            }
        }
        
        
    }
}