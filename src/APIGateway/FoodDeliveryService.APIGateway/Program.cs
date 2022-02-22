using Microsoft.AspNetCore.Mvc.Versioning;
using FoodDeliveryService.APIGateway.Configuration;
using FoodDeliveryService.Messaging.RabbitMQ;
using FoodDeliveryService.Mappers;
using OrderService.Proxy;
using OrderService.DTO;
using FoodDeliveryService.APIGateway.DTO.Requests;
using FoodDeliveryService.APIGateway.Mappers;
using RestaurantService.Proxy;
using OrderService.DTO.Entities;
using Microsoft.Extensions.Options;
using OrderService.Proxy.ProxyImplementations;
using RestaurantService.Proxy.ProxyImplementations;

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
    services.AddOptions<ApiGatewayConfiguration>()
                .Configure<IConfiguration>((settings, configuration) =>
                {
                    configuration.GetSection("ApiGateway").Bind(settings);
                });
}

static void ConfigureDependencyInjection(IServiceCollection services)
{
    services.AddSingleton<IOrderServiceProxy, OrderServiceProxyAsync>();
    services.AddSingleton<IRestaurantServiceProxy, RestaurantServiceProxyAsync>();
    services.AddSingleton<IMapper<CreateOrderRequest, OrderDetailsDTO>, CreateOrderRequestToCommandMapper>();
    services.UseRabbitMQClientFactory<IOrderServiceProxy>(sp =>
    {
        var configurationOptions = sp.GetRequiredService<IOptions<ApiGatewayConfiguration>>();
        var configuration = configurationOptions.Value.OrderServiceProxy;
        return new RabbitMQClientOptions
        {
            ConnectionString = configuration.MessageBrokerConnectionString,
            QueueName = configuration.MessageBrokerQueueName,
        };
    });
    services.UseRabbitMQClientFactory<IRestaurantServiceProxy>(sp =>
    {
        var configurationOptions = sp.GetRequiredService<IOptions<ApiGatewayConfiguration>>();
        var configuration = configurationOptions.Value.RestaurantServiceProxy;
        return new RabbitMQClientOptions
        {
            ConnectionString = configuration.MessageBrokerConnectionString,
            QueueName = configuration.MessageBrokerQueueName,
        };
    });
}
