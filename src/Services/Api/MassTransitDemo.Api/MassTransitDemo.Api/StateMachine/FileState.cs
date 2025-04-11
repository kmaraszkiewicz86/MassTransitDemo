using MassTransit;

namespace MassTransitDemo.Api.StateMachine
{
    public class FileState : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public string CurrentState { get; set; } = string.Empty;
    }
}
