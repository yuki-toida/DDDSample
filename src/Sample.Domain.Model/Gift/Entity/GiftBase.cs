using System;
using Sample.Domain.Model.Item.Entity;
using Sample.Domain.Shared.Gift;

namespace Sample.Domain.Model.Gift.Entity
{
    public abstract class GiftBase
    {
        protected GiftBase(
            long giftId
            , DateTimeOffset addDate
            , int reason
            , DateTimeOffset? limitDate
            , ItemContainer itemContainer
            , string word
            )
        {
            GiftId = giftId;
            AddDate = addDate;
            Reason = (GiftEnum.AddReason)reason;
            LimitDate = limitDate;
            ItemContainer = itemContainer;
            Word = word;
        }

        public long GiftId { get; }
        public DateTimeOffset AddDate { get; }
        public GiftEnum.AddReason Reason { get; }
        public DateTimeOffset? LimitDate { get; }
        public ItemContainer ItemContainer { get; }
        public string Word { get; }
    }
}
