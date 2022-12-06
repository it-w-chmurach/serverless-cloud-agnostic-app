using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace OrderService.HttpApi.Extensions
{
    public static class HttpRequestExtensions
    {
        public static async Task<T> DeserializeBodyAsync<T>(this HttpRequest req)
        {
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            return JsonConvert.DeserializeObject<T>(requestBody);
        }
    }
}