using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;

namespace Benchmarks
{
    public class CsharpCustomWebApplicationFactory: WebApplicationFactory<WebApplication.Startup>
    {
        protected override IHostBuilder CreateHostBuilder()
        {
            var builder = Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(x =>
                {
                    x.UseStartup<WebApplication.Startup>().UseTestServer();
                });
            return builder;
        }
    }
}