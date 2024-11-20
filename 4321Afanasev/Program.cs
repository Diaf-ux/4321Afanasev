using NLog;
using NLog.Web;
using Microsoft.EntityFrameworkCore;
using _4321Afanasev.Database;
using _4321Afanasev.Interfaces;
using _4321Afanasev.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

try
{
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    // Добавляем регистрацию DbContext
    builder.Services.AddDbContext<UniversityDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

    // Регистрируем сервис ITeacherService -> TeacherService
    builder.Services.AddScoped<ITeacherService, TeacherService>();
    builder.Services.AddScoped<IDisciplineService, DisciplineService>();
    builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });



    // Add services to the container.
    builder.Services.AddControllers();
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

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, "Stopped program because of an exception");
    throw;
}
finally
{
    LogManager.Shutdown();
}
