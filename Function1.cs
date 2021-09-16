using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CalculatorApp
{
    public static class Function1
    {
        [FunctionName("CalculatorApplication")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            try
            {
                log.LogInformation("C# HTTP trigger function processed a request.");

                double value1 = 0, value2 = 0;

                value1 = Convert.ToDouble(req.Query["value1"]);
                value2 = Convert.ToDouble(req.Query["value2"]);

                var result = value1 + value2;

                string responseMessage = $"value1: {value1}\nvalue2: {value2}\nYour result is {value1} + {value2} = {result}";

                return new OkObjectResult(responseMessage);
            }
            catch
            {
                return new BadRequestObjectResult("Your calculations are invalid. Try again!");
            }

        }
    }
}
