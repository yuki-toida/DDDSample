using Fango.Redis.Configuration;
using Fango.StackExchange.Redis;
using Fango.StackExchange.Redis.Balancing.Cryptography;

namespace Gaia.Infra.StackExchange
{
    public static class RedisFactory
    {
        public static RedisConnectionFactory Create(params string[] connections)
        {
            var settings = CreateSetting(connections);
            return new RedisConnectionFactory(new[] {settings});
        }

        private static RedisConnectionSetting CreateSetting(string[] connection, string name = "Default")
        {
            return new RedisConnectionSetting(
                () => new RedisConnection(
                    connection,
                    new RedisValueConverter(new RedisSerializer()),
                    new MD5KeyHashingRedisBalancer()
                ),
                name,
                true);
        }
    }
}
