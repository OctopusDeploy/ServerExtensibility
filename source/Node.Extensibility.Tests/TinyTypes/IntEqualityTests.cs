using System.Collections.Generic;
using NUnit.Framework;
using Octopus.Server.Extensibility.TinyTypes;

namespace Node.Extensibility.Tests.TinyTypes
{
    public class IntEqualityTests
    {
        [Test]
        [TestCaseSource(nameof(EqualTestCases))]
        public void EquivalentValuesShouldBeEqual(TinyType<int> a, TinyType<int> b)
        {
            Assert.True(a == b);
            Assert.False(a != b);

            if (a != null) Assert.True(a.Equals(b));
        }

        [Test]
        [TestCaseSource(nameof(UnequalTestCases))]
        public void NonEquivalentValuesShouldNotBeEqual(TinyType<int> a, TinyType<int> b)
        {
            Assert.False(a == b);
            Assert.True(a != b);

            if (a != null) Assert.False(a.Equals(b));
        }

        public static IEnumerable<TestCaseData> EqualTestCases()
        {
            yield return new TestCaseData(null, null);
            yield return new TestCaseData(new SomeIntType(0), new SomeIntType(0));
            yield return new TestCaseData(new SomeIntType(1), new SomeIntType(1));
        }

        public static IEnumerable<TestCaseData> UnequalTestCases()
        {
            yield return new TestCaseData(new SomeIntType(0), new SomeIntType(1));
            yield return new TestCaseData(new SomeIntType(1), new SomeIntType(2));
            yield return new TestCaseData(new SomeIntType(0), new SomeOtherIntType(0));
        }


        public class SomeIntType : TinyType<int>
        {
            public SomeIntType(int value) : base(value)
            {
            }
        }

        private class SomeOtherIntType : TinyType<int>
        {
            public SomeOtherIntType(int value) : base(value)
            {
            }
        }
    }
}