namespace SporEtkinlikleriYonetimSistemi.Models
{
    public class EventSchedule
    {
        public int Id { get; set; } // Primary Key
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int EventId { get; set; }

        // Foreign Key Relationship
        public Event Event { get; set; } = default!;
    }
}