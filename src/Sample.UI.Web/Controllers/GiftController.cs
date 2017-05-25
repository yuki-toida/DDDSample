using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Sample.Infra.Interface.AppContext;
using Sample.UI.Web.Settings;

namespace Sample.UI.Web.Controllers
{
    public class GiftController : AppControllerBase
    {
        public GiftController(IAppContext appContext, IOptions<AppSettings> settingsAccessor, IMapper mapper)
            : base(appContext, settingsAccessor, mapper)
        {
        }

        [HttpGet]
        public IActionResult GetUnopen()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Open([FromBody]long[] giftIds)
        {
            return Ok();
        }
    }
}
