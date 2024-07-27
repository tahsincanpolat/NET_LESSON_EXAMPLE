// web uygulamasý için bir builder oluþturur.
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// MVC (Model-View-Controller) yapýsýnýn eklenmesi
builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// Http isteðini Https e yönlendirir.
app.UseHttpsRedirection();
// Css, Js dosyalarý gibi statik dosyalarý kullanmamýzý saðlar.
app.UseStaticFiles();

// Yönlendirme
app.UseRouting();


app.UseAuthorization();

// HomeController daki Index methodu çalýþýr.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "about",
    pattern: "about",
    defaults: new { controller = "Home", action = "About" }
);

app.MapControllerRoute(
    name: "aboutDetails",
    pattern: "about/detail/{id}",
    defaults: new { controller = "Home", action = "AboutDetail" }
);

// Uygulamasýnýn çalýþmasýný saðlar.
app.Run();
