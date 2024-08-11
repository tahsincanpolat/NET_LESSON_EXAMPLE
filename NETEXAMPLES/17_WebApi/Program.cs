using _17_WebApi.DataContext;
using _17_WebApi.Seeder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ProductContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")) );


/*
 CORS
Geliþtirme aþamasýnda AllowAnyOrigin, AllowAnyMethod ve AllowAnyHeader ayarlarý genellikle geliþtirme aþamasýnda kullanýlýr. Çünkü türlü merkezlerde, methodlardan yada baþlýklardan gelen istekleri kabul eder. Bu, geliþtiricilerin hýzlý bir þekilþde istemcilerden API'yi test etmelerini saðlar.

Üretim Ortamýnda (Canlýda) güvenlik nedenleriyle daha kýsýtlayýcý CORS politikalarý kullanýlmasý önerilir. Örneðin, belilri
kökenlerden gelen isteklere izin vermek ve yalnýzca belirli HTTP methodlarýný ve baþlýklarýný kabul etmek gibi.
 
 */

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
        });
});



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Database i besleme

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ProductContext>();
    ProductSeeder.Seed(context);
}

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }


app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
