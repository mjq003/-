using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReleaseNews.Service;
using ReleaseNews.Models.Response;
using ReleaseNews.Models.Entity;
using ReleaseNews.Utility;
using ReleaseNews.Models.Request;

namespace ReleaseNews.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private UsersService _usersService;
        public LoginController(UsersService usersService)
        {
            _usersService = usersService;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CheckUser(string username, string password, string type)
        {
            try
            {
                var userid = _usersService.GetUsersByAccount(username.ToLower()).FirstOrDefault().F_UserId;
                UsersModel u = new UsersModel();
                ResponseModel rm = _usersService.CheckLogin(userid, username, password, type, ref u);
                if (rm.code == 200 && type == "0")
                {
                    HttpContext.Session.Set("CacheUser", ByteConvertHelper.Object2Bytes(u));
                }
                return Json(rm);
            }
            catch (Exception e)
            {
                return Json(new ResponseModel { code = 0, result = $"账号错误" });
            }
        }

        [HttpPost]
        public JsonResult SignUser(string username, string password, string realname)
        {
            try
            {
                var userlst = _usersService.GetUsersByAccount(username.ToLower()).ToList();
                if(userlst.Count()>0)
                    return Json(new ResponseModel { code = 0, result = "用户名已经存在" });
                var userrealnamelst = _usersService.GetUsersByRealName(realname).ToList();
                if (userrealnamelst.Count() > 0)
                    return Json(new ResponseModel { code = 0, result = "昵称已经存在" });
                AddUsers au = new AddUsers();
                au.F_Account = username;
                au.F_Password = password;
                au.F_RealName = realname;
                ResponseModel rm = _usersService.AddUser(au);
                return Json(rm);
            }
            catch (Exception e)
            {
                return Json(new ResponseModel { code = 0, result = $"账号错误" });
            }
        }



        [HttpPost]
        public JsonResult ExitLogin()
        {
            HttpContext.Session.Remove("CacheUser");
            return Json(new ResponseModel { code = 200, result = "退出成功" });
        }
    }
}
