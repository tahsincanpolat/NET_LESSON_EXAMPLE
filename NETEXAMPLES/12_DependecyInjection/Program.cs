using _12_DependecyInjection.Services.Abstract;
using _12_DependecyInjection.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// IMyService ve MyService'i containera ekliyoruz.
/*
 NET Core Dependency injection da servislerin �mr�n� (lifecycle) belirlemek i�in �� ana y�ntem kullan�l�r. AddTransient,AddScoped,
AddSingelton. Her birinin avantajlar� ve dezavantajlar� vard�r.

1. AddTransient => Bu y�ntemde her istek i�in yeni bir nesne olu�turulur. Bu servis her kullan�ld���nda yeni bir �rne�in olu�turulaca��
anlam�na gelir. Performans a��s�ndan maliyetli olabilir ��nk� her istek i�in yeni bir nesne olu�turulur.
2. AddScoped => her http iste�i (request) ba��na bir nesne olu�turur. Ayn� istek i�inde ayn� servis nesnesi kullan�l�r. Ancak farkl�
isteklerde farkl� nesneler olu�turulur. �stekler aras�nda veri payla��m� yap�lamaz. Bu sebeple baz� durumlarda verimsiz olabilir.
3. AddSingleton => Uygulama ba�lad���nda bir kez olu�turulan ve uygulama ya�am d�ng�s� boyunca ayn� kalan tek bir nesne olu�turur.
Performans a��s�ndan en verimlisidir. ��nk� nesne sadece bir kez olu�turulur.
 
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
