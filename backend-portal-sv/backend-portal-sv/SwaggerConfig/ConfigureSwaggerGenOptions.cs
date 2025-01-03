using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace backend_portal_sv.SwaggerConfig
{
    public class ConfigureSwaggerGenOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerGenOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateApiVersionInfo(description));
            }
        }

        private OpenApiInfo CreateApiVersionInfo(ApiVersionDescription description)
        {
            return new OpenApiInfo
            {
                Title = "API de Seguro de Viagens",
                Version = description.ApiVersion.ToString(),
                Description = "API destinada ao portal de seguros de viagens, oferecendo integração com diversos serviços relacionados a seguros para viagens nacionais/internacionais.",
                Contact = new OpenApiContact
                {
                    Name = "APISV",
                    Email = "neemiasb.dev@gmail.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Licenca -> Teste Técnico - API"
                }
            };
        }
    }
}
