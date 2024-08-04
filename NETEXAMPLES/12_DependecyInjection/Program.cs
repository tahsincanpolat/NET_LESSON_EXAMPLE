using _12_DependecyInjection.Services.Abstract;
using _12_DependecyInjection.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// IMyService ve MyService'i containera ekliyoruz.
/*
 NET Core Dependency injection da servislerin ömrünü (lifecycle) belirlemek için üç ana yöntem kullanýlýr. AddTransient,AddScoped,
AddSingelton. Her birinin avantajlarý ve dezavantajlarý vardýr.

1. AddTransient => Bu yöntemde her istek için yeni bir nesne oluþturulur. Bu servis her kullanýldýðýnda yeni bir örneðin oluþturulacaðý
anlamýna gelir. Performans açýsýndan maliyetli olabilir çünkü her istek için yeni bir nesne oluþturulur.
2. AddScoped => her http isteði (request) baþýna bir nesne oluþturur. Ayný istek içinde ayný servis nesnesi kullanýlýr. Ancak farklý
isteklerde farklý nesneler oluþturulur. Ýstekler arasýnda veri paylaþýmý yapýlamaz. Bu sebeple bazý durumlarda verimsiz olabilir.
3. AddSingleton => Uygulama baþladýðýnda bir kez oluþturulan ve uygulama yaþam döngüsü boyunca ayný kalan tek bir nesne oluþturur.
Performans açýsýndan en verimlisidir. Çünkü nesne sadece bir kez oluþturulur.
 
 */
builder.Services.AddSingleton<IMyService, MyService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
