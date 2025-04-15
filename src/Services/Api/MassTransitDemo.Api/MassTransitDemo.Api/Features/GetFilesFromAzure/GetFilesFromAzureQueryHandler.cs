using FluentResults;
using MassTransitDemo.Handlers;

namespace MassTransitDemo.Api.Features.GetFilesFromAzure
{
    public record GetFilesFromAzureQuery();

    public class GetFilesFromAzureQueryHandler : IQueryHandler<GetFilesFromAzureQuery, Result<FileFromAzureResponse[]>>
    {
        public Task<Result<FileFromAzureResponse[]>> Handle(GetFilesFromAzureQuery query, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}