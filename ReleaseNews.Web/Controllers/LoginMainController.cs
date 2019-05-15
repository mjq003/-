using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ReleaseNews.Web.Controllers
{
    public class LoginMainController : Controller
    {
        public LoginMainController()
        {

        }
        public ActionResult LoginIndex()
        {
            return View();
        }
    }
}
