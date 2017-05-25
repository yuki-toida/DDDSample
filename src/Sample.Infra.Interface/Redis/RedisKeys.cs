namespace Sample.Infra.Interface.Redis
{
    public static class RedisKeys
    {
        /// <summary>
        /// Uid採番用
        /// </summary>
        public static string SequenceUid()
        {
            return $"SequenceUid";
        }

        /// <summary>
        /// 連続アクセス検知(DOS攻撃)
        /// </summary>
        public static string AttackDetector(int uid)
        {
            return $"AttackDetector-{uid}";
        }

        /// <summary>
        /// 同一ユーザーによる重複リクエスト検知（ユーザのアクション単位）
        /// </summary>
        public static string OverlapDetecter(int uid)
        {
            return $"OverlapDetecter:{uid}";
        }
    }
}
