using Sample.Infra.Interface.AppContext;
using Sample.Infra.Interface.DataContext;

namespace Sample.App.Web
{
    public class AppContext : IAppContext
    {
        public AppContext(IDataContext dataContext)
        {
            DataContext = dataContext;
        }

        public IDataContext DataContext { get; }
    }
}
