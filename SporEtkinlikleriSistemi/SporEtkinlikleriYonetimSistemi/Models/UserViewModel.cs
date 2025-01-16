namespace SporEtkinlikleriYonetimSistemi.Models
{
    public class UserViewModel
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MaskedPassword { get; set; } // Maskelenmiş şifre
    }
}
