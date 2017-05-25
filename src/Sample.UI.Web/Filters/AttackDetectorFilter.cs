using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Sample.Infra.Interface.AppContext;
using Sample.UI.Web.Utility;

namespace Sample.UI.Web.Filters
{
    /// <summary>
    /// 同一Uidの連続アクセス検知フィルター
    /// </summary>
    public class AttackDetectorFilter : ActionFilterBase
    {
        public AttackDetectorFilter(IAppContext appContext) : base(appContext)
        {
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // 連続アクセス検知
            if (!AttackDetector.Valid())
            {
                context.Result = new BadRequestResult();
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
