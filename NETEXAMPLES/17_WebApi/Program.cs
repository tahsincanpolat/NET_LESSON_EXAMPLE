using _17_WebApi.DataContext;
using _17_WebApi.Seeder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ProductContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")) );


/*
 CORS
Geli�tirme a�amas�nda AllowAnyOrigin, AllowAnyMethod ve AllowAnyHeader ayarlar� genellikle geli�tirme a�amas�nda kullan�l�r. ��nk� t�rl� merkezlerde, methodlardan yada ba�l�klardan gelen istekleri kabul eder. Bu, geli�tiricilerin h�zl� bir �ekil�de istemcilerden API'yi test etmelerini sa�lar.

�retim Ortam�nda (Canl�da) g�venlik nedenleriyle daha k�s�tlay�c� CORS politikalar� kullan�lmas� �nerilir. �rne�in, belilri
k�kenlerden gelen isteklere izin vermek ve yaln�zca belirli HTTP methodlar�n� ve ba�l�klar�n� kabul etmek gibi.
 
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
