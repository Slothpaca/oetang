// Import necessary namespaces.
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;


namespace Oetang.API.Authentication
{

    // SwaggerOperationFilter class implements IOperationFilter to customize Swagger operations.
    public class SwaggerOperationFilter : IOperationFilter
    {

        // The Apply method is called for each operation in the API.
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {

            // Create a new OpenApiParameter to define a custom header for authentication.
            var header = new OpenApiParameter
            {
                Name = "Oetang-user",                               // Name of the header.
                In = ParameterLocation.Header,                      // Specify that this parameter is in the header.
                Required = true,                                    // Mark the header as required.
                Schema = new OpenApiSchema { Type = "string" }      // Specify the data type of the header value
            };


            // Add the header parameter to the operation's parameters collection.
            operation.Parameters.Add(header);
        }
    }
};