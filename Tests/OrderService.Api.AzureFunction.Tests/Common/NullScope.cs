using System;

namespace OrderService.Api.AzureFunction.Tests.Common
{
    public class NullScope : IDisposable
    {
        public static NullScope Instance { get; } = new NullScope();

        private NullScope()
        { }

        public void Dispose()
        { }
    }
}