public class Helper : IHelper
{
    //ACTION OLMAYAN BİR SINIF ICERISINDEN QUERYSTRINGE ERSIMEK ICIN KULLANILIR.

    // IHttpContextAccessor kullanmak ıcın program.cs dosyasına bır tanım yapmak zorundasın.

    // builder.Services.AddHttpContextAccessor();
    // builder.Services.AddScoped<IHelper,Helper>();

    public IHttpContextAccessor _context;
    public Helper(IHttpContextAccessor context)
    {
        _context = context;
    }
    public void GetQueryString()
    {


        //

        // HttpContext demek, web teknolojilerinde, ana sınıftır. Web'e ait bir çok şey httpcontext içerisinde yakalabilir

        // HttpContext'in içerisindekilere MVc Action içerisinden erişebilirsiniz

        // Ancak HttpContext'in içerisindekilere, action dışında bir sınıf içerisnde ulaşmak istediğinide, ulaşamazsınız

        // bu durumda, IHttpContextAccessor vasıtası ile iatediğiniz gibi erişebilirsiniz

        // Aşağıdaki örnekte, HTTPContext sınıfının içöerisindeki QueryString verisine, eriştik!!!..


        var queryString = _context.HttpContext.Request.QueryString;
    }
}
public interface IHelper
{
    public void GetQueryString();
}

// Kodun Genel Yapısı
// Helper Sınıfı:

// Helper sınıfı, IHelper adlı bir arabirimi (interface) uyguluyor.
// Bu sınıfın amacı, ASP.NET Core'un HttpContext nesnesine IHttpContextAccessor aracılığıyla erişmek
// ve QueryString değerlerini almak.
// IHttpContextAccessor:

// ASP.NET Core'da, HttpContext'e doğrudan erişmek istiyorsanız, 
// yalnızca Controller ya da Middleware gibi sınıflarda kullanabilirsiniz.
// Ancak, action dışındaki sınıflar (örneğin, Helper) HttpContext'e doğrudan erişemez.
// Bu durumda, IHttpContextAccessor kullanılarak HttpContext nesnesine ulaşılabilir.


// GetQueryString Metodu:

// Bu metot, HTTP isteğindeki QueryString'i alır.
// Query String, URL'nin sonunda yer alan ?key=value yapısındaki parametrelerdir.
// Örneğin, bir URL şu şekilde olabilir:
// https://www.example.com/products?category=electronics&page=2
// Yukarıdaki URL'den QueryString, şu şekildedir:
// ?category=electronics&page=2