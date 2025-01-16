namespace SporEtkinlikleriYonetimSistemi.Models
{
    public class UpcomingModel
    {
        public int EventID { get;set; }
        public string eventtitle { get;set; }
        public DateTime StartDate { get;set; }
        public DateTime EndDate { get; set; }

        public string organizername { get; set; }
    }
}
