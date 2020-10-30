using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Honeymustard.Serivces;

namespace Honeymustard
{
    public class HorseTimer
    {
        private readonly IFakeClient Client;

        public HorseTimer(IFakeClient client)
        {
            Client = client;
        }

        [FunctionName("HorseTimer")]
        public async Task Run([TimerTrigger("0 */5 * * * *")]TimerInfo timer, ILogger logger)
        {
            logger.LogInformation($"HorseTimer: {DateTime.Now}");
            var response = await Client.Get("https://jsonplaceholder.typicode.com/posts/1");
            logger.LogInformation(response);
        }
    }
}