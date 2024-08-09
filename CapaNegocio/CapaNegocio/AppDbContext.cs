using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BETripWay.CapaNegocio;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aeropuerto> Aeropuertos { get; set; }

    public virtual DbSet<Cdestino> Cdestinos { get; set; }

    public virtual DbSet<Ciudad> Ciudads { get; set; }

    public virtual DbSet<Comentario> Comentarios { get; set; }

    public virtual DbSet<Equipaje> Equipajes { get; set; }

    public virtual DbSet<Habitacion> Habitacions { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<MetodoPago> MetodoPagos { get; set; }

    public virtual DbSet<Pai> Pais { get; set; }

    public virtual DbSet<Pasajero> Pasajeros { get; set; }

    public virtual DbSet<Promocion> Promocions { get; set; }

    public virtual DbSet<Reserva> Reservas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Vuelo> Vuelos { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aeropuerto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Aeropuer__3214EC0735712352");

            entity.ToTable("Aeropuerto");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Abreviatura).HasMaxLength(10);
            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.CiudadNavigation).WithMany(p => p.Aeropuertos)
                .HasForeignKey(d => d.Ciudad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Aeropuert__Ciuda__10566F31");
        });

        modelBuilder.Entity<Cdestino>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cdestino__3214EC07886B42BA");

            entity.ToTable("Cdestino");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Valor).HasMaxLength(100);
        });

        modelBuilder.Entity<Ciudad>(entity =>
        {
            entity.HasKey(e => e.IdCiudad).HasName("PK__Ciudad__D4D3CCB0BFDBC68B");

            entity.ToTable("Ciudad");

            entity.Property(e => e.IdCiudad).ValueGeneratedNever();
            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.Pais).WithMany(p => p.Ciudads)
                .HasForeignKey(d => d.PaisId)
                .HasConstraintName("FK__Ciudad__PaisId__6754599E");
        });

        modelBuilder.Entity<Comentario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comentar__3214EC07146B4C51");

            entity.ToTable("Comentario");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CedulaUsuario).HasMaxLength(50);
            entity.Property(e => e.ComentarioTexto).HasMaxLength(500);

            entity.HasOne(d => d.CedulaUsuarioNavigation).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.CedulaUsuario)
                .HasConstraintName("FK__Comentari__Cedul__0B91BA14");
        });

        modelBuilder.Entity<Equipaje>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Equipaje__3214EC07953104C1");

            entity.ToTable("Equipaje");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(1, 1);

            entity.Property(e => e.Id).HasMaxLength(50);
            entity.Property(e => e.CedulaUsuario).HasMaxLength(50);
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.Tipo).HasMaxLength(100);

            entity.HasOne(d => d.CedulaUsuarioNavigation).WithMany(p => p.Equipajes)
                .HasForeignKey(d => d.CedulaUsuario)
                .HasConstraintName("FK__Equipaje__Cedula__08B54D69");
        });

        modelBuilder.Entity<Habitacion>(entity =>
        {
            entity.HasKey(e => e.IdHabitaciones).HasName("PK__Habitaci__2CD071588BE05988");

            entity.ToTable("Habitacion");

            entity.Property(e => e.IdHabitaciones)
            .ValueGeneratedNever()
                .UseIdentityColumn(1, 1);

            entity.Property(e => e.IdHabitaciones).ValueGeneratedNever();
            entity.Property(e => e.CedulaUsuario).HasMaxLength(50);
            entity.Property(e => e.Descripcion).HasMaxLength(500);
            entity.Property(e => e.TipoHabitacion).HasMaxLength(100);

            entity.HasOne(d => d.CedulaUsuarioNavigation).WithMany(p => p.Habitacions)
                .HasForeignKey(d => d.CedulaUsuario)
                .HasConstraintName("FK__Habitacio__Cedul__05D8E0BE");

            entity.HasOne(d => d.IdHotelNavigation).WithMany(p => p.Habitacions)
                .HasForeignKey(d => d.IdHotel)
                .HasConstraintName("FK__Habitacio__IdHot__04E4BC85");
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.IdHotel).HasName("PK__Hotel__653BCCC4CF2CC5AA");

            entity.ToTable("Hotel");

            entity.Property(e => e.IdHotel)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(1, 1); 

            entity.Property(e => e.Direccion).HasMaxLength(200);

            entity.HasOne(d => d.IdCiudadNavigation).WithMany(p => p.Hotels)
                .HasForeignKey(d => d.IdCiudad)
                .HasConstraintName("FK__Hotel__IdCiudad__02084FDA");
        });


        modelBuilder.Entity<MetodoPago>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MetodoPa__3214EC071BBAAFCF");

            entity.ToTable("MetodoPago");

            entity.Property(e => e.Cvc).HasMaxLength(10);
            entity.Property(e => e.Expiracion).HasMaxLength(10);
            entity.Property(e => e.NombreTitular).HasMaxLength(100);
            entity.Property(e => e.NumeroTarjeta).HasMaxLength(50);
        });

        modelBuilder.Entity<Pai>(entity =>
        {
            entity.HasKey(e => e.PaisId).HasName("PK__Pais__B501E185364AF088");

            entity.Property(e => e.PaisId).ValueGeneratedNever();
            entity.Property(e => e.CodigoPais).HasMaxLength(10);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Pasajero>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pasajero__3214EC076178DB44");

            entity.ToTable("Pasajero");

            entity.Property(e => e.Tipo).HasMaxLength(50);

            entity.HasOne(d => d.Reserva).WithMany(p => p.Pasajeros)
                .HasForeignKey(d => d.ReservaId)
                .HasConstraintName("FK__Pasajero__Reserv__7B5B524B");
        });

        modelBuilder.Entity<Promocion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Promocio__3214EC079C00B309");

            entity.ToTable("Promocion");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(1, 1);

            entity.Property(e => e.Descripcion).HasMaxLength(500);
            entity.Property(e => e.Destino).HasMaxLength(100);
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Titulo).HasMaxLength(100);
        });

        modelBuilder.Entity<Reserva>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reserva__3214EC0702DFC0E4");

            entity.ToTable("Reserva");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Apellidos).HasMaxLength(100);
            entity.Property(e => e.CiudadOrigen).HasMaxLength(100);
            entity.Property(e => e.Clase).HasMaxLength(50);
            entity.Property(e => e.Destino).HasMaxLength(100);
            entity.Property(e => e.FechaIda).HasColumnType("datetime");
            entity.Property(e => e.FechaRegreso).HasColumnType("datetime");
            entity.Property(e => e.Nombres).HasMaxLength(100);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.CedulaUsuario).HasName("PK__Usuario__C0B559BC7CA1F68E");

            entity.ToTable("Usuario");

            entity.Property(e => e.CedulaUsuario).HasMaxLength(50);
            entity.Property(e => e.Contrasenia).HasMaxLength(100);
            entity.Property(e => e.CorreoElectronico).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.PaisResidencia).HasMaxLength(100);
        });

        modelBuilder.Entity<Vuelo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vuelo__3214EC07BF48FBF9");

            entity.ToTable("Vuelo");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Cdestino).HasColumnName("CDestino");
            entity.Property(e => e.Fpartida)
                .HasColumnType("datetime")
                .HasColumnName("FPartida");
            entity.Property(e => e.Naeropuerto).HasColumnName("NAeropuerto");
            entity.Property(e => e.Nvuelo)
                .HasMaxLength(50)
                .HasColumnName("NVuelo");

            entity.HasOne(d => d.CdestinoNavigation).WithMany(p => p.Vuelos)
                .HasForeignKey(d => d.Cdestino)
                .HasConstraintName("FK__Vuelo__CDestino__32AB8735");

            entity.HasOne(d => d.CorigenNavigation).WithMany(p => p.Vuelos)
                .HasForeignKey(d => d.Corigen)
                .HasConstraintName("FK__Vuelo__Corigen__31B762FC");

            entity.HasOne(d => d.NaeropuertoNavigation).WithMany(p => p.Vuelos)
                .HasForeignKey(d => d.Naeropuerto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Vuelo__NAeropuer__339FAB6E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
