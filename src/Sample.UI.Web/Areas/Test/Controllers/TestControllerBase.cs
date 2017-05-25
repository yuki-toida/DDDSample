using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Sample.Infra.Interface.AppContext;
using Sample.UI.Web.Controllers;
using Sample.UI.Web.Settings;

namespace Sample.UI.Web.Areas.Test.Controllers
{
    [Area("Test")]
    public abstract class TestControllerBase : AppControllerBase
    {
        protected TestControllerBase(IAppContext appContext, IOptions<AppSettings> settingsAccessor, IMapper mapper)
            : base(appContext, settingsAccessor, mapper)
        {
        }
    }
}
