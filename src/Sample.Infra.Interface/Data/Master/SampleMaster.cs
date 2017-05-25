using System;
using System.Collections.Generic;
using System.Linq;

namespace Sample.Infra.Interface.Data.Master
{
    public partial class SampleMaster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset From { get; set; }
        public DateTimeOffset To { get; set; }
    }

    public partial class SampleMaster
    {
        public static IEnumerable<SampleMaster> All { get; private set; }

        private static IReadOnlyDictionary<int, SampleMaster[]> _dataByPk;

        public static void InitializeRepository(IEnumerable<SampleMaster> data)
        {
            All = data ?? Enumerable.Empty<SampleMaster>();
            _dataByPk = All
                .GroupBy(x => x.Id)
                .ToDictionary(x => x.Key, x => x.ToArray());
        }

        public static IEnumerable<SampleMaster> GetDataByPk(int id)
        {
            SampleMaster[] result;
            return _dataByPk.TryGetValue(id, out result)
                ? result
                : new SampleMaster[0];
        }
    }
}
