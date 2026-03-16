using iText.IO.Source;
using LAUCHA.application;
using LAUCHA.application.interfaces;
using LAUCHA.infrastructure;
using LAUCHA.infrastructure.asistencias;
using LAUCHA.infrastructure.persistence;
using LAUCHA.infrastructure.Services.Logs;
using LAUCHA.infrastructure.SysContab;
using Microsoft.EntityFrameworkCore;

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

builder.Services.AddDbContext<LiquidacionesDbContext>(options =>
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString),
        mySqlOptions =>
        {
            mySqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(10),
                errorNumbersToAdd: null
            );
        }
    )
);


//dependecy injection
//NEW 2025
builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();

builder.Services.AddSysContab(builder.Configuration);



builder.Services.AddHttpClient();



//Marcas
string marcasDb = builder.Configuration["ConnectionStrings:Asistencias"];
builder.Services.AddAsistenciasPersistence(marcasDb);

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
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<LiquidacionesDbContext>();

    if (!context.Database.CanConnect())
    {
        logger.LogError("No se pudo conectar a la base de datos");
        return;
    }
}


logger.LogInformation("todo parece ir bien c: ");
logger.LogInformation("app run...");

app.Run();

