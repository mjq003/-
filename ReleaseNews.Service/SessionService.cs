using Microsoft.AspNetCore.Http;
using ReleaseNews.Models.Response;
using ReleaseNews.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReleaseNews.Service
{
    public class SessionService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public SessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void Set()
        {
            //_session.Set("code", "123456");
        }

        public ResponseModel Get(string key)
        {
            byte[] result;
            _session.TryGetValue(key, out result);
            if (result == null)
                return new ResponseModel { code = 0, result = "获取失败" };
            else
                return new ResponseModel { code = 200, result = "获取成功", data = ByteConvertHelper.Bytes2Object<UsersModel>(result) };
        }
    }
}
