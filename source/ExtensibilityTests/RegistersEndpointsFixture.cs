using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration;
using Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api;
using Shouldly;

namespace Node.Extensibility.Tests
{
    [TestFixture]
    public class RegistersEndpointsFixture
    {
        const string Method = "GET123";
        const string Path = "/Path/Blah";
        TestRegisters registersEndpoints = null!;

        [SetUp]
        public void SetUp()
        {
            registersEndpoints = new TestRegisters();
        }

        [Test]
        public void blah()
        {
            OctopusJsonRegistration<string[]> sut = new OctopusJsonRegistration<string[]>();
            sut.Description.ShouldBe("");
        }

        [Test]
        public void AddWithType_InvalidType_Throws()
        {
            Action action = () => registersEndpoints.TestAdd(typeof(string), new AnonymousWhenEnabledEndpointInvocation<TestStore>());
            action.ShouldThrow<ArgumentException>().ParamName.ShouldBe("actionType");
        }

        [Test]
        public void AddWithType_InvalidInvocation_Throws()
        {
            Action action = () => registersEndpoints.TestAdd<TestAction>(new InvalidInvocation());
            action.ShouldThrow<ArgumentException>().ParamName.ShouldBe("invocation");
        }

        [Test]
        public void AddWithGeneric_AnonymousEndpointInvocation()
        {
            var registration = registersEndpoints.TestAdd<TestAction>(new AnonymousEndpointInvocation());
            registration.InvokerType.ShouldBe(typeof(AnonymousAsyncActionInvoker<TestAction>));
        }

        [Test]
        public void AddWithType_AnonymousEndpointInvocation()
        {
            var registration = registersEndpoints.TestAdd(typeof(TestAction), new AnonymousEndpointInvocation());
            registration.InvokerType.ShouldBe(typeof(AnonymousAsyncActionInvoker<TestAction>));
        }

        [Test]
        public void AddWithGeneric_AnonymousWhenEnabledEndpointInvocation()
        {
            var registration = registersEndpoints.TestAdd<TestAction>(new AnonymousWhenEnabledEndpointInvocation<TestStore>());
            registration.InvokerType.ShouldBe(typeof(AnonymousWhenEnabledAsyncActionInvoker<TestAction, TestStore>));
        }

        [Test]
        public void AddWithType_AnonymousWhenEnabledEndpointInvocation()
        {
            var registration = registersEndpoints.TestAdd(typeof(TestAction), new AnonymousWhenEnabledEndpointInvocation<TestStore>());
            registration.InvokerType.ShouldBe(typeof(AnonymousWhenEnabledAsyncActionInvoker<TestAction, TestStore>));
        }

        [Test]
        public void AddWithGeneric_SecuredEndpointInvocation()
        {
            var registration = registersEndpoints.TestAdd<TestAction>(new SecuredEndpointInvocation());
            registration.InvokerType.ShouldBe(typeof(SecuredAsyncActionInvoker<TestAction>));
        }

        [Test]
        public void AddWithType_SecuredEndpointInvocation()
        {
            var registration = registersEndpoints.TestAdd(typeof(TestAction), new SecuredEndpointInvocation());
            registration.InvokerType.ShouldBe(typeof(SecuredAsyncActionInvoker<TestAction>));
        }

        [Test]
        public void AddWithGeneric_SecuredWhenEnabledEndpointInvocation()
        {
            var registration = registersEndpoints.TestAdd<TestAction>(new SecuredWhenEnabledEndpointInvocation<TestStore>());
            registration.InvokerType.ShouldBe(typeof(SecuredWhenEnabledAsyncActionInvoker<TestAction, TestStore>));
        }

        [Test]
        public void AddWithType_SecuredWhenEnabledEndpointInvocation()
        {
            var registration = registersEndpoints.TestAdd(typeof(TestAction), new SecuredWhenEnabledEndpointInvocation<TestStore>());
            registration.InvokerType.ShouldBe(typeof(SecuredWhenEnabledAsyncActionInvoker<TestAction, TestStore>));
        }

        [Test]
        public void AddWithGeneric_SecuredAdministratorWhenEnabledEndpointInvocation()
        {
            var registration = registersEndpoints.TestAdd<TestAction>(new SecuredAdministratorWhenEnabledEndpointInvocation<TestStore>());
            registration.InvokerType.ShouldBe(typeof(SecuredAdministratorWhenEnabledAsyncActionInvoker<TestAction, TestStore>));
        }

        [Test]
        public void AddWithType_SecuredAdministratorWhenEnabledEndpointInvocation()
        {
            var registration = registersEndpoints.TestAdd(typeof(TestAction), new SecuredAdministratorWhenEnabledEndpointInvocation<TestStore>());
            registration.InvokerType.ShouldBe(typeof(SecuredAdministratorWhenEnabledAsyncActionInvoker<TestAction, TestStore>));
        }

        class TestRegisters : RegistersEndpoints
        {
            const string Method = "GET123";
            const string Path = "/Path/Blah";
            const string Description = "Blah Foo Woo";
            const RouteCategory Category = RouteCategory.Raw;

            public EndpointRegistration TestAdd<TAction>(IEndpointInvocation invocation)
                where TAction : IAsyncApiAction
            {
                Add<TAction>(Method, Path, Category, invocation, Description);
                return GetRegistration();
            }

            public EndpointRegistration TestAdd(Type actionType, IEndpointInvocation invocation)
            {
                Add(Method, Path, Category, actionType, invocation, Description);
                return GetRegistration();
            }

            EndpointRegistration GetRegistration()
            {
                return Registrations.Single(r => r.Path == Path && r.Method == Method && r.Category == Category && r.Description == Description);
            }
        }

        class TestAction : IAsyncApiAction
        {
            public Task<IOctoResponseProvider> ExecuteAsync(IOctoRequest request)
            {
                throw new NotImplementedException();
            }
        }

        class TestStore : IExtensionConfigurationStore
        {
            public bool GetIsEnabled()
            {
                throw new NotImplementedException();
            }

            public void SetIsEnabled(bool isEnabled)
            {
                throw new NotImplementedException();
            }
        }

        class InvalidInvocation : IEndpointInvocation
        {
        }
    }
}