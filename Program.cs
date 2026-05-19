using CalidadAireAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// 1. Conexion a Base de Datos
builder.Services.AddDbContext<AireDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Configuracion de Seguridad JWT
var llaveSecreta = "EstaEsMiClaveSuperSecretaDelParcial2026_NoRobar";
var key = Encoding.ASCII.GetBytes(llaveSecreta);

builder.Services.AddAuthentication(x => {
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x => {
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddControllers();

// 3. Swagger BÁSICO (Para cumplir el requisito sin que NET 10 explote)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Para la API del clima
builder.Services.AddHttpClient();

var app = builder.Build();

// 4. Activar Swagger
app.UseSwagger();
app.UseSwaggerUI();

// app.UseHttpsRedirection(); // Se queda comentado para evitar el 404 de antes
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();