using System;
using System.Threading.Tasks;
using hw6;
using Xunit;

namespace GiraffeTests
{
    public class GiraffeTests : IClassFixture<CustomWebApplicationFactory<Program.Startup>>
    {
        private readonly CustomWebApplicationFactory<Program.Startup> _factory;

        public GiraffeTests(CustomWebApplicationFactory<Program.Startup> factory)
        {
            _factory = factory;
        }
        
        [Theory]
        [InlineData("1", "plus", "2", 3)]
        [InlineData("1", "plus", "2.0", 3.0)]
        [InlineData("3", "divide", "2.0", 1.5)]
        [InlineData("2.1", "divide", "7.0", 0.3)]
        [InlineData("2.1", "subtract", "7.0", -4.9)]
        [InlineData("2.1", "multiply", "3", 6.3)]
        public async Task CheckRightResponse_RightArgs_CorrectAnswer(string arg1, string op, string arg2, decimal expected)
        {
            //arrange 
            
            var client = _factory.CreateClient();
            
            //act 

            var response = await client.GetAsync(
                $"/calculate/arg1={arg1}&op={op}&arg2={arg2}");
            var result = await response.Content.ReadAsStringAsync();
            //assert
            Decimal.TryParse(result, out decimal decRes);
            Assert.Equal(decRes, expected);
        }
        
        
    }
}

