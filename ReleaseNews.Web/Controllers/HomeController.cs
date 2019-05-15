using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReleaseNews.Models.Response;
using ReleaseNews.Service;
using ReleaseNews.Models.Entity;

namespace ReleaseNews.Web.Controllers
{
    public class HomeController : BaseController
    {
        private NewsService _newsService;
        private BannerService _bannerService;
        private UsersService _userService;
        private UserSendMessageService _usersendmessageService;
        public HomeController(NewsService newsService, BannerService bannerService, UsersService userService, UserSendMessageService usersendmessageService)
        {
            this._newsService = newsService;
            this._bannerService = bannerService;
            this._userService = userService;
            this._usersendmessageService = usersendmessageService;
        }

        public ActionResult Index()
        {
            var userList = HttpContext.Session.Get<UsersModel>("CacheUser");
            ViewData["Title"] = "首页";
            return View(_newsService.GetMainNewsClassifyList(userList));
        }
        [HttpGet]
        public JsonResult GetBanner()
        {
            return Json(_bannerService.GetBannerList());
        }
        [HttpGet]
        public JsonResult GetTotalNews()
        {
            return Json(_newsService.GetNewsCount(c => true));
        }
        [HttpGet]
        public JsonResult GetHomeNews()
        {
            return Json(_newsService.GetNewsList(c => true, 0, 8));
        }
        [HttpGet]
        public JsonResult GetNewCommentNewsList()
        {
            return Json(_newsService.GetNewCommentNewsList(c => true, 5));
        }
        [HttpGet]
        public JsonResult SearchOneNews(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
                return Json(new ResponseModel { code = 0, result = "关键字不能为空" });
            return Json(_newsService.GetSearchOneNews(c => c.Title.Contains(keyword)));
        }
        public ActionResult Wrong()
        {
            ViewData["Title"] = "404";
            return View(_newsService.GetNewsClassifyList());
        }
    }
}