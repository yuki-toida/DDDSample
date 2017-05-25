using MessagePack;
using Sample.Infra.Interface.Serialization.MessagePack;

namespace Sample.Infra.MessagePackCSharp
{
    public class MessagePackCSharpSerializer : IMessagePackSerializer
    {
        public byte[] Serialize<T>(T obj)
        {
            return MessagePackSerializer.Serialize(obj);
        }

        public T Deserialize<T>(byte[] bytes)
        {
            return MessagePackSerializer.Deserialize<T>(bytes);
        }
    }
}
