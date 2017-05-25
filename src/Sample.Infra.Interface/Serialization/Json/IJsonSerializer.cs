namespace Sample.Infra.Interface.Serialization.Json
{
    /// <summary>
    /// JSON のシリアライザーを共通化するためのインターフェイスです。
    /// </summary>
    public interface IJsonSerializer
    {
        string Serialize<T>(T obj);
        T Deserialize<T>(string json);
    }
}
