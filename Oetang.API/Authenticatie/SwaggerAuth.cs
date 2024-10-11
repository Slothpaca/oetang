using Microsoft.OpenApi.Models;
using Oetang.API.Authenticatie;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Oetang.API.Authentication;

public class SwaggerOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var header = new OpenApiParameter
        {
            Name = "Oetang-user",
            In = ParameterLocation.Header,
            Required = true,
            Schema = new OpenApiSchema { Type = "string" }
        };

        operation.Parameters.Add(header);
    }
}