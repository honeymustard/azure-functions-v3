using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Honeymustard.Serivces
{
    public class FakeClient : IFakeClient
    {
        static HttpClient Client = new HttpClient();
        ILogger<FakeClient> Logger;

        public FakeClient(ILogger<FakeClient> logger)
        {
            if (logger == null) throw new Exception("FakeClient: Logger cannot be null");
            Logger = logger;
        }

        public async Task<string> Get(string route)
        {
            try
            {
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri(route),
                    Method = new HttpMethod(HttpMethod.Get.ToString()),
                };

                request.Headers.Add("Accept", "application/json");

                var response = await Client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch(Exception e)
            {
                Logger.LogError($"NaiveClient: {e.ToString()}");
            }

            return "";
        }
    }
}