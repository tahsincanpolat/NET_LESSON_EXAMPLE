var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Bellek i�i da��t�lm�� �nbellek servisini ekler.
builder.Services.AddDistributedMemoryCache();

// Session yap�land�rmas�
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Oturumun ge�erlilik s�resi
    options.Cookie.HttpOnly = true; // Http �zerinden eri�imi k�s�tlay�p a�mak i�in kullan�l�r.
    options.Cookie.IsEssential = true; // Cookie'nin temel i�levsellik i�in gerekli oldu�unu belirtir.
});


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

app.UseSession(); // Session ekledik.

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();