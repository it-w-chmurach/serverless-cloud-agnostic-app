using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using OrderService.Api.Abstractions;
using OrderService.Api.Routes;
using OrderService.Application.Commands;
using OrderService.Application.Dtos;
using OrderService.HttpApi.Extensions;
using System;
using System.Threading.Tasks;

namespace OrderService.Api.AzureFunctions
{
    public class Functions : FunctionBase<Functions>
    {
        private readonly IMediator mediator;

        public Functions(IMediator mediator, ILogger<Functions> logger) : base(logger)
        {
            this.mediator = mediator;
        }

        [FunctionName("NewOrder")]
        public async Task<IActionResult> NewOrder(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = OrderRoutes.PostOrder)] HttpRequest req)
        {
            var requestId = req.HttpContext.TraceIdentifier;

            LogInformation("Received new order request", requestId);

            var newOrderDto = await req.DeserializeBodyAsync<NewOrderDto>();

            try
            {
                var orderDto = await mediator.Send(new CreateOrder(newOrderDto));
                LogInformation($"Order created successfully - Order Id {orderDto.Id}", requestId);

                return new CreatedResult(req.Path, orderDto);
            }
            catch (Exception ex)
            {
                LogError("Error while creating order", requestId, ex);
                return new BadRequestObjectResult($"Could not create order. Request id: {requestId}");
            }
        }
    }
}