namespace Sample.Infra.Interface.Serialization.MessagePack
{
    /// <summary>
    /// MessagePack のシリアライザーを共通化するためのインターフェイスです。
    /// </summary>
    public interface IMessagePackSerializer
    {
        byte[] Serialize<T>(T obj);
        T Deserialize<T>(byte[] bytes);
    }
}
