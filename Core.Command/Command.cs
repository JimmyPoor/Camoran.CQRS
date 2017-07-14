using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Camoran.CQRS.Core.Infrastructure
{
    //public class MediatorCommand : ICommand,IRequest,INotification
    //{
    //    public Guid CommmandId { get; private set; }

    //    public string Body { get; private set; }
    //    public string Topic { get; private set; }
    //    public DateTime CreateDate { get; private set; }

    //    public MediatorCommand(Guid commandId,string body,string topic)
    //    {
    //        CommmandId = commandId;
    //        Body = body;
    //        Topic = topic;
    //        CreateDate = DateTime.Now;
    //    }

    //    public virtual void SetBody(string body) => Body = body;

    //    public virtual void SetTopic(string topic) => Topic = topic;

    //    public override bool Equals(object obj)
    //    {
    //        return base.Equals(obj);
    //    }

    //    public override int GetHashCode()
    //    {
    //        return base.GetHashCode();
    //    }
    //}

    //public abstract class MediatorCommandHandler : ICommandHandler<MediatorCommand>, INotificationHandler<string>,IRequestHandler<MediatorCommand>
    //{
    //    public ICommandService Service { get; protected set; }
    //    public Mediator Mediator { get; protected set; }

    //    public MediatorCommandHandler(Mediator mediator, ICommandService service)
    //    {
    //        this.Service = service;
    //        this.Mediator = mediator;
    //    }

    //    public void Handle(MediatorCommand notification)
    //    {
    //        HandleCommand(notification);
    //    }
        
    //    public abstract void HandleCommand(MediatorCommand message);


    //    public void Send(MediatorCommand message)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Handle(string notification)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
    