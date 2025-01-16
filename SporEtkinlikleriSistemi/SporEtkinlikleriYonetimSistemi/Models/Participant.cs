namespace SporEtkinlikleriYonetimSistemi.Models
{
    public class Participant
    {
        public int ID { get; set; } // Katılımcının birincil anahtarı
        public string Name { get; set; } = string.Empty; // Katılımcının adı
        public int EventID { get; set; } // Seçilen etkinlik ID'si

        // İsteğe bağlı, etkinlik bilgisi için
        public Event? Event { get; set; }
    }
}

