using System;
using System.Collections.Generic;
using System.Text;

namespace Camoran.CQRS.Core
{
   public interface IRepository<T> where T:IAggregateRoot
    {
        T GetById(Guid id);

        void Save(T t);

        IUnitOfWork UnitOfWork { get; }

        IEventService EvntService { get; }
    }
}
