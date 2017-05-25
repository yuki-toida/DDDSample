using Sample.Domain.Model.Item.ValueObject;
using Sample.Domain.Shared.Item;

namespace Sample.Domain.Model.Item.Entity.Gold
{
    public class ItemGold : ItemBase
    {
        public ItemGold() : base(ItemConst.DefaultId)
        {
        }

        public override ItemEnum.Category Category => ItemEnum.Category.Gold;

        public override string Name => "金貨";
    }
}
