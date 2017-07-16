using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Camoran.CQRS.Core.Infrastructure
{
    public class MediatorCommand : ICommand, IRequest, INotification
    {
        public Guid CommmandId { get; private set; }

        public string Body { get; private set; }
        public string Topic { get; private set; }
        public DateTime CreateDate { get; private set; }

        public MediatorCommand(Guid commandId, string body, string topic)
        {
            CommmandId = commandId;
            Body = body;
            Topic = topic;
            CreateDate = DateTime.Now;
        }

        public virtual void SetBody(string body) => Body = body;

        public virtual void SetTopic(string topic) => Topic = topic;

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

}
    