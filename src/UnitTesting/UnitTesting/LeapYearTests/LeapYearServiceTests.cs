using System;
using NUnit.Framework;

namespace LeapYearTests
{
    public class LeapYearServiceTests
    {
        [Test]
        [TestCase(-100)]
        [TestCase(-4214)]
        [TestCase(-1)]
        public void IsLeapYear_InvalidYear_ThrowsArgumentOutOfRangeException(int invalidYear)
        {
            var service = new LeapYearService();

            Assert.Throws<ArgumentOutOfRangeException>(() => service.IsLeapYear(invalidYear));
        }

        [Test]
        [TestCase(1)]
        [TestCase(1900)]
        [TestCase(2022)]
        [TestCase(2021)]
        public void IsLeapYear_NotLeapYear_ReturnsFalse(int notLeapYear)
        {
            var service = new LeapYearService();

            var actual = service.IsLeapYear(notLeapYear);

            Assert.IsFalse(actual);
        }

        [Test]
        [TestCase(1)]
        [TestCase(1900)]
        [TestCase(2022)]
        [TestCase(2021)]
        public void IsLeapYear_LeapYear_ReturnsTrue(int leapYear)
        {
            var service = new LeapYearService();

            var actual = service.IsLeapYear(leapYear);

            Assert.IsTrue(actual);
        }
    }
}