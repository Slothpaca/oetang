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
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            builder.Services.AddSwaggerGen(c => c.OperationFilter<SwaggerOperationFilter>());
            builder.Services
                .AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(Program).Assembly));

            builder.Services
                .AddDbContext<OetangDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Oetang")));

            //Authenticatie toevoegen aan de builder
            
            builder.Services
                .AddAuthentication(options => options.DefaultScheme = "emailheader")
                .AddScheme<AuthenticationSchemeOptions, OetangAuthenticationHandler>("emailheader", options => { });

            builder.Services
                .AddAuthorization(options => {
                    options.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                });
           
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddControllers();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers().RequireAuthorization();

            app.Run();
        }
    }
}
