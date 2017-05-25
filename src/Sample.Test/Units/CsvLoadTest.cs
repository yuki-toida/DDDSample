using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sample.Infra.Interface.Data.Master;

namespace Sample.Test.Units
{
    [TestClass]
    public class CsvLoadTest : TestBase
    {
        [TestMethod]
        public void CsvLoadテスト()
        {
            Assert.IsTrue(SampleMaster.All.Any());
            Assert.IsTrue(SampleMaster.GetDataByPk(1).Any());
        }
    }
}
