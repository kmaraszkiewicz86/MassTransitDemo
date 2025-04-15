using Carter;
using FluentResults;
using MassTransit;

namespace MassTransitDemo.Api.Features.UploadFileToBlobStorage
{
    public class UploadFileToBlobStorageEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/upload-file", async (IPublishEndpoint publishEndpoint, UploadFileToBlobStorageCommand command) =>
            {
                await publishEndpoint.Publish(command);
                return Result.Ok();
            });
        }
    }
}
