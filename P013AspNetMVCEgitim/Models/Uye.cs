using System.ComponentModel.DataAnnotations;

namespace P013AspNetMVCEgitim.Models
{
	public class Uye
	{
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad Alanı Boş Geçilemez!"), StringLength(50)] // StringLength ile ad alanına kaç karakter gönderilebileceğini sınırlayabiliriz. bu kutu içinde yazılanlara data anateyşıns mı ne öyle birşey deniyor. Kural ve gereklilikler belirtilir.
        public string Ad { get; set; }
		[Required(ErrorMessage = "{0} Alanı Boş Geçilemez!"),StringLength(50)]
		public string Soyad { get; set; }
        [EmailAddress(ErrorMessage ="Geçersiz Mail Girdiniz!"),StringLength(50)] // email adres validasyon kodu
        public string? Email { get; set; }
		[Phone(ErrorMessage = "Geçersiz Telefon Girdiniz!"), StringLength(50)] // telefon no validasyon kodu
		public string? Telefon { get; set; }
        [Display(Name ="TC Kimlik Numarası"), MinLength(11, ErrorMessage = "{0} 11 karakter olmalıdır."), MaxLength(11, ErrorMessage = "{0} 11 karakter olmalıdır.") ] // Ekranda TcKimlikNo yerine TC Kimlik Numarası Yazsın. yani bizim verdiğimiz değişken ismini yansıtması yerine display özelliği atayarak ne yazdırmak istiyorsak onu gösteririz.
        public string TcKimlikNo { get; set; }
		[Display(Name = "Doğum Tarihi")]

		public DateTime? DogumTarihi { get; set; }
		[Display(Name = "Kullanıcı Adı")]

		public string? KullaniciAdi { get; set; }

		[Display(Name = "Şifre")]
		public string? Sifre { get; set; }
		[Display(Name = "Şifre Tekrar")]
		public string? SifreTekrar { get; set; }

    }
}
