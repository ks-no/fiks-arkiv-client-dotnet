namespace KS.Fiks.IO.Arkiv.Client.Models.Kodelister
{
    public class Kode
    {
        public string Verdi { get; }
        public string Beskrivelse { get; }

        public Kode(string Verdi, string Beskrivelse)
        {
            this.Verdi = Verdi;
            this.Beskrivelse = Beskrivelse;
        }
    }
}