using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.TestUtilities;
using OrderService.Api.AwsLambda.Tests.Common;
using System.Net;
using Xunit;

namespace OrderService.Api.AwsLambda.Tests.Scenarios
{
    public class FunctionScenarios
    {
        public FunctionScenarios()
        {
        }

        [Fact]
        public async Task TestGetMethodAsync()
        {
            var functions = new Functions();

            var request = new APIGatewayProxyRequest
            {
                Body = JsonTestDataProvider.NewOrder
            };

            var context = new TestLambdaContext();

            var response = await functions.NewOrder(request, context);

            Assert.Equal((int)HttpStatusCode.Created, response.StatusCode);
        }
    }
}