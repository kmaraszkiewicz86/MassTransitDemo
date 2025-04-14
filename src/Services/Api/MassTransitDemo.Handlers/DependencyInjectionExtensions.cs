using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace MassTransitDemo.Handlers
{
    public static class DependencyInjectionExtensions
    {
        public static void AddHandlerServices(this IServiceCollection services, Assembly assembly)
        {
            services.AddClassesToDependencyInjection(typeof(ICommandHandler<,>), assembly);
            services.AddClassesToDependencyInjection(typeof(IQueryHandler<,>), assembly);
        }

        private static IServiceCollection AddClassesToDependencyInjection(this IServiceCollection services, Type type, Assembly? assembly = null)
        {
            if (assembly is null)
                assembly = type.Assembly;

            var types = assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.GetInterfaces()
                    .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == type))
                .ToList();

            foreach (var implementationType in types)
            {
                var interfaceType = implementationType.GetInterfaces().First(i => i != type);

                services.AddSingleton(interfaceType, implementationType);
            }

            return services;
        }
    }
}
