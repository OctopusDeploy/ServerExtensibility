using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Principal;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using Octopus.Data.Storage.Configuration;
using Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration;
using Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api;
using Octopus.Server.Extensibility.HostServices.Authorization;
using Shouldly;

namespace Node.Extensibility.Tests
{
    [TestFixture]
    public class InvokerFixture
    {
        IAsyncApiAction apiAction = null!;
        IOctoRequest request = null!;
        IExtensionConfigurationStore store = null!;
        IOctoResponseProvider expectedResponse = null!;

        [SetUp]
        public void SetUp()
        {
            apiAction = Substitute.For<IAsyncApiAction>();
            request = Substitute.For<IOctoRequest>();
            expectedResponse = Substitute.For<IOctoResponseProvider>();
            store = Substitute.For<IExtensionConfigurationStore>();

            apiAction.ExecuteAsync(request).Returns(Task.FromResult(expectedResponse));
        }

        [Test]
        public async Task AnonymousAsyncActionInvoker_AlwaysExecutes()
        {
            var invoker = new AnonymousAsyncActionInvoker<IAsyncApiAction>(apiAction);

            var response = await invoker.ExecuteAsync(request);

            response.ShouldBe(expectedResponse);
        }

        [Test]
        public async Task AnonymousWhenEnabledAsyncActionInvoker_Enabled_Executes()
        {
            var invoker = new AnonymousWhenEnabledAsyncActionInvoker<IAsyncApiAction, IExtensionConfigurationStore>(apiAction, store);
            store.GetIsEnabled().Returns(true);

            var response = await invoker.ExecuteAsync(request);

            response.ShouldBe(expectedResponse);
        }

        [Test]
        public async Task AnonymousWhenEnabledAsyncActionInvoker_Disabled_Errors()
        {
            var invoker = new AnonymousWhenEnabledAsyncActionInvoker<IAsyncApiAction, IExtensionConfigurationStore>(apiAction, store);
            store.GetIsEnabled().Returns(false);

            var response = await invoker.ExecuteAsync(request);

            response.Response.ShouldBeOfType<OctoBadRequestResponse>().ErrorMessages.ShouldContain("Extension is disabled.");
            apiAction.DidNotReceiveWithAnyArgs().ExecuteAsync(request);
        }

        [Test]
        public async Task SecuredAsyncActionInvoker_HasUser_Executes()
        {
            var invoker = new SecuredAsyncActionInvoker<IAsyncApiAction>(apiAction);

            var response = await invoker.ExecuteAsync(request);

            response.ShouldBe(expectedResponse);
        }

        [Test]
        public async Task SecuredAsyncActionInvoker_NoUser_Errors()
        {
            var invoker = new SecuredAsyncActionInvoker<IAsyncApiAction>(apiAction);
            request.User.Returns((IPrincipal)null!);

            var response = await invoker.ExecuteAsync(request);

            response.Response.ShouldBeOfType<OctoUnauthorisedResponse>();
            apiAction.DidNotReceiveWithAnyArgs().ExecuteAsync(request);
        }

        [Test]
        public async Task SecuredWhenEnabledAsyncActionInvoker_EnabledAndHasUser_Executes()
        {
            var invoker = new SecuredWhenEnabledAsyncActionInvoker<IAsyncApiAction, IExtensionConfigurationStore>(apiAction, store);
            store.GetIsEnabled().Returns(true);

            var response = await invoker.ExecuteAsync(request);

            response.ShouldBe(expectedResponse);
        }

        [Test]
        public async Task SecuredWhenEnabledAsyncActionInvoker_EnabledAndNoUser_Errors()
        {
            var invoker = new SecuredWhenEnabledAsyncActionInvoker<IAsyncApiAction, IExtensionConfigurationStore>(apiAction, store);
            store.GetIsEnabled().Returns(true);
            request.User.Returns((IPrincipal)null!);

            var response = await invoker.ExecuteAsync(request);

            response.Response.ShouldBeOfType<OctoUnauthorisedResponse>();
            apiAction.DidNotReceiveWithAnyArgs().ExecuteAsync(request);
        }

        [Test]
        public async Task SecuredWhenEnabledAsyncActionInvoker_DisabledAndHasUser_Errors()
        {
            var invoker = new SecuredWhenEnabledAsyncActionInvoker<IAsyncApiAction, IExtensionConfigurationStore>(apiAction, store);
            store.GetIsEnabled().Returns(false);

            var response = await invoker.ExecuteAsync(request);

            response.Response.ShouldBeOfType<OctoBadRequestResponse>().ErrorMessages.ShouldContain("Extension is disabled.");
            apiAction.DidNotReceiveWithAnyArgs().ExecuteAsync(request);
        }

        [Test]
        public async Task SecuredAdministratorWhenEnabledAsyncActionInvoker_EnabledAndHasAdminUser_Executes()
        {
            var authorizationChecker = Substitute.For<IAuthorizationChecker>();
            var invoker = new SecuredAdministratorWhenEnabledAsyncActionInvoker<IAsyncApiAction, IExtensionConfigurationStore>(apiAction, store, new Lazy<IAuthorizationChecker>(() => authorizationChecker));
            store.GetIsEnabled().Returns(true);
            authorizationChecker.IsCurrentUserAdministrator().Returns(true);

            var response = await invoker.ExecuteAsync(request);

            response.ShouldBe(expectedResponse);
        }

        [Test]
        public async Task SecuredAdministratorWhenEnabledAsyncActionInvoker_EnabledAndHasNonAdminUser_Errors()
        {
            var authorizationChecker = Substitute.For<IAuthorizationChecker>();
            var invoker = new SecuredAdministratorWhenEnabledAsyncActionInvoker<IAsyncApiAction, IExtensionConfigurationStore>(apiAction, store, new Lazy<IAuthorizationChecker>(() => authorizationChecker));
            store.GetIsEnabled().Returns(true);
            authorizationChecker.IsCurrentUserAdministrator().Returns(false);

            var response = await invoker.ExecuteAsync(request);

            response.Response.ShouldBeOfType<OctoUnauthorisedResponse>();
            apiAction.DidNotReceiveWithAnyArgs().ExecuteAsync(request);
        }

        [Test]
        public async Task SecuredAdministratorWhenEnabledAsyncActionInvoker_EnabledAndNoUser_Errors()
        {
            var authorizationChecker = Substitute.For<IAuthorizationChecker>();
            var invoker = new SecuredAdministratorWhenEnabledAsyncActionInvoker<IAsyncApiAction, IExtensionConfigurationStore>(apiAction, store, new Lazy<IAuthorizationChecker>(() => authorizationChecker));
            store.GetIsEnabled().Returns(true);
            request.User.Returns((IPrincipal)null!);
            authorizationChecker.IsCurrentUserAdministrator().Returns(true);

            var response = await invoker.ExecuteAsync(request);

            response.Response.ShouldBeOfType<OctoUnauthorisedResponse>();
            apiAction.DidNotReceiveWithAnyArgs().ExecuteAsync(request);
        }

        [Test]
        public async Task SecuredAdministratorWhenEnabledAsyncActionInvoker_DisabledAndHasAdminUser_Errors()
        {
            var authorizationChecker = Substitute.For<IAuthorizationChecker>();
            var invoker = new SecuredAdministratorWhenEnabledAsyncActionInvoker<IAsyncApiAction, IExtensionConfigurationStore>(apiAction, store, new Lazy<IAuthorizationChecker>(() => authorizationChecker));
            store.GetIsEnabled().Returns(false);
            authorizationChecker.IsCurrentUserAdministrator().Returns(true);

            var response = await invoker.ExecuteAsync(request);

            response.Response.ShouldBeOfType<OctoBadRequestResponse>().ErrorMessages.ShouldContain("Extension is disabled.");
            apiAction.DidNotReceiveWithAnyArgs().ExecuteAsync(request);
        }


        class TheAction : IAsyncApiAction
        {
            public Task<IOctoResponseProvider> ExecuteAsync(IOctoRequest request)
            {
                return Task.FromResult((IOctoResponseProvider)new WrappedResponse(new TestResponse()));
            }

            class WrappedResponse : IOctoResponseProvider
            {
                public WrappedResponse(OctoResponse response) => Response = response;

                public OctoResponse Response { get; private set; }

                public virtual IOctoResponseProvider WithCookie(OctoCookie cookie)
                {
                    Response = Response.WithCookie(cookie);
                    return this;
                }

                public virtual IOctoResponseProvider WithHeader(string name, IEnumerable<string> value)
                {
                    Response = Response.WithHeader(name, value);
                    return this;
                }
            }

            class TestResponse : OctoResponse
            {
                public TestResponse() : base(HttpStatusCode.Ambiguous)
                {
                }
            }
        }
    }
}