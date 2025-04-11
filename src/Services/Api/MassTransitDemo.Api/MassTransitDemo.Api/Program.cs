using Carter;
using MassTransit;
using MassTransitDemo.Api.StateMachine;
using MassTransitDemo.Handlers;

namespace MassTransitDemo.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();
            builder.Services.AddHandlerServices(typeof(Program).Assembly);

            builder.Services.AddMassTransit(cfg =>
            {
                cfg.SetKebabCaseEndpointNameFormatter();
                cfg.AddSagaStateMachine<FileStateMachine, FileState>()
                    .InMemoryRepository();

                cfg.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("rabbitmq://localhost");
                    cfg.ConfigureEndpoints(context);
                });
            });

            builder.Services.AddCarter();


            var app = builder.Build();

            app.MapCarter();

            app.Run();
        }
    }
}
