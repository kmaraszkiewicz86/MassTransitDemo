﻿using Microsoft.Extensions.DependencyInjection;

namespace MassTransitDemo.Handlers
{
    public class QueryDispatcher(IServiceProvider serviceProvider) : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;

        public Task<TQueryResult> Dispatch<TQuery, TQueryResult>(TQuery query, CancellationToken cancellation)
        {
            var handler = _serviceProvider.GetRequiredService<IQueryHandler<TQuery, TQueryResult>>();
            return handler.Handle(query, cancellation);
        }
    }
}
