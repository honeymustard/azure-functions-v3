using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Honeymustard.Serivces;

[assembly: FunctionsStartup(typeof(Honeymustard.Startup))]

namespace Honeymustard
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddScoped<IFakeClient, FakeClient>();
        }
    }
}