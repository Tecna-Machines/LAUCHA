using LAUCHA.application.interfaces;
using LAUCHA.application.UseCase.AgregarEmpleadoNuevo;
using LAUCHA.domain.entities;
using LAUCHA.domain.interfaces.IRepositories;
using LAUCHA.domain.interfaces.IUnitsOfWork;
using LAUCHA.infrastructure.persistence;
using LAUCHA.infrastructure.repositories;
using LAUCHA.infrastructure.unitOfWork;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//custom

//database
string connectionString = builder.Configuration["ConnectionStrings:Production"];

if (builder.Environment.IsDevelopment())
{
    connectionString = builder.Configuration["ConnectionStrings:Test"];
}

builder.Services.AddDbContext<LiquidacionesDbContext>(options => options.UseMySQL(connectionString));

//dependecy injection
builder.Services.AddScoped<ICrearEmpleadoService, AgregarEmpleadoNuevoService>();
builder.Services.AddScoped<IUnitOfWorkEmpleado, UnitOfWorkEmpleado>();
builder.Services.AddScoped<IGenericRepository<Empleado>, EmpleadoRepository>();
builder.Services.AddScoped<IGenericRepository<Cuenta>, CuentaRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseHttpsRedirection();
    app.UseAuthorization();
}


app.MapControllers();

app.Run();
