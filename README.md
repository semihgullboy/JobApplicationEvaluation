# Şirket Yorum Platformu


Bu proje, iş başvurusu yapan adayların şirketlerle yaşadıkları deneyimleri paylaşabildiği, başvuru süreçlerini değerlendirebildiği ve diğer adayların geri bildirimlerini görüntüleyebildiği bir platform sunar. Amaç, işe alım süreçlerinde şeffaflığı artırmak, adayların gerçek tecrübelerden faydalanmasını sağlamak ve şirketlerin işe alım performanslarını objektif geri bildirimlerle geliştirmelerine yardımcı olmaktır.

## Kullanılan Teknolojiler

- **.NET Core Web API**: Backend servislerinin geliştirilmesi için kullanıldı.
- **Entity Framework Core**: Veritabanı işlemleri ve Code-First için kullanılmıştır.
- **PostgreSQL**: Uygulamanın ilişkisel veritabanı.
- **JWT (JSON Web Token)**: Kimlik doğrulama ve yetkilendirme için kullanıldı.
- **AutoMapper**: Entity ve DTO / ViewModel dönüşümleri için kullanıldı.
- **Docker & Docker Compose**: PostgreSQL ve bağımlılıkların container ortamında çalıştırılması için kullanıldı.
- **Swagger**: API dokümantasyonu için kullanılmıştır.

## Mimari Yapı

Projede **Katmanlı Mimari (Layered Architecture)**  yapısı kullanılmıştır.
<pre> JobApplicationEvaluation/
├── JobApplicationEvaluation.Api/
│   └── Controllers, API yapılandırmaları
├── JobApplicationEvaluation.Business/
│   └── İş kuralları ve servisler
├── JobApplicationEvaluation.Core/
│   └── Ortak yapılar
├── JobApplicationEvaluation.DataAccess/
│   └── EF Core, veri erişim işlemleri
├── JobApplicationEvaluation.Entity/
│   └── Entity modelleri
└── JobApplicationEvaluation.ViewModels/
    └── Request / Response modelleri </pre>

## ⚙️ Kurulum ve Çalıştırma

Bu bölümde projenin Visual Studio kullanılarak lokal ortamda çalıştırılması adım adım anlatılmaktadır.

### 1️⃣ Projeyi klonlayın:

```bash
git clone https://github.com/semihgullboy/JobApplicationEvaluation.git
cd JobApplicationEvaluation
```
### 2️⃣ Veritabanı Kurulumu

PostgreSQL’i Docker üzerinden çalıştırın:

```bash
docker compose up -d
```

### 3️⃣ appsettings.json Ayarları

`JobApplicationEvaluation.Api/appsettings.json` dosyasında aşağıdaki alanları kendi ortamınıza göre düzenleyin:

```json
{
  "ConnectionStrings": {
    "Context": "Host=localhost;Port=5432;Database=JobApplicationEvaluation;Username=postgres;Password=postgres"
  },
  "JWTAuth": {
  "ValidAudienceURL": "yoururl",
  "ValidIssuerURL": "yoururl",
  "SecretKey": "yoursecretkey",
  "Expire": "7"
}
}
```
### 4️⃣ Veritabanı Migration’larını Çalıştırma:

   Package manager konsolunu açınız ve varsayılan projeyi JobApplicationEvaluation.DataAccess yapınız.

   ```bash
   add-migration init
   update-database
   ```

### 5️⃣ Uygulamanızı başlatın ve API'yi test edin:

Swagger üzerinden API endpoint'lerinizi aşağıda bulunan dökümanlara göre test edebilirsiniz.
