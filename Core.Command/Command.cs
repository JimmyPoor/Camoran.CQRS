using System;
using System.Collections.Generic;
using System.Text;

namespace Camoran.CQRS.Core.Infrastructure
{
    public class Command : ICommand
    {
        public Guid CommmandId { get; private set; }

        public string Body { get; private set; }
        public string Topic { get; private set; }
        public DateTime CreateDate { get; private set; }

        public Command(Guid commandId,string body,string topic)
        {
            CommmandId = commandId;
            Body = body;
            Topic = topic;
            CreateDate = DateTime.Now;
        }

        public void SetBody(string body) => Body = body;

        public void SetTopic(string topic) => Topic = topic;

    }
}
