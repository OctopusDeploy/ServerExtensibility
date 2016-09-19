using System;
using Nancy;
using Nancy.Cookies;

namespace Octopus.Server.Extensibility.HostServices.Authentication
{
    public interface IAuthCookieCreator
    {
        INancyCookie CreateAuthCookie(NancyContext context, Guid token, bool persistant);
    }
}