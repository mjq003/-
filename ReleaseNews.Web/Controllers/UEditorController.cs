using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UEditor.Core;
using ReleaseNews.Service;
using ReleaseNews.Models.Response;
using Microsoft.AspNetCore.Hosting;
using ReleaseNews.Models.Request;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReleaseNews.Web.Controllers
{
    public class UEditorController : BaseController
    {
        private readonly UEditorService _ueditorService;
        private UsersService _userService;
        private NewsService _newsService;
        private UserInfoService _userinfoService;
        private UserSendMessageService _usersendmessageService;
        private IHostingEnvironment hostingEnv;
        public UEditorController(UEditorService ueditorService, IHostingEnvironment env, UserInfoService userinfoService, UsersService userService, NewsService newsService, UserSendMessageService usersendmessageService)
        {
            this._ueditorService = ueditorService;
            hostingEnv = env;
            this._userinfoService = userinfoService;
            this._userService = userService;
            this._newsService = newsService;
            this._usersendmessageService = usersendmessageService;
        }

        [HttpGet, HttpPost]
        [RequestSizeLimit(100_000_000)]
        public ContentResult Upload()
        {
            var response = _ueditorService.UploadAndGetResponse(HttpContext);
            return Content(response.Result, response.ContentType);
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "发布帖子";
            var userList = HttpContext.Session.Get<UsersModel>("CacheUser");
            ViewData["postclassify"] = _newsService.GetPostNewsClassifyList(1);
            return View(_newsService.GetMainNewsClassifyList(userList));
        }

        [HttpPost]
        public JsonResult AddPost(int classifyId, string title, string content)
        {
            var userList = HttpContext.Session.Get<UsersModel>("CacheUser");
            return Json(_newsService.AddPost(new AddNews { Title = title, Contents = content, UserId = userList.data.F_UserId, NewsClassifyId = classifyId }));
        }
    }
}
