using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Howframework.Domain.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IUnitOfWork StartSession();

        void Save<T>(T entity);
    }
}
