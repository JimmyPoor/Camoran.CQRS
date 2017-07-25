using System;
using System.Collections.Generic;
using System.Text;

namespace Camoran.CQRS.Core
{
    public interface ISnapshot<T>
    {
        void Save(int version,T t);

        IEnumerable<T> GetByVersionId(int version);
    }
}
