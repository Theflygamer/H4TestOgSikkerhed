using AngleSharp;
using Microsoft.Extensions.Configuration;

namespace H4TestOgSikkerhedTest
{
    public class ConnectionstringTest
    {
        [Fact]
        public void ConnectionString()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var conn = config["DefaultConnection"];
        }
    }
}