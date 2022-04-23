using CalcStats.Lib;
using NUnit.Framework;

namespace CalcStats.Tests
{
    public class CalcStatsServiceTests
    {
        [Test]
        [TestCase(new[] { 0, 1, 2 }, 0)]
        [TestCase(new[] { -6, 7, -21 }, -21)]
        [TestCase(new[] { 1234, -4567, 8910 }, -4567)]
        public void GetMinValue_ArrayOfIntegers_ReturnsMinValue(int[] sequence, int expectedMin)
        {
            // Arrange
            var calcStatsServiceService = new CalcStatsService();

            // Act
            var actualMin = calcStatsServiceService.GetMinValue(sequence);

            // Assert
            Assert.AreEqual(expectedMin, actualMin);
        }

        [Test]
        [TestCase(new[] { 0, 1, 2 }, 2)]
        [TestCase(new[] { -6, -7, -21 }, -6)]
        [TestCase(new[] { 1234, -4567, 8910 }, 8910)]
        public void GetMaxValue_ArrayOfIntegers_ReturnsMaxValue(int[] sequence, int expectedMax)
        {
            // Arrange
            var calcStatsService = new CalcStatsService();

            // Act
            var actualMax = calcStatsService.GetMaxValue(sequence);

            // Assert
            Assert.AreEqual(expectedMax, actualMax);
        }

        [Test]
        [TestCase(new[] { 123456 }, 1)]
        [TestCase(new[] { 6, 7, 8 }, 3)]
        [TestCase(new[] { -6, -7, -21, 1234, -4567, 8910 }, 6)]
        public void GetSequenceCount_ArrayOfIntegers_ReturnsCountOfSequence(int[] sequence, int expectedCount)
        {
            // Arrange
            var calcStatsService = new CalcStatsService();

            // Act
            var actualCount = calcStatsService.GetSequenceCount(sequence);

            // Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        [TestCase(new[] { 0, 1, 2 }, 1)]
        [TestCase(new[] { -6, 7, -22 }, -7)]
        [TestCase(new[] { 1234, -4567, 8910 }, 1859)]
        public void GetAverageValue_ArrayOfIntegers_ReturnsAverageValue(int[] sequence, double expectedAverage)
        {
            // Arrange
            var calcStatsService = new CalcStatsService();

            // Act
            var actualAverage = calcStatsService.GetAverageValue(sequence);

            // Assert
            Assert.AreEqual(expectedAverage, actualAverage);
        }
    }
}