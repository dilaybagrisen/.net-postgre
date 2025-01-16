namespace SporEtkinlikleriYonetimSistemi.Models
{
    public class ParticipantWithEventViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int? eventid { get; set; } // EventID özelliğini ekledik
        public string eventtitle { get; set; }
        public DateTime? eventstartdate { get; set; }
        public DateTime? eventenddate { get; set; }
    }

}

