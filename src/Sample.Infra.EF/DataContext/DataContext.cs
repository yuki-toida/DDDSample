using Microsoft.EntityFrameworkCore;
using Sample.Infra.EF.Repository;
using Sample.Infra.Interface.DataContext;
using Sample.Infra.Interface.Repository;

namespace Sample.Infra.EF.DataContext
{
    public class DataContext : IDataContext
    {
        private readonly DbContext _dbContext;

        public DataContext(DbContext dbContext)
        {
            _dbContext = dbContext;

            Repositories = new Repositories(dbContext);
        }

        // DB
        public IRepositories Repositories { get; }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
    }
}
