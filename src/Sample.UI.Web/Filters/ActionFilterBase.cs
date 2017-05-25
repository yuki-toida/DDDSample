using Microsoft.AspNetCore.Mvc.Filters;
using Sample.Infra.Interface.AppContext;

namespace Sample.UI.Web.Filters
{
    public abstract class ActionFilterBase : IActionFilter
    {
        protected ActionFilterBase(IAppContext appContext)
        {
            AppContext = appContext;
        }

        protected IAppContext AppContext;

        public abstract void OnActionExecuting(ActionExecutingContext context);

        public abstract void OnActionExecuted(ActionExecutedContext context);
    }
}
