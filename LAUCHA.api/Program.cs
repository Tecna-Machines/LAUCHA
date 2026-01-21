using LAUCHA.application;
using LAUCHA.application.interfaces;
using LAUCHA.domain.entities;
using LAUCHA.domain.entities.Contrato;
using LAUCHA.domain.Entities.Empleados;
using LAUCHA.domain.Entities.Liquidaciones;
using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.domain.interfaces.IServices;
using LAUCHA.infrastructure;
using LAUCHA.infrastructure.persistence;
using LAUCHA.infrastructure.repositories;
using LAUCHA.infrastructure.Services.Logs;
using LAUCHA.infrastructure.Services.Marcas;
using LAUCHA.infrastructure.Services.Marcas.Interface;
using LAUCHA.infrastructure.Services.Marcas.Persistence;
using LAUCHA.infrastructure.Services.Menues;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//custom
string banner = @" $$$$$$\  $$\   $$\ $$$$$$$$\ $$$$$$$\        $$\       $$$$$$\  
$$  __$$\ $$ | $$  |$$  _____|$$  __$$\       $$ |     $$  __$$\ 
$$ /  $$ |$$ |$$  / $$ |      $$ |  $$ |      $$ |     $$ /  $$ |
$$$$$$$$ |$$$$$  /  $$$$$\    $$$$$$$  |      $$ |     $$ |  $$ |
$$  __$$ |$$  $$<   $$  __|   $$  __$$<       $$ |     $$ |  $$ |
$$ |  $$ |$$ |\$$\  $$ |      $$ |  $$ |      $$ |     $$ $$\$$ |
$$ |  $$ |$$ | \$$\ $$$$$$$$\ $$ |  $$ |      $$$$$$$$\\$$$$$$ / 
\__|  \__|\__|  \__|\________|\__|  \__|      \________|\___$$$\ 
                                                            \___|
                                                                 
                                                                 ";

Console.WriteLine(banner + "\n");

//Logs
string logPath = builder.Configuration["Appsettings:logPath"];

if (logPath == null)
{
    Console.WriteLine("error , falta la ruta del archivo de log");
    return;
}

builder.Services.AddSingleton<ILogsApp, LogService>(log =>
{
    return new LogService(logPath);
});

//database
string connectionString = builder.Configuration["ConnectionStrings:Production"];

if (builder.Environment.IsDevelopment())
{
    connectionString = builder.Configuration["ConnectionStrings:Test"];
}

builder.Services.AddDbContext<LiquidacionesDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

//dependecy injection
//NEW 2025
builder.Services.AddInfrastructureServices();
builder.Services.AddAplicationServices();

builder.Services.AddScoped<IGenericRepository<Empleado>, Borrame>();

builder.Services.AddScoped<IGenericRepository<Adicional>, AdicionalRepository>();




builder.Services.AddScoped<IGenericRepository<Remuneracion>, RemuneracionRepository>();
builder.Services.AddScoped<IRemuneracionRepository, RemuneracionRepository>();





//builder.Services.AddScoped<ILiquidacionService, CrearLiquidacionService>();

builder.Services.AddScoped<IGenericRepository<RemuneracionPorLiquidacionPersonal>, RemuneracionPorLiquidacionRepository>();
builder.Services.AddScoped<IGenericRepository<RetencionPorLiquidacionPersonal>, RetencionPorLiquidacionRepository>();
builder.Services.AddScoped<IGenericRepository<Liquidacion>, LiquidacionPersonalRepository>();

builder.Services.AddScoped<IItemsLiquidacionRepository, ITemsLiquidacionRepository>();


builder.Services.AddScoped<IGenericRepository<NoRemuneracion>, NoRemuneracionRepository>();
builder.Services.AddScoped<INoRemuneracionRepository, NoRemuneracionRepository>();
builder.Services.AddScoped<IGenericRepository<NoRemuneracionPorLiquidacionPersonal>, NoRemuneracionPorLiquidacionRepository>();



builder.Services.AddScoped<ILiquidacionRepositoryOLD, LiquidacionPersonalRepository>();

builder.Services.AddScoped<IGenericRepository<PagoLiquidacion>, PagoLiquidacionRepository>();


builder.Services.AddHttpClient();



//servicios externos
builder.Services.AddScoped<IMenuesService>(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    string? user = configuration["MenuService:user"];
    string? password = configuration["MenuService:password"];
    string? url = configuration["MenuService:url"];

    if (user == null || password == null || url == null)
    {
        throw new ArgumentNullException();
    }

    var httpClient = sp.GetRequiredService<IHttpClientFactory>().CreateClient();
    httpClient.BaseAddress = new Uri(url);

    return new MenuesService(httpClient, user, password);
});


//Marcas
string? databaseMarcas = builder.Configuration["MarcasService:databasePath"];


builder.Services.AddDbContext<MarcasDbContext>(options => options.UseMySQL(databaseMarcas));

builder.Services.AddScoped<IMarcasDb, MarcasDb>();
builder.Services.AddScoped<ISistemaMarcas, MarcasServiceAccess>();

//CORS deshabilitar
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseHttpsRedirection();
    app.UseAuthorization();
}

app.UseCors("AllowAll");

app.MapControllers();

var logger = app.Services.GetRequiredService<ILogsApp>();
logger.LogInformation("preparando inicio de aplicacion");

//test database
var builderConnectionString = new MySqlConnectionStringBuilder(connectionString);
string host = builderConnectionString.Server;


logger.LogInformation("iniciando prueba de conexion con base de datos...");

try
{
    using var scope = builder.Services.BuildServiceProvider().CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<LiquidacionesDbContext>();

    if (!context.Database.CanConnect())
    {
        logger.LogError($"fallo la conexion con el servidor de base de datos: {host}");
    }

    logger.LogInformation("conexion exitosa con el servidor DB: {Host}", host);
    scope.Dispose();
}
catch (Exception ex)
{
    logger.LogError(ex, "se genero una excepcion al conectar con el host: {Host}", host);
    return;
}



logger.LogInformation("todo parece ir bien c: ");
logger.LogInformation("app run...");

app.Run();
