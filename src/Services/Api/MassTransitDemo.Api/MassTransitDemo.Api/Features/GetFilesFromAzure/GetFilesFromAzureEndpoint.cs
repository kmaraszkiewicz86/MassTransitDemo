using Carter;
using FluentResults;
using MassTransitDemo.Api.Models.Responses;
using MassTransitDemo.Handlers;

namespace MassTransitDemo.Api.Features.GetFilesFromAzure
{
    public class GetFilesFromAzureEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/get-files", async (IQueryHandler<GetFilesFromAzureQuery, Result<FileFromAzureResponse[]>> queryHandler) =>
                await queryHandler.Handle(new GetFilesFromAzureQuery(), CancellationToken.None));
        }
    }
}
