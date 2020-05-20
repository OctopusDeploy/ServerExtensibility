using System.Collections.Generic;
using NUnit.Framework;
using Octopus.Server.Extensibility.TinyTypes;

namespace Node.Extensibility.Tests.TinyTypes
{
    public class StringEqualityTests
    {
        [Test]
        [TestCaseSource(nameof(EqualTestCases))]
        public void EquivalentValuesShouldBeEqual(TinyType<string> a, TinyType<string> b)
        {
            Assert.True(a == b);
            Assert.False(a != b);

            if (a != null) Assert.True(a.Equals(b));
        }

        [Test]
        [TestCaseSource(nameof(UnequalTestCases))]
        public void NonEquivalentValuesShouldNotBeEqual(TinyType<string> a, TinyType<string> b)
        {
            Assert.False(a == b);
            Assert.True(a != b);

            if (a != null) Assert.False(a.Equals(b));
        }

        public static IEnumerable<TestCaseData> EqualTestCases()
        {
            yield return new TestCaseData(null, null);
            yield return new TestCaseData(new SomeStringType("a"), new SomeStringType("a"));
            yield return new TestCaseData(new SomeStringType("A"), new SomeStringType("A"));
            yield return new TestCaseData(new SomethingCaseInsensitive("A"), new SomethingCaseInsensitive("a"));
        }

        public static IEnumerable<TestCaseData> UnequalTestCases()
        {
            yield return new TestCaseData(new SomeStringType("a"), new SomeStringType("a "));
            yield return new TestCaseData(new SomeStringType("a"), new SomeStringType(" a"));
            yield return new TestCaseData(new SomeStringType("a"), new SomeStringType(" a "));
            yield return new TestCaseData(new SomeStringType("a"), new SomeStringType("A"));
            yield return new TestCaseData(new SomeStringType("a"), new SomeStringType("b"));
            yield return new TestCaseData(new SomeStringType("a"), new SomeOtherStringType("a"));
            yield return new TestCaseData(new SomethingCaseInsensitive("A"), new SomethingCaseInsensitive("A "));
        }

        public class SomeStringType : TinyType<string>
        {
            public SomeStringType(string value) : base(value)
            {
            }
        }

        private class SomeOtherStringType : TinyType<string>
        {
            public SomeOtherStringType(string value) : base(value)
            {
            }
        }

        private class SomethingCaseInsensitive : CaseInsensitiveStringTinyType
        {
            public SomethingCaseInsensitive(string value) : base(value)
            {
            }
        }
    }
}