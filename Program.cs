using Microsoft.OpenApi.Models;
using CineApi.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirOrigenLocal", policy =>
    {
        policy.AllowAnyOrigin() // Permitimos cualquier origen para pruebas /////////////////////////////
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("PermitirOrigenLocal");

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

PeliculaController.InicializarDatos();
SesionController.InicializarDatos();
AsientoController.InicializarDatos();
SalaController.InicializarDatos();

app.Run();
