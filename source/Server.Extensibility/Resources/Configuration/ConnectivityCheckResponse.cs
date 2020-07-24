using System;
using System.Collections.Generic;

namespace Octopus.Server.Extensibility.Resources.Configuration
{
    public class ConnectivityCheckResponse
    {
        readonly List<ConnectivityCheckMessage> messages;

        public ConnectivityCheckResponse()
        {
            messages = new List<ConnectivityCheckMessage>();
        }

        public IEnumerable<ConnectivityCheckMessage> Messages => messages;

        public void AddMessage(ConnectivityCheckMessageCategory category, string message)
        {
            messages.Add(new ConnectivityCheckMessage(category, message));
        }
    }
}