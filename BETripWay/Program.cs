
using BETripWay.CapaNegocio;
using CapaServicio.Repositorio;
using Gestion_Vuelos.Repositorios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

//Add Services Promociones
builder.Services.AddScoped<IRepositorioPromocion, RepositorioPromocion>();
// Add Services Equipaje
builder.Services.AddScoped<IRepositorioEquipaje, RepositorioEquipaje>();
// Add Services Usuarios
builder.Services.AddScoped<IRepositorioUsuario,RepositorioUsuario>();
//Add Services Hotel
builder.Services.AddScoped<IRepositorioHotel, RepositorioHotel>();
//Add Services Habitacion
builder.Services.AddScoped<IRepositorioHabitacion, RepositorioHabitacion>();
//Services Metodo Pago
builder.Services.AddScoped<IRepositorioMetodoPago, RepositorioMetodoPago>();
//Services Pasajero
builder.Services.AddScoped<IRepositorioPasajero, RepositorioPasajero>();
//Services Reserva
builder.Services.AddScoped<IRepositorioReserva, RepositorioReserva>();
//Services Vuelo
builder.Services.AddScoped<IRepositorioVuelo, RepositorioVuelo>();
//Services Aeropuerto
builder.Services.AddScoped<IRepositorioAeropuerto, RepositorioAeropuerto>();
//Services Comentario
builder.Services.AddScoped<IRepositorioComentario, RepositorioComentario>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Cors
builder.Services.AddCors(options => options.AddPolicy("AllowWebApp",
    builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

//Add Context
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("conexion"),
        sqlOptions => sqlOptions.MigrationsAssembly("BETripWay"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowWebApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
