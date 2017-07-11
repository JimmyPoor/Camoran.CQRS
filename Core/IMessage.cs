using System;
using System.Collections.Generic;
using System.Text;

namespace Camoran.CQRS.Core
{
    public interface IMessage
    {   
        string Body { get; set; }
        string Topic { get; set; }
    }
}
