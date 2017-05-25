using Sample.Infra.Interface.Data.Transaction;

namespace Sample.Infra.Interface.Repository
{
    public interface IRepositories
    {
        IRepository<GiftTranOpen> GiftTranOpen { get; }
        IRepository<GiftTranUnopen> GiftTranUnopen { get; }
        IRepository<UserTranBase> UserTranBase { get; }
    }
}
