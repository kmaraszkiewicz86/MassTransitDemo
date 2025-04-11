using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace MassTransitDemo.Handlers
{
    public static class DependencyInjectionExtensions
    {
        public static void AddHandlerServices(this IServiceCollection services, Assembly assembly)
        {
            services.AddSingleton<ICommandDispatcher, CommandDispatcher>();
            services.AddSingleton<IQueryDispatcher, QueryDispatcher>();
            services.AddClassesToDependencyInjection(typeof(ICommandHandler<,>), assembly);
            services.AddClassesToDependencyInjection(typeof(IQueryHandler<,>), assembly);
        }

        private static IServiceCollection AddClassesToDependencyInjection(this IServiceCollection services, Type type, Assembly? assembly = null)
        {
            if (assembly is null)
                assembly = type.Assembly;

            var types = assembly.GetTypes()
                .Where(t => t is { IsClass: true, IsAbstract: false }
                            && t.GetInterfaces().Contains(type))
                .ToList();

            foreach (var implementationType in types)
            {
                var interfaceType = implementationType.GetInterfaces().First(i => i != type);

                services.AddScoped(interfaceType, implementationType);
            }

            return services;
        }
    }
}
