using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OrderService.Api.AzureFunction.Tests.Common;
using OrderService.Api.AzureFunctions;
using OrderService.HttpApi.AzureFunctions;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace OrderService.Api.AzureFunction.Tests.Scenarios
{
    public class FunctionScenarios
    {
        private readonly Functions _functions;

        public FunctionScenarios()
        {
            // move host initialization to base class
            var startup = new Startup();
            var host = new HostBuilder()
                .ConfigureWebJobs(startup.Configure)
                .Build();

            _functions = new Functions(
                mediator: host.Services.GetRequiredService<IMediator>(),
                logger: host.Services.GetRequiredService<ILogger<Functions>>());
        }

        [Fact]
        public async void Should_create_new_order()
        {
            var newOrderJson = JsonTestDataProvider.NewOrder;

            var httpRequest = await CreatePostRequest(newOrderJson);

            var httpResult = (CreatedResult)await _functions.NewOrder(httpRequest);

            httpResult.StatusCode.Should().Be((int)HttpStatusCode.Created);
        }

        private async Task<HttpRequest> CreatePostRequest(string jsonBody)
        {
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Method = "POST";
            httpContext.Request.Scheme = "http";
            httpContext.Request.Host = new HostString("localhost");
            httpContext.Request.ContentType = "application/json";
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            await writer.WriteAsync(jsonBody);
            await writer.FlushAsync();
            stream.Position = 0;
            httpContext.Request.Body = stream;
            return httpContext.Request;
        }
    }
}