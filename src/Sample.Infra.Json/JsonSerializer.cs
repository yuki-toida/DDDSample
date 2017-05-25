using System;
using System.Text;
using Newtonsoft.Json;
using Sample.Infra.Interface.Serialization.Json;

namespace Sample.Infra.Json
{
    public class JsonSerializer : IJsonSerializer
    {
        public string Serialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public byte[] Serialize(object value)
        {
            var json = JsonConvert.SerializeObject(value);
            return Encoding.UTF8.GetBytes(json);
        }

        public T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public object Deserialize(byte[] value, Type type)
        {
            var json = Encoding.UTF8.GetString(value);
            return JsonConvert.DeserializeObject(json, type);
        }
    }
}
