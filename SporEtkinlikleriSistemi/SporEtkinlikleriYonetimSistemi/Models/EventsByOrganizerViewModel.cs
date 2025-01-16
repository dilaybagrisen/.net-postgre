namespace SporEtkinlikleriYonetimSistemi.Models
{
    public class EventsByOrganizerViewModel
    {

        public int organizerid { get; set; }
        public string organizername { get; set; }
        public int EventID { get; set; }
        public string eventtitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
