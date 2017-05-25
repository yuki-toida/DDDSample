using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Sample.Infra.Interface.AppContext;
using Sample.UI.Web.Settings;

namespace Sample.UI.Web.Controllers
{
    public abstract class AppControllerBase : Controller
    {
        protected AppControllerBase(IAppContext appContext, IOptions<AppSettings> settingsAccessor, IMapper mapper)
        {
            AppContext = appContext;
            Settings = settingsAccessor.Value;
            Mapper = mapper;
        }

        protected IAppContext AppContext { get; }
        protected AppSettings Settings { get; }
        protected IMapper Mapper { get; }

        ///// <summary>
        ///// 重複リクエスト検知処理
        ///// </summary>
        //public T InvokeOverlap<T>(Func<T> func, T defaultResult)
        //{
        //    var result = default(T);
        //    var isOverlap = true;
        //    var key = RedisKeys.OverlapDetecter(0);
        //    var redis = AppContext.DataContext.Redis;

        //    try
        //    {
        //        if (redis.StringClient.SetIfNotExists(key, 1))
        //        {
        //            redis.KeyClient.Expire(key, TimeSpan.FromSeconds(4));
        //            result = func();
        //            isOverlap = false;
        //        }
        //    }
        //    finally
        //    {
        //        if (!isOverlap)
        //            redis.KeyClient.Delete(key);
        //    }

        //    return isOverlap ? defaultResult : result;
        //}
    }
}
