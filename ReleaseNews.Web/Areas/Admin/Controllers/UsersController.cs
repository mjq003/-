using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using ReleaseNews.Models.Entity;
using ReleaseNews.Service;
using Microsoft.AspNetCore.Hosting;
using ReleaseNews.Models.Request;
using Microsoft.AspNetCore.Http;
using ReleaseNews.Models.Response;
using System.IO;
using ReleaseNews.Utility;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReleaseNews.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        // GET: /<controller>/
        public ActionResult Index()
        {
            return View();
        }
        private UsersService _usersService;
        private IHostingEnvironment _host;
        public UsersController(UsersService userssService, IHostingEnvironment host)
        {
            this._usersService = userssService;
            this._host = host;
        }

        [HttpGet]
        public JsonResult GetUsers(int pageIndex, int pageSize, string keyword)
        {
            List<Expression<Func<Users, bool>>> wheres = new List<Expression<Func<Users, bool>>>();
            if (!string.IsNullOrEmpty(keyword))
            {
                wheres.Add(c => c.F_Account.Contains(keyword) || c.F_RealName.Contains(keyword));
            }
            int total = 0;
            var news = _usersService.UsersUserQuery(pageSize, pageIndex, out total, wheres);
            return Json(new { total = total, data = news.data });
        }

        public ActionResult UsersAdd()
        {
            return View();
        }


        [HttpPost]
        public async Task<JsonResult> AddUser(AddUsers users, IFormCollection collection)
        {
            if (string.IsNullOrEmpty(users.F_Account))
                return Json(new ResponseModel { code = 0, result = "请输入账号！" });
            if (string.IsNullOrEmpty(users.F_Password))
                return Json(new ResponseModel { code = 0, result = "请输入密码" });
            var files = collection.Files;
            if (files.Count > 0)
            {
                var webRootPath = _host.WebRootPath;
                string relativeDirPath = "/UserPic";
                string absolutePath = webRootPath + relativeDirPath;

                string[] fileTypes = new string[] { ".gif", ".jpg", ".jpeg", ".png", ".bmp" };
                string extension = Path.GetExtension(files[0].FileName);
                if (fileTypes.Contains(extension.ToLower()))
                {
                    if (!Directory.Exists(absolutePath)) Directory.CreateDirectory(absolutePath);
                    string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
                    var filePath = absolutePath + "/" + fileName;
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await files[0].CopyToAsync(stream);
                    }
                    users.F_Image = "/UserPic/" + fileName;
                    return Json(_usersService.AddUser(users));
                }
                return Json(new ResponseModel { code = 0, result = "图片格式有误" });
            }
            return Json(new ResponseModel { code = 0, result = "请上传图片文件" });
        }




        [HttpPost]
        public async Task<JsonResult> UpdateUserInfo(EditUsers edituser, IFormCollection collection)
        {
            var userList = HttpContext.Session.Get<UsersModel>("CacheUser");
            edituser.F_UserId = userList.data.F_UserId;
            edituser.F_Account = _usersService.GetOneUsers(edituser.F_UserId).data.F_Account;
            var files = collection.Files;
            if (files.Count > 0)
            {
                var webRootPath = _host.WebRootPath;
                string relativeDirPath = "/UserPic";
                string absolutePath = webRootPath + relativeDirPath;

                string[] fileTypes = new string[] { ".gif", ".jpg", ".jpeg", ".png", ".bmp" };
                string extension = Path.GetExtension(files[0].FileName);
                if (fileTypes.Contains(extension.ToLower()))
                {
                    if (!Directory.Exists(absolutePath)) Directory.CreateDirectory(absolutePath);
                    string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
                    var filePath = absolutePath + "/" + fileName;
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await files[0].CopyToAsync(stream);
                    }
                    edituser.F_Image = "/UserPic/" + fileName;

                    UsersModel u = new UsersModel();
                    ResponseModel rm = _usersService.UpdateUserInfo(edituser, ref u);
                    if (rm.code == 200)
                    {
                        HttpContext.Session.Set("CacheUser", ByteConvertHelper.Object2Bytes(u));
                    }
                    return Json(rm);
                }
                return Json(new ResponseModel { code = 0, result = "图片格式有误" });
            }
            else
            {
                edituser.F_Image = _usersService.GetOneUsers(edituser.F_UserId).data.F_Image;
                UsersModel u = new UsersModel();
                ResponseModel rm = _usersService.UpdateUserInfo(edituser, ref u);
                if (rm.code == 200)
                {
                    HttpContext.Session.Set("CacheUser", ByteConvertHelper.Object2Bytes(u));
                }
                return Json(rm);
            }
        }



        public ActionResult UserUpdatePwd(int id)
        {
            return View(_usersService.GetOneUsers(id));
        }


        [HttpPost]
        public JsonResult UserUpdatePwd(EditUserPwd edituserpwd)
        {
            if (string.IsNullOrEmpty(edituserpwd.F_NewPassword))
                return Json(new ResponseModel { code = 0, result = "请输入新密码！" });
            return Json(_usersService.UpdateUserPassWord(edituserpwd));
        }


        public ActionResult UserEdit(int id)
        {
            return View(_usersService.GetOneUsers(id));
        }

        [HttpPost]
        public async Task<JsonResult> UserEdit(EditUsers edituser, IFormCollection collection)
        {
            if (string.IsNullOrEmpty(edituser.F_Account))
                return Json(new ResponseModel { code = 0, result = "请输入用户名！" });
            var files = collection.Files;
            if (files.Count > 0)
            {
                var webRootPath = _host.WebRootPath;
                string relativeDirPath = "\\UserPic";
                string absolutePath = webRootPath + relativeDirPath;

                string[] fileTypes = new string[] { ".gif", ".jpg", ".jpeg", ".png", ".bmp" };
                string extension = Path.GetExtension(files[0].FileName);
                if (fileTypes.Contains(extension.ToLower()))
                {
                    if (!Directory.Exists(absolutePath)) Directory.CreateDirectory(absolutePath);
                    string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
                    var filePath = absolutePath + "\\" + fileName;
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await files[0].CopyToAsync(stream);
                    }
                    edituser.F_Image = "/UserPic/" + fileName;
                    return Json(_usersService.UpdateUser(edituser));
                }
                return Json(new ResponseModel { code = 0, result = "图片格式有误" });
            }
            else
            {
                edituser.F_Image = _usersService.GetOneUsers(edituser.F_UserId).data.F_Image;
                return Json(_usersService.UpdateUser(edituser));
            }
        }
    }
}
