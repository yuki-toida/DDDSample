using System;
using Fango.StackExchange.Redis;
using Gaia.Infra.Json;

namespace Gaia.Infra.StackExchange
{
    internal class RedisSerializer : IRedisSerializer
    {
        public byte[] Serialize(object value)
        {
            return new JsonSerializer().Serialize(value);
        }

        public object Deserialize(byte[] value, Type type)
        {
            return new JsonSerializer().Deserialize(value, type);
        }
    }
}
