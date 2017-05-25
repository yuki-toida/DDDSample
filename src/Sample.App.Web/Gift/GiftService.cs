using Sample.Infra.Interface.AppContext;

namespace Sample.App.Web.Gift
{
    public class GiftService : AppServiceBase
    {
        public GiftService(IAppContext appContext) : base(appContext)
        {
        }

        /// <summary>
        /// ギフト開ける
        /// </summary>
        /// <param name="giftIds">指定GiftId</param>
        public void Open(long[] giftIds)
        {
            
        }
    }
}
