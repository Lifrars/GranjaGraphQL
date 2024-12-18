using Microsoft.EntityFrameworkCore;
using GranjaGraphQL.Models;

namespace GranjaGraphQL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; } = null!;
        public DbSet<Porcino> Porcinos { get; set; } = null!;
        public DbSet<Alimentacion> Alimentaciones { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>().HasData(
                new Cliente
                {
                    Id = 1,
                    Cedula = "1234567890",
                    Nombres = "Juan",
                    Apellidos = "Pérez",
                    Direccion = "Calle Falsa 123",
                    Telefono = "555-1234"
                },
                new Cliente
                {
                    Id = 2,
                    Cedula = "0987654321",
                    Nombres = "Ana",
                    Apellidos = "Gómez",
                    Direccion = "Calle Verdadera 456",
                    Telefono = "555-5678"
                }
            );

            modelBuilder.Entity<Porcino>().HasData(
                new Porcino
                {
                    Id = 1,
                    Identificacion = "P001",
                    Raza = "Landrace",
                    Edad = 2,
                    Peso = 120.5f,
                    ClienteId = 1 
                },
                new Porcino
                {
                    Id = 2,
                    Identificacion = "P002",
                    Raza = "Duroc",
                    Edad = 3,
                    Peso = 150.2f,
                    ClienteId = 2 
                }
            );


            modelBuilder.Entity<Alimentacion>().HasData(
                new Alimentacion
                {
                    Id = 1,
                    PorcinoId = 1, 
                    Detalles = "Alimentación balanceada con proteínas"
                },
                new Alimentacion
                {
                    Id = 2,
                    PorcinoId = 2, 
                    Detalles = "Alimentación con maíz y soja"
                }
            );

            // Configurar relaciones de porcino y alimentaciones/ Test
            modelBuilder.Entity<Porcino>()
                .HasOne(p => p.Cliente)
                .WithMany(c => c.Porcinos)
                .HasForeignKey(p => p.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Alimentacion>()
                .HasOne(a => a.Porcino)
                .WithMany(p => p.Alimentaciones)
                .HasForeignKey(a => a.PorcinoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
