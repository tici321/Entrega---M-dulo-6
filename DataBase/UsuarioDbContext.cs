using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GOTRAVEL.Model;

namespace GOTRAVEL.DataBase
{
    public class UsuarioDbContext : DbContext
    {
        public UsuarioDbContext(DbContextOptions<UsuarioDbContext>options) : base(options) {

        }

        public DbSet<Usuario> Usuarios { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

        var usuario = modelBuilder.Entity<Usuario>();
        usuario.ToTable("usuario");
        usuario.HasKey(x => x.id);
        usuario.Property(x => x.id).HasColumnName("id").ValueGeneratedOnAdd();
        usuario.Property(x => x.Nome).HasColumnName("nome").IsRequired();
        usuario.Property(x => x.email).HasColumnName("email");
        }

    }
}