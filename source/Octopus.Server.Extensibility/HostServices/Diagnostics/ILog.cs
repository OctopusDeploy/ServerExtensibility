using System;

namespace Octopus.Server.Extensibility.HostServices.Diagnostics
{
    public interface ILog
    {
        void Trace(string messageText);
        void Trace(Exception error);
        void Trace(Exception error, string messageText);

        void Verbose(string messageText);
        void Verbose(Exception error);
        void Verbose(Exception error, string messageText);

        void Info(string messageText);
        void Info(Exception error);
        void Info(Exception error, string messageText);

        void Warn(string messageText);
        void Warn(Exception error);
        void Warn(Exception error, string messageText);

        void Error(string messageText);
        void Error(Exception error);
        void Error(Exception error, string messageText);

        void Fatal(string messageText);
        void Fatal(Exception error);
        void Fatal(Exception error, string messageText);

        void Write(LogCategory category, string messageText);
        void Write(LogCategory category, Exception error);
        void Write(LogCategory category, Exception error, string messageText);

        void Flush();
    }
}