# Merhaba bu burada proje ile uğraştığım günlerdeki kazanımları ve sorunları aktarıyor olacağım. Bazı günleri toplu şekilde ele alabilirim.

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
- Bugün projede yenilemeler yaptım. Database olarak MSSQL kullanacağım
- .Net versiyonunu 5'ten 6'ya çektim.
- Director sınıfını kaldırdım, Actor'de bir bool değişken ile kontrol etmek istedim.

## Gün 8 - 9 - 10

- JWT Authentication işlemleri tamamlandı. Burada beni zorlayan şey daha önce JWT üretip kullanmıştım ama JWT'nin sahip olduğu payload bölümünü boş bırakmıştım. Bu projede de o şekilde kullanmak istedim ama hata aldım ve bu hatanın payloadın boş olmasından kaynaklandığını tespit etmem 6 saatime mal oldu :)
- Adminin yaptığı işlemler olan film ekleme, güncelleme , filme tür ve actor ekleme silme gibi endpointleri hazırladım
- Actorlerin için CRUD operasyonlarını tamamladım. Burada bir yeni bilgi öğrendim. Kurmuş olduğum yapıda Actor ve Movie many to many ilişkide olduğu için iki entity arasında koleksiyon şeklinde bulunuyor. Tüm aktörleri JSON olarak vermeye çalıştığım zaman bu koleksiyon sarmalına girdiğini ve bunun için bu tarz zincir döngü oluşturan yapıları JSON'nun defaultta çeviremediğini fark ettim. Bu hatanın çözümü için program.cs içerisinde bir ayar yapmam gerekti detaylar orada mevcut.
- Bu uygulamada kullanılacak endpointler için Postman'da bir koleksiyon oluşturdum proje sonlandığında READ.me dosyasına eklemesini yapacağım.
- Tek bir değer aldığım endpointlerde mesela Id gibi bu yapıları query'den çekme kararı aldım.
- Proje initialize edildiğinde gözükmesi için dummy data ekledim.

## Gün 11

- Genreler için controller oluşturuldu, CRUD operasyonları sağlıklı çalışıyor
- Yapımda Customer'lar Order verebiliyor ve bu orderlar Movieler içerebiliyor. Bu işlemleri nere yapmalıyım kararı beni açıkcası düşündürdü.Bu işlem için OrderController açıp orada mı gerçekleştirmeliyim yoksa CustomerController'da bunu halletsem olur mu şeklinde düşüncelerden sonra kararım Customer bu işlemi yaptığı için bu Controller altında toplamaktan yana oldu. Benzer mantıkla bu işleri servis olarakta CustomerService'e yükledim.
- Sipariş oluşturma endpointi oluşturuldu

## Gün 12

- Unit test altyapısı ve ayarlamaları yapıldı.
- Actor eklemek için unit test yazmayı denedim ama teorik olarak bu konuda çok eksiğimin olduğunu düşünüyorum. Mesela benim kullanmış olduğum patterne göre test ayarlarını yaptığım CommonFixtureTest clasının nasıl olmasını gerektiği tam kavrayamadım.
- Bu konu üzerine daha fazla makale okuyup tekrar dönmeyi planlıyorum
- Bir çok endpoint hazır olduğu için artık bugünden sonra React projesine geçiş yapacağım eksiklik olması dahilinde tabiki backende dönüş yaparım.

## Gün 13

- Projede frontend'e geçiş sağladım. İlgili yapı create-react-app ile oluşturuldu
- İşleyiş olarak css tarafında Tailwind kullanma kararı aldım.
- Navbar componenti tamamlandı.
- React router 6 yı projede kullanıyor olacağım
- Validasyonlar için ilk tercihim yup'tan yanaydı ama react-hook-form diye bir kütüphane buldum internette basit validasyonları bununla yapacağım daha kompleks yapılarda yup ile schema oluşturmaya yöneleceğim.

## Gün 14

- Authenticatin işlemlerini hallettim. Burada yaşadığım zorluklardan biri şu oldu Authenticate olmuş kullanıcının state'ini kontrol etmek. Sayfa yenilendiğinde state'im gidiyordu. Çözüm için bu alanda çalışan bir arkadaşımdan fikir aldım. Localstorage state ile bu durumun üstesinden geldim
- Şuan da ön tarafta kodlarım çok backend variymiş :) Bunun önüne geçmek için kendime componentler hazırlamaya karar verdim. Button gibi container gibi
- API tarafında ara ara değişiklikler yapıyorum ihtiyaç oldukça
- Formu tasarlamak için react-hook-form kullanıyorum

## Gün 15

- Repositoryler ayrıldı. Front ve Backendi ayırmak istedim
- Bu projeye başlayalı bir yıl oluyor, şimdiki bilgim ile bir çok şeyi refactor etmem lazım ama bir karar aldım bu haliyle devam ettireceğim
- Authentication işlemlerini değiştirdim refresh key httponly olacak şekilde servis ediliyor
- Comment operasyonları için gerekli servisler entegre edildi
- Bir iki haftada projenin tamamlanması için bazı yapılardan vazgeçtim
