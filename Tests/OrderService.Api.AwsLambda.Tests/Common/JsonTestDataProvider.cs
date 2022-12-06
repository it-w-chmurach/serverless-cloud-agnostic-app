using System.IO;

namespace OrderService.Api.AwsLambda.Tests.Common
{
    internal static class JsonTestDataProvider
    {
        private static readonly string _dataFolder =
            Path.Combine(Directory.GetCurrentDirectory(), "Common");

        public static string NewOrder => File
                .ReadAllText(Path.Combine(_dataFolder, "new-order-data.json"));
    }
}