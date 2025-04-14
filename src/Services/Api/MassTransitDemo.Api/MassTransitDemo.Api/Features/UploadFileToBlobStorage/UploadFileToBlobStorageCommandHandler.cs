using FluentResults;
using MassTransitDemo.Handlers;

namespace MassTransitDemo.Api.Features.UploadFileToBlobStorage
{
    public record UploadFileToBlobStorageCommand(string FileName, string Body);

    public class UploadFileToBlobStorageCommandHandler : ICommandHandler<UploadFileToBlobStorageCommand, Result>
    {
        public async Task<Result> Handle(UploadFileToBlobStorageCommand command, CancellationToken cancellation)
        {
            Console.WriteLine($"File {command.FileName} to uploading");

            return await Task.FromResult(Result.Ok());
        }
    }
}
