using APIS.Models;
using Microsoft.EntityFrameworkCore;

namespace APIS.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Autores> autores { get; set; } //For each table in the DB
        public DbSet<Categorias> categorias { get; set; }
        public DbSet<Libros> libros { get; set; }
        public DbSet<Libros_has_autores> libros_has_autores { get; set; }
        public DbSet<Multas> multas { get; set; }
        public DbSet<Prestamo_libros> prestamo_libros { get; set; }
        public DbSet<Roles> roles { get; set; }
        public DbSet<Usuario_has_roles> usuario_has_roles { get; set; }
        public DbSet<Usuarios> usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Libros_has_autores>()
                .HasKey(lha => new { lha.Autores_IdAutor, lha.Libros_LibroId });
            modelBuilder.Entity<Usuario_has_roles>()
                .HasKey(lha => new { lha.Usuarios_UsuarioId1, lha.Roles_RolesId });

            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Libros_has_autores>().HasNoKey();
        //    modelBuilder.Entity<Usuario_has_roles>().HasNoKey();

        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
