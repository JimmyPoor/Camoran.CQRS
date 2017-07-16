using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Camoran.CQRS.Core.Infrastructure
{
    public abstract class MediatorCommandHandler<Command> :
       ICommandHandler<Command>,
       IRequestHandler<Command>
        where Command : MediatorCommand
    {
        public ICommandService<Command> Service { get; protected set; }
        public IMediator Mediator { get; protected set; }

        public MediatorCommandHandler(IMediator mediator, ICommandService<Command> service)
        {
            this.Service = service;
            this.Mediator = mediator;
        }

        public async void Handle(Command request)
        {
            await HandleCommand(request);

            Service.SaveCommnad(request);
        }

        public abstract Task HandleCommand(Command message);

        public Task Send(Command message)
        {
            return Mediator.Send(message);
        }

    }
}
