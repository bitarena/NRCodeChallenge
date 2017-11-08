using LightInject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRCodeChallenge.Domain.RepositoryContracts;
using System.Linq;
using System.Threading.Tasks;

namespace NRCodeChallenge.IntegrationTest
{
    [TestClass]
    public class ContributorRepositoryTests
    {
        IContributorRepository sut;

        [TestInitialize]
        public void TestInitialize()
        {
            var iocContainer = IoC.IoCRegister.Register();
            sut = iocContainer.GetInstance<IContributorRepository>();
        }

        [TestMethod]
        public async Task ShouldReturnData()
        {
            // Arrange
            var city = "barcelona";
            var page = 1;
            var size = 1;
            var expected = size;

            // Act
            var actual = await sut.GetByCityAsync(city, page, size);

            // Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public async Task ShouldReturnSpecifiedSize()
        {
            // Arrange
            var city = "barcelona";
            var page = 1;
            var size = 10;
            var expected = size;

            // Act
            var actual = await sut.GetByCityAsync(city, page, size);

            // Assert
            Assert.AreEqual(expected, actual.Count());
        }

        [TestMethod]
        public async Task CheckPerformanceWhenTakeIs1AndTakeIs100()
        {
            // Arrange
            var city = "barcelona";
            var page = 1;
            var size1 = 1;
            var size100 = 100;

            // Act
            var actual1 = await sut.GetByCityAsync(city, page, size1);

            var actual100 = await sut.GetByCityAsync(city, page, size100);

            // Assert
            Assert.IsNotNull(actual1);
            Assert.IsNotNull(actual100);
        }
    }
}
