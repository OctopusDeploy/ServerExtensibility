using NUnit.Framework;
using Octopus.Data;
using Octopus.Server.Extensibility.Results;

namespace Node.Extensibility.Tests
{
    [TestFixture]
    public class ResultFromExtensionTests
    {
        [Test]
        public void CheckFailureWithFailureCheck()
        {
            var result = new TestClassWithResultMethod().DoSomething(TestClassWithResultMethod.Behaviour.Failure);
            if (result is FailureResult fail)
            {
                Assert.AreEqual("Some failure reason", fail.ErrorString);
            }
        }

        [Test]
        public void CheckFailureWithSuccessCheck()
        {
            var result = new TestClassWithResultMethod().DoSomething(TestClassWithResultMethod.Behaviour.Failure);
            if (result is Result<TestObjectBeingReturned>)
            {
                Assert.Fail("This result wasn't a success case!");
            }
        }

        [Test]
        public void CheckSuccessWithSuccessCheck()
        {
            var result = new TestClassWithResultMethod().DoSomething(TestClassWithResultMethod.Behaviour.Success);
            if (result is Result<TestObjectBeingReturned> success)
            {
                Assert.AreEqual("Some Name", success.Value.Name);
            }
        }

        [Test]
        public void CheckSuccessWithFailureCheck()
        {
            var result = new TestClassWithResultMethod().DoSomething(TestClassWithResultMethod.Behaviour.Success);
            if (result is FailureResult)
            {
                Assert.Fail("This result wasn't a failure case!");
            }
        }

        [Test]
        public void CheckSuccessWithNullableType()
        {
            var result = new TestClassWithResultMethod().DoSomething(TestClassWithResultMethod.Behaviour.Success);
            if (result is Result<TestObjectBeingReturned?> success)
            {
                Assert.AreEqual("Some Name", success.Value?.Name);
            }
        }

        [Test]
        public void CheckDisabledWithDisabledCheck()
        {
            var result = new TestClassWithResultMethod().DoSomething(TestClassWithResultMethod.Behaviour.Disabled);
            if (!(result is FailureResultFromDisabledExtension<TestObjectBeingReturned>))
            {
                Assert.Fail("The result should have indicated the extension was disabled");
            }
        }

        [Test]
        public void CheckDisabledWithSuccessCheck()
        {
            var result = new TestClassWithResultMethod().DoSomething(TestClassWithResultMethod.Behaviour.Disabled);
            if (result is Result<TestObjectBeingReturned>)
            {
                Assert.Fail("This result wasn't a success case!");
            }
        }

        [Test]
        public void CheckDisabledIsHandledLikeNormalFailureCheck()
        {
            var result = new TestClassWithResultMethod().DoSomething(TestClassWithResultMethod.Behaviour.Disabled);
            if (!(result is FailureResultFromExtension<TestObjectBeingReturned>))
            {
                Assert.Fail("The result should have indicated the extension was disabled, which should also be treated as a normal failure");
            }
        }

        class TestClassWithResultMethod
        {
            public enum Behaviour
            {
                Success,
                Failure,
                Disabled
            }
            public IResultFromExtension<TestObjectBeingReturned> DoSomething(Behaviour behaviour)
            {
                if (behaviour == Behaviour.Failure)
                    return ResultFromExtension<TestObjectBeingReturned>.Failed("Some failure reason");
                else if (behaviour == Behaviour.Disabled)
                    return ResultFromExtension<TestObjectBeingReturned>.ExtensionDisabled();
                return ResultFromExtension<TestObjectBeingReturned>.Success(new TestObjectBeingReturned("Some Name"));
            }
        }

        class TestObjectBeingReturned
        {
            public TestObjectBeingReturned(string name)
            {
                Name = name;
            }

            public string Name { get; }
        }
    }
}