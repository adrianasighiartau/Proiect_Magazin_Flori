using System.Security.Policy;

namespace Proiect_Magazin_Flori.Areas.Identity.Data
{
    public class Cos
    {public int ID { get; set; }
        public string UserID { get; set; }
        public SiteUser? SiteUser { get; set; }
     public int? FloareID { get; set; }
        public Floare? Floare { get; set; }
        public int Cantitate {  get; set; }

    }
}
