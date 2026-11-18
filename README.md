# 🚀 Dinamik Portfolyo & Yönetim Paneli (ASP.NET Core MVC)

MY Academy bunyesinde gerceklestirilen Bootcampte yapilan bu proje, **ASP.NET Core MVC**, **Entity Framework Core** ve **MS SQL Server** teknolojileri kullanılarak geliştirilmiş; modüler vitrin (UI) yapısına ve kapsamlı bir yönetim paneline (**Admin Area**) sahip dinamik bir portfolyo web uygulamasıdır.

---

## 🎯 Proje Hakkında

Uygulama iki ana katmandan oluşmaktadır:
1. **Kullanıcı Vitrini (UI):** Hakkımda, yetenekler, deneyimler, eğitim geçmişi, kategoriye göre filtrelenebilen aktif projeler ve doğrulamalı iletişim formunu sunar.
2. **Yönetim Paneli (Admin Area):** Tüm vitrin içeriklerinin dinamik olarak yönetildiği, `DashboardViewModel` destekli yönetim özetinin ve gelişmiş gelen kutusu sisteminin yer aldığı kontrol merkezidir.

---

## 🛠️ Kullanılan Teknolojiler & Mimari Yaklaşımlar

* **Backend:** C#, ASP.NET Core MVC (.NET), Area Yapısı, ViewComponent Mimarisi
* **Veritabanı & ORM:** Entity Framework Core (Code-First & Migrations), MS SQL Server
* **LINQ & Sorgulama:** `Include` (Eager Loading), `GroupBy`, `OrderByDescending`, `Where`, `Count`, `Take`
* **Frontend:** HTML5, CSS3, Bootstrap 5, JavaScript (Fetch API / AJAX), Bootstrap Icons
* **Kullanıcı Deneyimi & Bildirimler:** SweetAlert2 (Merkezi onay ve durum bildirimleri), Bootstrap Modal
* **Doğrulama & Dosya Yönetimi:** Data Annotations (`[Required]`, `[EmailAddress]`, `[StringLength]`, `[NotMapped]`), `IFormFile` ile sunucuya görsel yükleme
<img width="1912" height="966" alt="3" src="https://github.com/user-attachments/assets/e02fa157-1681-47b2-afb8-e0191e319290" />

---

## ✨ Öne Çıkan Modüller ve Özellikler
<img width="1912" height="984" alt="4" src="https://github.com/user-attachments/assets/e087bbe0-3aae-4481-aed3-5a14090bbd0e" />

### 📊 1. Yönetim Özeti (Dashboard)
* **Tip Güvenli Mimari:** Farklı entity verilerini tek ekranda toplamak için oluşturulan `DashboardViewModel`.
* **7 Dinamik İstatistik Kartı:** Toplam proje, aktif proje, yetenek, deneyim, eğitim, toplam mesaj ve okunmamış mesaj sayıları.
* **Kategori Özeti:** `GroupBy` sorgusu ile her kategorideki proje dağılımını gösteren tablo ve ilerleme çubuğu grafiği.
* **Hızlı Bakış & Kısayollar:** Son eklenen 3 proje, modal destekli son 5 mesaj ve hızlı erişim butonları.

### 📁 2. Gelişmiş Proje & Kategori Yönetimi
* **İlişkisel Yapı:** `Project` ve `Category` tabloları arasında Foreign Key / Navigation Property bağlantısı ve `SelectList` (`asp-items`) entegrasyonu.
* **Aktif / Pasif Durum Kontrolü:** `IsActive` alanı ile pasif projelerin admin panelinde tutulup vitrinde gizlenmesi.
* **Görsel Yükleme:** `IFormFile` ile proje görsellerinin güvenli şekilde sunucuya (`wwwroot`) yüklenmesi.
* **Filtreleme ve Sıralama:** Hem admin panelinde hem de UI vitrininde kategori bazlı filtreleme ve en yeniden eskiye sıralama.
<img width="1912" height="984" alt="5" src="https://github.com/user-attachments/assets/8664d595-3c33-4a2a-90aa-8b77766074fb" />
<img width="1912" height="993" alt="6" src="https://github.com/user-attachments/assets/f3520a08-c041-4a32-945a-852e7c243911" />

### 📩 3. Gelişmiş Gelen Kutusu (Mesaj Yönetimi)
* **İki Katmanlı Doğrulama:** İletişim formundan gönderilen verilerin hem istemci hem sunucu tarafında Data Annotations ile doğrulanıp kaydedilmesi.
* **AJAX & Bootstrap Modal:** Sayfa yenilenmeden mesaj detayının modal pencerede açılması ve otomatik **"Okundu"** olarak işaretlenmesi.
* **Görsel Ayrım & Canlı Sayaç:** Okunmamış mesajların tabloda vurgulanması, gönderen/konuya göre arama ve sol menüde canlı okunmamış mesaj rozeti.
<img width="1912" height="993" alt="7" src="https://github.com/user-attachments/assets/e30552a9-6c4c-4f99-815f-1cab5126bc20" />

### 🔔 4. Kullanıcı Deneyimi (UX) İyileştirmeleri
* Tüm silme işlemlerinde **SweetAlert2** onay pencereleri.
* Ekleme, güncelleme, durum değiştirme ve hata senaryolarında `TempData` tabanlı merkezi bildirim sistemi.
<img width="1912" height="993" alt="8" src="https://github.com/user-attachments/assets/d7aac2b8-2871-44f6-8f2e-9f82c63ce2ae" />

---
<img width="1912" height="993" alt="9" src="https://github.com/user-attachments/assets/a9f5aa9f-82b4-46db-96cf-7df7e6d4f8d9" />

## ⚙️ Kurulum ve Çalıştırma

1. Depoyu bilgisayarınıza klonlayın:
   ```bash
   git clone https://github.com
   ```
2. `Context/PortfolioContext.cs` dosyasındaki veritabanı bağlantı cümlesini (`ConnectionString`) kendi SQL Server örneğinize göre güncelleyin.
3. Visual Studio **Package Manager Console** üzerinden veritabanını oluşturun:
   ```powershell
   Update-Database
   ```
4. Projeyi çalıştırın (`F5`):
   * **Vitrin Sayfası:** `/Default/Index`
   * **Yönetim Paneli:** `/Admin/Dashboard/Index`

---

## 👤 Geliştirici

**Mustafa Bolat**  
Elektrik-Elektronik Mühendisi & Junior .NET Developer  
GitHub: [@BolatMustafa](https://github.com)
