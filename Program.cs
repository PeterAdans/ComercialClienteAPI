using ComercialClienteAPI.Data;
using ComercialClienteAPI.Repository;
using ComercialClienteAPI.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1️⃣ CONFIGURAR CONEXIÓN A SQL SERVER
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2️⃣ REGISTRAR CONTROLADORES (✅ ESTO FALTABA)
builder.Services.AddControllers(); // <-- IMPORTANTE

// 3️⃣ INYECTAR REPOSITORIOS
builder.Services.AddScoped<ClienteRepository>();
builder.Services.AddScoped<ComercialRepository>();
builder.Services.AddScoped<PedidoRepository>();

// 4️⃣ INYECTAR SERVICIOS
builder.Services.AddScoped<ClienteService, ClienteServiceImpl>();
builder.Services.AddScoped<ComercialService, ComercialServiceImpl>();
builder.Services.AddScoped<PedidoService, PedidoServiceImpl>();

// 5️⃣ CONFIGURAR SWAGGER
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 6️⃣ CONSTRUIR LA APP
var app = builder.Build();

// 7️⃣ USAR SWAGGER EN DESARROLLO
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 8️⃣ RUTEO Y HTTPS
app.UseHttpsRedirection();
app.MapControllers(); // Habilita [ApiController]

app.Run();
