using Sample.Infra.Interface.Data.Transaction;

namespace Sample.Domain.Model.Gift.Entity
{
    public class OpenGift : GiftBase
    {
        public OpenGift(GiftTranOpen tran)
            : base(tran.GiftId, tran.AddDate, tran.AddReason, tran.LimitDate, null, tran.Word)
        {
        }
    }
}
