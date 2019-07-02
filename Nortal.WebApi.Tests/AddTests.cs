using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Nortal.WebApi;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class AddTests
    {
        private TestServer _server;
        private HttpClient _client;
        
        [SetUp]
        public void Setup()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Test]
        public async Task AddThreeNumbers()
        {
            var url = "api/add";
            var body = new
            {
                a = 1,
                b = 2,
                c = 3
            };
            
            // Act
            var response = await _client.PostAsync(url, GetStringContent(body));
            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.AreEqual("6", responseString);
        }

        public static StringContent GetStringContent(object obj)
            => new StringContent(JsonConvert.SerializeObject(obj), Encoding.Default, "application/json");
    }
}