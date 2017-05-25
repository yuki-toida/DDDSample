using Sample.Infra.Interface.Data.Transaction;

namespace Sample.Domain.Model.Gift.Entity
{
    public class UnopenGift : GiftBase
    {
        public UnopenGift(GiftTranUnopen tran)
            : base(tran.GiftId, tran.AddDate, tran.AddReason, tran.LimitDate, null, tran.Word)
        {
        }
    }
}
