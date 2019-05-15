using System;
using System.Collections.Generic;
using System.Text;

namespace ReleaseNews.Models.Request
{
    public class EditUserPwd
    {
        public int F_UserId { get; set; }
        public string F_NewPassword { get; set; }
    }
}
