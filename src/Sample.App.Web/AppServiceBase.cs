using Sample.Domain.Model.User.Entity;
using Sample.Infra.Interface.AppContext;

namespace Sample.App.Web
{
    public abstract class AppServiceBase
    {
        protected AppServiceBase(IAppContext appContext)
        {
            AppContext = appContext;
            //User = new UserBase(appContext.DataContext.UserBaseRepository.Find(1));
        }

        public IAppContext AppContext { get; }
        public UserBase User { get; }
    }
}
