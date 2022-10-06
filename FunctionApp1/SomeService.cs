using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionApp1
{
    public class SomeService : ISomeService
    {
        public SomeService(
            // scoped service that contains the headers
            RequestHeaderScopedService requestHeaderScopedService, 
            // inject the logger via DI
            ILogger<SomeService> logger)
        {
            RequestHeaderScopedService = requestHeaderScopedService;
            Logger = logger;
        }

        public RequestHeaderScopedService RequestHeaderScopedService { get; }
        public ILogger<SomeService> Logger { get; }

        public void GetData()
        {
            var headers = RequestHeaderScopedService.headers;
        }
    }
}
