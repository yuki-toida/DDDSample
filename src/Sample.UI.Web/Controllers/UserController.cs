using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Sample.Infra.Interface.AppContext;
using Sample.UI.Web.Settings;

namespace Sample.UI.Web.Controllers
{
    public class UserController : AppControllerBase
    {
        public UserController(IAppContext appContext, IOptions<AppSettings> settingsAccessor, IMapper mapper)
            : base(appContext, settingsAccessor, mapper)
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("hoge");
        }
    }
}
