using MediatR;

namespace Camoran.CQRS.Core.Infrastructure
{
    public interface IMediatorCommandHandler<Command> :
       ICommandHandler<Command>,
       IRequestHandler<Command>
        where Command : MediatorCommand
    {
         IMediator Mediator { get; }
    } 
}
