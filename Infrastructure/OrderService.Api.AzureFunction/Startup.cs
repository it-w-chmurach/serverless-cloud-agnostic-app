using MediatR;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using OrderService.Application.Commands;
using OrderService.Domain.Repositories;
using OrderService.HttpApi.AzureFunctions;
using OrderService.Persistence.MongoDb.Repositories;

[assembly: FunctionsStartup(typeof(Startup))]

namespace OrderService.HttpApi.AzureFunctions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddMediatR(typeof(CreateOrder).Assembly);

            builder.Services.AddScoped<IOrderRepository, OrderAggregateRepository>();
        }
    }
}