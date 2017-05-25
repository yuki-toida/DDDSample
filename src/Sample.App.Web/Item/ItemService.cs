using Sample.Domain.Model.Item.Entity.Gold;
using Sample.Infra.Interface.AppContext;

namespace Sample.App.Web.Item
{
    public class ItemService : AppServiceBase
    {
        public ItemService(IAppContext appContext) : base(appContext)
        {
        }

        public ItemGold GetGold()
        {
            return new ItemGold();
        }
    }
}
