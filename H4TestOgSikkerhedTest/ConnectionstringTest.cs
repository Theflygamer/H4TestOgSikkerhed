using AngleSharp;
using Microsoft.Extensions.Configuration;

namespace H4TestOgSikkerhedTest
{
    public class ConnectionStringTest
    {
        [Fact]
        public void ConnectionStringIsUnchanged()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            string conn = config.GetSection("ConnectionStrings")["DefaultConnection"];

            Assert.Equal("Server=(localdb)\\mssqllocaldb;Database=aspnet-H4TestOgSikkerhed-26fc563d-8bca-4346-9675-5b772c84e2dc;Trusted_Connection=True;MultipleActiveResultSets=true", conn);
        }
    }
}