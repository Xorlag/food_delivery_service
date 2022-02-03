using FoodDeliveryService.APIGateway.Commands;
using FoodDeliveryService.APIGateway.Configuration;
using FoodDeliveryService.APIGateway.QueueClients;
using FoodDeliveryService.APIGateway.QueueClients.Factory;
using FoodDeliveryService.APIGateway.Services;
using Microsoft.AspNetCore.Mvc.Versioning;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
});

builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

ConfigureDependencyInjection(builder.Services);
SetupApiGatewayConfiguration(builder.Configuration, builder.Services);

var app = builder.Build();

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

static void SetupApiGatewayConfiguration(IConfiguration configuration, IServiceCollection services)
{
    var configurationInstance = new ApiGatewayConfiguration(configuration);
    services.AddSingleton<IOrderServiceConfiguration>(configurationInstance);
}

static void ConfigureDependencyInjection(IServiceCollection services)
{
    services.AddSingleton<IMessageBrokerClientFactory, RabbitMQClientFactory>();
    services.AddSingleton<OrderServiceClient>();
    services.AddSingleton<IConnectionFactory, ConnectionFactory>();
}
