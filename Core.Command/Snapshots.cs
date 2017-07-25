using System;
using System.Collections.Generic;
using System.Text;
using Guards.Extensions;

namespace Camoran.CQRS.Core.Infrastructure
{
    public class InMemorySnapshot<T> : ISnapshot<T>
    {
        protected IDictionary<int, T> _memoto;

        public virtual IEnumerable<T> GetByVersionId(int version)
        {
            if (version < 0) version = 0;

            foreach(var key in _memoto.Keys)
            {
                yield return _memoto[key];
            }
        }

        public virtual void Save(int version,T t)
        {
            t.EnsureNotNull();

            _memoto.Add(version, t);
        }
    }
}     
