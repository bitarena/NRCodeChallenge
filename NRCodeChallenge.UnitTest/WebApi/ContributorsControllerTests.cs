using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRCodeChallenge.ServiceLibrary.Contracts;
using NRCodeChallenge.WebApi.Controllers;
using NRCodeChallenge.WebApi.Models;
using NSubstitute;
using System.Threading.Tasks;

namespace NRCodeChallenge.UnitTest.WebApi
{
    [TestClass]
    public class ContributorsControllerTests
    {
        static ContributorsController sut;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            var appService = Substitute.For<INRCodeChallengeAppService>();
            sut = new ContributorsController(appService);
        }

        [TestMethod]
        public async Task ShouldReturnErrorWhenTakeIsNot50Nor100Nor150()
        {
            // Arrange
            var request = new ContributorRequest
            {
                CityName = "london",
                Take = 10,
            };

            // Act
            var actual = await sut.Get(request);

            // Assert
        }

        [TestMethod]
        public async Task ShouldReturnErrorWhenCityNameContainsNumbers()
        {
            // Arrange
            var request = new ContributorRequest
            {
                CityName = "london123",
                Take = 50,
            };

            // Act
            var actual = await sut.Get(request);

            // Assert
        }

    }
}
