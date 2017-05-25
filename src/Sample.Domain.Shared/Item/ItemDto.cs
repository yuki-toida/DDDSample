using MessagePack;

namespace Sample.Domain.Shared.Item
{
    [MessagePackObject]
    public class ItemDto
    {
        [Key(0)]
        public int Id { get; set; }
        [Key(1)]
        public ItemEnum.Category Category { get; set; }
        [Key(2)]
        public string Name { get; set; }
    }
}
