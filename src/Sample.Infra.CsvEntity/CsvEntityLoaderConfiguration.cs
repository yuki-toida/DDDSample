using System.Collections.Generic;

namespace Sample.Infra.CsvEntity
{
    /// <summary>
    /// <see cref="CsvEntityLoader"/>が処理を行うために必要な設定情報を表します
    /// </summary>
    public class CsvEntityLoaderConfiguration
    {
        /// <summary>
        /// CSVファイルを読み込む最上位ディレクトリのパスです
        /// </summary>
        public string CsvRootDirectoryPath { get; set; }

        /// <summary>
        /// ロードしたCSVデータをマッピングする型が含まれるアセンブリの名前です
        /// </summary>
        public IEnumerable<string> MapTargetAssemblies { get; set; }
    }
}
