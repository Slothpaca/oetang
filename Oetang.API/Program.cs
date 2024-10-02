using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oetang.API.Database;

namespace Oetang.API
{
    public class Program
    {
        private string trst = "";

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(Program).Assembly));
            builder.Services.AddDbContext<OetangDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Oetang")));
            builder.Services.AddControllers();

            var app = builder.Build();
            app.UseHttpsRedirection();
            app.MapControllers();

            app.Run();
        }
    }
}
