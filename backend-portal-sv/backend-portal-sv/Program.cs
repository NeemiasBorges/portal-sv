using Asp.Versioning.ApiExplorer;
using backend_portal_sv.SwaggerConfig;
using Infra.Conection;
using Infra.Repository;
using Infra.Repository.Interfaces;
using Infra.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Services.Services;
using Services.Services.Chatbot;
using Services.Services.Chatbot.Interface;
using Services.Services.Cliente;
using Services.Services.Cliente.Interfaces;
using Services.Services.Interfaces;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Configuração dos Controllers
builder.Services.AddControllers();

// Configuração Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
// Configuração do contexto de banco de dados
builder.Services.AddDbContext<ConnectionContext>();

#region Repositorios
builder.Services.AddScoped<IStorageHandler, StorageHandler>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IChatbotRepository, ChatbotRepository>();
#endregion

#region Services
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IChatbotService, ChatbotService>();
#endregion

// Configuração do logger
builder.Services.AddSingleton<Serilog.ILogger>(new LoggerConfiguration()
    .CreateLogger());

#region API Versioning
builder.Services.AddApiVersioning().AddMvc().AddApiExplorer(setup =>
{
    setup.GroupNameFormat = "'v'VVV";
    setup.SubstituteApiVersionInUrl = true;
});
builder.Services.ConfigureOptions<ConfigureSwaggerGenOptions>();
#endregion

#region Swagger Configuration
builder.Services.AddSwaggerGen(c =>
{
    c.OperationFilter<SwaggerDefaultValues>();
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        In = ParameterLocation.Header,
        Description = "Bearer {token}",
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new string[] {}
        }
    });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});
#endregion

#region HTTP Response Configuration
builder.Services.Configure<HttpResponse>(options =>
{
    options.Headers.Add("Content-Type", "application/json; charset=utf-8");
});
#endregion

#region Authentication
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Secret"] ?? "")),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
#endregion

var app = builder.Build();

#region Middleware Configuration
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error-dev");
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var version = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        foreach (var item in version.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{item.GroupName}/swagger.json", $"Versão API - {item.GroupName.ToUpper()}");
        }
    });
}
else
{
    app.UseExceptionHandler("/error");
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseStatusCodePages();
app.UseAuthorization();
app.MapControllers();
#endregion

await app.RunAsync();
