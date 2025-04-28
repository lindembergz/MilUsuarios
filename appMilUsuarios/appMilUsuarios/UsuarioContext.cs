using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;

namespace appMilUsuarios
{
    public class UsuarioContext : DbContext
    {

        public UsuarioContext(DbContextOptions<UsuarioContext> options)
        : base(options)
        { }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Team> Equipe { get; set; }
        public DbSet<Project> Projetos { get; set; }
        public DbSet<Log> Log { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Adicionando índices para melhorar performance
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Score);

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Ativo);
        }

    }
}
