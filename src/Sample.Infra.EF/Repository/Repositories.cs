using Microsoft.EntityFrameworkCore;
using Sample.Infra.Interface.Data.Transaction;
using Sample.Infra.Interface.Repository;

namespace Sample.Infra.EF.Repository
{
    public class Repositories : IRepositories
    {
        internal Repositories(DbContext dbContext)
        {
            GiftTranOpen = new Repository<GiftTranOpen>(dbContext);
            GiftTranUnopen = new Repository<GiftTranUnopen>(dbContext);
            UserTranBase = new Repository<UserTranBase>(dbContext);
        }

        public IRepository<GiftTranOpen> GiftTranOpen { get; }
        public IRepository<GiftTranUnopen> GiftTranUnopen { get; }
        public IRepository<UserTranBase> UserTranBase { get; }
    }
}
