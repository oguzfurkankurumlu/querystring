Query String, bir web uygulamasında URL'ye eklenen ve genellikle veri veya parametreleri taşımak için kullanılan bir yapıdır. Genellikle bir URL'nin sonunda, "?" karakteri ile başlar ve ardından anahtar-değer çiftleri şeklinde parametreler gelir. Parametreler arasına "&" karakteri konularak birden fazla veri taşınabilir.

Query String'in Kullanım Amaçları:
Veri Taşımak: Kullanıcıdan alınan bilgileri başka bir sayfaya taşımak.
Filtreleme: Bir sayfada gösterilecek verileri filtrelemek veya sıralamak.
Sayfalama: Örneğin, bir ürün listesini sayfa numarasına göre göstermek.
Durum Saklama: Kullanıcının yaptığı seçimleri URL üzerinden tutmak.

Key value cinsinden deger alır
sayfalar arası veri transferi yapabilirsin.
httppost, querystrıng,coocies, sesosın, sayfalar arası veri trasnfert 

querrystrıng sessıon gıbı gızlı olarak gonderılmez
her zaman browserın adres cubugndan gonderılır.
bu sebeple gızlı verılen querystrıng ıle gonderılmemesı tasınmaması gerekmektedir.
-----------------------------------------------------------
home controller a 
  public IActionResult Querystring()
    {
        return View();
    }
yazdım
-----------------------------------------------------------
home index e 
 <!-- <a href="/Home/Querystring?name=Hasan&lastname=Ayaz">Linke Git</a> -->
 ekledim.
-----------------------------------------------------------
 QueryStringModel
 olusturudum
-----------------------------------------------------------
 homecontrollerda 
 
 public IActionResult Querystring(QueryStringModel model)
    {
        return View();
    }
seklınde yazdım.
-----------------------------------------------------------
program.cs e 
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IHelper,Helper>();
ekledim
builder.Services.AddScoped<IHelper, Helper>(); satırı, ASP.NET Core'da Dependency Injection (Bağımlılık Enjeksiyonu) için bir hizmet (service) kaydı yapar. Bu, uygulama boyunca bir interface ile bir sınıfın bağlanmasını sağlar ve böylece uygulama, bu sınıfın bir örneğini (instance) ihtiyacı olduğunda otomatik olarak oluşturabilir.
-----------------------------------------------------------
external klasoru actım ıcıne helper.cs yazdım.
sayfa altında acıklamaları var
-----------------------------------------------------------
daha sonra homecontrollera bu yazıldı


    public IHelper _helper;
    public HomeController(IHelper helper)
    {
        _helper = helper;
    }


  public IActionResult QueryString(QueryStringModel model){
        var result = HttpContext.Request.QueryString;
        _helper.GetQueryString();
        return View();
     }


-----------------------------------------------------------
