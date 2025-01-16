namespace SporEtkinlikleriYonetimSistemi.Models
{
    public class Event
    {
        public int EventID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int OrganizerID { get; set; }
        public User? Organizer { get; set; } = default!;

        public List<Participant>? Participants { get; set; }
    }
}
