using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading.Tasks;
using NUnit.Framework;
using Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api;
using Shouldly;

namespace Node.Extensibility.Tests.RequestExecutorBuilder
{
    [TestFixture]
    public class RequestExecutorBuilderFixture
    {
        static readonly IRequiredParameter<string> Name = new RequiredQueryParameterProperty<string>("name", "Name to lookup");
        static readonly IRequiredParameter<bool> IsEnabled = new RequiredQueryParameterProperty<bool>("isEnabled", "Enabled flag");
        static readonly OctopusJsonRegistration<TestResponseResource> Result = new OctopusJsonRegistration<TestResponseResource>();

        [Test]
        public async Task SingleParameterPassesThroughCorrectly()
        {
            var testRequest = new TestRequest();
            testRequest.TestParameters.Add("name", "Foo");

            var provider = await testRequest
                .WithParameter(Name)
                .HandleAsync(name =>
            {
                name.ShouldBe("Foo");
                return Task.FromResult(Result.Response(new TestResponseResource { Name = name }));
            });

            provider.Response.ShouldBeOfType<OctoDataResponse>();
            var testResponseResource = (TestResponseResource)((OctoDataResponse)provider.Response).Model;
            testResponseResource.Name.ShouldBe("Foo");
        }

        [Test]
        public async Task MultipleParametersPassesThroughCorrectly()
        {
            var testRequest = new TestRequest();
            testRequest.TestParameters.Add("name", "Foo");
            testRequest.TestParameters.Add("isEnabled", "true");

            var provider = await testRequest
                .WithParameter(Name)
                .WithParameter(IsEnabled)
                .HandleAsync(name => isEnabled =>
                {
                    name.ShouldBe("Foo");
                    return Task.FromResult(Result.Response(new TestResponseResource { Name = name, IsEnabled = isEnabled }));
                });
            
            provider.Response.ShouldBeOfType<OctoDataResponse>();
            var testResponseResource = (TestResponseResource)((OctoDataResponse)provider.Response).Model;
            testResponseResource.Name.ShouldBe("Foo");
            testResponseResource.IsEnabled.ShouldBe(true);
        }

        class TestRequest : IOctoRequest
        {
            static readonly BadRequestRegistration missingParameter = new BadRequestRegistration("Required URL parameter {parameter.Name} is missing");

            public string Scheme { get; }
            public bool IsHttps { get; }
            public string Host { get; }
            public string PathBase { get; }
            public string Path { get; }
            public string Protocol { get; }
            public IDictionary<string, IEnumerable<string>> Headers { get; }
            public IDictionary<string, string> Form { get; }
            public IDictionary<string, string> Cookies { get; }
            public IPrincipal User { get; }
            
            public Dictionary<string, object> TestParameters = new Dictionary<string, object>();
            
            public Task<IOctoResponseProvider> GetParameterValue<T>(IResponderParameter<T> parameter, Func<T, Task<IOctoResponseProvider>> onSuccess)
            {
                T value = default(T);
                if (!TestParameters.ContainsKey(parameter.Name))
                {

                    if (parameter is IRequiredParameter)
                    {
                        if (!TestParameters.ContainsKey(parameter.Name))
                            return Task.FromResult(missingParameter.Response($"Required URL parameter {parameter.Name} is missing"));
                    }
                    else
                    {
                        value = ((IOptionalParameter<T>) parameter).DefaultValue;
                    }
                }
                else
                {
                    value = (T) Convert.ChangeType(TestParameters[parameter.Name], typeof(T));
                }

                return onSuccess(value);
            }

            public RequestExecutorBuilder<TParameterType> WithParameter<TParameterType>(IResponderParameter<TParameterType> parameter)
            {
                return new RequestExecutorBuilder<TParameterType>(this, parameter);
            }

            public TResource GetBody<TResource>(RequestBodyRegistration<TResource> requestBodyRegistration)
            {
                throw new NotImplementedException();
            }
        }

        class TestResponseResource
        {
            public string Name { get; set; }
            public bool IsEnabled { get; set; }
        }
    }
}