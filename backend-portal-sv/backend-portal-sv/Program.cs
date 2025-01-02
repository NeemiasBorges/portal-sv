using Infra.Conection;
using Infra.Repository;
using Infra.Repository.Interfaces;
using Microsoft.OpenApi.Models;
using Serilog;
using Services.Services.Cliente;
using Services.Services.Cliente.Interfaces;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ConnectionContext>();
#region repositorios
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
#endregion

#region services
builder.Services.AddScoped<IClienteService, ClienteService>();
#endregion

builder.Services.AddSingleton<Serilog.ILogger>(new LoggerConfiguration()
    .CreateLogger());

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SV API",
        Version = "v1",
        Description = "API para gerenciamento de SV"
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
