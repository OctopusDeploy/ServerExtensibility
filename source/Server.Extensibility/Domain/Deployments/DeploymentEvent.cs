using System;
using Octopus.Server.Extensibility.HostServices.Diagnostics;
using Octopus.Server.Extensibility.HostServices.Domain.Events;
using Octopus.Server.Extensibility.HostServices.Model.Projects;

namespace Octopus.Server.Extensibility.Domain.Deployments
{
    public enum DeploymentEventType
    {
        DeploymentStarted,
        DeploymentResumed,
        DeploymentSucceeded,
        DeploymentFailed,
        ManualInterventionInterruptionRaised,
        GuidedFailureInterruptionRaised
    }

    public class DeploymentEvent : DomainEvent
    {
        public DeploymentEvent(DeploymentEventType eventType, IDeployment deployment, ITaskLog taskLog)
        {
            EventType = eventType;
            Deployment = deployment;
            TaskLog = taskLog;
        }

        public DeploymentEventType EventType { get; }
        public IDeployment Deployment { get; }
        public ITaskLog TaskLog { get; }
    }
}