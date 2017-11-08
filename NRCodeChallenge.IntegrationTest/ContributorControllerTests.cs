using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRCodeChallenge.WebApi;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace NRCodeChallenge.IntegrationTest
{
    [TestClass]
    public class ContributorControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        private const string BaseAddress = "http://localhost:53371";

        public ContributorControllerTests()
        {
            _server = new TestServer(new WebHostBuilder()
                                   .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [TestMethod]
        public async Task ShouldReturnDataWhenRequestIsOk()
        {
            // Act
            var response = await _client.GetAsync($"{BaseAddress}/api/contributors/barcelona/50");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.IsNotNull(responseString);
        }

        [TestMethod]
        public async Task ShouldReturnBadRequestWhenTakeIsNot50Or100Or150()
        {
            // Arrange
            var expectedStatusCode = HttpStatusCode.BadRequest;

            // Act
            var response = await _client.GetAsync($"{BaseAddress}/api/contributors/london/1");

            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.AreEqual(expectedStatusCode, response.StatusCode);
        }

        [TestMethod]
        public async Task ShouldReturnBadRequestWhenCityNameContainsNumbers()
        {
            // Arrange
            var expectedStatusCode = HttpStatusCode.BadRequest;

            // Act
            var response = await _client.GetAsync($"{BaseAddress}/api/contributors/newyork1/100");

            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.AreEqual(expectedStatusCode, response.StatusCode);
        }

        [TestMethod]
        public async Task ShouldReturnOkWhenNoDataIsReturned()
        {
            // Arrange
            var expectedStatusCode = HttpStatusCode.OK;

            // Act
            var response = await _client.GetAsync($"{BaseAddress}/api/contributors/fakecity/100");

            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.AreEqual(expectedStatusCode, response.StatusCode);
        }
    }
}
