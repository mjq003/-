using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReleaseNews.Models.Request;
using ReleaseNews.Models.Response;
using ReleaseNews.Service;
using ReleaseNews.Models.Entity;

namespace ReleaseNews.Web.Controllers
{
    public class NewsController : BaseController
    {
        private NewsService _newsService;
        private CommentService _commentService;
        private UsersService _userService;
        private UserSendMessageService _usersendmessageService;

        public NewsController(NewsService newsService, CommentService commentService, UsersService usersService, UserSendMessageService usersendmessageService)
        {
            _newsService = newsService;
            _commentService = commentService;
            _userService = usersService;
            this._usersendmessageService = usersendmessageService;
        }

        public IActionResult Classify(int id)
        {
            if (id <= 0)
                Response.Redirect("/Home/Index");
            var classify = _newsService.GetOneNewsClassify(id);
            ViewData["Title"] = "板块页";
            var userList = HttpContext.Session.Get<UsersModel>("CacheUser");
            ViewData["ClassifyName"] = classify.data.Name;
            var newsList = _newsService.GetNewsList(c => true, id, 6);
            ViewData["NewsList"] = newsList;
            var newCommentNews = _newsService.GetNewCommentNewsList(c => c.NewsClassifyId == id, 5);
            ViewData["NewCommentNews"] = newCommentNews;
            ViewData["Title"] = classify.data.Name;
            return View(_newsService.GetMainNewsClassifyList(userList));
        }
        public IActionResult Detail(int id)
        {
            if (id <= 0)
                Response.Redirect("/Home/Index");
            ViewData["Title"] = "详情页";
            var news = _newsService.GetoneNews(id);
            var userList = HttpContext.Session.Get<UsersModel>("CacheUser");
            ViewData["Title"] = news.data.Title + "-" + "详情页";
            ViewData["News"] = news;
            var recommendNews = _newsService.GetRecommendNewsList(id);
            ViewData["RecommendNews"] = recommendNews;
            var comments = _commentService.GetCommentList(c => c.NewsId == id && c.OldId == 0);
            ViewData["Comments"] = comments;
            return View(_newsService.GetMainNewsClassifyList(userList));
        }

        //public IActionResult Comments()
        //{
        //    var news = _newsService.GetoneNews(48);
        //    var userList = HttpContext.Session.Get<UsersModel>("CacheUser");
        //    if (news.code == 0)
        //    {
        //        Response.Redirect("/Home/Index");
        //    }
        //    else
        //    {
        //        ViewData["Title"] = news.data.Title + "-" + "详情页";
        //        ViewData["News"] = news;
        //        var recommendNews = _newsService.GetRecommendNewsList(48);
        //        ViewData["RecommendNews"] = recommendNews;
        //        var comments = _commentService.GetCommentList(c => c.NewsId == 48);
        //        ViewData["Comments"] = comments;
        //    }
        //    return View(_newsService.GetMainNewsClassifyList(userList));
        //}


        public IActionResult AllTeam()
        {
            ViewData["Title"] = "所有球队专区";
            var news = _newsService.GetNewsList(c => true, 0, 6);
            var newsClassify = _newsService.GetNewsClassifyList();
            ViewData["News"] = news;
            ViewData["AllNewsClassify"] = newsClassify;
            var userList = HttpContext.Session.Get<UsersModel>("CacheUser");
            return View(_newsService.GetMainNewsClassifyList(userList));
        }

        [HttpPost]
        public JsonResult AddComment(AddComment comment)
        {
            var userList = HttpContext.Session.Get<UsersModel>("CacheUser");
            if (comment.NewsId <= 0)
                return Json(new ResponseModel { code = 0, result = "新闻不存在" });
            if (string.IsNullOrEmpty(comment.Contents))
                return Json(new ResponseModel { code = 0, result = "内容不能为空" });
            return Json(_commentService.AddComment(comment, userList.data));
        }

        [HttpPost]
        public JsonResult GetLove(int Id)
        {
            var userList = HttpContext.Session.Get<UsersModel>("CacheUser");
            return Json(_commentService.GetLove(Id, userList.data.F_UserId));
        }

        [HttpGet]
        public JsonResult SearchOneNews(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
                return Json(new ResponseModel { code = 0, result = "关键字不能为空" });
            return Json(_newsService.GetSearchOneNews(c => c.Title.Contains(keyword)));
        }


        [HttpGet]
        public JsonResult CheckReply(int NewsId, int UserId, int OldId)
        {
            var userList = HttpContext.Session.Get<UsersModel>("CacheUser");
            if (UserId == userList.data.F_UserId)
                return Json(new ResponseModel { code = 0, result = "不能自己回复自己" });
            else
                return Json(new ResponseModel { code = 200, result = "" });
        }

        public ActionResult Reply(int NewsId, int UserId, int OldId)
        {
            var userName = _userService.GetOneUsers(UserId).data.F_RealName;
            ViewData["UserName"] = userName;
            ViewData["OldId"] = OldId;
            ViewData["UserId"] = UserId;
            ViewData["NewsId"] = NewsId;
            return View();
        }


        [HttpPost]
        public JsonResult GetReply(int NewsId, int UserId, int OldId, string Contents)
        {
            if (string.IsNullOrEmpty(Contents))
                return Json(new ResponseModel { code = 0, result = "请输入回复内容" });
            AddComment ac = new AddComment();
            ac.NewsId = NewsId;
            ac.UserId = UserId;
            ac.OldId = OldId;
            ac.Contents = Contents;
            var userList = HttpContext.Session.Get<UsersModel>("CacheUser");
            ac.ReplyUserId = userList.data.F_UserId;
            return Json(_commentService.AddReplyComment(ac));
        }

    }
}