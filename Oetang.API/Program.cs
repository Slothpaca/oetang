// Include necessary namespaces.
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Oetang.API.Authenticatie;
using Oetang.API.Authentication;
using Oetang.API.Database;


namespace Oetang.API
{

    public class Program
    {

        public static void Main(string[] args)
        {
            // Builds the web application, using configuration from 'appsettings.json' or other config sources.
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;


            // Adds Swagger to generate API documentation.
            builder.Services
                .AddSwaggerGen(c => c.OperationFilter<SwaggerOperationFilter>());

            // Adds MediatR to support CQRS pattern (commands/queries).
            builder.Services
                .AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(Program).Assembly));

            // Configures the Entity Framework Core DbContext to use SQL Server with a connection string.
            builder.Services
                .AddDbContext<OetangDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Oetang")));

            // Adds custom authentication via an email header, using the 'OetangAuthenticationHandler'.
            builder.Services
                .AddAuthentication(options => options.DefaultScheme = "emailheader")
                .AddScheme<AuthenticationSchemeOptions, OetangAuthenticationHandler>("emailheader", options => { });

            // Adds authorization services with a default policy that requires authenticated users.
            builder.Services
                .AddAuthorization(options => {
                    options.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                });

            // Adds HTTP context accessor service for accessing the current request context.
            builder.Services.AddHttpContextAccessor();

            // Adds support for controllers and API endpoints.
            builder.Services.AddControllers();


            // Builds the web application.
            var app = builder.Build();

            // Enables Swagger and Swagger UI for API documentation and testing.
            app.UseSwagger();
            app.UseSwaggerUI();

            // Forces HTTPS for security.
            app.UseHttpsRedirection();

            // Enables authentication and authorization in the application.
            app.UseAuthentication();
            app.UseAuthorization();

            // Maps the controller routes, ensuring authorization is required for all endpoints.
            app.MapControllers().RequireAuthorization();

            // Runs the web application.
            app.Run();
        }
    }
}
