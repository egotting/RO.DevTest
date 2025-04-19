using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RO.DevTest.Application;
using RO.DevTest.Domain.Entities;
using RO.DevTest.Infrastructure.IoC;
using RO.DevTest.Persistence;
using RO.DevTest.Persistence.Extension;
using RO.DevTest.Persistence.IoC;

namespace RO.DevTest.WebApi;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        var CString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<DefaultContext>(opt =>
        {
            opt.UseNpgsql(CString);
        });

        builder.Services.InjectPersistenceDependencies().InjectInfrastructureDependencies();
        builder.Services.InjectPersistenceDependencies().ConfigureHandlers();
        builder.Services.InjectPersistenceDependencies().ValidatorInjection();
        // Add Mediatr to program
        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(
                typeof(ApplicationLayer).Assembly,
                typeof(Program).Assembly
            );
        });
        var app = builder.Build();
        await app.Services.RunMigration();
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}