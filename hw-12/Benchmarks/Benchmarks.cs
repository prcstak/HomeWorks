using System.Net.Http;
using BenchmarkDotNet.Attributes;

namespace Benchmarks
{
    [MinColumn]
    [MaxColumn]
    [MedianColumn]
    public class Benchmarks
    {
        private HttpClient _csharpClient;
        private HttpClient _fsharpClient;

        [GlobalSetup]
        public void GlobalSetUp()
        {
            _csharpClient = new CsharpCustomWebApplicationFactory().CreateClient();
            _fsharpClient = new FsharpCustomWebApplicationFactory().CreateClient();
        }
        
        [Benchmark(Description = "C#: 1450 - 2")]
        public void CsharpMinusOperation()
        {
            var response = _csharpClient.GetAsync(
                $"/sub?arg1=1449&arg2=2").GetAwaiter().GetResult();
        }

        [Benchmark(Description = "C#: 5050 + 1")]
        public void CsharpAddOperation()
        {
            var response = _csharpClient.GetAsync(
                $"/add?arg1=5050&arg2=1").GetAwaiter().GetResult();
        }
        
        [Benchmark(Description = "C#: 225 * 5")]
        public void CsharpMultiplyOperation()
        {
            var response = _csharpClient.GetAsync(
                $"/mult?arg1=225&arg2=5").GetAwaiter().GetResult();
        }

        [Benchmark(Description = "C#: 100 / 10")]
        public void CsharpDivisionOperation()
        {
            var response = _csharpClient.GetAsync(
                $"/div?arg1=100&arg2=10").GetAwaiter().GetResult();
        }

        [Benchmark(Description = "F#: 1450 - 2")]
        public string FsharpMinusOperation()
        {
            var response = _fsharpClient.GetAsync(
                "/calculate/arg1=1450&op=subtract&arg2=2").GetAwaiter().GetResult();
            return response.ToString();
        }

        [Benchmark(Description = "F#: 5050 + 1")]
        public string FsharpAddOperation()
        {
            var response = _fsharpClient.GetAsync(
                $"/calculate/arg1=5050&op=plus&arg2=1").GetAwaiter().GetResult();
            return response.ToString();
        }

        [Benchmark(Description = "F#: 225 * 5")]
        public string FsharpMultiplyOperation()
        {
            var response = _fsharpClient.GetAsync(
                $"/calculate/arg1=225&op=multiply&arg2=5").GetAwaiter().GetResult();            
            return response.ToString();
        }

        [Benchmark(Description = "F#: 100 / 10")]
        public string FsharpDivisionOperation()
        {
            var response = _fsharpClient.GetAsync(
                $"/calculate/arg1=100&op=divide&arg2=10").GetAwaiter().GetResult();            
            return response.ToString();
        }
    }
}