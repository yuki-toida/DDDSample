using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sample.Infra.Interface.AppContext;

namespace Sample.Test
{
    [TestClass]
    public abstract class TestBase
    {
        protected IAppContext AppContext;
        protected IMapper Mapper;

        [TestInitialize]
        public void Initialize()
        {
            AppContext = TestConfiguration.ServiceProvider.GetService<IAppContext>();
            Mapper = TestConfiguration.ServiceProvider.GetService<IMapper>();
        }
    }
}
