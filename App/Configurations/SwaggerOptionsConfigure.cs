using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace App.Configurations;

public class SwaggerOptionsConfigure : IConfigureOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;

    public SwaggerOptionsConfigure(IApiVersionDescriptionProvider provider) => _provider = provider;
    
    public void Configure(SwaggerGenOptions options)
    {
        foreach (var item in _provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(item.GroupName, new OpenApiInfo()
            {
                Title = $"Web Api {item.ApiVersion}",
                Version = item.ApiVersion.ToString(),
            });
        }
    }
}