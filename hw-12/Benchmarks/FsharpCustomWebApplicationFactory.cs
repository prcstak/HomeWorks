using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using Startup = hw6.Program;

namespace Benchmarks
{
    public class FsharpCustomWebApplicationFactory: WebApplicationFactory<Startup.Startup>
    {
        protected override IHostBuilder CreateHostBuilder()
        {
            var builder = Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(x =>
                {
                    x.UseStartup<Startup.Startup>().UseTestServer();
                });
            return builder;
        }
    }
}