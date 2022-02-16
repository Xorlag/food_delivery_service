using Microsoft.AspNetCore.Mvc.Versioning;
using FoodDeliveryService.APIGateway.Configuration;
using FoodDeliveryService.Messaging.RabbitMQ;
using FoodDeliveryService.Mappers;
using OrderService.Proxy;
using OrderService.DTO;
using FoodDeliveryService.APIGateway.DTO.Requests;
using FoodDeliveryService.APIGateway.Mappers;
using RestaurantService.Proxy;

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
    services.AddSingleton<IOrderServiceProxyConfiguration>(configurationInstance);
    services.AddSingleton<IRestaurantServiceProxyConfiguration>(configurationInstance);
}

static void ConfigureDependencyInjection(IServiceCollection services)
{
    services.AddSingleton<OrderServiceProxy>();
    services.AddSingleton<RestaurantServiceProxy>();
    services.AddSingleton<IMapper<CreateOrderRequest, OrderDetailsDTO>, CreateOrderRequestToCommandMapper>();
    services.UseRabbitMQClientFactory();
}
