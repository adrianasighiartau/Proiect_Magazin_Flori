namespace Proiect_Magazin_Flori.Areas.Identity.Data
{
    public class Adresa
    { public int ID { get; set; }
        public string UserID { get; set; }
        public SiteUser? SiteUser { get; set; }
    public string Nume { get; set; }
    public string Prenume { get; set; }
    public string Oras { get; set; }
    public string Strada { get; set; }
    }
}
