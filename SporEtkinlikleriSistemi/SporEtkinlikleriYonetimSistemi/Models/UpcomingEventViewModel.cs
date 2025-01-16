namespace SporEtkinlikleriYonetimSistemi.Models
{
    public class UpcomingEventViewModel
    {

        public int EventID { get; set; }
        public string EventTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string OrganizerName { get; set; }
    }
}
