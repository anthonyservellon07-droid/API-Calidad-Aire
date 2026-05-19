using CalidadAireAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// 1.1.------ Conexion a Base de Datos ..............................................................
builder.Services.AddDbContext<AireDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2.1 Configuracion de Seguridad JWT ...............................................................
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

// 3.1 Swagger ........................................................................................
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Para la API del clima ..................................................................
builder.Services.AddHttpClient();

var app = builder.Build();

// 4.1 Activar Swagger..................................................................
app.UseSwagger();
app.UseSwaggerUI();

// app.UseHttpsRedirection(); 
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
