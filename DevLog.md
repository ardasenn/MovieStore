## Gün 1

- Proje katmanları oluşturuldu
- Kullanılacak Entity'ler oluşturuldu

## Gün 2

- Geleneksel katmanlı mimariden vazgeçerek, projeyi Onion Architecture'a çevirdim.
- Entitylerde değişikliğe gittim
- InMemory yapısını kurmaya çalışırken Entity Configlerim olmadan başladığım için o kısmı yarıda bırakıp Entity Configlerine yöneldim.

## Gün 3

- Onion Architecture mantığını anlamada biraz zorlandım açıkcası. Bana ana katman tamamıyla Persistance gibi geliyor çünkü repository ve servislerimin concrete nesnelerini orada oluşturuyoruz. Sanırım daha fazla makale okumam gerek
- Architecture uygulamak açıkcası çok fazla canımı sıktı sürekli yeni klasör yeni sınıf cod yazmaya her ne kadar taakatim kalmasa da Customer oluşturmayı sağlıklı bir şekilde bitirdim.
- Validasyonlar için FluentValidation , Mapleme işlemleri için AutoMapper kütüphanelerini ekledim.
- Genel olarak bugün code'lamamı daha hızlı yapabilmek için kütüphaneleri ve servislerimi entegre ettim diyebilirim.

## Gün 4

- Genre service işlemlerini yazdım
- Şu zamana kadar ben yazdığın kodları ViewModel klasörümü business layer iinde tutuyordum. Bu projede Presentation katmanında tutma kararını aldım. Bence daha geliştirilebilir oldu diyebilirim.

## Gün 5

- Custom exception Middleware yapısı projeme entegre ettim. Hata mesajları konsola veya kullanıcıya nasıl gösterilmeli kararını halen daha vermiş değilim. Şuanda string olarak birleştirdiğim hataları json'a çevirip gönderiyorum. Sanırım ilerleyen günlerde refactor yapmam gerekecek.

## Gün 6

- Actor ve Director arasındaki ilişkinin one to one olması CRUD operasyonlarda iş kararları almamı gerektirdi. Director dependent şekilde kurguladım.
- Database'den veri silisi olmayacak statülerini pasifize ettim.

## Gün 7

- Projeye yaklaşık 6 ay ara vermiştim. (Vay be ne kadar da hızlı ilerlemiş zaman)
- Bugün yani 09.04.2023 tarihinde projede yenilemeler yaptım. Database olarak MSSQL kullanacağım
- .Net versiyonunu 5'ten 6'ya çektim.
- Director sınıfını kaldırdım, Actor'de bir bool değişken ile kontrol etmek istedim.
