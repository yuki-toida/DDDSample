using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using CsvHelper;

namespace Sample.Infra.CsvEntity
{
    public class CsvEntityLoader
    {
        /// <summary>
        /// CSVファイルの内容をファイル名称と一致するクラスにマップします。
        /// Entityにマップされたデータと型情報を返却します。
        /// </summary>
        public static IEnumerable<CsvEntityRelation> Load(CsvEntityLoaderConfiguration config)
        {
            var filePaths = Directory.GetFiles(config.CsvRootDirectoryPath, "*.csv", SearchOption.AllDirectories);
            var types = config.MapTargetAssemblies
                .Distinct()
                .Select(x => Assembly.Load(new AssemblyName(x)))
                .SelectMany(x => x.ExportedTypes)
                .ToArray();

            var result = new List<CsvEntityRelation>(filePaths.Length);

            foreach (var filePath in filePaths)
            {
                var fileName = Path.GetFileNameWithoutExtension(filePath);
                var entityTypes = types
                    .Where(x => x.Name == fileName)
                    .ToArray();

                var relation = new CsvEntityRelation
                {
                    CsvName = fileName
                };
                result.Add(relation);

                if (!entityTypes.Any())
                {
                    // 型情報が存在しない場合は処理をスキップ
                    throw new Exception("CSVファイル名に一致する型が見つかりませんでした。");
                }
                else if (entityTypes.Length > 1)
                {
                    // 型情報が複数存在する場合は処理をスキップ
                    throw new Exception("CSVファイル名に一致する型が複数存在するためマップする型を特定できませんでした。");
                }

                relation.EntityType = entityTypes.First();

                using (var fileStream = File.OpenText(filePath))
                using (var csvReader = new CsvReader(fileStream))
                {
                    // 動的型付けのためにメソッドを生成する。
                    var getRecordsMethod = GetRecordsMethod.MakeGenericMethod(relation.EntityType);
                    var toArrayMethod = ToArrayMethod.MakeGenericMethod(relation.EntityType);

                    var dataRaw = getRecordsMethod.Invoke(csvReader, null);
                    relation.LoadedData = (IEnumerable<object>)toArrayMethod.Invoke(null, new[] { dataRaw });
                }
            }

            return result;
        }

        private static readonly MethodInfo GetRecordsMethod = typeof(CsvReader).GetMethod("GetRecords", Type.EmptyTypes);
        private static readonly MethodInfo ToArrayMethod = typeof(Enumerable).GetMethod("ToArray");
    }
}
