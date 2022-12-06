using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using OrderService.Application.Commands;
using OrderService.Application.Dtos;
using OrderService.Domain.Repositories;
using OrderService.Persistence.MongoDb.Repositories;
using System.Net;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace OrderService.Api.AwsLambda;

public class Functions
{
    private readonly IMediator _mediator;

    public Functions()
    {
        var services = new ServiceCollection();
        ConfigureServices(services);
        var serviceProvider = services.BuildServiceProvider();
        _mediator = serviceProvider.GetRequiredService<IMediator>();
    }

    public async Task<APIGatewayProxyResponse> NewOrder(APIGatewayProxyRequest request, ILambdaContext context)
    {
        context.Logger.LogInformation("Get Request\n");

        var newOrderDto = JsonConvert.DeserializeObject<NewOrderDto>(request.Body);

        var orderDto = await _mediator.Send(new CreateOrder(newOrderDto));

        var response = Create201Response(orderDto);

        return response;
    }

    private static APIGatewayProxyResponse Create201Response<T>(T body)
    {
        return new APIGatewayProxyResponse
        {
            StatusCode = (int)HttpStatusCode.Created,
            Body = JsonConvert.SerializeObject(body),
            Headers = new Dictionary<string, string> { { "Content-Type", "application/json" } }
        };
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddMediatR(typeof(CreateOrder).Assembly);
        services.AddScoped<IOrderRepository, OrderAggregateRepository>();
    }
}