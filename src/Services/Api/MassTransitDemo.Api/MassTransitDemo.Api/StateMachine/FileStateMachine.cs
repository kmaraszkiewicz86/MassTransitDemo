using FluentResults;
using MassTransit;
using MassTransitDemo.Api.Features.UploadFileToBlobStorage;
using MassTransitDemo.Api.StateMachine.States;
using MassTransitDemo.Handlers;

namespace MassTransitDemo.Api.StateMachine
{
    public class FileStateMachine : MassTransitStateMachine<FileState>
    {
        public State Uploading { get; private set; } = null!;
        public State Uploaded { get; private set; } = null!;
        public Event<IFileUploading> FileUploading { get; private set; } = null!;
        public Event<IFileUploaded> FileUploaded { get; private set; } = null!;

        public FileStateMachine(ICommandHandler<UploadFileToBlobStorageCommand, Result> commandHandler)
        {
            InstanceState(x => x.CurrentState);
            Event(() => FileUploaded, x => x.CorrelateById(m => m.Message.FileId));
            Event(() => FileUploading, x => x.CorrelateById(m => m.Message.FileId));
            Initially(
                When(FileUploading)
                    .Then(async context =>
                    {
                        await commandHandler.Handle(new UploadFileToBlobStorageCommand(context.Message.FileId, context.Message.FileName, context.Message.Body), CancellationToken.None);
                        Console.WriteLine($"File {context.Message.FileId} to uploading");
                    })
                    .TransitionTo(Uploading));

            During(Uploading,
                When(FileUploaded)
                    .Then(context =>
                    {
                        Console.WriteLine($"File {context.Message.FileName} uploaded to {context.Message.BlobUrl} at {context.Message.UploadedAt}");
                    })
                    .TransitionTo(Uploaded));
        }
    }
}
