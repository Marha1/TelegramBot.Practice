using Application.Services.Implementations;
using Application.Services.Interfaces;
using Domain.Models;
using Infrastructure.Dal;
using Infrastructure.Dal.Interfaces;
using Infrastructure.Dal.Repository;
using Infrastructure.Jobs;
using Microsoft.EntityFrameworkCore;

class Program
{
    static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Configuration.AddJsonFile("appsettings.json");
        builder.Services.AddDbContext<AplicationContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddScoped<IBaseRepository<Employee>, EmployeRepository>();
        builder.Services.AddScoped<IEmployeService, EmployeService>();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        var serviceProvider = builder.Services.BuildServiceProvider(); // создаем ServiceProvider
        await PostcardSheduler.Start(serviceProvider,builder.Configuration);  // Передаем ServiceProvider в метод Start
        var app = builder.Build();
        app.UseHttpsRedirection();
        app.MapControllers();
        app.Run();
    }
}