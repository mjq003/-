using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReleaseNews.Service;
using ReleaseNews.Models.Response;
using ReleaseNews.Models.Entity;
using ReleaseNews.Models.Request;

namespace ReleaseNews.Web.Controllers
{
    public class UserInfoController : BaseController
    {
        private UsersService _userService;
        private NewsService _newsService;
        private UserInfoService _userinfoService;
        private UserSendMessageService _usersendmessageService;
        public UserInfoController(UserInfoService userinfoService, UsersService userService, NewsService newsService, UserSendMessageService usersendmessageService)
        {
            this._userinfoService = userinfoService;
            this._userService = userService;
            this._newsService = newsService;
            this._usersendmessageService = usersendmessageService;
        }

        /// <summary>
        /// type:0 用户自己  1其他用户查看
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public IActionResult Index(int userId, int type)
        {
            ViewData["Title"] = "用户详情页";
            var users = _userService.GetOneUsers(userId);
            var usersCache = HttpContext.Session.Get<UsersModel>("CacheUser");
            ViewData["Users"] = users;
            ViewData["Funs"] = _userinfoService.GetFunsCount(userId).data;
            ViewData["Follow"] = _userinfoService.GetFollowCount(userId).data;
            ViewData["UserId"] = userId;
            var userpost = _newsService.GetUserPost(userId);
            ViewData["PublishNews"] = userpost;
            if (usersCache.code == 0 || userId != usersCache.data.F_UserId)
            {
                ViewBag.Type = 1;
                ViewData["UserType"] = "Ta发过的帖子";
            }
            else
            {
                ViewBag.Type = 0;
                ViewData["UserType"] = "我发过的帖子";
            }
            return View(_newsService.GetMainNewsClassifyList(usersCache));
        }


        public IActionResult Follow(int Id, int type)
        {
            ViewData["Title"] = "关注列表页";
            var userList = HttpContext.Session.Get<UsersModel>("CacheUser");
            ViewBag.id = Id;
            ViewBag.type = type;
            return View(_newsService.GetMainNewsClassifyList(userList));
        }


        public IActionResult SendMessage(int Id)
        {
            var userName = _userService.GetOneUsers(Id).data.F_RealName;
            ViewData["UserName"] = userName;
            ViewData["UserId"] = Id;
            return View();
        }


        public IActionResult UpdateUserInfo(int Id)
        {
            return View(_userService.GetOneUsers(Id));
        }


        public IActionResult Messages()
        {
            var userList = HttpContext.Session.Get<UsersModel>("CacheUser");
            var sendmessage = _usersendmessageService.GetOneUserSendMessageByUserId(userList.data.F_UserId);
            _usersendmessageService.UpdateIfCheck(userList.data.F_UserId);
            ViewData["Sendmessage"] = sendmessage;
            return View();
        }

        [HttpPost]
        public JsonResult Addfollow(int followId)
        {
            var userList = HttpContext.Session.Get<UsersModel>("CacheUser");
            return Json(_userinfoService.AddUserFollow(userList.data.F_UserId, followId));
        }

        [HttpPost]
        public JsonResult Deletefollow(int followId)
        {
            var userList = HttpContext.Session.Get<UsersModel>("CacheUser");
            return Json(_userinfoService.DelUserFollow(userList.data.F_UserId, followId));
        }


        [HttpGet]
        public JsonResult UserFunsPageQuery(int followId)
        {
            return Json(_userinfoService.UserFunsPageQuery(followId));
        }

        [HttpGet]
        public JsonResult UserFollowPageQuery(int userId)
        {
            return Json(_userinfoService.UserFollowPageQuery(userId));
        }

        [HttpPost]
        public JsonResult AddUserSendMessage(AddUserSendMessage usersendmessage)
        {
            if (string.IsNullOrEmpty(usersendmessage.Message))
                return Json(new ResponseModel { code = 0, result = "请输入消息内容" });
            var userList = HttpContext.Session.Get<UsersModel>("CacheUser");
            usersendmessage.UserId = userList.data.F_UserId;
            return Json(_usersendmessageService.AddUserSendMessage(usersendmessage));
        }
    }
}
