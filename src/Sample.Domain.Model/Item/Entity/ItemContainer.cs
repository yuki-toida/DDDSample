namespace Sample.Domain.Model.Item.Entity
{
    public class ItemContainer
    {
        public ItemContainer(ItemBase item, int num)
        {
            Item = item;
            Num = num;
        }

        public ItemBase Item { get; }
        public int Num { get; }
    }

    public class ItemContainer<T> : ItemContainer where T : ItemBase
    {
        public ItemContainer(T item, int num) : base(item, num)
        {
        }

        public new T Item => base.Item as T;
    }
}
