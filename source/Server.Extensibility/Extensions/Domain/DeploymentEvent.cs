using Octopus.Server.Extensibility.HostServices.Domain.Events;
using Octopus.Server.Extensibility.HostServices.Model.Projects;

namespace Octopus.Server.Extensibility.Extensions.Domain
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
        public DeploymentEvent(DeploymentEventType eventType, IDeployment deployment)
        {
            EventType = eventType;
            Deployment = deployment;
        }

        public DeploymentEventType EventType { get; set; }
        public IDeployment Deployment { get; set; }
    }
}