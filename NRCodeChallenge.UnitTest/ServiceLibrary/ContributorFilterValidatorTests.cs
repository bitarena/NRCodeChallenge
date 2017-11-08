using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRCodeChallenge.ServiceLibrary.Contracts;
using NRCodeChallenge.ServiceLibrary.Implementation;
using NRCodeChallenge.UnitTest.MockFactories;

namespace NRCodeChallenge.UnitTest.ServiceLibrary
{
    [TestClass]
    public class ContributorFilterValidatorTests
    {
        static IContributorFilterValidator sut;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            sut = new ContributorFilterValidator();
        }

        [TestMethod]
        public void ShouldReturnTrueWhenTakeIs50()
        {
            // Arrange
            var filter = ContributorFilterDtoFactory.CreateWithTake(50);

            // Act
            var actual = sut.Validate(filter);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ShouldReturnTrueWhenTakeIs100()
        {
            // Arrange
            var filter = ContributorFilterDtoFactory.CreateWithTake(100);

            // Act
            var actual = sut.Validate(filter);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ShouldReturnTrueWhenTakeIs150()
        {
            // Arrange
            var filter = ContributorFilterDtoFactory.CreateWithTake(150);

            // Act
            var actual = sut.Validate(filter);

            // Assert
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ShouldReturnFalseWhenTakeIsNot50Or100Or150()
        {
            // Arrange
            var filter = ContributorFilterDtoFactory.CreateWithTake(30);

            // Act
            var actual = sut.Validate(filter);

            // Assert
            Assert.IsFalse(actual);
        }
    }
}
