using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReleaseNews.Service;
using Microsoft.AspNetCore.Hosting;

namespace ReleaseNews.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private UsersService _userService;
        private IHostingEnvironment _host;
        public HomeController(UsersService userService, IHostingEnvironment host)
        {
            this._userService = userService;
            this._host = host;
        }
        // GET: Home
        public ActionResult Index(string username)
        {
            var users = _userService.GetUsersByAccount(username);
            if (users.Count() == 0)
            {
                return RedirectToRoute(new { controller = "Login", action = "Index" });
            }
            else
            {
                ViewData["username"] = users.FirstOrDefault()?.F_RealName;
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            return View();
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}