using System;

namespace Octopus.Server.Extensibility.HostServices.Web
{
    public interface IWebPortalConfigurationStore
    {
        string GetListenPrefixes();
        void SetListenPrefixes(string listenPrefixes);

        bool GetForceSSL();
        void SetForceSSL(bool forceSSL);

        bool GetRequestLoggingEnabled();
        void SetRequestLoggingEnabled(bool requestLoggingEnabled);

        string GetCorsWhitelist();
        void SetCorsWhitelist(string corsWhitelist);

        string GetXFrameOptionAllowFrom();
        void SetXFrameOptionAllowFrom(string xFrameOptionAllowFrom);

        bool GetIsAutoLoginEnabled();
        void SetIsAutoLoginEnabled(bool isAutoLoginEnabled);
    }
}