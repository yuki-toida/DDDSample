using System;
using System.Collections.Generic;

namespace Sample.Infra.CsvEntity
{
    /// <summary>
    /// CSVファイルからロードされたデータと、マップされたEntityの型が情報を表します
    /// </summary>
    public class CsvEntityRelation
    {
        /// <summary>
        /// CSVファイルの名称
        /// </summary>
        public string CsvName { get; set; }

        /// <summary>
        /// CSVデータがマップされた型
        /// </summary>
        public Type EntityType { get; set; }

        /// <summary>
        /// CSVファイルからロードされたデータ
        /// </summary>
        public IEnumerable<object> LoadedData { get; set; }
    }
}
