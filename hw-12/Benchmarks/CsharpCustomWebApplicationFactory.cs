using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using WebApplication;

namespace Benchmarks
{
    public class CsharpCustomWebApplicationFactory: WebApplicationFactory<Startup>
    {
        protected override IHostBuilder CreateHostBuilder()
        {
            var builder = Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(x =>
                {
                    x.UseStartup<Startup>().UseTestServer();
                });
            return builder;
        }
    }
}