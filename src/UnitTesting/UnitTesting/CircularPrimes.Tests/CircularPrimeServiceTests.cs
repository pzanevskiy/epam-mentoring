using CircularPrimes.Lib;
using NUnit.Framework;

namespace CircularPrimes.Tests
{
    public class CircularPrimeServiceTests
    {
        [Test]
        [TestCase(1, 0)]
        [TestCase(10, 4)]
        [TestCase(100, 13)]
        [TestCase(1000, 25)]
        [TestCase(10000, 33)]
        [TestCase(100000, 43)]
        [TestCase(1000000, 55)]
        public void GetCircularPrimesAmount_Range_ReturnsAmountOfCircularPrimes(int range, int expectedAmount)
        {
            // Arrange
            var circularPrimeService = new CircularPrimeService();

            // Act
            var actualAmount = circularPrimeService.GetCircularPrimesAmount(range);

            // Assert
            Assert.AreEqual(expectedAmount, actualAmount);
        }

        [Test]
        [TestCase(1, new int[] { })]
        [TestCase(10, new[] { 2, 3, 5, 7 })]
        [TestCase(100, new[] { 2, 3, 5, 7, 11, 13, 17, 31, 37, 71, 73, 79, 97 })]
        public void GetCircularPrimes_Number_ReturnsCircularPrimes(int range, int[] expectedRange)
        {
            // Arrange
            var circularPrimeService = new CircularPrimeService();

            // Act
            var actualRange = circularPrimeService.GetCircularPrimes(range);

            // Assert
            Assert.AreEqual(expectedRange, actualRange);
        }
    }
}