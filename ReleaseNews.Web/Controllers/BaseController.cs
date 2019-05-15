using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ReleaseNews.Models.Response;

namespace ReleaseNews.Web.Controllers
{
    public class BaseController : Controller
    {
        //拦截器,如果缓存失效,跳转至登录页面
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var userList = HttpContext.Session.Get<UsersModel>("CacheUser");
            if (userList.code == 0 || userList.data.F_UserId == 0)
            {
                HttpContext.Response.Redirect("/LoginMain/LoginIndex");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
