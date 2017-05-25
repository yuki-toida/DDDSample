using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sample.Test.Units
{
    [TestClass]
    public class AutoMapperTest : TestBase
    {
        [TestMethod]
        public void マッピングテスト()
        {
            Mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}
