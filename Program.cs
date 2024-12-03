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

app.Urls.Add("https://*:7000");
app.Urls.Add("https://*:5000");

app.UseCors("PermitirOrigenLocal");

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

SalaController.InicializarDatos();
PeliculaController.InicializarDatos();
HorarioController.InicializarHorarios();
SesionController.InicializarDatos();
AsientoController.InicializarDatos();

app.Run();