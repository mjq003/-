using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReleaseNews.Service;
using ReleaseNews.Models.Response;
using System.Linq.Expressions;
using ReleaseNews.Models.Entity;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReleaseNews.Web.Controllers
{
    public class PostController : BaseController
    {
        private NewsService _newsService;
        private CommentService _commentService;
        private UsersService _userService;
        private UserSendMessageService _usersendmessageService;
        public PostController(NewsService newsService, CommentService commentService, UsersService usersService, UserSendMessageService usersendmessageService)
        {
            _newsService = newsService;
            _commentService = commentService;
            _userService = usersService;
            _usersendmessageService = usersendmessageService;
        }
        public IActionResult Index()
        {
            ViewData["Title"] = "步行街-社区";
            var news = _newsService.GetNewsList(c => true, 0, 6);
            var newsFatherClassify = _newsService.GetPostNewsClassifyList(0);
            var newsSonClassify = _newsService.GetPostNewsClassifyList(1);
            ViewData["News"] = news;
            ViewData["FatherNewsClassify"] = newsFatherClassify;
            ViewData["SonNewsClassify"] = newsSonClassify;
            var userList = HttpContext.Session.Get<UsersModel>("CacheUser");
            return View(_newsService.GetMainNewsClassifyList(userList));
        }
    }
}
