using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace App.Configurations;

public class RemoveAllSchemas : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        swaggerDoc.Components.Schemas.Clear();
    }
}