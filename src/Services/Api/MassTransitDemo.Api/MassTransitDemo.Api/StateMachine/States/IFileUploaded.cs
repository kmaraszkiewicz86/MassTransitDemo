namespace MassTransitDemo.Api.StateMachine.States
{
    public interface IFileUploaded
    {
        Guid FileId { get; }

        string FileName { get; }

        string BlobUrl { get; }

        DateTime UploadedAt { get; }
    }

}
