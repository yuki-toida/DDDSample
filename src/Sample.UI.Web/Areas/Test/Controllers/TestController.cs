using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Sample.App.Web.Item;
using Sample.Domain.Shared.Item;
using Sample.Infra.Interface.AppContext;
using Sample.Infra.Interface.Data.Master;
using Sample.UI.Web.Areas.Test.Models;
using Sample.UI.Web.Settings;

namespace Sample.UI.Web.Areas.Test.Controllers
{
    public class TestController : TestControllerBase
    {
        public TestController(IAppContext appContext, IOptions<AppSettings> settingsAccessor, IMapper mapper)
            : base(appContext, settingsAccessor, mapper)
        {
        }

        [HttpGet]
        public IActionResult GetGold()
        {
            var gold = new ItemService(AppContext).GetGold();
            var dto = Mapper.Map<ItemGoldDto>(gold);
            return Ok(dto);
        }

        public IActionResult GetSampleMaster()
        {
            return Ok(SampleMaster.All);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new TestViewModel());
        }
    }
}
