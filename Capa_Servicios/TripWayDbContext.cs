using CapaModelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class TripWayDbContext : DbContext
    {
        public TripWayDbContext(DbContextOptions<TripWayDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Vuelo> Vuelos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Promocion> Promociones { get; set; }
        public DbSet<Pasajero> Pasajeros { get; set; }
        public DbSet<MetodoPago> MetodosPago { get; set; }
        public DbSet<Hotel> Hoteles { get; set; }
        public DbSet<Habitacion> Habitaciones { get; set; }
        public DbSet<Equipaje> Equipajes { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Cdestino> Cdestinos { get; set; }
        public DbSet<Aeropuerto> Aeropuertos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ciudad>()
                .HasOne(c => c.Pais)
                .WithMany()
                .HasForeignKey(c => c.PaisId);

            modelBuilder.Entity<Vuelo>()
                .HasOne(v => v.Origen)
                .WithMany()
                .HasForeignKey(v => v.Corigen)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vuelo>()
                .HasOne(v => v.Destino)
                .WithMany()
                .HasForeignKey(v => v.CDestino)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Equipaje>()
                .HasOne(e => e.Usuario)
                .WithMany()
                .HasForeignKey(e => e.CedulaUsuario);

            modelBuilder.Entity<Comentario>()
                .HasOne(c => c.Usuario)
                .WithMany()
                .HasForeignKey(c => c.CedulaUsuario);

            modelBuilder.Entity<Habitacion>()
                .HasOne(h => h.Usuario)
                .WithMany()
                .HasForeignKey(h => h.CedulaUsuario);

        }
    }
}
