using Microsoft.Extensions.Logging;

namespace OrderService.Api.Abstractions
{
    public abstract class FunctionBase<T> where T : class
    {
        private readonly ILogger<T> logger;

        protected FunctionBase(ILogger<T> logger)
        {
            this.logger = logger;
        }

        protected void LogInformation(string customMessage, string requestId)
        {
            var messageToLog = CreateCustomMessageToLog(customMessage, requestId);
            logger.LogInformation(messageToLog);
        }

        protected void LogError(string customMessage, string requestId, Exception ex)
        {
            var messageToLog = CreateCustomMessageToLog(customMessage, requestId);
            logger.LogError(ex, messageToLog);
        }

        private static string CreateCustomMessageToLog(string message, string requestId)
        {
            return $"{message} - Request id: {requestId}";
        }
    }
}