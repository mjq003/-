using Microsoft.AspNetCore.Http;
using ReleaseNews.Models.Entity;
using ReleaseNews.Models.Response;
using ReleaseNews.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReleaseNews.Web
{
    public static class SessionExtensions
    {
        //获取缓存数据
        public static ResponseModel Get<T>(this ISession session, string key)
        {
            byte[] result;
            session.TryGetValue(key, out result);
            if (result == null)
                return new ResponseModel { code = 0, result = "获取失败" };
            else
                return new ResponseModel { code = 200, result = "获取成功", data = ByteConvertHelper.Bytes2Object<T>(result) };
        }
    }
}
