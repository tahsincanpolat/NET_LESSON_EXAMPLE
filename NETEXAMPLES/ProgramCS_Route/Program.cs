// web uygulamas� i�in bir builder olu�turur.
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// MVC (Model-View-Controller) yap�s�n�n eklenmesi
builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// Http iste�ini Https e y�nlendirir.
app.UseHttpsRedirection();
// Css, Js dosyalar� gibi statik dosyalar� kullanmam�z� sa�lar.
app.UseStaticFiles();

// Y�nlendirme
app.UseRouting();


app.UseAuthorization();

// HomeController daki Index methodu �al���r.
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

// Uygulamas�n�n �al��mas�n� sa�lar.
app.Run();
