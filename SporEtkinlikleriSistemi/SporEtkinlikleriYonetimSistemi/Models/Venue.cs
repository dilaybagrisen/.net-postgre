namespace SporEtkinlikleriYonetimSistemi.Models
{
    public class Venue
    {
        public int VenueID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int Capacity { get; set; }
    }
}
