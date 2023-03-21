using Microsoft.EntityFrameworkCore;

namespace P013AspNetMVCEgitim.Models
{
	//OnMemoryDb kullanabilmek için projeye sağ tık nuget package manager menüsünü aç. Oradan Browser sekmesinden InMemory paketini ve  EntityFrameworkCore.design paketlerini yüklüyoruz.
	public class UyeContext : DbContext
	{
        public DbSet<Uye> Uyes { get; set; } // üyeler anlamında uyes. uyes ismini ilk kez burada oluşturduk ve diğer alanlarda kullanacağız.

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)//onconfiguring sql yerine sanal db de çalışmamızı sağlayan kod.
		{
			//EntityFrameworkCore veritabanı işlemleri için yapılandırma ayarlarını yapabildiğimiz metot.
			optionsBuilder.UseInMemoryDatabase("InMemoryDb"); // bilgisayarımızın ram belleğini sala veritabanı olarak kullanmasını sağlayan ayarı yaptık.
			//bu ayardan sonra projemizin program.cs classına gidip bu UyeContext sınıfını servis olarak ekliyoruz.
			base.OnConfiguring(optionsBuilder);
		}
	}
}
