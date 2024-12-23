
# ASP.NET Core QueryString ve Dependency Injection Kullanımı

Bu proje, ASP.NET Core'da QueryString kullanımını ve Dependency Injection (Bağımlılık Enjeksiyonu) işlemlerini göstermek için oluşturulmuştur. Aşağıda adım adım nasıl ilerlediğimiz açıklanmıştır.

## 1. **QueryString Nedir?**

QueryString, bir web uygulamasında URL'ye eklenen ve genellikle veri veya parametreleri taşımak için kullanılan bir yapıdır. URL'nin sonunda, `?` karakteri ile başlar ve ardından anahtar-değer çiftleri şeklinde parametreler gelir. Parametreler arasına `&` karakteri konularak birden fazla veri taşınabilir.

**QueryString'in Kullanım Amaçları:**
- **Veri Taşımak:** Kullanıcıdan alınan bilgileri başka bir sayfaya taşımak.
- **Filtreleme:** Bir sayfada gösterilecek verileri filtrelemek veya sıralamak.
- **Sayfalama:** Örneğin, bir ürün listesini sayfa numarasına göre göstermek.
- **Durum Saklama:** Kullanıcının yaptığı seçimleri URL üzerinden tutmak.

**Önemli Not:**  
QueryString, Session gibi gizli olarak gönderilmez. Her zaman tarayıcı adres çubuğundan gönderilir. Bu nedenle, gizli verilerin QueryString ile gönderilmemesi gerektiği unutulmamalıdır.

---

## 2. **Uygulama Adımları**

### Home Controller - `QueryString` Action

Öncelikle, HomeController'da bir `QueryString` action metodu oluşturulmuştur:

```csharp
public IActionResult QueryString()
{
    return View();
}
```

### Home Index - Link Ekleme

Home Index view dosyasına, URL'ye parametreler ekleyerek `QueryString`'e veri gönderecek bir link eklenmiştir:

```html
<a href="/Home/QueryString?name=Hasan&lastname=Ayaz">Linke Git</a>
```

### QueryStringModel Oluşturulması

Parametreleri taşıyacak bir model sınıfı oluşturulmuştur. Bu model, query string parametrelerini almak için kullanılacaktır.

```csharp
public class QueryStringModel
{
    public string Name { get; set; }
    public string Lastname { get; set; }
}
```

### Home Controller - Model Alımı

HomeController'da, `QueryStringModel` parametrelerini alacak bir action metodu eklenmiştir:

```csharp
public IActionResult QueryString(QueryStringModel model)
{
    return View();
}
```

### `Program.cs` - Dependency Injection Ayarları

Dependency Injection (DI) kullanabilmek için `Program.cs` dosyasına aşağıdaki servis kayıtları eklenmiştir:

```csharp
builder.Services.AddHttpContextAccessor();  // HTTP context erişimi sağlanır
builder.Services.AddScoped<IHelper, Helper>();  // IHelper interface'inin Helper sınıfı ile ilişkilendirilmesi
```

**Açıklama:**  
`builder.Services.AddScoped<IHelper, Helper>();` satırı, ASP.NET Core'da Bağımlılık Enjeksiyonu için bir servis kaydeder. Bu, uygulama boyunca bir interface ile bir sınıfın bağlanmasını sağlar ve sınıfın örneği gerektiğinde otomatik olarak oluşturulur.

### Helper Sınıfı - External Klasörü

Proje içinde dış sınıf (helper) işlemlerini yönetecek bir `Helper` sınıfı `External` klasörüne eklenmiştir:

```csharp
public class Helper : IHelper
{
    public void GetQueryString()
    {
        // QueryString işleme kodları burada yer alacak
    }
}
```

### Home Controller - IHelper Bağımlılığı

`HomeController` sınıfında, Dependency Injection ile `IHelper` türünde bir bağımlılık alınmıştır:

```csharp
public class HomeController : Controller
{
    private readonly IHelper _helper;

    public HomeController(IHelper helper)
    {
        _helper = helper;
    }

    public IActionResult QueryString(QueryStringModel model)
    {
        var result = HttpContext.Request.QueryString;
        _helper.GetQueryString();
        return View();
    }
}
```

---

## 3. **Sonuç**

Bu adımlar, ASP.NET Core'da QueryString kullanarak verileri URL üzerinden göndermeyi ve Dependency Injection (Bağımlılık Enjeksiyonu) kullanarak bir yardımcı sınıf (helper) eklemeyi göstermektedir. `QueryString` ile veri taşıma ve parametreleri işleme işlemleri oldukça yaygındır ve doğru şekilde kullanıldığında web uygulamalarında faydalıdır.

## 4. **Önemli Notlar:**
- QueryString ile taşınan veriler her zaman tarayıcı adres çubuğunda görüneceği için gizli verilerin bu şekilde taşınması önerilmez.
- Bağımlılık enjeksiyonunu doğru şekilde yapılandırarak uygulamanın sürdürülebilirliğini artırabilirsiniz.

---

## 5. **Kaynaklar**
- [ASP.NET Core Bağımlılık Enjeksiyonu](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-7.0)
- [ASP.NET Core QueryString Kullanımı](https://learn.microsoft.com/en-us/aspnet/core/mvc/controllers/understanding-action-methods?view=aspnetcore-7.0)
