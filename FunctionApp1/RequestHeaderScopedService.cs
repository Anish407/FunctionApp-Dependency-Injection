using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;

namespace FunctionApp1
{
    public class RequestHeaderScopedService
    {
        public Dictionary<string,StringValues> headers { get; set; } = new Dictionary<string, StringValues>();
    }
}
