using _14_Middleware.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
/* 
Middleware nedir?
Middleware, .NET Core uygulamalarýnda gelen istekleri (request) iþlemek ve yanýtlarý (response) oluþturmak için kullanýlan bir
yazýlým bileþenidir. Middleware genellikle http isteklerinde ve yanýtlarýný iþlemenin yaný sýra, uygulamanýzýn çeþitli iþlevelerini
yerine getirir. Her bir middleware, isteði iþleyip bir sonraki middleware'e geçebilir yada yanýt oluþturabilir.
 
 
 
 */
app.UseMiddleware<RequestTimingMiddleware>();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
