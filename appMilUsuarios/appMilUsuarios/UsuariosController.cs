using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prometheus;



//POC

public class Team
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public bool Lider { get; set; }
    public List<Project> Projetos { get; set; }
}

public class Project
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public bool Concluido { get; set; }
}

public class Log
{
    public Guid Id { get; set; }
    public DateTime Data { get; set; }
    public string Acao { get; set; }
}
public class Usuario
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public int Idade { get; set; }
    public int Score { get; set; }
    public bool Ativo { get; set; }
    public string Pais { get; set; }
    public Team Equipe { get; set; }
    public List<Log> Logs { get; set; }
}



namespace appMilUsuarios
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioContext _context;

        public UsuariosController(UsuarioContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<Usuario> value)
        {
            var startTime = DateTime.UtcNow;
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            try
            {
                await _context.Usuarios.AddRangeAsync(value); 
                await _context.SaveChangesAsync();

                stopwatch.Stop();
                return Ok(new
                {
                    message = $"Importados {value.Count} usuários",
                    timestamp = startTime,
                    processingTimeMs = stopwatch.ElapsedMilliseconds
                });
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                return StatusCode(500, new
                {
                    error = ex.Message,
                    timestamp = startTime,
                    processingTimeMs = stopwatch.ElapsedMilliseconds
                });
            }


        }

        [ResponseCache(Duration = 60)]
        [HttpGet("superusers")]

        public async Task<IActionResult> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var startTime = DateTime.UtcNow;
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();

            try
            {
                var usuarios = await _context.Usuarios
                .Where(x => x.Ativo && x.Score >= 900)
                .Include(u => u.Equipe)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

                stopwatch.Stop();
                return Ok(new
                {
                    users = usuarios,
                    count = usuarios.Count,
                    timestamp = startTime,
                    processingTimeMs = stopwatch.ElapsedMilliseconds
                });

            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                return StatusCode(500, new {
                    error = ex.Message,
                    timestamp = startTime,
                    processingTimeMs = stopwatch.ElapsedMilliseconds });
            }
        }

    }
}
