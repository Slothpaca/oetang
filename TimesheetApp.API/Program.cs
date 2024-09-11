using TimesheetApp.API.Users.Data.Repositories;

namespace TimesheetApp.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add authorization
        //builder.Services.AddAuthorization();
        
        // Add MediatR
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
        
        // Register our own classes via Dependency Injection (DI)
        builder.Services.AddTransient<IUserRepository, UserRepository>();
        
        // Register all controllers
        builder.Services.AddControllers();

        // Add Swagger / OpenAPI
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.MapControllers();
        
        //app.UseAuthorization();
        
        app.Run();
    }
}