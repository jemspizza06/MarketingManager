using Microsoft.EntityFrameworkCore;
using Infraestructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// 1. Configurar la cadena de conexión desde appsettings.json
// 1. Obtener la cadena
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. Configurar MySQL con una versión fija (así no necesita conectarse para crear la migración)
builder.Services.AddDbContext<MarketingDbContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 31))));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();