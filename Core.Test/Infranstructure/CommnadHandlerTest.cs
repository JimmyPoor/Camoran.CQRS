﻿using System;
using System.Collections.Generic;
using MediatR.Pipeline;
using Scrutor;
using Xunit;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Camoran.CQRS.Core.Infrastructure;
using Camoran.CQRS.Core;
using System.Threading.Tasks;

namespace Core.Test.Infranstructure
{

    public class MediatorCommandHandlerTest
    {
        IMediator _mediator;
        ICommandService<MyMediatorCommand> _commandService;
        MyMediatorCommandHandler _commandHandler;

        public MediatorCommandHandlerTest()
        {
            _mediator = BuildMediator();
            _commandService = BuildCommandService();
            _commandHandler = new MyMediatorCommandHandler(_mediator, _commandService);
        }

        [Fact]
        public void BuildCommandTest()
        {
            var command = BuildCommmand();

            Assert.NotNull(command);
        }


        [Fact]
        public void CommandHanleTest()
        {
            var command = BuildCommmand();
            
        }


        [Fact]
        public async void SendCommandTest()
        {
            var command = BuildCommmand();
            await _mediator.Send(command);

            Assert.Equal(command.Body, "Save Complete");
        }

        private MyMediatorCommand BuildCommmand()
        {
            return new MyMediatorCommand(Guid.NewGuid(), "Body", "Topic");
        }

        private IMediator BuildMediator()
        {
            var services = new ServiceCollection();

            services.AddScoped<SingleInstanceFactory>(p => t => p.GetRequiredService(t));
            services.AddScoped<MultiInstanceFactory>(p => t => p.GetRequiredServices(t));

            services.AddSingleton(Console.Out);

            services.Scan(scan => scan
              .FromAssembliesOf(typeof(IMediator), typeof(MyMediatorCommand))
              .AddClasses()
              .AsImplementedInterfaces());

            var provider = services.BuildServiceProvider();
            var mediator = provider.GetRequiredService<IMediator>();

            return mediator;
        }

        private MyMediatorCommandService BuildCommandService()
        {
            var services = new ServiceCollection()
                .AddTransient<ICommandService<MyMediatorCommand>, MyMediatorCommandService>()
                .BuildServiceProvider();

            return services.GetService<ICommandService<MyMediatorCommand>>() as MyMediatorCommandService;
        }
    }


    public static class ServiceProviderExtension
    {
        public static IEnumerable<object> GetRequiredServices(this IServiceProvider provider, Type serviceType)
        {
            return (IEnumerable<object>)provider.GetRequiredService(typeof(IEnumerable<>).MakeGenericType(serviceType));
        }
    }


    public class MyMediatorCommand : MediatorCommand
    {
        public MyMediatorCommand(Guid commandId, string body, string topic) : base(commandId, body, topic)
        {
        }
    }

    public class MyMediatorCommandHandler : MediatorCommandHandler<MyMediatorCommand>
    {
        public MyMediatorCommandHandler(IMediator mediator, ICommandService<MyMediatorCommand> service) : base(mediator, service)
        {
        }

        public override Task HandleCommand(MyMediatorCommand message)
        {
            message.SetBody("Handle Command");
            return Task.FromResult(message);
        }
    }

    public class MyMediatorCommandService : ICommandService<MyMediatorCommand>
    {
        public Task SaveCommandAsync(MyMediatorCommand command)
        {
            throw new NotImplementedException();
        }

        public void SaveCommnad(MyMediatorCommand command)
        {
            command.SetBody("Save Complete");
        }
    }



}
