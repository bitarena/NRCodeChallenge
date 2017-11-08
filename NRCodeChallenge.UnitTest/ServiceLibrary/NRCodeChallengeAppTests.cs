using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRCodeChallenge.Domain.RepositoryContracts;
using NRCodeChallenge.ServiceLibrary.Contracts;
using NRCodeChallenge.ServiceLibrary.Implementation;
using NRCodeChallenge.UnitTest.MockFactories;
using NSubstitute;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NRCodeChallenge.UnitTest.ServiceLibrary
{
    [TestClass]
    public class NRCodeChallengeAppTests
    {
        INRCodeChallengeAppService sut;
        IContributorRepository contributorRepository;
        IContributorFilterValidator contributorFilterValidator;


        [TestInitialize]
        public void TestInitialize()
        {
            contributorRepository = Substitute.For<IContributorRepository>();
            contributorFilterValidator = Substitute.For<IContributorFilterValidator>();
            sut = new NRCodeChallengeAppService(contributorRepository, contributorFilterValidator);
        }

        [TestMethod]
        public void ShouldReturnContributorsWhenTakeIs50()
        {
            // Arrange
            var filter = ContributorFilterDtoFactory.CreateWithTake(50);

            var expected = ContributorFactory.CreateList(50);
            contributorRepository.GetByCityAsync(filter.CityName, Arg.Any<int>(), Arg.Any<int>()).Returns(expected);
            contributorFilterValidator.Validate(filter).Returns(true);

            // Act
            var actual = sut.GetContributorsByCityAsync(filter);

            // Assert
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public async Task ShouldReturnContributorsWhenTakeIs100()
        {
            // Arrange
            var filter = ContributorFilterDtoFactory.CreateWithTake(100);
            var expected = ContributorFactory.CreateList(filter.Take);

            contributorRepository.GetByCityAsync(filter.CityName, 1, 100).Returns(expected);
            contributorFilterValidator.Validate(filter).Returns(true);

            // Act
            var actual = await sut.GetContributorsByCityAsync(filter);

            // Assert
            Assert.AreEqual(expected.Count(), actual.Count());
            Assert.AreEqual(expected.First().Username, actual.First().Username);
            Assert.AreEqual(expected.Last().Username, actual.Last().Username);
        }

        [TestMethod]
        public async Task ShouldReturnContributorsWhenTakeIs150()
        {
            // Arrange
            var filter = ContributorFilterDtoFactory.CreateWithTake(150);
            var expected1 = ContributorFactory.CreateList(100);
            var expected2 = ContributorFactory.CreateList(100, "adios");
            var expected = expected1.Concat(expected2).Take(filter.Take);

            contributorRepository.GetByCityAsync(filter.CityName, 1, 100).Returns(expected1);
            contributorRepository.GetByCityAsync(filter.CityName, 2, 100).Returns(expected2);
            contributorFilterValidator.Validate(filter).Returns(true);

            // Act
            var actual = await sut.GetContributorsByCityAsync(filter);

            // Assert
            Assert.AreEqual(expected.Count(), actual.Count());
            Assert.AreEqual(expected.First().Username, actual.First().Username);
            Assert.AreEqual(expected.Last().Username, actual.Last().Username);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task ShouldThrowExceptionWhenTakeIsLessThan50()
        {
            // Arrange
            var filter = ContributorFilterDtoFactory.CreateWithTake(30);

            // Act
            await sut.GetContributorsByCityAsync(filter);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task ShouldThrowExceptionWhenTakeBetween50And100()
        {
            // Arrange
            var filter = ContributorFilterDtoFactory.CreateWithTake(75);

            // Act
            await sut.GetContributorsByCityAsync(filter);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task ShouldThrowExceptionWhenTakeBetween100And150()
        {
            // Arrange
            var filter = ContributorFilterDtoFactory.CreateWithTake(120);

            // Act
            await sut.GetContributorsByCityAsync(filter);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task ShouldThrowExceptionWhenTakeIsGreaterThan150()
        {
            // Arrange
            var filter = ContributorFilterDtoFactory.CreateWithTake(300);

            // Act
            await sut.GetContributorsByCityAsync(filter);

            // Assert
        }
    }
}
