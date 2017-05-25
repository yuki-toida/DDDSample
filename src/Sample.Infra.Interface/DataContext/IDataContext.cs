using System;
using Sample.Infra.Interface.Repository;

namespace Sample.Infra.Interface.DataContext
{
    public interface IDataContext : IDisposable
    {
        IRepositories Repositories { get; }
        int SaveChanges();
    }
}
