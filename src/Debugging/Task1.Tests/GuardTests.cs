using NUnit.Framework;
using System;

namespace Task1.Tests
{
    public class GuardTests
    {
        [TestCase(1)]
        [TestCase("randomString")]
        public void ArgumentNotNull_NotNullArgument_DoesNotThrowException(object value)
        {
            Assert.DoesNotThrow(() => Guard.ArgumentNotNull(value, nameof(value)));
        }

        [Test]
        public void ArgumentNotNull_NullArgument_ThrowsArgumentNullException()
        {
            string nullArgument = null;

            Assert.Throws<ArgumentNullException>(() => Guard.ArgumentNotNull(nullArgument, nameof(nullArgument)));
        }
    }
}
