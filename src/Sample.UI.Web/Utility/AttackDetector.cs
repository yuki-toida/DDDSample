namespace Sample.UI.Web.Utility
{
    public static class AttackDetector
    {
        // 検知間隔(s)
        public const int DurationSecond = 1;

        // BAN時間(s)
        public const int BanSecond = 60;

        // 検知閾回数
        public const int LimitCount = 16;

        // Luaスクリプト
        public const string LuaScript = @"
local key = KEYS[1]
local limit = tonumber(ARGV[1])
local count = redis.call('INCR', key)
if(count < limit) then
    if (count == 1) then
        local expireSec = tonumber(ARGV[2])
        redis.call('EXPIRE', key, expireSec)
    end
else
    local banSec = tonumber(ARGV[3])
    redis.call('EXPIRE', key, banSec)
end
return count
";

        /// <summary>
        /// 連続アクセス検証
        /// </summary>
        public static bool Valid()
        {
            return true;
        }
    }
}
