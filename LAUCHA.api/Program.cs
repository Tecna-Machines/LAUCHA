using LAUCHA.application;
using LAUCHA.application.interfaces;
using LAUCHA.infrastructure;
using LAUCHA.infrastructure.asistencias;
using LAUCHA.infrastructure.persistence;
using LAUCHA.infrastructure.Services.Logs;
using LAUCHA.infrastructure.SysContab;

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
string logsPath = builder
                 .Configuration["Appsettings:logPath"] 
                 ?? throw new ArgumentNullException("falta.log");


builder.Services.AddSingleton<ILogsApp, LogService>(log =>
{
    return new LogService(logsPath);
});


//dependecy injection
//NEW 2025

string dbLiquidacion = builder
                       .Configuration["ConnectionStrings:Production"] 
                       ?? throw new ArgumentNullException("db.liq");

if (builder.Environment.IsDevelopment())
{
    dbLiquidacion = builder
                   .Configuration["ConnectionStrings:Development"] 
                   ?? throw new ArgumentNullException("db.liq");
}

builder.Services.AddInfrastructureServices(dbLiquidacion);
builder.Services.AddApplicationServices();
builder.Services.AddSysContab(builder.Configuration);


//Marcas
string marcasDb = builder
                  .Configuration["ConnectionStrings:Asistencias"] 
                  ?? throw new ArgumentNullException("db.asistencias");

builder.Services.AddAsistencias(marcasDb);




builder.Services.AddHttpClient();




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


logger.LogInformation("[OK] inicio completado");
logger.LogInformation("[OK] servidor funcionando");

app.Run();

