using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace IPAddressAPI
{
    public static class Function1
    {
        [FunctionName("GetClientIPAddress")]
        public static async Task<string> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get",  Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            
            var remoteAddr = req.HttpContext.Connection.RemoteIpAddress;


            return $"Caller IP Address: {remoteAddr}";
        }
    }
}
