using Sample.Infra.Interface.DataContext;

namespace Sample.Infra.Interface.AppContext
{
    public interface IAppContext
    {
        IDataContext DataContext { get; }
    }
}
