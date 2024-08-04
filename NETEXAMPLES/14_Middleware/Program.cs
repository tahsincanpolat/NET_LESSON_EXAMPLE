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
Middleware, .NET Core uygulamalar�nda gelen istekleri (request) i�lemek ve yan�tlar� (response) olu�turmak i�in kullan�lan bir
yaz�l�m bile�enidir. Middleware genellikle http isteklerinde ve yan�tlar�n� i�lemenin yan� s�ra, uygulaman�z�n �e�itli i�levelerini
yerine getirir. Her bir middleware, iste�i i�leyip bir sonraki middleware'e ge�ebilir yada yan�t olu�turabilir.
 
 
 
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
