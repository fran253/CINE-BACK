using Microsoft.OpenApi.Models;
using CineApi.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Configuración de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins(
            "http://52.87.111.65",   // IP pública de tu servidor
            "http://localhost",      // Frontend en local
            "http://127.0.0.1:5000"  // Otras IPs si las necesitas
        )
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Usamos HTTP para el desarrollo
app.Urls.Add("http://*:7000");  // Usamos el puerto 7000
app.Urls.Add("http://*:5000");  // Si es necesario el puerto 5000 también

app.UseCors("AllowSpecificOrigin");

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();  // Elimina esta línea si no tienes configurado HTTPS
app.UseAuthorization();

app.MapControllers();

SalaController.InicializarDatos();
PeliculaController.InicializarDatos();
HorarioController.InicializarHorarios();
SesionController.InicializarDatos();
AsientoController.InicializarDatos();

// Ejecutar la aplicación en HTTP
app.Run("http://0.0.0.0:7000");  // Puerto HTTP en 7000
