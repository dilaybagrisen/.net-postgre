
namespace SporEtkinlikleriYonetimSistemi.Models
{
    public class EventParticipant
    {
        public int ID { get; set; }
        public int EventID { get; set; }
        public int ParticipantID { get; set; }

        public Event? Event { get; set; } = default!;
        public User? Participant { get; set; } = default!;

    }
}
