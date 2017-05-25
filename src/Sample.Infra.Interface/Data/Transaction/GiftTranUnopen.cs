using System;

namespace Sample.Infra.Interface.Data.Transaction
{
    public partial class GiftTranUnopen
    {
        public long GiftId { get; set; }
        public int Uid { get; set; }
        public DateTimeOffset AddDate { get; set; }
        public int AddReason { get; set; }
        public DateTimeOffset? LimitDate { get; set; }
        public int ItemCategory { get; set; }
        public int ItemId { get; set; }
        public int ItemNum { get; set; }
        public string Word { get; set; }
    }
}
