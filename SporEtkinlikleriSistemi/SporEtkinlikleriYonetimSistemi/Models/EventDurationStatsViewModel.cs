namespace SporEtkinlikleriYonetimSistemi.Models
{
    public class EventDurationStatsViewModel
    {

        public int EventID { get; set; }
        public string eventtitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int durationindays { get; set; }
    }
}
