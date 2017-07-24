using System;
using System.Collections.Generic;
using System.Text;

namespace Camoran.CQRS.Core
{
    public interface IUnitOfWork:IDisposable
    {
        void Start();

        void Commit();

        void RollBack();
    }
}
