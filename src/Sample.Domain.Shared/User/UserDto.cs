using MessagePack;

namespace Sample.Domain.Shared.User
{
    [MessagePackObject]
    public class UserDto
    {
        [Key(0)]
        public int Uid { get; set; }
    }
}
