using System;
using appMilUsuarios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UsuarioContext>(opt => opt.UseInMemoryDatabase("UsuariosDB"));

builder.Services.AddResponseCompression();

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.UseResponseCompression();

app.Run();
