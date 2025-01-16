namespace SporEtkinlikleriYonetimSistemi.Models
{
    public class PastEventsViewModel
    {
        public int EventID { get; set; }
        public string eventtitle { get; set; }
        public string eventdescription { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string organizername { get; set; }
    }

}
