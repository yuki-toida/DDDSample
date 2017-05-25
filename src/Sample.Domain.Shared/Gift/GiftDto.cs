using System;
using MessagePack;
using Sample.Domain.Shared.Item;

namespace Sample.Domain.Shared.Gift
{
    [MessagePackObject]
    public class GiftDto
    {
        [Key(0)]
        public long GiftId { get; set; }
        [Key(1)]
        public DateTimeOffset AddDate { get; set; }
        [Key(2)]
        public GiftEnum.AddReason Reason { get; set; }
        [Key(3)]
        public DateTimeOffset? LimitDate { get; set; }
        [Key(4)]
        public ItemContainerDto ItemContainer { get; set; }
        [Key(5)]
        public string Word { get; set; }
    }
}
