namespace MassTransitDemo.Api.StateMachine.States
{
    public interface IFileUploading
    {
        Guid FileId { get; }

        string FileName { get; }

        string Body { get; }
    }
}
