using Sample.Infra.Interface.AppContext;

namespace Sample.App.Web.User
{
    public class UserService : AppServiceBase
    {
        public UserService(IAppContext appContext) : base(appContext)
        {
        }
    }
}
