using AutoMapper;
using System.Text.Json.Serialization;
using HonestProduct.Infrastructure.Helpers;
using HonestProduct.Infrastructure.Config;
using HonestProduct.Web.Repositories;
using HonestProduct.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// add services to DI container
{
    var root = Directory.GetCurrentDirectory();
    var dotenv = Path.Combine(root, ".env");
    DotEnvFile.LoadFile(dotenv);
    var config = new ConfigurationBuilder().AddEnvironmentVariables().Build();

    var services = builder.Services;
    var env = builder.Environment;

    services.AddDbContext<DataBaseContext>();
    services.AddCors();
    services.AddControllers().AddJsonOptions(x =>
    {
        x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

        x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    // configure DI for application services
    services.AddScoped<IProductRepository, ProductRepository>();
    services.AddScoped<IProductService, ProductService>();
}

var app = builder.Build();

// configure HTTP request pipeline
{
    // global cors policy
    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

    // global error handler
    app.UseMiddleware<ErrorHandlerMiddleware>();

    app.MapControllers();
}

app.Run(Environment.GetEnvironmentVariable("HTTP_ADDRESS"));