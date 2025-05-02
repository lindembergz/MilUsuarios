using Prometheus;
using System;
using appMilUsuarios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UsuarioContext>(opt => opt.UseInMemoryDatabase("UsuariosDB"));

builder.Services.AddResponseCompression();

var app = builder.Build();

app.UseRouting();

app.UseMetricServer(); // Expõe métricas em /metrics
app.UseHttpMetrics();

app.MapControllers();



app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapMetrics(); // Endpoint /metrics
});

app.UseSwagger();
app.UseSwaggerUI();
app.UseResponseCompression();

app.Run();
