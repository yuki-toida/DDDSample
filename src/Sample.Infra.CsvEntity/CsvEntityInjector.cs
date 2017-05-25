using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Sample.Infra.CsvEntity
{
    public class CsvEntityInjector
    {
        /// <summary>
        /// データを注入する際に使用される静的メソッドの名称。
        /// </summary>
        private const string EntityTypeRequiredMethodName = "InitializeRepository";

        /// <summary>
        /// 関連する型にデータを注入します。
        /// データを受け取る型は以下のメソッドを実装している必要があります。
        /// public static void InitializeRepository(IEnumerable<EntityType /> data)
        /// </summary>
        public static void Inject(IEnumerable<CsvEntityRelation> relations)
        {
            relations = relations?.ToArray();
            if (relations == null || !relations.Any())
                return;

            foreach (var relation in relations)
            {
                var method = relation.EntityType
                    .GetMethod(EntityTypeRequiredMethodName, BindingFlags.Static | BindingFlags.Public);

                method.Invoke(null, new object[] { relation.LoadedData });
            }
        }
    }
}
