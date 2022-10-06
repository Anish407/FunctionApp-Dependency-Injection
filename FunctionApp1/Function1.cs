using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using System.Xml.Linq;
using FunctionApp1;
using System.Linq;

[assembly: FunctionsStartup(typeof(Startup))] // It didnt work then bcoz we missed to add this
namespace FunctionApp1
{
    public class Function1
    {
        public Function1(RequestHeaderScopedService requestHeaderScopedService, ISomeService someService)
        {
            RequestHeaderScopedService = requestHeaderScopedService;
            SomeService = someService;
        }

        public RequestHeaderScopedService RequestHeaderScopedService { get; }
        public ISomeService SomeService { get; }

        [FunctionName("Function1")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                // set the headers and inject this service anywhere to get the headers
                RequestHeaderScopedService.headers = req.Headers.ToDictionary(i => i.Key, k=> k.Value);

                // call the class that injects the scoped service
                SomeService.GetData();

                return new OkObjectResult("Success");
            }
            catch (Exception ex)
            {
                return new BadRequestResult();
            }
        }
    }
}
