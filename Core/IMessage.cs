using System;
using System.Collections.Generic;
using System.Text;
//using System.Runtime.

namespace Camoran.CQRS.Core
{
    public interface IMessage
    {   
        string Body { get; }
        string Topic { get; }
        DateTime CreateDate { get; }
    }
}
