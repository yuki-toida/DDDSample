using MessagePack;

namespace Sample.Domain.Shared.Item
{
    [MessagePackObject]
    public class ItemContainerDto
    {
        [Key(0)]
        public ItemDto Item { get; set; }
        [Key(1)]
        public int Num { get; set; }
    }
}
