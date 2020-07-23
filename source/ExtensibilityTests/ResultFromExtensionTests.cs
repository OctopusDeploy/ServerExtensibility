using System;
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
            if (result is IFailureResult fail)
                Assert.AreEqual("Some failure reason", fail.ErrorString);
        }

        [Test]
        public void CheckFailureWithSuccessCheck()
        {
            var result = new TestClassWithResultMethod().DoSomething(TestClassWithResultMethod.Behaviour.Failure);
            if (result is ISuccessResult<TestObjectBeingReturned>)
                Assert.Fail("This result wasn't a success case!");
        }

        [Test]
        public void CheckSuccessWithSuccessCheck()
        {
            var result = new TestClassWithResultMethod().DoSomething(TestClassWithResultMethod.Behaviour.Success);
            if (result is ISuccessResult<TestObjectBeingReturned> success)
                Assert.AreEqual("Some Name", success.Value.Name);
        }

        [Test]
        public void CheckSuccessWithFailureCheck()
        {
            var result = new TestClassWithResultMethod().DoSomething(TestClassWithResultMethod.Behaviour.Success);
            if (result is IFailureResult)
                Assert.Fail("This result wasn't a failure case!");
        }

        [Test]
        public void CheckSuccessWithNullableType()
        {
            var result = new TestClassWithResultMethod().DoSomething(TestClassWithResultMethod.Behaviour.Success);
            if (result is ISuccessResult<TestObjectBeingReturned?> success)
                Assert.AreEqual("Some Name", success.Value?.Name);
        }

        [Test]
        public void CheckDisabledWithDisabledCheck()
        {
            var result = new TestClassWithResultMethod().DoSomething(TestClassWithResultMethod.Behaviour.Disabled);
            if (!(result is IFailureResultFromDisabledExtension<TestObjectBeingReturned>))
                Assert.Fail("The result should have indicated the extension was disabled");
        }

        [Test]
        public void CheckDisabledWithSuccessCheck()
        {
            var result = new TestClassWithResultMethod().DoSomething(TestClassWithResultMethod.Behaviour.Disabled);
            if (result is ISuccessResult<TestObjectBeingReturned>)
                Assert.Fail("This result wasn't a success case!");
        }

        [Test]
        public void CheckDisabledIsHandledLikeNormalFailureCheck()
        {
            var result = new TestClassWithResultMethod().DoSomething(TestClassWithResultMethod.Behaviour.Disabled);
            if (!(result is IFailureResultFromDisabledExtension))
                Assert.Fail("The result should have indicated the extension was disabled, which should also be treated as a normal failure");
        }

        [Test]
        public void CheckSuccessNoObjectWithSuccessCheck()
        {
            var result = new TestClassWithResultMethod().DoSomethingWithNoObjectToReturn(TestClassWithResultMethod.Behaviour.Success);
            if (result is ISuccessResult)
                Assert.Pass("Was success");
            else
                Assert.Fail("Was supposed to be success");
        }

        [Test]
        public void CheckSuccessNoObjectWithFailureCheck()
        {
            var result = new TestClassWithResultMethod().DoSomethingWithNoObjectToReturn(TestClassWithResultMethod.Behaviour.Success);
            if (result is IFailureResult)
                Assert.Fail("This result wasn't a failure case!");
        }


        [Test]
        public void CheckDisabledNoObjectWithDisabledCheck()
        {
            var result = new TestClassWithResultMethod().DoSomethingWithNoObjectToReturn(TestClassWithResultMethod.Behaviour.Disabled);
            if (!(result is IFailureResultFromDisabledExtension))
                Assert.Fail("The result should have indicated the extension was disabled");
        }

        [Test]
        public void CheckDisabledNoObjectWithSuccessCheck()
        {
            var result = new TestClassWithResultMethod().DoSomethingWithNoObjectToReturn(TestClassWithResultMethod.Behaviour.Disabled);
            if (result is ISuccessResult)
                Assert.Fail("This result wasn't a success case!");
        }

        [Test]
        public void CheckFailureNoObjectWithFailureCheck()
        {
            var result = new TestClassWithResultMethod().DoSomethingWithNoObjectToReturn(TestClassWithResultMethod.Behaviour.Failure);
            if (result is IFailureResult fail)
                Assert.AreEqual("Some failure reason", fail.ErrorString);
        }

        [Test]
        public void CheckFailureNoObjectWithSuccessCheck()
        {
            var result = new TestClassWithResultMethod().DoSomethingWithNoObjectToReturn(TestClassWithResultMethod.Behaviour.Failure);
            if (result is ISuccessResult)
                Assert.Fail("This result wasn't a success case!");
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
                if (behaviour == Behaviour.Disabled)
                    return ResultFromExtension<TestObjectBeingReturned>.ExtensionDisabled();
                return ResultFromExtension<TestObjectBeingReturned>.Success(new TestObjectBeingReturned("Some Name"));
            }

            public IResultFromExtension DoSomethingWithNoObjectToReturn(Behaviour behaviour)
            {
                if (behaviour == Behaviour.Failure)
                    return ResultFromExtension.Failed("Some failure reason");
                if (behaviour == Behaviour.Disabled)
                    return ResultFromExtension.ExtensionDisabled();
                return ResultFromExtension.Success();
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