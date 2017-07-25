using System;
using System.Collections.Generic;
using System.Text;

namespace Camoran.CQRS.Core.Infrastructure
{
    public class InMemorySnapshot<T> : ISnapshot<T>
    {
        private IDictionary<int, T> _memoto;

        public IEnumerable<T> GetByVersionId(int version)
        {
            if (version < 0) version = 0;
            return null;
        }

        public void Save(int version,T t)
        {
            _memoto.Add(version, t);
        }
    }
}     
