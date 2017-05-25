using Sample.Domain.Shared.Item;

namespace Sample.Domain.Model.Item.Entity
{
    public abstract class ItemBase
    {
        protected ItemBase(int id)
        {
            Id = id;
        }

        public int Id { get; }
        public abstract ItemEnum.Category Category { get; }
        public abstract string Name { get; }
    }
}
